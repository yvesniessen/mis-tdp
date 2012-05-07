using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using MIS_TDP.Controller;

namespace MIS_TDP
{
    public class FabrikateViewModel : ViewModelBase
    {
        #region Constructor
        public FabrikateViewModel()
        {
            this._EditFabrikatCommand = new DelegateCommand(this.EditFabrikatAction);
            this._NeuesFabrikatCommand = new DelegateCommand(this.NeuesFabrikatAction);
            this._UpdateCommand = new DelegateCommand(this.UpdateFabrikatAction);
        }
        #endregion

        public override void Initialize(IDictionary<string, string> parameters)
        {
            base.Initialize(parameters);

            this.Items = databaseController.GetFabrikate();
        }

        #region properties
        private ObservableCollection<TblFabrikat> items = new ObservableCollection<TblFabrikat>();
        public ObservableCollection<TblFabrikat> Items
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
        private ICommand _EditFabrikatCommand;
        public ICommand EditFabrikatCommand
        {
            get
            {
                return this._EditFabrikatCommand;
            }
        }

        private void EditFabrikatAction(object a)
        {
            TblFabrikat fabrikat = a as TblFabrikat;
            if (fabrikat == null)
            {
                return;
            }
            INavigationService navigationService = this.GetService<INavigationService>();
            if (navigationService == null)
            {
                return;
            }

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("FabrikatNr", fabrikat.ID.ToString());

            navigationService.Navigate("/View/FabrikatPage.xaml", parameters);
        }

        private ICommand _NeuesFabrikatCommand;
        public ICommand NeuesFabrikatCommand
        {
            get
            {
                return this._NeuesFabrikatCommand;
            }
        }

        private void NeuesFabrikatAction(object a)
        {
            INavigationService navigationService = this.GetService<INavigationService>();
            if (navigationService == null)
            {
                return;
            }

            navigationService.Navigate("/View/FabrikatPage.xaml");
        }

        private ICommand _UpdateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                return this._UpdateCommand;
            }
        }

        private void UpdateFabrikatAction(object a)
        {
            this.Items = databaseController.GetFabrikate();
        }
        #endregion
    }
}
