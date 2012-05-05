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
using MIS_TDP.Controller;

namespace MIS_TDP.TestField
{
    public partial class TestPage3 : PhoneApplicationPage
    {
        public TestPage3()
        {
            InitializeComponent();
        }

        private void hyperlinkButton1_Click(object sender, RoutedEventArgs e)
        {
            DatabaseController.ReportDatabase();
        }
    }
}