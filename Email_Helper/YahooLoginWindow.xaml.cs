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
using System;

namespace Email_Helper
{
    /// <summary>
    /// Логика взаимодействия для YahooLoginWindow.xaml
    /// </summary>
    public partial class YahooLoginWindow : Window
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
        public YahooLoginWindow()
        {
            InitializeComponent();
            MouseLeftButtonDown += new MouseButtonEventHandler
       (YahooLoginWindow_MouseLeftButtonDown);
            Creator = new FormCreator();
        }
        void YahooLoginWindow_MouseLeftButtonDown(object sender,

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

                    client.Connect("imap.mail.yahoo.com", 993, true);
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
                    DataEnterWindowYahoo form = new DataEnterWindowYahoo();

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
