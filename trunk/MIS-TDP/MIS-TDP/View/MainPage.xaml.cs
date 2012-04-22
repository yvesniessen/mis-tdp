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

namespace MIS_TDP
{
    public partial class MainPage : PhoneApplicationPage
    {
        #region Contructor
        MainWindowViewModel mvm;
        public MainPage()
        {
            mvm = new MainWindowViewModel();
            InitializeComponent();
        }
        #endregion

        #region react to gui events
        private void hyperlinkButton1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/TestSection.xaml", UriKind.Relative));
        }
        #endregion
    }
}