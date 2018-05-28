using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Imap;
using MailKit.Search;
using MailKit;
using MimeKit;
using System.Windows;

namespace Email_Helper
{
  
  public  class Authorizer
    {
        private ImapClient client;

        public Authorizer(ImapClient Client)
        {
            client = Client;
        }

       // public ImapClient Client { get => Client; set => Client = value; }

        public void Autorize(string login,string password,string clientImap,Window loginForm)
        {
            Window form;
            using (client = new ImapClient())
            {
                bool error = false;
                try
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    client.Connect(clientImap, 993, true);
                    //login = LoginTextBox.Text;
                    //password = PasswordTextBox.Password;
                    client.Authenticate(login, password);
                }
                catch (Exception)
                {
                    error = true;
                    MessageBox.Show("Login Error");
                }
                if (!error)
                {
                    if (loginForm.ToString() == "Email_Helper.GmailLoginWindow")
                    {
                        form = new DataEnterWindowGmail();
                    }
                    else if (loginForm.ToString() == "Email_Helper.MailruLoginWindow")
                    {
                        form = new DataEnterWindow();
                    }
                    else
                    if (loginForm.ToString() == "Email_Helper.YahooLoginWindow")
                    {
                        form = new DataEnterWindowYahoo();
                    }
                    else if (loginForm.ToString() == "Email_Helper.YandexLoginWindow")
                    {
                        form = new DataEnterWindowYandex();
                    }
                    else { form = new Window(); MessageBox.Show("Unknown Form"); }
                    

                    client.Disconnect(true);
                    form.Show();
                    loginForm.Hide();

                }
            }
        }
    }
}
