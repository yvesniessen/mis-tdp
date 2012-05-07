using Microsoft.Phone.Controls;
using MIS_TDP.Controller;
using System.Windows.Controls;

namespace MIS_TDP
{
    public partial class VersicherungenPage : PageBase
    {
        public VersicherungenPage()
        {
            InitializeComponent();

            this.DataContext = new VersicherungenViewModel();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }

        void ItemsListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            VersicherungenViewModel viewModel = this.DataContext as VersicherungenViewModel;
            ListBox listBox = sender as ListBox;

            if (listBox != null && viewModel != null)
            {
                viewModel.EditVersicherungCommand.Execute(listBox.SelectedItem);
            }
        }

        private void NeueVersicherungApplicationBarMenuItem_Click(object sender, System.EventArgs e)
        {
            VersicherungenViewModel viewModel = this.DataContext as VersicherungenViewModel;
            if (viewModel != null)
            {
                viewModel.NeueVersicherungCommand.Execute(null);
            }
        }

        private void UpdateApplicationBarMenuItem_Click(object sender, System.EventArgs e)
        {
            VersicherungenViewModel viewModel = this.DataContext as VersicherungenViewModel;
            if (viewModel != null)
            {
                viewModel.UpdateCommand.Execute(null);
            }
        }

        private void NeueVersicherungApplicationBarIconButton_Click(object sender, System.EventArgs e)
        {
            VersicherungenViewModel viewModel = this.DataContext as VersicherungenViewModel;
            if (viewModel != null)
            {
                viewModel.NeueVersicherungCommand.Execute(null);
            }
        }

        private void UpdateApplicationBarIconButton_Click(object sender, System.EventArgs e)
        {
            VersicherungenViewModel viewModel = this.DataContext as VersicherungenViewModel;
            if (viewModel != null)
            {
                viewModel.UpdateCommand.Execute(null);
            }
        }
    }
}
