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
        MailController mc = new MailController();
        public TestPage1()
        {
            InitializeComponent();
        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            mc.createMail();
        }

      
    }
}
