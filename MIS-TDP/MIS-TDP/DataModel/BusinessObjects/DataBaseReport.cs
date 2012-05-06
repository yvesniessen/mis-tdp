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
using System.IO.IsolatedStorage;

namespace MIS_TDP.DataModel.BusinessObjects
{


    /// <summary>
    /// Buisiness Object for Database Reports
    /// </summary>
    [XmlRoot("databasereport")]
    public  class DataBaseReport
    {
        #region properties
        /// <summary>
        /// Gets or sets the aufträge.
        /// </summary>
        /// <value>
        /// The aufträge.
        /// </value>
        [XmlElement("Auftraege")]
        public List<TblAuftrag> Aufträge { get; set; }


        /// <summary>
        /// Gets or sets the versicherungen.
        /// </summary>
        /// <value>
        /// The versicherungen.
        /// </value>
        [XmlElement("Versicherungen")]
        public List<TblVersicherung> Versicherungen { get; set; }

        /// <summary>
        /// Gets or sets the attachments.
        /// </summary>
        /// <value>
        /// The attachments.
        /// </value>
        [XmlElement("Attachments")]
        public List<TblAttachment> Attachments { get; set; }

        /// <summary>
        /// Gets or sets the fabrikate.
        /// </summary>
        /// <value>
        /// The fabrikate.
        /// </value>
        [XmlElement("Fabrikate")]
        public List<TblFabrikat> Fabrikate { get; set; }
        #endregion

        #region public properties
        // ruft funktion XMLSerialize auf und schreibt Ergebnis in den Isolated Storage
        /// <summary>
        /// Isoes the storage backup.
        /// </summary>
        public void IsoStorageBackup()
        {

        }


        /// <summary>
        /// CSVs the serialize.
        /// </summary>
        public void CSVSerialize()
        {

        }

        /// <summary>
        /// XMLs the serialize.
        /// </summary>
        public void XMLSerialize()
        {
            Debug.WriteLine("CREATE XML FILE");
            
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.Indent = true;

            using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream stream = myIsolatedStorage.OpenFile("BackupDB.xml", FileMode.Create))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(DataBaseReport));
                    using (XmlWriter xmlWriter = XmlWriter.Create(stream, xmlWriterSettings))
                    {
                        serializer.Serialize(xmlWriter, this);
                    }
                }
            }

            /**
            // Glaube das hier sollte besser generisch sein....
             XmlSerializer ser = new XmlSerializer(typeof(List<TblAuftrag>));
            using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream stream = myIsolatedStorage.OpenFile("BackupDB.xml", FileMode.Create))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<TblAuftrag>));
                    using (XmlWriter xmlWriter = XmlWriter.Create(stream, xmlWriterSettings))
                    {
                        serializer.Serialize(xmlWriter, Aufträge);
                    }
                }
            }
             * */
        }

        public void XMLDeserialize()
        {
            try
            {
                using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream stream = myIsolatedStorage.OpenFile("BackupDB.xml", FileMode.Open))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(DataBaseReport));
                        DataBaseReport data = (DataBaseReport)serializer.Deserialize(stream);
                        
                    }
                }
                Debug.WriteLine("DataBaseReport Onject deserialized");
            }
            catch
            {
                MessageBox.Show("Error occurred while deserialisation");
            }
        }


        
        #endregion

    }
}
