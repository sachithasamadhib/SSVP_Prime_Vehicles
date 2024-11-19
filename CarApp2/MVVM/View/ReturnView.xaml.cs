using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using System.Net.Mail;
using System.Net;

namespace CarApp2.MVVM.View
{


    /// <summary>
    /// Interaction logic for ReturnView.xaml
    /// </summary>
    public partial class ReturnView : UserControl
    {

        String randomCode;
        public static String to;


        public static String go;

        private List<string> searchSuggestions = new List<string>();
        public ReturnView()
        {
            InitializeComponent();
        }
        private void getdata()
        {
            string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\user\\Documents\\ssvpCarAppDB.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection(connString);

            try
            {
                con.Open();
                string sql = "SELECT * FROM Vehicle";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, con);

                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "Vehicle Data");
                DataGridEdetails.ItemsSource = ds.Tables["Vehicle Data"].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

        }
        private void searchData(string searchTerm)
        {
            string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\user\\Documents\\ssvpCarAppDB.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection(connString);

            try
            {
                con.Open();
                string sql = "SELECT * FROM Vehicle WHERE Name LIKE @searchTerm OR Vehicle_Id LIKE @searchTerm";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, con);
                dataAdapter.SelectCommand.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");

                DataSet ds = new DataSet();
                dataAdapter.Fill(ds, "Vehicle Data");
                DataGridEdetails.ItemsSource = ds.Tables["Vehicle Data"].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void comboBoxSearch_KeyUp(object sender, KeyEventArgs e)
        {
            string searchTerm = comboBoxSearch.Text;
            if (searchTerm.Length >= 2)
            {
                FilterSearchSuggestions(searchTerm);
            }
        }

        private void comboBoxSearch_DropDownOpened(object sender, EventArgs e)
        {
            LoadSearchSuggestions();
        }

        private void LoadSearchSuggestions()
        {
            string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\user\\Documents\\ssvpCarAppDB.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection con = new SqlConnection(connString);

            try
            {
                con.Open();
                string sql = "SELECT DISTINCT Vehicle_Id FROM Vehicle";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();
                searchSuggestions.Clear();
                while (reader.Read())
                {
                    searchSuggestions.Add(reader["Vehicle_Id"].ToString());
                }
                comboBoxSearch.ItemsSource = searchSuggestions;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
        private void FilterSearchSuggestions(string searchTerm)
        {
            var filteredSuggestions = searchSuggestions.FindAll(s => s.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0);
            comboBoxSearch.ItemsSource = filteredSuggestions;
            comboBoxSearch.IsDropDownOpen = true;

            // Set cursor position
            var textBox = (TextBox)comboBoxSearch.Template.FindName("PART_EditableTextBox", comboBoxSearch);
            if (textBox != null)
            {
                textBox.SelectionStart = searchTerm.Length;
                textBox.SelectionLength = 0;
            }
        }
        void fillingDataGridUsingDataTable()
        {
            DataTable dt = new DataTable();
            DataColumn id = new DataColumn("Vehicle_ID", typeof(int));
            DataColumn Name = new DataColumn("Name", typeof(string));
          

            dt.Columns.Add(id);
            dt.Columns.Add(Name);
           




        }
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            searchData(comboBoxSearch.Text);
        }

        private void DataGridEdetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DataGridEdetails.SelectedItem is DataRowView row_selected)
            {
                txtCarID.Text = row_selected["Vehicle_Id"].ToString();
                txtType.Text = row_selected["Name"].ToString();
                
                
            }
        }

        private void btnReturnOK_Click(object sender, RoutedEventArgs e)
        {
            string text = txtmail.Text;

            String from, pass, messageBody;
           
            MailMessage message = new MailMessage();
            to = text;
            from = "virajwgunasinghe@gmail.com";
            pass = "wnpojticgjbsozah";
            messageBody = messageBody = "The prices can be negotiated! " + "\n" + "Location: No.207 wijerama mawatha,colombo 7 " + "\n" + "Contact: +94 76 0193 056 " + "\n" + "SSVP(pvt)ltd " + "\n" + "Thank you!"; ;
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

        private void txtmail_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
