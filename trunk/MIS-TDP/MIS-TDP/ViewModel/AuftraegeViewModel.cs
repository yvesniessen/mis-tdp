using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using MIS_TDP.Controller;

namespace MIS_TDP
{
    public class AuftraegeViewModel : ViewModelBase
    {
        #region Constructor
        public AuftraegeViewModel()
        {
            this._EditAuftragCommand = new DelegateCommand(this.EditAuftragAction);
            this._NeuerAuftragCommand = new DelegateCommand(this.NeuerAuftragAction);
            this._UpdateCommand = new DelegateCommand(this.UpdateAuftragAction);
        }
        #endregion 

        public override void Initialize(IDictionary<string, string> parameters)
        {
            base.Initialize(parameters);

            this.Items = databaseController.GetAuftraege();
        }

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

        private ICommand _NeuerAuftragCommand;
        public ICommand NeuerAuftragCommand
        {
            get
            {
                return this._NeuerAuftragCommand;
            }
        }

        private void NeuerAuftragAction(object a)
        {
            INavigationService navigationService = this.GetService<INavigationService>();
            if (navigationService == null)
            {
                return;
            }

            navigationService.Navigate("/View/AuftragPage.xaml");
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
