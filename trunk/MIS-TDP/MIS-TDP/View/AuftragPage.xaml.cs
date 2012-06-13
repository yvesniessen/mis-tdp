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
using Microsoft.Phone.Tasks;

namespace MIS_TDP
{
    public partial class AuftragPage : PageBase
    {
        public AuftragPage()
        {
            InitializeComponent();

            this.DataContext = new AuftragViewModel();
        }

        Boolean blockDataReload = false;
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            if (this.blockDataReload)
            {
                this.blockDataReload = false;
                return;
            }

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

        private void choosePhoneNumber_Click(object sender, RoutedEventArgs e)
        {
            PhoneNumberChooserTask phoneNumberChooserTask = new PhoneNumberChooserTask();
            phoneNumberChooserTask.Completed += new EventHandler<PhoneNumberResult>(phoneNumberChooserTask_Completed);
            phoneNumberChooserTask.Show();
        }

        String number;
        String displayName;
        void phoneNumberChooserTask_Completed(object sender, PhoneNumberResult e)
        {
            this.blockDataReload = true;

            if (e.TaskResult == TaskResult.OK)
            {
                displayName = e.DisplayName;
                String[] arr = e.DisplayName.Split(' ');

                if (arr.Count() == 1)
                {
                    this.VornameTextBox.Text = arr[0];
                }
                if (arr.Count() == 2)
                {
                    this.VornameTextBox.Text = arr[0];
                    this.NachnameTextBox.Text = arr[1];
                }
                else if (arr.Count() == 3)
                {
                    this.VornameTextBox.Text = arr[0] + " " + arr[1];
                    this.NachnameTextBox.Text = arr[2];
                }

                number = e.PhoneNumber;
            }
        }

        private void callPhoneNumber_Click(object sender, RoutedEventArgs e)
        {
            if (number != null && number.Length > 0)
            {
                PhoneCallTask phoneCallTask = new PhoneCallTask();
                phoneCallTask.DisplayName = displayName;
                phoneCallTask.PhoneNumber = number;
                phoneCallTask.Show();
            }
            else
            {
                MessageBox.Show("Keine Nummer gespeichert !");
            }
        }
    }
}
