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
    public class FabrikatViewModel : ViewModelBase
    {
        #region Constructor
        public FabrikatViewModel()
        {
            this.saveFabrikatCommand = new DelegateCommand(this.SaveFabrikatAction);
        }

        public override void Initialize(IDictionary<string, string> parameters)
        {
            base.Initialize(parameters);

            if (parameters == null)
            {
                return;
            }

            string fabrikatNrString = null;
            if (!parameters.TryGetValue("FabrikatNr", out fabrikatNrString))
            {
                //neue Versicherung
                this.IsNewItem = true;
                this.Item = new TblFabrikat();
            }
            else
            {
                //Versicherung laden
                int fabrikatNr = -1;
                int.TryParse(fabrikatNrString, out fabrikatNr);

                if (fabrikatNr != -1)
                {
                    this.IsNewItem = false;
                    this.Item = databaseController.GetFabrikat(fabrikatNr);
                }
            }
        }

        private void loadSampleData()
        {

        }
        #endregion

        #region properties

        private TblFabrikat item;
        public TblFabrikat Item
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

        private ICommand saveFabrikatCommand;
        public ICommand SaveFabrikatCommand
        {
            get
            {
                return this.saveFabrikatCommand;
            }
        }

        private void SaveFabrikatAction(object o)
        {
            if (this.Item == null || this.Item.Bezeichnung == null)
            {
                return;
            }

            if (this.IsNewItem)
            {
                databaseController.AddFabrikat(this.Item);
                this.IsNewItem = false;
            }
            else
            {
                databaseController.UpdateFabrikat(this.Item);
            }
        }
        #endregion
    }
}