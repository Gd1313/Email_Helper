using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Email_Helper
{
   public class FormCreator
    {
        public void GmailFormCreate(MainWindow mainForm)
        {
            GmailLoginWindow form = new GmailLoginWindow();
            form.Show();
            mainForm.Hide();
        }

        public void MailruFormCreate(MainWindow mainForm)
        {
            MailruLoginWindow form = new MailruLoginWindow();
            form.Show();
            mainForm.Hide();
        }

        public void YandexFormCreate(MainWindow mainForm)
        {
            YandexLoginWindow form = new YandexLoginWindow();
            form.Show();
            mainForm.Hide();
        }

        public void YahooFormCreate(MainWindow mainForm)
        {
            YahooLoginWindow form = new YahooLoginWindow();
            form.Show();
            mainForm.Hide();
        }

        public void MainFormShow(Window functionalForm)
        {
            MainWindow form = new MainWindow();
            functionalForm.Hide();
            form.Show();
        }
    }
}
