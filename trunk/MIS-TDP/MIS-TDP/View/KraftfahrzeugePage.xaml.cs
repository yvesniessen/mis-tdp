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
    public partial class KraftfahrzeugePage : PageBase
    {
        public KraftfahrzeugePage()
        {
            InitializeComponent();

            this.DataContext = new KraftfahrzeugeViewModel();
        }

        void ItemsListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            KraftfahrzeugeViewModel viewModel = this.DataContext as KraftfahrzeugeViewModel;
            ListBox listBox = sender as ListBox;

            if (listBox != null && viewModel != null)
            {
                viewModel.EditAuftragCommand.Execute(listBox.SelectedItem);
            }
        }


        private void UpdateApplicationBarMenuItem_Click(object sender, System.EventArgs e)
        {
            KraftfahrzeugeViewModel viewModel = this.DataContext as KraftfahrzeugeViewModel;
            if (viewModel != null)
            {
                viewModel.UpdateCommand.Execute(null);
            }
        }

        private void UpdateApplicationBarIconButton_Click(object sender, System.EventArgs e)
        {
            KraftfahrzeugeViewModel viewModel = this.DataContext as KraftfahrzeugeViewModel;
            if (viewModel != null)
            {
                viewModel.UpdateCommand.Execute(null);
            }
        }
    }
}
