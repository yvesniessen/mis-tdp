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
using Microsoft.Phone.Controls;

namespace MIS_TDP
{
    public abstract class PageBase : PhoneApplicationPage
    {
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (NavigationService != null)
                NavigationService.Navigating += new System.Windows.Navigation.NavigatingCancelEventHandler(NavigationService_Navigating);

            ViewModelBase viewModel = this.DataContext as ViewModelBase;
            if(viewModel != null)
                viewModel.Initialize(this.NavigationContext.QueryString);
        }

        private void NavigationService_Navigating(object sender, System.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            NavigationService.Navigating -= new System.Windows.Navigation.NavigatingCancelEventHandler(NavigationService_Navigating);

            this.OnNavigating();
        }

        protected virtual void OnNavigating()
        {

        }
        
    }
}
