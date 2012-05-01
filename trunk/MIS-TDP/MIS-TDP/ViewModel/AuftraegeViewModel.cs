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
    public class AuftraegeViewModel : ViewModelBase
    {
        #region Constructor
        public AuftraegeViewModel()
        {
            this.loadSampleData();
            //this.loadDBData();
        }

        private void loadSampleData()
        {
            System.Uri resourceUri = new System.Uri("/MIS-TDP;component/SampleData/AuftraegeViewModelSampleData.xaml", System.UriKind.Relative);
            if (System.Windows.Application.GetResourceStream(resourceUri) != null)
            {
                System.Windows.Application.LoadComponent(this, resourceUri);
            }
        }

            private void loadDBData()
        {
            IList<TblAuftrag> auftraege = Controller.DatabaseController.GetAuftraege();

            foreach (TblAuftrag auftrag in auftraege)
            {
                Auftrag tmp = new Auftrag();
                tmp.Auftragsnummer = auftrag.AuftragNr;
                tmp.Datum = Convert.ToDateTime(auftrag.Datum);
                Items.Add(tmp);
            }

        }   

        #endregion 

        #region properties
        private ObservableCollection<Auftrag> items = new ObservableCollection<Auftrag>();
        public ObservableCollection<Auftrag> Items
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
