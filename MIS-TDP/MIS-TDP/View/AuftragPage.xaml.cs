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
    public partial class AuftragPage : PageBase
    {
        public AuftragPage()
        {
            InitializeComponent();

            this.DataContext = new AuftragViewModel();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            AuftragViewModel viewModel = this.DataContext as AuftragViewModel;
            if (viewModel != null && viewModel.Item != null)
            {
                if (viewModel.Item.TblVersicherung == null)
                    viewModel.Item.TblVersicherung = this.VersicherungListPicker.SelectedItem as TblVersicherung;

                if (viewModel.Item.TblFabrikat == null)
                    viewModel.Item.TblFabrikat = this.FabrikatListPicker.SelectedItem as TblFabrikat;
            }
        }

        protected override void OnNavigating()
        {
            AuftragViewModel viewModel = this.DataContext as AuftragViewModel;
            if (viewModel != null)
            {
                viewModel.SaveAuftragCommand.Execute(null);
            }
        }
    }
}
