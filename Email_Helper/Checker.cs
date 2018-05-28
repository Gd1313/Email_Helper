using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Imap;
using MailKit.Search;
using MailKit;
using MimeKit;
using System.Windows.Threading;
using Hardcodet.Wpf.TaskbarNotification;

namespace Email_Helper
{
   public class Checker
    {
        public ImapClient client;

        public Checker(ImapClient client)
        {
            this.client = client;
        }

        public void Check(TaskbarIcon MyNotifyIcon, string email, string word)
        {
            var inbox = client.Inbox;
            inbox.Open(FolderAccess.ReadOnly);
            MimeMessage message;
            foreach (var uid in inbox.Search(SearchQuery.NotSeen))
            {

                message = inbox.GetMessage(uid);
                if (email != null)
                {
                    foreach (var mailbox in message.From.Mailboxes)
                    {
                        if (mailbox.Address == email)
                        {
                            MyNotifyIcon.ShowBalloonTip("Email Delivered", "Delivered your email with sender email adress " + email, BalloonIcon.Info);

                        }
                    }
                }

            }
            if (word != null)
            {
                for (int i = 0; i < inbox.Count; i++)
                {
                    message = inbox.GetMessage(i);
                    if (message.TextBody.Contains(word))
                    {
                        MyNotifyIcon.ShowBalloonTip("Email Delivered", "Delivered your email with key word " + word, BalloonIcon.Info);
                    }
                }
            }
        }
    }
}
