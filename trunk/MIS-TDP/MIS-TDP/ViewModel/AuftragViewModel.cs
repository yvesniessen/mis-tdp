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
            this.loadSampleData();
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
        private Auftrag item;
        public Auftrag Item
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

        

        private ObservableCollection<Versicherung> VersicherungenItems = new ObservableCollection<Versicherung>();
        public ObservableCollection<Versicherung> Versicherungen
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

        private ObservableCollection<Fabrikat> FabrikateItems = new ObservableCollection<Fabrikat>();
        public ObservableCollection<Fabrikat> Fabrikate
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
            neuerAuftrag.GeschaetzterSchaden = (int)this.item.GeschaetzterSchaden;
            neuerAuftrag.KfzFabrikat = this.item.KfzFabrikat.Bezeichnung;
            neuerAuftrag.KfzKennzeichen = this.item.KfzKennzeichen;
            neuerAuftrag.VersicherterName = this.item.VersicherterNachname;
            neuerAuftrag.VersicherterVorname = this.item.VersicherterVorname;
 //           neuerAuftrag.VersicherungNr = this.item.Versicherung.VersicherungID;

            Controller.DatabaseController.AddAuftrag(neuerAuftrag);
        }

        #endregion
    }
}
