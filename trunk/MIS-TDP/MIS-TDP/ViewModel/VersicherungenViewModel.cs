using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using MIS_TDP.Controller;

namespace MIS_TDP
{
    public class VersicherungenViewModel : ViewModelBase
    {
        #region Constructor
        public VersicherungenViewModel()
        {
            this._EditVersicherungCommand = new DelegateCommand(this.EditVersicherungAction);
            this._NeueVersicherungCommand = new DelegateCommand(this.NeueVersicherungAction);
            this._UpdateCommand = new DelegateCommand(this.UpdateVersicherungAction);
        }
        #endregion

        public override void Initialize(IDictionary<string, string> parameters)
        {
            base.Initialize(parameters);

            this.Items = databaseController.GetVersicherungen();
        }

        #region properties
        private ObservableCollection<TblVersicherung> items = new ObservableCollection<TblVersicherung>();
        public ObservableCollection<TblVersicherung> Items
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
        private ICommand _EditVersicherungCommand;
        public ICommand EditVersicherungCommand
        {
            get
            {
                return this._EditVersicherungCommand;
            }
        }

        private void EditVersicherungAction(object a)
        {
            TblVersicherung versicherung = a as TblVersicherung;
            if (versicherung == null)
            {
                return;
            }
            INavigationService navigationService = this.GetService<INavigationService>();
            if (navigationService == null)
            {
                return;
            }

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("VersicherungNr", versicherung.VersicherungNr.ToString());

            navigationService.Navigate("/View/VersicherungPage.xaml", parameters);
        }

        private ICommand _NeueVersicherungCommand;
        public ICommand NeueVersicherungCommand
        {
            get
            {
                return this._NeueVersicherungCommand;
            }
        }

        private void NeueVersicherungAction(object a)
        {
            INavigationService navigationService = this.GetService<INavigationService>();
            if (navigationService == null)
            {
                return;
            }

            navigationService.Navigate("/View/VersicherungPage.xaml");
        }

        private ICommand _UpdateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                return this._UpdateCommand;
            }
        }

        private void UpdateVersicherungAction(object a)
        {
            this.Items = databaseController.GetVersicherungen();
        }
        #endregion
    }
}
