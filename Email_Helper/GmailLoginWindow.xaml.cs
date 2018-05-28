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
    /// Логика взаимодействия для GmailLoginWindow.xaml
    /// </summary>
    public partial class GmailLoginWindow : Window
    {
        FormCreator Creator;
        Authorizer Authorizer;
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
        public GmailLoginWindow()
        {
            InitializeComponent();
            MouseLeftButtonDown += new MouseButtonEventHandler
        (GmailLoginWindow_MouseLeftButtonDown);
            Creator = new FormCreator();
            Authorizer = new Authorizer(client);
        }
        void GmailLoginWindow_MouseLeftButtonDown(object sender,MouseButtonEventArgs e)

        {

            DragMove();

        }

        private void Button_Click(object sender, RoutedEventArgs ex)
        {
            login = LoginTextBox.Text;
            password = PasswordTextBox.Password;
            Authorizer.Autorize(LoginTextBox.Text, PasswordTextBox.Password, "imap.gmail.com", this);
        }


        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            Creator.MainFormShow(this);
        }
    }
}
