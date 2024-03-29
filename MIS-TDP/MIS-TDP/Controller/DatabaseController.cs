﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using MIS_TDP.DataModel.BusinessObjects;
using System.Data.Linq;

namespace MIS_TDP.Controller
{
  
    public class DatabaseController
    {
        

        //Singleton Instanz
        private static DatabaseController instance;

        public static DatabaseController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DatabaseController();
                }
                return instance;
            }
        }

        private const string ConnectionString = @"isostore:/Database.sdf";

        #region Hilfsfunktionen

        private  ObservableCollection<T> toObservableCollection<T>(IEnumerable<T> enumerable)
        {

            var col = new ObservableCollection<T>();
            foreach (var cur in enumerable)
            {
                col.Add(cur);
            }
            return col;
        }

        #endregion

        #region Generelle Datenbank-Befehle (create delete Report)

        public Boolean DatabaseExists()
        {
            using (var context = new DatabaseContext(ConnectionString))
            {
                return context.DatabaseExists();
            }
        }

        public void CreateDatabase()
        {
            using (var context = new DatabaseContext(DatabaseContext.ConnectionString)) //new DatabaseContext(ConnectionString))
            {
                if (!context.DatabaseExists())
                {
                    // create database if it does not exist
                    context.CreateDatabase();

                }
            }
        }

        public void DeleteDatabase()
        {
            using (var context = new DatabaseContext(DatabaseContext.ConnectionString))
            {
                if (context.DatabaseExists())
                {
                    // delete database if it exist
                    context.DeleteDatabase();
                }
            }
        }

        #region Database Reporting

        public void ReportDatabase()
        {
            using (var context = new DatabaseContext(DatabaseContext.ConnectionString))
            {
                Debug.WriteLine("Database-Report");
                DataBaseReport result = new DataBaseReport();
                result.Aufträge = (from a in context.TblAuftrag select a).ToList<TblAuftrag>();
                result.Attachments = (from a in context.TblAttachment select a).ToList<TblAttachment>();
                result.Versicherungen = (from a in context.TblVersicherung select a).ToList<TblVersicherung>();
                result.Fabrikate = (from a in context.TblFabrikat select a).ToList<TblFabrikat>();
                result.XMLSerialize();
            }

            using (var context = new DatabaseContext(DatabaseContext.ConnectionString))
            {
                Debug.WriteLine("Database-Report");
                DataBaseReport result = new DataBaseReport();
                result.Aufträge = (from a in context.TblAuftrag select a).ToList<TblAuftrag>();
                result.Attachments = (from a in context.TblAttachment select a).ToList<TblAttachment>();
                result.Versicherungen = (from a in context.TblVersicherung select a).ToList<TblVersicherung>();
                result.Fabrikate = (from a in context.TblFabrikat select a).ToList<TblFabrikat>();
                result.CSVSerialize();
            }
        }

        /// <summary>
        /// Saves the XML serialiable element.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="writer">The writer.</param>
        /// <param name="elementName">Name of the element.</param>
        /// <param name="element">The element.</param>
        /*public void SaveXmlSerialiableElement<T>(this XmlWriter writer, String elementName, T element) where T : IXmlSerializable
        {
            writer.WriteStartElement(elementName);
            writer.WriteAttributeString("TYPE", element.GetType().AssemblyQualifiedName);
            element.WriteXml(writer);
            writer.WriteEndElement();
        }*/
        #endregion

        #endregion

        #region Funktionen für Anhänge (add, update,delete,get,getAll)

        public void AddAttachment(TblAttachment attachment)
        {
            using (var context = new DatabaseContext(DatabaseContext.ConnectionString))
            {
                if (context.DatabaseExists())
                {
                    context.TblAttachment.InsertOnSubmit(attachment);
                    context.SubmitChanges();
                }
            }
        }

        public void UpdateAttachment(TblAttachment attachment)
        {
            using (var context = new DatabaseContext(DatabaseContext.ConnectionString))
            {
                if (context.DatabaseExists())
                {

                    var attach = (from a in context.TblAttachment
                                  where a.AttachmentNr == attachment.AttachmentNr
                                  select a).Single();
                    attach.Data = attachment.Data;

                    context.SubmitChanges();
                }
            }
        }

        public void DeleteAttachment(TblAttachment Attachment)
        {
            using (var context = new DatabaseContext(DatabaseContext.ConnectionString))
            {
                if (context.DatabaseExists())
                {
                    context.TblAttachment.DeleteOnSubmit(Attachment);
                    context.SubmitChanges();
                }
            }
        }

        public void DeleteAttachment(int AttachmentNr)
        {
            TblAttachment attachment = GetAttachment(AttachmentNr);

            DeleteAttachment(attachment);
        }

        public ObservableCollection<TblAttachment> GetAttachments()
        {
            IList<TblAttachment> attachments;

            using (var context = new DatabaseContext(DatabaseContext.ConnectionString))
            {
                attachments = (from tblAttachment in context.TblAttachment select tblAttachment).ToList();
            }
            return toObservableCollection<TblAttachment>(attachments);
        }

        public TblAttachment GetAttachment(int AttachmentID)
        {
            TblAttachment attachment;
            using (var context = new DatabaseContext(DatabaseContext.ConnectionString))
            {
                //Da identifier in where klausel geprüft darf nur einer vorkommen somit .Single()
                attachment = (from tblAttachment in context.TblAttachment
                              where tblAttachment.AttachmentNr == AttachmentID
                              select tblAttachment).Single();
            }
            return attachment;
        }

        #endregion (

        #region Funktionen für Aufträge (add, update,delete,get,getAll)

        public void AddAuftrag(TblAuftrag auftrag)
        {
            auftrag.Datum = DateTime.Now;

            using (var context = new DatabaseContext(DatabaseContext.ConnectionString))
            {
                if (context.DatabaseExists())
                {
                    context.TblAuftrag.InsertOnSubmit(auftrag);
                    context.SubmitChanges();
                }
            }
        }

        public void UpdateAuftrag(TblAuftrag auftrag)
        {
            using (var context = new DatabaseContext(DatabaseContext.ConnectionString))
            {
                if (context.DatabaseExists())
                {

                    var auft = (from a in context.TblAuftrag
                                where a.AuftragNr == auftrag.AuftragNr
                                select a).Single();

                    auft.GeschaetzterSchaden = auftrag.GeschaetzterSchaden;
                    auft.KfzKennzeichen = auftrag.KfzKennzeichen;
                    auft.VersicherterName = auftrag.VersicherterName;
                    auft.VersicherterVorname = auftrag.VersicherterVorname;
                    auft.VersicherungNr = auftrag.VersicherungNr;

                    context.SubmitChanges();
                }
            }
        }

        public void DeleteAuftrag(TblAuftrag Auftrag)
        {
            using (var context = new DatabaseContext(DatabaseContext.ConnectionString))
            {
                if (context.DatabaseExists())
                {
                    context.TblAuftrag.DeleteOnSubmit(Auftrag);
                    context.SubmitChanges();
                }
            }
        }

        public void DeleteAuftrag(int AuftragNr)
        {
            TblAuftrag auftrag = GetAuftrag(AuftragNr);

            DeleteAuftrag(auftrag);
        }


        public ObservableCollection<TblAuftrag> GetAuftraege()
        {
            List<TblAuftrag> auftraege = new List<TblAuftrag>();

            using (var context = new DatabaseContext(DatabaseContext.ConnectionString))
            {
                auftraege = (from tblAuftrag in context.TblAuftrag select tblAuftrag).ToList();
            }
            return toObservableCollection<TblAuftrag>(auftraege);
        }

        public TblAuftrag GetAuftrag(int AuftragNr)
        {
            TblAuftrag auftrag;
            using (var context = new DatabaseContext(DatabaseContext.ConnectionString))
            {
                DataLoadOptions lo = new DataLoadOptions();
                lo.LoadWith<TblAuftrag>(a => a.TblVersicherung);
                lo.LoadWith<TblAuftrag>(a => a.TblFabrikat);

                context.LoadOptions = lo;

                //Da identifier in where klausel geprüft darf nur einer vorkommen somit .Single()
                auftrag = (from tblAuftrag in context.TblAuftrag
                           where tblAuftrag.AuftragNr == AuftragNr
                           select tblAuftrag).Single();
            }
            return auftrag;
        }

        #endregion

        #region Funktionen für Versicherungen (add, update,delete,get,getAll)

        public void AddVersicherung(TblVersicherung versicherung)
        {
            using (var context = new DatabaseContext(DatabaseContext.ConnectionString))
            {
                if (context.DatabaseExists())
                {
                    context.TblVersicherung.InsertOnSubmit(versicherung);
                    context.SubmitChanges();
                }
            }
        }

        public void UpdateVersicherung(TblVersicherung versicherung)
        {
            using (var context = new DatabaseContext(DatabaseContext.ConnectionString))
            {
                if (context.DatabaseExists())
                {

                    var vers = (from a in context.TblVersicherung
                                where a.VersicherungNr == versicherung.VersicherungNr
                                select a).Single();
                    vers.Name = versicherung.Name;

                    context.SubmitChanges();
                }
            }
        }

        public void DeleteVersicherung(TblVersicherung Versicherung)
        {
            using (var context = new DatabaseContext(DatabaseContext.ConnectionString))
            {
                if (context.DatabaseExists())
                {
                    context.TblVersicherung.DeleteOnSubmit(Versicherung);
                    context.SubmitChanges();
                }
            }
        }

        public void DeleteVersicherung(int VersicherungNr)
        {
            TblVersicherung versicherung = GetVersicherung(VersicherungNr);

            DeleteVersicherung(versicherung);
        }

        public ObservableCollection<TblVersicherung> GetVersicherungen()
        {
            IList<TblVersicherung> versicherungen;
            using (var context = new DatabaseContext(DatabaseContext.ConnectionString))
            {
                versicherungen = (from tblVersicherung in context.TblVersicherung select tblVersicherung).ToList();
            }
            return toObservableCollection<TblVersicherung>(versicherungen);
        }

        public TblVersicherung GetVersicherung(int VersicherungsNr)
        {
            TblVersicherung versicherung;
            using (var context = new DatabaseContext(DatabaseContext.ConnectionString))
            {
                //Da identifier in where klausel geprüft darf nur einer vorkommen somit .Single()
                versicherung = (from tblVersicherung in context.TblVersicherung
                                where tblVersicherung.VersicherungNr == VersicherungsNr
                                select tblVersicherung).Single();
                
            }
            return versicherung;
        }
        #endregion

        #region Funktionen für Fabrikate (add, update, delete, get, getAll)

        public void AddFabrikat(TblFabrikat fabrikat)
        {
            using (var context = new DatabaseContext(DatabaseContext.ConnectionString))
            {
                if (context.DatabaseExists())
                {
                    context.TblFabrikat.InsertOnSubmit(fabrikat);
                    context.SubmitChanges();
                }
            }
        }

        public void UpdateFabrikat(TblFabrikat fabrikat)
        {
            using (var context = new DatabaseContext(DatabaseContext.ConnectionString))
            {
                if (context.DatabaseExists())
                {

                    var fab = (from a in context.TblFabrikat
                               where a.ID == fabrikat.ID
                               select a).Single();
                    fab.Bezeichnung = fabrikat.Bezeichnung;

                    context.SubmitChanges();
                }
            }
        }

        public void DeleteFabrikat(TblFabrikat fabrikat)
        {
            using (var context = new DatabaseContext(DatabaseContext.ConnectionString))
            {
                if (context.DatabaseExists())
                {
                    context.TblFabrikat.DeleteOnSubmit(fabrikat);
                    context.SubmitChanges();
                }
            }
        }

        public void DeleteFabrikat(int FabrikatID)
        {
            TblFabrikat fabrikat = GetFabrikat(FabrikatID);

            DeleteFabrikat(fabrikat);
        }

        public ObservableCollection<TblFabrikat> GetFabrikate()
        {
            IList<TblFabrikat> fabrikate;
            using (var context = new DatabaseContext(DatabaseContext.ConnectionString))
            {
                fabrikate = (from tblFabrikat in context.TblFabrikat select tblFabrikat).ToList();
            }
            return toObservableCollection<TblFabrikat>(fabrikate);
        }

        public TblFabrikat GetFabrikat(int FabrikatID)
        {
            TblFabrikat fabrikat;
            using (var context = new DatabaseContext(DatabaseContext.ConnectionString))
            {
                //Da identifier in where klausel geprüft darf nur einer vorkommen somit .Single()
                fabrikat = (from tblFabrikat in context.TblFabrikat
                            where tblFabrikat.ID == FabrikatID
                            select tblFabrikat).Single();
            }
            return fabrikat;
        }

        #endregion

        #region Testfunktionen


        //public void AddEmployee(Test testdaten)
        //{

        //    using (var context = new DatabaseContext(ConnectionString))
        //    {

        //        if (context.DatabaseExists())
        //        {

        //            context.Test.InsertOnSubmit(testdaten);

        //            context.SubmitChanges();

        //        }

        //    }

        //}



        //public IList<Test> GetEmployees()
        //{

        //    IList<Test> Testdaten;

        //    using (var context = new DatabaseContext(ConnectionString))
        //    {

        //        Testdaten = (from test in context.Test select test).ToList();

        //    }



        //    return Testdaten;

        //}

        #endregion
    }
}
