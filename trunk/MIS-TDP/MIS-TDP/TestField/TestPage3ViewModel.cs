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
using MIS_TDP.DataModel.BusinessObjects;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Diagnostics;

namespace MIS_TDP
{
    public class TestPage3ViewModel : ViewModelBase
    {
        public void ExportToCsv()
        {

            databaseController.ReportDatabase();
            /*
            using (var context = new DatabaseContext(DatabaseContext.ConnectionString))
            {
                MessageBox.Show("HALLO");
                DataBaseReport report = new DataBaseReport();

                List<TblFabrikat> temp = toList(databaseController.GetFabrikate());

                foreach (TblFabrikat fab in temp)
                {
                    report.Fabrikate.Add(fab.Bezeichnung.ToString());
                    Debug.WriteLine(fab.Bezeichnung);
                }

                MemoryStream ms = new MemoryStream();
                Serialize(ms, report);
                ms.Position = 0;
            }
            */

            //report.XMLSerialize();
        }

        public static void Serialize(Stream streamObject, object objForSerialization)
        {
            using (var context = new DatabaseContext(DatabaseContext.ConnectionString))
            {
                if (objForSerialization == null || streamObject == null)
                    return;

                XmlSerializer serializer = new XmlSerializer(objForSerialization.GetType());
                serializer.Serialize(streamObject, objForSerialization);
            }
        }

        public static object Deserialize(Stream streamObject, Type serializedObjectType)
        {
            if (serializedObjectType == null || streamObject == null)
                return null;

            XmlSerializer serializer = new XmlSerializer(serializedObjectType);
            return serializer.Deserialize(streamObject);
        }


        private static List<T> toList<T>(IEnumerable<T> enumerable)
        {
            var col = new List<T>();

            foreach (var cur in enumerable)
            {

                col.Add(cur);

            }
            return col;
        }
    }
}