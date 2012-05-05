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
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml;
using System.Diagnostics;
using System.IO;

namespace MIS_TDP.DataModel.BusinessObjects
{
    
    [XmlRoot("databasereport")]
    public  class DataBaseReport
    {
        [XmlElement("Auftraege")]
        public List<TblAuftrag> Aufträge { get; set; }

        [XmlElement("Versicherungen")]
        public List<TblVersicherung> Versicherungen { get; set; }

        [XmlElement("Attachments")]
        public List<TblAttachment> Attachments { get; set; }

        [XmlElement("Fabrikate")]
        public List<TblFabrikat> Fabrikate { get; set; }



        public void XMLSerialize()
        {
            Debug.WriteLine("CREATE XML FILE");
            XmlSerializer ser = new XmlSerializer(typeof(DataBaseReport));

           // ser.Serialize(Console.Out, Aufträge);
            using (var sw = new StreamWriter(@"c:\test.xml"))
            {
                var serializer = new XmlSerializer(typeof(List<TblAuftrag>));
                serializer.Serialize(sw, Aufträge);
            }
        }
    }
}
