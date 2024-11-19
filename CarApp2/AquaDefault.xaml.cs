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
using System.Windows.Shapes;

namespace CarApp2
{
    /// <summary>
    /// Interaction logic for AquaDefault.xaml
    /// </summary>
    public partial class AquaDefault : Window
    {
        public AquaDefault()
        {
            InitializeComponent();
        }

        private void IconImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();   
        }

        private void btnDefaultCOnfigOk_Click(object sender, RoutedEventArgs e)
        {
            CustomerPaymentDetails cpd1 = new CustomerPaymentDetails();
            this.Close();
            cpd1.Show();
        }

        private void btnViewPrice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string connstring = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\user\\Documents\\ssvpCarAppDB.mdf;Integrated Security=True;Connect Timeout=30";
                using (SqlConnection con = new SqlConnection(connstring))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO Vehicle (Vehicle_Id, Name, Colour, QTY, Seat_Material, DashBoard, StearingWheel, Rim, Door, Generation, Engine, FuelType, Price, DelivaryDate) VALUES (@v1,@v2,@v3,@v4,@v5,@v6,@v7,@v8,@v9,@v10,@v11,@v12,@v13,@v14)", con);
                    float Price = 6500000;

                    // Validate NIC and Name
                    if (string.IsNullOrEmpty(txtNIC.Text) || string.IsNullOrEmpty(txtName.Text))
                    {
                        MessageBox.Show("Please enter valid NIC and Name.");
                        return;
                    }

                    cmd.Parameters.AddWithValue("@v1", txtNIC.Text);
                    cmd.Parameters.AddWithValue("@v2", txtName.Text);

                    // Colour
                    if (rdbColour_B.IsChecked == true)
                    {
                        cmd.Parameters.AddWithValue("@v3", "Black");
                    }
                    else if (rdbColour_W.IsChecked == true)
                    {
                        Price=Price+ 200000;
                        cmd.Parameters.AddWithValue("@v3", "White");
                    }
                    else
                    {
                        MessageBox.Show("Please select a color.");
                        return;
                    }

                    // Quantity
                    if (!float.TryParse(txtQty.Text, out float qty) || qty <= 0)
                    {
                        MessageBox.Show("Please enter a valid quantity.");
                        return;
                    }
                    cmd.Parameters.AddWithValue("@v4", (int)qty);

                    // Assuming placeholders for unselected options
                    cmd.Parameters.AddWithValue("@v5", "-");
                    cmd.Parameters.AddWithValue("@v6", "-");
                    cmd.Parameters.AddWithValue("@v7", "-");
                    cmd.Parameters.AddWithValue("@v8", "-");
                    cmd.Parameters.AddWithValue("@v9", "-");

                    cmd.Parameters.AddWithValue("@v10", "5.1");
                    cmd.Parameters.AddWithValue("@v11", "Hybrid");
                    cmd.Parameters.AddWithValue("@v12", "Petrol");

                    Price = Price * qty;
                    cmd.Parameters.AddWithValue("@v13", Price);
                    txtViewPrice.Text = Price.ToString("F2");

                    int date;
                    if (qty < 3)
                    {
                        date = 3;
                    }
                    else if (qty > 3 && qty <= 5)
                    {
                        date = 10;
                    }
                    else
                    {
                        date = 30;
                    }
                    cmd.Parameters.AddWithValue("@v14", date);

                    int result = cmd.ExecuteNonQuery();

                    if (result == 1)
                    {
                        MessageBox.Show("Data inserted successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Something went wrong.");
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnViewPriceAqua_Click(object sender, RoutedEventArgs e)
        {
            CustomerPaymentDetails cpd1 = new CustomerPaymentDetails();
            this.Close();
            cpd1.Show();
        }
    }
}
