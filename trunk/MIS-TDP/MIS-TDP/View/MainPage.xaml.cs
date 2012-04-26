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
using System.Diagnostics;




namespace MIS_TDP
{
    public partial class MainPage : PhoneApplicationPage
    {

        #region members
        Button buttonToTestArea;
        #endregion

        #region Contructor
        MainWindowViewModel mvm;
        public MainPage()
        {
            mvm = new MainWindowViewModel();
            InitializeComponent();
                InitDebugMode();
          
        }
        #endregion


        #region Debug Mode
        //[Conditional("DEBUG")]
        private void InitDebugMode()
        {
            // add button and link to test area if system is in debug mode / debugger is attached
            if (System.Diagnostics.Debugger.IsAttached)
            {
                this.buttonDevView.Visibility = Visibility.Visible;
            }
        }
        #endregion

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {

        }


    }
}
