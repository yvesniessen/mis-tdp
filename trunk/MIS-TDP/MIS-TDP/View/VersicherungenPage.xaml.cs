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
    public partial class VersicherungenPage : PhoneApplicationPage
    {
        public VersicherungenPage()
        {
            InitializeComponent();
        }


        private void ApplicationBarButtonAddClick(object sender, System.EventArgs e)
        {
            Uri uri = new System.Uri("/MIS-TDP;component/View/VersicherungPage.xaml", System.UriKind.Relative);
            this.NavigationService.Navigate(uri);
        }

        private void ApplicationBarButtonUpdateClick(object sender, System.EventArgs e)
        {
            (DataContext as VersicherungenViewModel).loadDBData();
        }
    }
}
