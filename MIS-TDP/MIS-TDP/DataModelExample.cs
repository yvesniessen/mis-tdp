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

namespace MIS_TDP
{
    // Dies ist ein exemplarisches Datenmodell für die Kapselung von Daten
    public class DataModelExample : DataModelBase
    {

        #region properties
        private String NameValue = default(string);
        public string Name
        {
            get
            {
                return NameValue;
            }
            set
            {
                NameValue = value;

            }
        }

        private String ContentValue = default(string);
        public string Content
        {
            get
            {
                return ContentValue;
            }
            set
            {
                ContentValue = value;

            }
        }
        #endregion
    }
}
