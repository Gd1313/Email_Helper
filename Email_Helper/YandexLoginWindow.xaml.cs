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
using MailKit.Net.Imap;
using MailKit.Search;
using MailKit;
using MimeKit;

namespace Email_Helper
{
    /// <summary>
    /// Логика взаимодействия для YandexLoginWindow.xaml
    /// </summary>
    public partial class YandexLoginWindow : Window
    {
        FormCreator Creator;
        public ImapClient Client
        {
            get
            {
                return client;
            }
        }
        ImapClient client;
        static string login;
        static string password;
        public string Login
        {
            get
            {
                return login;
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
        }
        public YandexLoginWindow()
        {
            InitializeComponent();
            MouseLeftButtonDown += new MouseButtonEventHandler
        (YandexLoginWindow_MouseLeftButtonDown);
            Creator = new FormCreator();
        }
        void YandexLoginWindow_MouseLeftButtonDown(object sender,

   MouseButtonEventArgs e)

        {

            DragMove();

        }

        private void Button_Click(object sender, RoutedEventArgs ex)
        {
            using (client = new ImapClient())
            {
                bool error = false;
                try
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    client.Connect("imap.yandex.ru", 993, true);
                    login = LoginTextBox.Text;
                    password = PasswordTextBox.Password;
                    client.Authenticate(login, password);
                }
                catch (Exception)
                {
                    error = true;
                    MessageBox.Show("Login Error");
                }
                if (!error)
                {
                    DataEnterWindowYandex form = new DataEnterWindowYandex();

                    client.Disconnect(true);
                    form.Show();
                    this.Hide();

                }
            }
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Creator.MainFormShow(this);
        }
       

    }
}
