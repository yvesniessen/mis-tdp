using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Tasks;

namespace MIS_TDP.Controller
{
    public class MailController
    {
        public void createMail()
        {
            EmailComposeTask emailComposeTask = new EmailComposeTask();
            emailComposeTask.Subject = "message subject";
            emailComposeTask.Body = "message body";
            emailComposeTask.To = "bastian.dreher@gmx.net";
            emailComposeTask.Cc = "";
            emailComposeTask.Bcc = "";
            emailComposeTask.Show();
        }

        #region email adress chooser
        void emailAdressChooser()
        {
            EmailAddressChooserTask emailAddressChooserTask = new EmailAddressChooserTask();
            emailAddressChooserTask.Completed += new EventHandler<EmailResult>(emailAddressChooserTask_Completed);
        }

        void emailAddressChooserTask_Completed(object sender, EmailResult e)
        {
            if (e.TaskResult == TaskResult.OK)
            {
                MessageBox.Show("The email for " + e.DisplayName + " is " + e.Email);

                //Code to send a new email message using the retrieved email address.
                //EmailComposeTask emailComposeTask = new EmailComposeTask();
                //emailComposeTask.To = e.Email;
                //emailComposeTask.Subject = e.DisplayName + ", here is an email from my app!";
                //emailComposeTask.Show();
            }
        }

        #endregion

        public void call()
        {
            PhoneCallTask task = new PhoneCallTask();
           
            task.PhoneNumber = "000000000";
            
            task.DisplayName = "User K. User";
            
            task.Show();
        }

    }
}
