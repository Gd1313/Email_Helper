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
        public Window GetWindow(string name)
        {
            switch (name)
            {
                case "Gmail": return new GmailLoginWindow();
                case "Mailru": return new MailruLoginWindow();
                case "Yandex": return new YandexLoginWindow();
                case "Yahoo": return new YahooLoginWindow();
                case "Main": return new MainWindow();
                default: return null;
            }
        }
    }
}
