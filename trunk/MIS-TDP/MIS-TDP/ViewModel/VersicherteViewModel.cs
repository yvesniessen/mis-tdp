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
using System.Collections.ObjectModel;
using System.Diagnostics;
using MIS_TDP.Controller;
using System.Collections.Generic;

namespace MIS_TDP
{
    public class VersicherteViewModel : ViewModelBase
    {
        #region Constructor
        public VersicherteViewModel()
        {
            this._EditAuftragCommand = new DelegateCommand(this.EditAuftragAction);
            this._UpdateCommand = new DelegateCommand(this.UpdateAuftragAction);
            this.Items = databaseController.GetAuftraege();
        }

        #endregion 

        #region properties
        private ObservableCollection<TblAuftrag> items = new ObservableCollection<TblAuftrag>();
        public ObservableCollection<TblAuftrag> Items
        {
            get
            {
                return items;
            }
            set
            {
                items = value;
                OnPropertyChanged("Items");
                Debug.WriteLine("Property: Items");
            }
        }
        #endregion

        #region ButtonCommands
        private ICommand _EditAuftragCommand;
        public ICommand EditAuftragCommand
        {
            get
            {
                return this._EditAuftragCommand;
            }
        }

        private void EditAuftragAction(object a)
        {
            TblAuftrag auftrag = a as TblAuftrag;
            if (auftrag == null)
            {
                return;
            }
            INavigationService navigationService = this.GetService<INavigationService>();
            if (navigationService == null)
            {
                return;
            }

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("AuftragNr", auftrag.AuftragNr.ToString());

            navigationService.Navigate("/View/AuftragPage.xaml", parameters);
        }

        private ICommand _UpdateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                return this._UpdateCommand;
            }
        }

        private void UpdateAuftragAction(object a)
        {
            this.Items = databaseController.GetAuftraege();
        }
        #endregion
    }
}
