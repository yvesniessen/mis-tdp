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
using System.Collections.Generic;
using System.Diagnostics;

namespace MIS_TDP
{
    public class VersicherungenViewModel : ViewModelBase
    {
        #region Constructor
        public VersicherungenViewModel()
        {
            //this.loadSampleData();
            //this.loadDBData();
        }

        private void loadDBData()
        {

        }

        #endregion

        #region properties
        private ObservableCollection<Versicherung> items = new ObservableCollection<Versicherung>();
        public ObservableCollection<Versicherung> Items
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

        #endregion
    }
}
