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
using System.Net;
using System.Net.Mail;

namespace CarApp2.MVVM.View
{
    /// <summary>
    /// Interaction logic for supportView.xaml
    /// </summary>
    public partial class supportView : UserControl
    {
        public static String to;
        String from, pass, messageBody;

        public supportView()
        {
            InitializeComponent();
        }

        public object MessageBoxButtons { get; private set; }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSubmit_Click_1(object sender, RoutedEventArgs e)
        {
            MailMessage message = new MailMessage();
            to = (txtyouremail.Text).ToString();
            from = "virajwgunasinghe@gmail.com";
            pass = "tlsndlsusddnpthn";
            messageBody = txtmessage.Text;
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messageBody;
            message.Subject = "SSVP Customer Service";
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
    }
}
