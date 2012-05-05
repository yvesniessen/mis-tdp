using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using MIS_TDP.Controller;
using Microsoft.Live;
using Microsoft.Live.Controls;

namespace MIS_TDP
{
    public partial class TestPage1 : PhoneApplicationPage
    {
        #region members
        MailController mc = new MailController();
        //private LiveConnectClient client;
        #endregion

        #region constructor
        public TestPage1()
        {
            InitializeComponent();
        }
        #endregion

        #region react 2 gui events
        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
        
            //mc.createMail();
        }

        private void signInButton1_SessionChanged(object sender, LiveConnectSessionChangedEventArgs e)
        {
            //if (e.status == liveconnectsessionstatus.connected)
            //{
            //    client = new liveconnectclient(e.session);
            //    this.textblocksingstatus.text = "signed in.";
            //    client.getcompleted +=
            //        new eventhandler<liveoperationcompletedeventargs>(ongetcompleted);
            //    client.getasync("me", null);
            //}

            //else
            //{
            //    this.textblocksingstatus.text = "not signed in.";
            //    client = null;
            //}
        }
        #endregion

        #region handler functions
        void OnGetCompleted(object sender, LiveOperationCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                string firstName = "";
                string lastName = "";
                if (e.Result.ContainsKey("first_name") ||
                    e.Result.ContainsKey("last_name"))
                {
                    if (e.Result.ContainsKey("first_name"))
                    {
                        if (e.Result["first_name"] != null)
                        {
                            firstName = e.Result["first_name"].ToString();
                        }
                    }
                    if (e.Result.ContainsKey("last_name"))
                    {
                        if (e.Result["last_name"] != null)
                        {
                            lastName = e.Result["last_name"].ToString();
                        }
                    }
                    this.textBlockSingStatus.Text =
                        "Hello, " + firstName + lastName + "!";
                }
                else
                {
                    this.textBlockSingStatus.Text = "Hello, signed-in user!";
                }
            }
            else
            {
                this.textBlockSingStatus.Text = "Error calling API: " +
                    e.Error.ToString();
            }
        }
        #endregion
    }
}
