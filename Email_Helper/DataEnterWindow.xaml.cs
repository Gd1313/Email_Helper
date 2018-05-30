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
using System.Windows.Threading;
using Hardcodet.Wpf.TaskbarNotification;

namespace Email_Helper
{
    /// <summary>
    /// Логика взаимодействия для DataEnterWindow.xaml
    /// </summary>
    public partial class DataEnterWindow : Window
    {
        WindowState prevState;
        List<string> wordCollection;
        List<string> emailCollection;
        DispatcherTimer timer;
        public ImapClient client;
        public string login;
        public string password;
        string email;
        string word;
        Checker Checker;
        ProgramStarter programStarter;
        public DataEnterWindow()
        {
            InitializeComponent();
           
            wordCollection = new List<string>();
            emailCollection = new List<string>();
             timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0,0,15);
            MailruLoginWindow form = new MailruLoginWindow();
            login = form.Login;
            password = form.Password;
            client = new ImapClient();
            client.ServerCertificateValidationCallback = (s, c, h, e) => true;

            client.Connect("imap.mail.ru", 993, true);
            
            client.Authenticate(this.login, this.password);
            Checker = new Checker(client);
            programStarter = new ProgramStarter(MyNotifyIcon, this, timer);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Checker.Check(MyNotifyIcon, email, word);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TextEnterBox.Text != null|| TextEnterBox.Text!=" ")
            {
                if (TextEnterBox.Text.Contains('@'))
                {
                    email = TextEnterBox.Text;
                }
                else word = TextEnterBox.Text;
                TextEnterBox.Clear();
            }
            else MessageBox.Show("Enter key word or email adress");
           
        }

        private void Done_Click(object sender, RoutedEventArgs e)
        {
            programStarter.Start();
        }

        private void DataEnterWindow1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }
        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
                Hide();
            else
                prevState = WindowState;
        }
        private void TaskbarIcon_TrayLeftMouseDown(object sender, RoutedEventArgs e)
        {
            Show();
            WindowState = prevState;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void DataEnterWindow1_Activated(object sender, EventArgs e)
        {
         
        }

        private void MyNotifyIcon_TrayBalloonTipClicked(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://e.mail.ru");
            client.Disconnect(true);
            Environment.Exit(0);
        }
    }
}
