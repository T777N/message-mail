using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Costumer> costumers = new List<Costumer>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (nameTxb.Text != "" && emailTxb.Text != "" && nameTxb.Text != null && emailTxb.Text != null)
            {
                Costumer costumer1 = new Costumer();
                costumer1.Add(nameTxb.Text, emailTxb.Text);
                costumers.Add(costumer1);


            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < costumers.Count; i++)
            {
                SendVerificationCodeToEmail(costumers[i].Email, "abc");
            }

        }

        public void SendVerificationCodeToEmail(string email, string code)
        {
            string mailBodyhtml =
            $"<h1>This code was sent by WhatsApp Server</h1>";
            var domain = email.Split('@')[1];
            var msg = new MailMessage("yoxlamag780@gmail.com", email, "This your code : " + code, mailBodyhtml);
            msg.IsBodyHtml = true;
            SmtpClient smtpClient = new SmtpClient($"smtp.mail.ru", 587);
            smtpClient.UseDefaultCredentials = true;
            smtpClient.Credentials = new NetworkCredential("yoxlamag780@gmail.com", "yoxlama1234");
            smtpClient.EnableSsl = true;
            try
            {
                smtpClient.Send(msg);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    class Costumer
    {
        public string Product_name { get; set; }
        public string Email { get; set; }

        public Costumer()
        {
            Product_name = "";
            Email = "";
        }
        public Costumer(string name, string email)
        {
            Product_name = name;
            Email = email;
        }
        public void Add(string name, string email)
        {
            Product_name = name;
            Email = email;
        }

    }
}
