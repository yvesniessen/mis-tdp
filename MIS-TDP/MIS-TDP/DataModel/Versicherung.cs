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
    // Datenmodell für die Entität Versicherung
    public class Versicherung : DataModelBase
    {

        #region properties
        private Int32 VersicherungIDValue = 0;
        public Int32 VersicherungID
        {
            get
            {
                return VersicherungIDValue;
            }
            set
            {
                VersicherungIDValue = value;
                OnPropertyChanged("VersicherungID");
                Debug.WriteLine("Property: VersicherungID");
            }
        }

        private String BezeichnungValue = default(String);
        public String Bezeichnung
        {
            get
            {
                return BezeichnungValue;
            }
            set
            {
                BezeichnungValue = value;
                OnPropertyChanged("Bezeichnung");
                Debug.WriteLine("Property: Bezeichnung");
            }
        }
        #endregion

        public override string ToString()
        {
            return this.Bezeichnung;
        }

        public override bool Equals(object obj)
        {
            Versicherung other = obj as Versicherung;
            if (other == null)
                return false;
            if (other == this)
                return true;

            if (!VersicherungID.Equals(other.VersicherungID))
                return false;

            if (!Bezeichnung.Equals(other.Bezeichnung))
                return false;

            return true;
        }

        public override int GetHashCode()
        {
            return VersicherungID.GetHashCode() + Bezeichnung.GetHashCode();
        }
    }
}
