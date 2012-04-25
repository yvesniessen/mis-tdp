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
    // Datenmodell für die Entität Fabrikat
    public class Fabrikat : DataModelBase
    {

        #region properties
        private Int32 FabriaktIDValue = 0;
        public Int32 FabriaktID
        {
            get
            {
                return FabriaktIDValue;
            }
            set
            {
                FabriaktIDValue = value;
                OnPropertyChanged("FabriaktID");
                Debug.WriteLine("Property: FabriaktID");
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
            Fabrikat other = obj as Fabrikat;
            if (other == null)
                return false;
            if (other == this)
                return true;

            if (!FabriaktID.Equals(other.FabriaktID))
                return false;

            if (!Bezeichnung.Equals(other.Bezeichnung))
                return false;

            return true;
        }

        public override int GetHashCode()
        {
            return FabriaktID.GetHashCode() + Bezeichnung.GetHashCode();
        }
    }
}
