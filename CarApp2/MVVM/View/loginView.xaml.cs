using CarApp2.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace CarApp2.MVVM.View
{
    /// <summary>
    /// Interaction logic for loginView.xaml
    /// </summary>
    public partial class loginView : UserControl
    {
        int count;

        string username;

        public loginView()
        {
            InitializeComponent();
            
        }

        private void btnLogin_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Your Logged In!!");
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

        }
        int attempts = 0;
        int maxAttempts = 3;
        private void btnLogin_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {


                string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\SSVPCar\\ssvpCarAppDB.mdf;Integrated Security=True;Connect Timeout=30;";

                SqlConnection con1 = new SqlConnection(connString);

                con1.Open();

                SqlCommand cmd = new SqlCommand("SELECT* FROM SignUp WHERE Username = @v1 ", con1);

                cmd.Parameters.AddWithValue("@v1", txtUser.Text);


                SqlDataReader rdrd = cmd.ExecuteReader();


                if (rdrd.Read())
                {

                    string username = rdrd["Username"].ToString();
                    string password = rdrd["Password"].ToString();

                    if (attempts < maxAttempts)
                    {

                        if (username == txtUser.Text && password == txtPass.Password)
                        {

                            

                            DashBoard d1 = new DashBoard();
                            HideParentWindow();
                            username = txtUser.Text;
                            d1.SetUsername(username);
                            
                            d1.Show();

                            
                         
                        }
                        else
                        {
                            attempts++;
                            txtUser.Clear();
                            txtPass.Clear();
                            txtBerror.Text = "Enter a valid Username or Password";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Incorrect username or password. Please try again.Your Logged out..!");
                        Application.Current.Shutdown();

                    }

                    con1.Close();

                }
            }
            catch (Exception obj) { MessageBox.Show(obj.Message.ToString()); }


        }
        private void HideParentWindow()
        {
            // Find the parent window and hide it
            Window parentWindow = Window.GetWindow(this);
            if (parentWindow != null)
            {
                parentWindow.Hide();
            }
        }


    }
}