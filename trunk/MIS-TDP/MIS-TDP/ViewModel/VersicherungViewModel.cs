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
    public class VersicherungViewModel : ViewModelBase
    {
        #region Constructor
        public VersicherungViewModel()
        {
            this.saveVersicherungCommand = new DelegateCommand(this.SaveVersicherungAction);
        }

        public override void Initialize(IDictionary<string, string> parameters)
        {
            base.Initialize(parameters);

            if (parameters == null)
            {
                return;
            }

            string versicherungNrString = null;
            if (!parameters.TryGetValue("VersicherungNr", out versicherungNrString))
            {
                //neue Versicherung
                this.IsNewItem = true;
                this.Item = new TblVersicherung();
            }
            else
            {
                //Versicherung laden
                int versicherungNr = -1;
                int.TryParse(versicherungNrString, out versicherungNr);

                if (versicherungNr != -1)
                {
                    this.IsNewItem = false;
                    this.Item = databaseController.GetVersicherung(versicherungNr);
                }
            }
        }

        private void loadSampleData()
        {

        }
        #endregion

        #region properties

        private TblVersicherung item;
        public TblVersicherung Item
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


        #endregion

        #region ButtonCommands

      private ICommand saveVersicherungCommand;
        public ICommand SaveVersicherungCommand
        {
            get
            {
                return this.saveVersicherungCommand;
            }
        }

        private void SaveVersicherungAction(object o)
        {
            if (this.Item == null || this.Item.Name == null)
            {
                return;
            }

            if (this.IsNewItem)
            {
                databaseController.AddVersicherung(this.Item);
                this.IsNewItem = false;
            }
            else
            {
                databaseController.UpdateVersicherung(this.Item);
            }
        }
        #endregion
    }
}