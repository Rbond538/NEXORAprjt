using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NEXORA_NgonziCollin
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices.WindowsRuntime;
    using System.Threading.Tasks;
    using Windows.Foundation;
    using Windows.Foundation.Collections;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Primitives;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Navigation;

    public sealed partial class Quiz : Page
    {
        private List<QNDataModel> qns;
        private int cqi;
        private int score;
        private DispatcherTimer timer;
        public async Task ShowMessageBox(string message)
        {
            ContentDialog dialog = new ContentDialog()
            {
                Title = "Login Message",
                Content = message,
                CloseButtonText = "OK"
            };
            await dialog.ShowAsync();
        }
        private int timeleft;
        public Quiz()
        {
            this.InitializeComponent();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(10);
            timer.Tick += Timer_Tick;
            loadQuestion();
            setQuestion();
        }

        private void Timer_Tick(object sender, object e)
        {
            timeleft--;
            txttimer.Text = timeleft.ToString();
            if (timeleft <= 0)
            {
                timer.Stop();
                cqi++;
                setQuestion();
            }
        }

        private void loadQuestion()
        {
            qns = new List<QNDataModel>()
        {
            new QNDataModel()
            {
                QuestionTest = "What is ecomorce?",
                Option1 = "Buying and selling goods or services",
                Option2 = "Repairing computers",
                Option3 = "Designing buildings",
                Option4 = "Installing opertating systems",
                CorrectAnswer = 1
            },
            new QNDataModel()
            {
                QuestionTest = "Which feature allows a customer to keep products before checkout?",
                Option1 = "Search Engine",
                Option2 = "Shopping Cart",
                Option3 = "Web Browser",
                Option4 = "Login Page",
                CorrectAnswer = 2
            },
            new QNDataModel(){
                QuestionTest = "What is the main purpose of an online product catalogue?",
                Option1 = "To Display available products and thier information",
                Option2 = "To repair customer devices",
                Option3 = "To create passwords",
                Option4 = "To manage employees",
                CorrectAnswer = 1
            },
            new QNDataModel()
            {
                QuestionTest = "Which Information is usefull when describing an electronic product",
                Option1 = "Product specifications",
                Option2 = "Customer password",
                Option3 = "Employee salary",
                Option4 = "Database password",
                CorrectAnswer = 1
            },
            new QNDataModel()
            {
                QuestionTest = "Why is customer feedback useful to an e-commerce business?",
                Option1 = "It can help the business understand customer experiences and improve services",
                Option2 = "It automatically creates passwords",
                Option3 = "It replaces the shopping cart",
                Option4 = "It removes all products",
                CorrectAnswer = 1
            }
        };
        }

        private async Task setQuestion()
        {
            if (cqi < qns.Count)
            {
                var currentquestion = qns[cqi];
                txtQuestion.Text = currentquestion.QuestionTest;
            radioOptA.Content = currentquestion.Option1;
            radioOptB.Content = currentquestion.Option2;
            radioOptC.Content = currentquestion.Option3;
            radioOptD.Content = currentquestion.Option4;

                timeleft = 20;
                timer.Stop();
                txttimer.Text = timeleft.ToString();
                timer.Start();
            }
            else
            {
                await ShowMessageBox("Quiz Completed Questions: 5, Correct Answers: 3, Wrong Answers: 8, Score: 66%");

            radioOptA.Visibility = Visibility.Collapsed;
            radioOptB.Visibility = Visibility.Collapsed;
            radioOptC.Visibility = Visibility.Collapsed;
            radioOptD.Visibility = Visibility.Collapsed;

            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (radioOptA.IsChecked == false && radioOptB.IsChecked == false && radioOptC.IsChecked == false && radioOptD.IsChecked == false)
            {
                return;
            }
            var currentquestion = qns[cqi];
            var mostcorrectanswer = currentquestion.CorrectAnswer;
            if (radioOptA.IsChecked == true && mostcorrectanswer == 1 ||
                radioOptB.IsChecked == true && mostcorrectanswer == 2 ||
                radioOptC.IsChecked == true && mostcorrectanswer == 3 ||
                radioOptD.IsChecked == true && mostcorrectanswer == 4)
            {
                score++;
            }
            cqi++;
            setQuestion();

        radioOptA.IsChecked = false;
        radioOptB.IsChecked = false;
        radioOptC.IsChecked = false;
        radioOptD.IsChecked = false;
        }

    }
}