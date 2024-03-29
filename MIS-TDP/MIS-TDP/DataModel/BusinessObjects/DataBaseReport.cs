﻿using System;
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

        //Constructor
        public DataBaseReport()
        {
            Fabrikate = new List<TblFabrikat>();
            Attachments = new List<TblAttachment>();
            Versicherungen = new List<TblVersicherung>();
            Aufträge = new List<TblAuftrag>();
        }

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
            using (var context = new DatabaseContext(DatabaseContext.ConnectionString))
            {
                Debug.WriteLine("CREATE CSV FILE");

                using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    using (IsolatedStorageFileStream stream = myIsolatedStorage.OpenFile("BackupDB.csv", FileMode.Create))
                    {
                        StreamWriter sw = new StreamWriter(stream);
                        sw.WriteLine("ATTACHMENT");
                        foreach (TblAttachment attachment in this.Attachments)
                        {
                            sw.WriteLine(attachment.AttachmentNr.ToString() + "," + attachment.Data + "," + attachment.Typ.ToString());
                            sw.Flush();
                        }
                        sw.WriteLine("AUFTRAG");
                        foreach (TblAuftrag auftrag in this.Aufträge)
                        {
                            sw.WriteLine(auftrag.AuftragNr.ToString() + "," + auftrag.AttachmentNr);
                            sw.Flush();
                        }
                        sw.WriteLine("VERSICHERUNG");
                        foreach (TblVersicherung versicherung in this.Versicherungen)
                        {
                            sw.WriteLine(versicherung.VersicherungNr.ToString() + "," + versicherung.Name);
                            sw.Flush();
                        }
                        sw.WriteLine("FABRIKAT");
                        foreach (TblFabrikat fabrikat in this.Fabrikate)
                        {
                            sw.WriteLine(fabrikat.ID.ToString() + "," + fabrikat.Bezeichnung);
                            sw.Flush();
                        }
                        sw.Close();
                    }
                }
            }
        }

        

        /// <summary>
        /// XMLs the serialize.
        /// </summary>
        public void XMLSerialize()
        {
            using (var context = new DatabaseContext(DatabaseContext.ConnectionString))
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
            }
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
