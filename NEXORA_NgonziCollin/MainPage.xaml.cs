using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NEXORA_NgonziCollin
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        string connectionstring = "Data Source=R103-PC15;Initial Catalog=EcommerceDB_NgonziCollin;User ID=sa;Password=sap;Encrypt=False";

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
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Login_tbl where UserName=@UName and UserPassword =@UPass";

            cmd.Parameters.AddWithValue("@UName", txtUserName.Text);
            cmd.Parameters.AddWithValue("@UPass", txtPassword.Password);

            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                Frame.Navigate(typeof(Quiz));
            }
            else
            {
                await ShowMessageBox("Invalid username or password");
                return;
            }
            con.Close();
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RegistrationPage));
        }

    }
}
