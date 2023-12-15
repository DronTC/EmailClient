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

namespace MyEmailClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MailMessage(object sender, RoutedEventArgs e)
        {
            string server = textBoxServer.Text;
            int port = Convert.ToInt32(TextBoxPort.Text);
            string email = TextBoxEmail.Text;
            string password = TextBoxPassword.Text;
            string from = TextBoxFrom.Text;
            string to = TextBoxTo.Text;
            string theme = TextBoxTheme.Text;
            string message = TextBoxDescription.Text;

            if (server == "" || port == 0 || email == "" || password == "" || from == "" || to == "" || theme == "" || message == "")
            {
                MessageBox.Show("Необходимо заполнить все поля");
                return;
            }

            MailMessage mail = Mail.CreateMail(from, email, to, theme, message);

            Mail.SendMail(server, port, email, password, mail);
            MessageBox.Show("Сообщение отправлено");
        }
    }
}
