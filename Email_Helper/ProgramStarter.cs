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
   public class ProgramStarter
    {
        TaskbarIcon notifyIcon;
        Window window;
        DispatcherTimer timer;

        public ProgramStarter(TaskbarIcon notifyIcon, Window window, DispatcherTimer timer)
        {
            this.notifyIcon = notifyIcon;
            this.window = window;
            this.timer = timer;
        }

        public void Start()
        {
            MessageBox.Show("Start");
            notifyIcon.Icon = new System.Drawing.Icon("Icon.ico");
            window.WindowState = WindowState.Minimized;
            timer.Start();
            window.Hide();
        }
    }
}
