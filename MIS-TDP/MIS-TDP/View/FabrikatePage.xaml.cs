using Microsoft.Phone.Controls;
using MIS_TDP.Controller;
using System.Windows.Controls;

namespace MIS_TDP
{
    public partial class FabrikatePage : PageBase
    {
        public FabrikatePage()
        {
            InitializeComponent();

            this.DataContext = new FabrikateViewModel();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }

        void ItemsListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            FabrikateViewModel viewModel = this.DataContext as FabrikateViewModel;
            ListBox listBox = sender as ListBox;

            if (listBox != null && viewModel != null)
            {
                viewModel.EditFabrikatCommand.Execute(listBox.SelectedItem);
            }
        }

        private void NeuesFabrikatApplicationBarMenuItem_Click(object sender, System.EventArgs e)
        {
            FabrikateViewModel viewModel = this.DataContext as FabrikateViewModel;
            if (viewModel != null)
            {
                viewModel.NeuesFabrikatCommand.Execute(null);
            }
        }

        private void UpdateApplicationBarMenuItem_Click(object sender, System.EventArgs e)
        {
            FabrikateViewModel viewModel = this.DataContext as FabrikateViewModel;
            if (viewModel != null)
            {
                viewModel.UpdateCommand.Execute(null);
            }
        }

        private void NeuesFabrikatApplicationBarIconButton_Click(object sender, System.EventArgs e)
        {
            FabrikateViewModel viewModel = this.DataContext as FabrikateViewModel;
            if (viewModel != null)
            {
                viewModel.NeuesFabrikatCommand.Execute(null);
            }
        }

        private void UpdateApplicationBarIconButton_Click(object sender, System.EventArgs e)
        {
            FabrikateViewModel viewModel = this.DataContext as FabrikateViewModel;
            if (viewModel != null)
            {
                viewModel.UpdateCommand.Execute(null);
            }
        }
    }
}
