using Microsoft.Phone.Controls;
using MIS_TDP.Controller;
using System.Windows.Controls;

namespace MIS_TDP
{
    public partial class AuftraegePage : PageBase
    {
        public AuftraegePage()
        {
            InitializeComponent();

            this.DataContext = new AuftraegeViewModel();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }

        void ItemsListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            AuftraegeViewModel viewModel = this.DataContext as AuftraegeViewModel;
            ListBox listBox = sender as ListBox;

            if(listBox != null && viewModel != null)
            {
                viewModel.EditAuftragCommand.Execute(listBox.SelectedItem);
            }
        }

        private void NeuerAuftragApplicationBarMenuItem_Click(object sender, System.EventArgs e)
        {
            AuftraegeViewModel viewModel = this.DataContext as AuftraegeViewModel;
            if (viewModel != null)
            {
                viewModel.NeuerAuftragCommand.Execute(null);
            }
        }

        private void UpdateApplicationBarMenuItem_Click(object sender, System.EventArgs e)
        {
            AuftraegeViewModel viewModel = this.DataContext as AuftraegeViewModel;
            if (viewModel != null)
            {
                viewModel.UpdateCommand.Execute(null);
            }
        }

        private void NeuerAuftragApplicationBarIconButton_Click(object sender, System.EventArgs e)
        {
            AuftraegeViewModel viewModel = this.DataContext as AuftraegeViewModel;
            if (viewModel != null)
            {
                viewModel.NeuerAuftragCommand.Execute(null);
            }
        }

        private void UpdateApplicationBarIconButton_Click(object sender, System.EventArgs e)
        {
            AuftraegeViewModel viewModel = this.DataContext as AuftraegeViewModel;
            if (viewModel != null)
            {
                viewModel.UpdateCommand.Execute(null);
            }
        }
    }
}
