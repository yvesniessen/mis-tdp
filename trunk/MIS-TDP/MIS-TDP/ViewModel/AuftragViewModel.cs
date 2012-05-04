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
    public class AuftragViewModel : ViewModelBase
    {
        #region Constructor
        public AuftragViewModel()
        {
            //this.loadSampleData();

         //Todo: nur Testdaten, hier muss entsprechende ID des Auftrags geladen werden mit dem Page aufgerufen wurde
            this.item = Controller.DatabaseController.GetAuftrag(1);
        }

        private void loadSampleData()
        {
            System.Uri resourceUri = new System.Uri("/MIS-TDP;component/SampleData/AuftragViewModelSampleData.xaml", System.UriKind.Relative);
            if (System.Windows.Application.GetResourceStream(resourceUri) != null)
            {
                System.Windows.Application.LoadComponent(this, resourceUri);
            }
        }
        #endregion 

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

        public  void AddAuftrag()
        {
            TblAuftrag neuerAuftrag  = new TblAuftrag();
            neuerAuftrag = item;

            Controller.DatabaseController.AddAuftrag(neuerAuftrag);
        }

        #endregion
    }
}
