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
    /// Interaction logic for customizeView.xaml
    /// </summary>
    public partial class customizeView : UserControl
    {
        public customizeView()
        {
            InitializeComponent();
        }

        private void btnDefaultLexus_Click(object sender, RoutedEventArgs e)
        {
           LexusDefault ld1 = new LexusDefault();
            ld1.Show();
        }

        private void btnDefaultPrius_Click(object sender, RoutedEventArgs e)
        {
            PriusDefault Pd1 = new PriusDefault();
            Pd1.Show();
        }

        private void btnDefaultAqua_Click(object sender, RoutedEventArgs e)
        {
            AquaDefault Ad1 = new AquaDefault();
            Ad1.Show();
        }

        private void btnCustomizeLexus_Click(object sender, RoutedEventArgs e)
        {
            LexusCustomize Lc1 = new LexusCustomize();
            Lc1.Show();
        }

        private void btnCustomizePrius_Click(object sender, RoutedEventArgs e)
        {
            PriusCustomize Pc1 = new PriusCustomize();
            Pc1.Show();
        }

        private void btnCustomizeAqua_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnCustomizeAqua_Click(object sender, RoutedEventArgs e)
        {
            AquaCustomize AqC1 = new AquaCustomize();   
            AqC1.Show();    
        }

        private void btnCustomize_Click(object sender, RoutedEventArgs e)
        {
            LexusCustomize lc1 = new LexusCustomize (); 
            lc1.Show();
        }
    }
}
