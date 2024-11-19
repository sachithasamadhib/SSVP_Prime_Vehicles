using CarApp2.MVVM.View;
using CarApp2.MVVM.ViewModel;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for DashBoard.xaml
    /// </summary>
    public partial class DashBoard : Window
    {
       
        public DashBoard()
        {
            InitializeComponent();
           
            this.MaxHeight = 700;
            this.MaxWidth = 1300;
        }

        private void pnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMinimized_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState.Equals(WindowState.Minimized);
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
           
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
           
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {

        }

        private void btnLogin_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void rdbModel_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void rdbModel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Your Logged Out !","Log Out",MessageBoxButton.OK, MessageBoxImage.Exclamation);
            MainWindow m1 = new MainWindow();
            this.Close();
            m1.Show();
        }
        public void SetUsername(string username)
        {
            txtBusername.Text = username;
        }
    }
}
