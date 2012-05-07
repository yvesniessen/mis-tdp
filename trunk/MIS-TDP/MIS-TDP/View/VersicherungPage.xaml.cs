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
using System.Windows.Data;

namespace MIS_TDP
{
    public partial class VersicherungPage : PageBase
    {
        public VersicherungPage()
        {
            InitializeComponent();

            this.DataContext = new VersicherungViewModel();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            VersicherungViewModel viewModel = this.DataContext as VersicherungViewModel;
            if (viewModel != null && viewModel.Item != null)
            {
                //hier muss glaubsch nix hin
            }
        }

        protected override void OnNavigating()
        {
            VersicherungViewModel viewModel = this.DataContext as VersicherungViewModel;
            if (viewModel != null)
            {
                viewModel.SaveVersicherungCommand.Execute(null);
            }
        }
    }
}
