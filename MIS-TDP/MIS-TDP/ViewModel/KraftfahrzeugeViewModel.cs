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

namespace MIS_TDP
{
    public class KraftfahrzeugeViewModel : ViewModelBase
    {
        #region Constructor
        public KraftfahrzeugeViewModel()
        {
            this.loadSampleData();
        }

        private void loadSampleData()
        {
            System.Uri resourceUri = new System.Uri("/MIS-TDP;component/SampleData/AuftraegeViewModelSampleData.xaml", System.UriKind.Relative);
            if (System.Windows.Application.GetResourceStream(resourceUri) != null)
            {
                System.Windows.Application.LoadComponent(this, resourceUri);
            }
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

        #endregion
    }
}
