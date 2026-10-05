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
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NEXORA_NgonziCollin
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegistrationPage : Page
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
        public RegistrationPage()
        {
            this.InitializeComponent();
        }
        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionstring);
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "insert into Customer_tbl (FirstName,LastName,PhoneNumber,Email,DeliveryAddress,City," +
                "Country,UserName,UserPassword,ConfirmPassword) values (@FName,@LName,@Phone_No,@Email,@DAddress," +
                "@City,@Country,@UName,@UPass,@CPass)" + "select SCOPE_IDENTITY()";

            SqlParameter FName = new SqlParameter("@FName", System.Data.SqlDbType.VarChar);
            SqlParameter LName = new SqlParameter("@LName", System.Data.SqlDbType.VarChar);
            SqlParameter Phone = new SqlParameter("@Phone_No", System.Data.SqlDbType.VarChar);
            SqlParameter Email = new SqlParameter("@Email", System.Data.SqlDbType.VarChar);
            SqlParameter DAddress = new SqlParameter("@DAddress", System.Data.SqlDbType.VarChar);
            SqlParameter City = new SqlParameter("@City", System.Data.SqlDbType.VarChar);
            SqlParameter Country = new SqlParameter("@Country", System.Data.SqlDbType.VarChar);
            SqlParameter UName = new SqlParameter("@UName", System.Data.SqlDbType.VarChar);
            SqlParameter UPass = new SqlParameter("@UPass", System.Data.SqlDbType.VarChar);
            SqlParameter CPass = new SqlParameter("@CPass", System.Data.SqlDbType.VarChar);
            //SqlParameter RegDate = new SqlParameter("@RegDate", System.Data.SqlDbType.DateTime);

            FName.Value = txtFirstName.Text;
            LName.Value = txtLastName.Text;
            Phone.Value = txtPhoneNumber.Text;
            Email.Value = txtEmail.Text;
            DAddress.Value = txtDeliveryAddress.Text;
            City.Value = txtCity.Text;
            Country.Value = txtCountry.Text;
            UName.Value = txtUserName.Text;
            UPass.Value = txtPassword.Password;
            CPass.Value = txtConfirmPassword.Password;
            //RegDate.Value = RegDateValue;
            //RegDate.Value = ;

            //cmd.Parameters.AddWithValue("@FName",txtFirstName.Text);
            //cmd.Parameters.AddWithValue("@LName", txtLastName.Text);
            //cmd.Parameters.AddWithValue("@Phone_No", txtPhoneNumber.Text);
            //cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
            //cmd.Parameters.AddWithValue("@DAddress", txtDeliveryAddress.Text);
            //cmd.Parameters.AddWithValue("@City", txtCity.Text);
            //cmd.Parameters.AddWithValue("@Country", txtCountry.Text);
            //cmd.Parameters.AddWithValue("@UName", txtUserName.Text);
            //cmd.Parameters.AddWithValue("@UPass", txtPassword.Password);
            //cmd.Parameters.AddWithValue("@CPass", txtConfirmPassword.Password);

            cmd.Parameters.Add(FName);
            cmd.Parameters.Add(LName);
            cmd.Parameters.Add(Phone);
            cmd.Parameters.Add(Email);
            cmd.Parameters.Add(DAddress);
            cmd.Parameters.Add(City);
            cmd.Parameters.Add(Country);
            cmd.Parameters.Add(UName);
            cmd.Parameters.Add(UPass);
            cmd.Parameters.Add(CPass);

            int CustomerID = Convert.ToInt32(cmd.ExecuteScalar());
            //cmd.Parameters.Add(RegDate);
            //int DateT = "insert ";
            //cmd.Parameters.

            //int DateTime = new DatePicker();
            //Login
            SqlCommand cmdlogin = new SqlCommand();
            cmdlogin.Connection = con;
            cmdlogin.CommandText = "insert into Login_tbl (UserName, UserPassword, CustomerID) values (@UName, @UPass, @CID)"; //+ "select SCOPE_IDENTITY()";

            cmdlogin.Parameters.AddWithValue("@UName", txtUserName.Text);
            cmdlogin.Parameters.AddWithValue("@UPass", txtPassword.Password);
            cmdlogin.Parameters.AddWithValue("@CID", CustomerID);
            //cmdlogin.Parameters.AddWithValue("@LSatus", "True");

            //cmdlogin.Parameters = new SqlParameter("@LLogin", System.Data.SqlValue.DateTime);

            //int LoginIDValue = Convert.ToInt32(cmd.ExecuteScalar());
            //cmdlogin.Parameters.AddWithValue("@CID", LoginIDValue);
            //RegDate.Value = Convert.ToInt32(cmd.ExecuteScalar());

            cmdlogin.ExecuteScalar();

            if (txtPassword.Password != txtConfirmPassword.Password)
            {
                await ShowMessageBox("Password and Confirm Password do not match");
            }
            else
            {
                Frame.Navigate(typeof(MainPage));
            }
            //SqlDataReader reader = cmdlogin.ExecuteReader();

            //if (reader.HasRows)
            //{
            //Frame.Navigate(typeof(MainPage));
            //}


            con.Close();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
