using CarApp2.MVVM.View;
using CarApp2.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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


namespace CarApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        



        public MainWindow()
        {
            InitializeComponent();

            
            
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello FK");
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello FK");
        }

        private void btnExit_MouseEnter(object sender, MouseEventArgs e)
        {
           
        }

        private void btnExit_MouseEnter(object sender, MouseButtonEventArgs e)
        {

            
        }

        private void btnMinimize_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnMaximize_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }
        }

        private void btnMaximize_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {

            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }
        }

        

        public void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
           

               
                
            
        }

        private void btnExit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void RadioButton_Checked_3()
        {

        }
    }
}
