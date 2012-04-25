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
using System.ComponentModel;
using System.Diagnostics;

namespace MIS_TDP
{
    // Datenmodell für die Entität Auftrag
    public class Auftrag : DataModelBase
    {

        #region properties
        private Int32 AuftragsnummerValue = 0;
        public Int32 Auftragsnummer
        {
            get
            {
                return AuftragsnummerValue;
            }
            set
            {
                AuftragsnummerValue = value;
                OnPropertyChanged("Auftragsnummer");
                Debug.WriteLine("Property: Auftragsnummer");
            }
        }

        private DateTime DatumValue = default(DateTime);
        [TypeConverter(typeof(ConvertibleTypeConverter<DateTime>))]
        public DateTime Datum
        {
            get
            {
                return DatumValue;
            }
            set
            {
                DatumValue = value;
                OnPropertyChanged("Datum");
                Debug.WriteLine("Property: Datum");
            }
        }

        private Versicherung VersicherungValue;
        public Versicherung Versicherung
        {
            get
            {
                return VersicherungValue;
            }
            set
            {
                VersicherungValue = value;
                OnPropertyChanged("Versicherung");
                Debug.WriteLine("Property: Versicherung");
            }
        }

        private Int32 VersichertennummerValue = default(Int32);
        public Int32 Versichertennummer
        {
            get
            {
                return VersichertennummerValue;
            }
            set
            {
                VersichertennummerValue = value;
                OnPropertyChanged("Versichertennummer");
                Debug.WriteLine("Property: Versichertennummer");
            }
        }

        private String VersicherterVornameValue = default(String);
        public String VersicherterVorname
        {
            get
            {
                return VersicherterVornameValue;
            }
            set
            {
                VersicherterVornameValue = value;
                OnPropertyChanged("VersicherterVorname");
                Debug.WriteLine("Property: VersicherterVorname");
                OnPropertyChanged("Versicherter");
                Debug.WriteLine("Property: Versicherter");
            }
        }

        private String VersicherterNachnameValue = default(String);
        public String VersicherterNachname
        {
            get
            {
                return VersicherterNachnameValue;
            }
            set
            {
                VersicherterNachnameValue = value;
                OnPropertyChanged("VersicherterNachname");
                Debug.WriteLine("Property: VersicherterNachname");
                OnPropertyChanged("Versicherter");
                Debug.WriteLine("Property: Versicherter");
            }
        }

        public String Versicherter
        {
            get
            {
                return VersicherterNachname + ", " + VersicherterVorname;
            }
        }

        private String KfzKennzeichenValue = default(String);
        public String KfzKennzeichen
        {
            get
            {
                return KfzKennzeichenValue;
            }
            set
            {
                KfzKennzeichenValue = value;
                OnPropertyChanged("KfzKennzeichen");
                Debug.WriteLine("Property: KfzKennzeichen");
            }
        }

        private Fabrikat KfzFabrikatValue;
        public Fabrikat KfzFabrikat
        {
            get
            {
                return KfzFabrikatValue;
            }
            set
            {
                KfzFabrikatValue = value;
                OnPropertyChanged("KfzFabrikat");
                Debug.WriteLine("Property: KfzFabrikat");
            }
        }

        private Double GeschaetzterSchadenValue = default(Double);
        public Double GeschaetzterSchaden
        {
            get
            {
                return GeschaetzterSchadenValue;
            }
            set
            {
                GeschaetzterSchadenValue = value;
                OnPropertyChanged("GeschaetzterSchaden");
                Debug.WriteLine("Property: GeschaetzterSchaden");
            }
        }
        #endregion
    }
}
