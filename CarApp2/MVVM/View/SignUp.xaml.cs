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
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : UserControl
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnSignup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string password = txtPassword.Password;
                string confirmPassword = txtComPassword.Password;
                string username = txtUsername.Name;
                string name = txtName.Name;
                DateTime? selectedDate = DOB.SelectedDate;


                if (string.IsNullOrEmpty(username) ||
                    string.IsNullOrEmpty(password) ||
                    string.IsNullOrEmpty(confirmPassword) ||
                    string.IsNullOrEmpty(name) ||
                    selectedDate == null)
                {
                    MessageBox.Show("Please fill in all the required fields.", "Missing Fields", MessageBoxButton.OK, MessageBoxImage.Warning);

                }
                else
                {
                    if (password != confirmPassword)
                    {
                        MessageBox.Show("Enter the correct password.", "Password Mismatch", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }

                    string dateOfBirth = selectedDate.Value.ToString("MM/dd/yyyy");
                    int yearOfBirth = selectedDate.Value.Year;

                    string connstring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\user\\Documents\\ssvpCarAppDB.mdf;Integrated Security=True;Connect Timeout=30";
                    SqlConnection con = new SqlConnection(connstring);

                    con.Open();

                    SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM SignUP WHERE Username = @Username", con);
                    checkCmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                    int existingUserCount = (int)checkCmd.ExecuteScalar();

                    if (existingUserCount > 0)
                    {
                        MessageBox.Show("Username already exists. Please choose a different username.", "Duplicate Username", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    SqlCommand cmd = new SqlCommand("INSERT INTO SignUP VALUES(@v1,@v2,@v3,@v4,@v5)", con);
                    cmd.Parameters.AddWithValue("@v1", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@v2", txtPassword.Password);
                    cmd.Parameters.AddWithValue("@v3", txtComPassword.Password);
                    cmd.Parameters.AddWithValue("@v4", txtName.Text);
                    cmd.Parameters.AddWithValue("@v5", DOB.Text);

                    int result = cmd.ExecuteNonQuery();
                    MessageBox.Show("Registration Successful go to the signin Page", "Successful", MessageBoxButton.OK, MessageBoxImage.None);

                }
            }

            catch (Exception ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
        }
    }
}
