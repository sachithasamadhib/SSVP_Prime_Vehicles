using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace CarApp2
{
    /// <summary>
    /// Interaction logic for SSVPBill.xaml
    /// </summary>
    public partial class SSVPBill : Window
    {
        String randomCode;
        public static String to;
        public SSVPBill()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            


try
{
    string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\user\\Documents\\ssvpCarAppDB.mdf;Integrated Security=True;Connect Timeout=30";

    using (SqlConnection con = new SqlConnection(connString))
    {
        con.Open();
        MessageBox.Show("Database connected successfully");

        string vehicleQuery = "SELECT Engine,Colour,QTY,Price,DelivaryDate FROM Vehicle WHERE Vehicle_Id = @VehicleIdParam";
        string customerQuery = "SELECT Country,TelePhone,Email FROM Customer WHERE NIC = @NICParam";

                    // First query for Vehicle
                    using (SqlCommand cmd = new SqlCommand(vehicleQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@VehicleIdParam", Vehicle_Id.Text); // Unique parameter name
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            if (rdr.Read())
                            {
                                txtEngineType.Text = rdr["Engine"].ToString();
                                txtColour.Text = rdr["Colour"].ToString();
                                txtQuantity.Text = rdr["QTY"].ToString();
                                txtPrice.Text = rdr["Price"].ToString();
                                txtDeliverDate.Text = rdr["DelivaryDate"].ToString();
                                // Assuming other fields exist in your Vehicle table
                            }
                            else
                            {
                                MessageBox.Show("No data found for the given Vehicle ID.");
                            }
                        }
                    }

                    // Second query for Customer
                    using (SqlCommand cmd1 = new SqlCommand(customerQuery, con))
                    {
                        cmd1.Parameters.AddWithValue("@NICParam", txtNIC.Text); // Unique parameter name
                        using (SqlDataReader rdr1 = cmd1.ExecuteReader())
                        {
                            if (rdr1.Read())
                            {
                                // Assuming columns like Country, Telephone exist in your Customer table
                                txtCountry.Text = rdr1["Country"].ToString();
                                txtTelephone.Text = rdr1["Telephone"].ToString();
                                txtEmail.Text = rdr1["Email"].ToString();
                                // Ensure you are not setting the same TextBox multiple times with different data
                            }
                            else
                            {
                                MessageBox.Show("No data found for the given NIC.");
                            }
                        }
                    }

                }
            }
catch (Exception obj)
{
    MessageBox.Show(obj.Message.ToString());
}

        }

        private void btnDefaultCOnfigOk_Click(object sender, RoutedEventArgs e)
        {
            if (randomCode == (txtOTP.Text).ToString())
            {
                to = txtEmail.Text;

                MessageBox.Show("Password correct");
                DashBoard d2 = new DashBoard();
                this.Close();
                d2.Show();

            }
            else
            {
                MessageBox.Show("Wrong Code");

            }
        }

        private void ckBoxOTP_Checked(object sender, RoutedEventArgs e)
        {
            String from, pass, messageBody;
            Random rand = new Random();
            randomCode = (rand.Next(999999)).ToString();
            MailMessage message = new MailMessage();
            to = (txtEmail.Text).ToString();
            from = "virajwgunasinghe@gmail.com";
            pass = "tlsndlsusddnpthn";
            messageBody = "Your reset code is " + randomCode;
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messageBody;
            message.Subject = "Password Reseting Code";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);

            try
            {
                smtp.Send(message);
                MessageBox.Show("Code Send Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnPurchaseCancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\SSVPCar\\ssvpCarAppDB.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True";

                using (SqlConnection con = new SqlConnection(connString))
                {
                    con.Open();
                    MessageBox.Show("Database connected successfully");

                    // Delete query for Vehicle
                    string deleteVehicleQuery = "DELETE  FROM Vehicle WHERE Vehicle_Id = @VehicleIdParamr";

                    // Delete query for Customer
                    string deleteCustomerQuery = "DELETE  FROM Customer WHERE NIC = @NICParamr";

                    // First query for Vehicle
                    using (SqlCommand cmd = new SqlCommand(deleteVehicleQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@VehicleIdParamr", Vehicle_Id.Text); // Unique parameter name
                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            if (rdr.Read())
                            {
                                txtEngineType.Text = rdr["Engine"].ToString();
                                txtColour.Text = rdr["Colour"].ToString();
                                txtQuantity.Text = rdr["QTY"].ToString();
                                txtPrice.Text = rdr["Price"].ToString();
                                txtDeliverDate.Text = rdr["DelivaryDate"].ToString();
                                // Assuming other fields exist in your Vehicle table
                            }
                            else
                            {
                                MessageBox.Show("No data found for the given Vehicle ID.");
                            }
                        }
                    }

                    // Second query for Customer
                    using (SqlCommand cmd1 = new SqlCommand(deleteCustomerQuery, con))
                    {
                        cmd1.Parameters.AddWithValue("@NICParamr", txtNIC.Text); // Unique parameter name
                        using (SqlDataReader rdr1 = cmd1.ExecuteReader())
                        {
                            if (rdr1.Read())
                            {
                                // Assuming columns like Country, Telephone exist in your Customer table
                                txtCountry.Text = rdr1["Country"].ToString();
                                txtTelephone.Text = rdr1["Telephone"].ToString();
                                txtEmail.Text = rdr1["Email"].ToString();
                                // Ensure you are not setting the same TextBox multiple times with different data
                            }
                            else
                            {
                                MessageBox.Show("No data found for the given NIC.");
                            }
                        }
                    }

                }
            }
            catch (Exception obj)
            {
                MessageBox.Show(obj.Message.ToString());
            }
        }
    }
}
