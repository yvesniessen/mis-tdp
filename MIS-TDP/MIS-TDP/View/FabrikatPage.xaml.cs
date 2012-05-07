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
    public partial class FabrikatPage : PageBase
    {
        public FabrikatPage()
        {
            InitializeComponent();

            this.DataContext = new FabrikatViewModel();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            FabrikatViewModel viewModel = this.DataContext as FabrikatViewModel;
            if (viewModel != null && viewModel.Item != null)
            {
                //hier muss glaubsch nix hin
            }
        }

        protected override void OnNavigating()
        {
            FabrikatViewModel viewModel = this.DataContext as FabrikatViewModel;
            if (viewModel != null)
            {
                viewModel.SaveFabrikatCommand.Execute(null);
            }
        }
    }
}
