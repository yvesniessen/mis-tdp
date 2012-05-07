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
using System.Collections.Generic;
using MIS_TDP.Controller;

namespace MIS_TDP
{
    public class AuftragViewModel : ViewModelBase
    {
        #region Constructor
        public AuftragViewModel()
        {
            this.saveAuftragCommand = new DelegateCommand(this.SaveAuftragAction);
            this.VersicherungenItems = databaseController.GetVersicherungen();
            this.FabrikateItems = databaseController.GetFabrikate();
        }
        #endregion

        public override void Initialize(IDictionary<string, string> parameters)
        {
            base.Initialize(parameters);

            if (parameters == null)
            {
                return;
            }

            string auftragNrString = null;
            if (!parameters.TryGetValue("AuftragNr", out auftragNrString))
            {
                //neuer Auftrag
                this.IsNewItem = true;
                this.Item = new TblAuftrag();
            }
            else
            {
                //Auftrag laden
                int auftragNr = -1;
                int.TryParse(auftragNrString, out auftragNr);

                if (auftragNr != -1)
                {
                    this.IsNewItem = false;
                    this.Item = databaseController.GetAuftrag(auftragNr);
                }
            }
        }
        

        #region properties

        private TblAuftrag item;
        public TblAuftrag Item
        {
            get
            {
                return item;
            }
            set
            {
                item = value;
                OnPropertyChanged("Item");
                Debug.WriteLine("Property: Item");
            }
        }

        private Boolean _isNewItem;
        public Boolean IsNewItem
        {
            get
            {
                return _isNewItem;
            }
            set
            {
                _isNewItem = value;
                OnPropertyChanged("IsNewItem");
                Debug.WriteLine("Property: IsNewItem");
            }
        }

        private ObservableCollection<TblVersicherung> VersicherungenItems = new ObservableCollection<TblVersicherung>();
        public ObservableCollection<TblVersicherung> Versicherungen
        {
            get
            {
                return VersicherungenItems;
            }
            set
            {
                VersicherungenItems = value;
                OnPropertyChanged("VersicherungenItems");
                Debug.WriteLine("Property: VersicherungenItems");
            }
        }

        private ObservableCollection<TblFabrikat> FabrikateItems = new ObservableCollection<TblFabrikat>();
        public ObservableCollection<TblFabrikat> Fabrikate
        {
            get
            {
                return FabrikateItems;
            }
            set
            {
                FabrikateItems = value;
                OnPropertyChanged("FabrikateItems");
                Debug.WriteLine("Property: FabrikateItems");
            }
        }
        #endregion

        #region ButtonCommands

        private ICommand saveAuftragCommand;
        public ICommand SaveAuftragCommand
        {
            get
            {
                return this.saveAuftragCommand;
            }
        }

        private void SaveAuftragAction(object o)
        {
            if (this.Item == null)
            {
                return;
            }

            if (this.IsNewItem)
            {
                databaseController.AddAuftrag(this.Item);
                this.IsNewItem = false;
            }
            else
            {
                databaseController.UpdateAuftrag(this.Item);
            }
        }
        #endregion
    }
}
