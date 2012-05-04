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

    public class FabrikateViewModel : ViewModelBase
    {

        #region Constructor
        public FabrikateViewModel()
        {
            //this.loadSampleData();
            this.loadDBData();
        }

        public void loadDBData()
        {
            this.items = Controller.DatabaseController.GetFabrikate();
        }

        #endregion

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


        #endregion
    }
}
