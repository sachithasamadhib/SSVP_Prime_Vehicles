using MaterialDesignThemes.Wpf;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarApp2.MVVM.View
{
    /// <summary>
    /// Interaction logic for modelView.xaml
    /// </summary>
    public partial class modelView : UserControl
    {
        public modelView()
        {
            InitializeComponent();
        }

        private void IconImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            lexusMoreData l1 = new lexusMoreData();
            l1.Show();
               
        }

        private void IconImage_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            PriusMoreData p1 = new PriusMoreData();
            p1.Show();
        }

        private void IconImage_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            AquaMoreData a1 = new AquaMoreData();
            a1.Show();
        }
    }
}
