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
using System.Linq;

namespace MIS_TDP.Controller
{
    public static class DatabaseController
    {
        private const string ConnectionString = @"isostore:/Database.sdf";



        public static void CreateDatabase()
        {

            using (var context = new DatabaseContext(ConnectionString))
            {

                if (!context.DatabaseExists())
                {

                    // create database if it does not exist

                    context.CreateDatabase();

                }

            }

        }



        public static void DeleteDatabase()
        {

            using (var context = new DatabaseContext(ConnectionString))
            {

                if (context.DatabaseExists())
                {

                    // delete database if it exist

                    context.DeleteDatabase();

                }

            }

        }

        public static void AddAttachment(TblAttachment attachment)
        {
            using (var context = new DatabaseContext(ConnectionString))
            {
                if (context.DatabaseExists())
                {
                    context.TblAttachment.InsertOnSubmit(attachment);
                    context.SubmitChanges();
                }
            }
        }

        public static void UpdateAttachment(TblAttachment attachment)
        {
            using (var context = new DatabaseContext(ConnectionString))
            {
                if (context.DatabaseExists())
                {

                    var attach = (from a in context.TblAttachment
                                  where a.AttachmentNr == attachment.AttachmentNr
                                  select a).Single();
                    attach.AuftragNr = attachment.AuftragNr;
                    attach.Data = attachment.Data;

                    context.SubmitChanges();
                }
            }
        }

        public static IList<TblAttachment> GetAttachments()
        {
            IList<TblAttachment> attachments;

            using (var context = new DatabaseContext(ConnectionString))
            {
                attachments = (from tblAttachment in context.TblAttachment select tblAttachment).ToList();
            }
            return attachments;
        }

        public static void AddAuftrag(TblAuftrag auftrag)
        {
            auftrag.Datum = DateTime.Now;

            using (var context = new DatabaseContext(ConnectionString))
            {
                if (context.DatabaseExists())
                {
                    context.TblAuftrag.InsertOnSubmit(auftrag);
                    context.SubmitChanges();
                }
            }
        }

        public static void UpdateAuftrag(TblAuftrag auftrag)
        {
            using (var context = new DatabaseContext(ConnectionString))
            {
                if (context.DatabaseExists())
                {

                    var auft = (from a in context.TblAuftrag
                                where a.AuftragNr == auftrag.AuftragNr
                                select a).Single();

                    auft.GeschaetzterSchaden = auftrag.GeschaetzterSchaden;
                    auft.KfzFabrikat = auftrag.KfzFabrikat;
                    auft.KfzKennzeichen = auftrag.KfzKennzeichen;
                    auft.VersicherterName = auftrag.VersicherterName;
                    auft.VersicherterVorname = auftrag.VersicherterVorname;
                    auft.VersicherungNr = auftrag.VersicherungNr;

                    context.SubmitChanges();
                }
            }
        }

        public static IList<TblAuftrag> GetAuftraege()
        {
            IList<TblAuftrag> auftraege;

            using (var context = new DatabaseContext(ConnectionString))
            {
                auftraege = (from tblAuftrag in context.TblAuftrag select tblAuftrag).ToList();
            }
            return auftraege;
        }

        public static TblAuftrag GetAuftrag(int AuftragNr)
        {
            TblAuftrag auftrag;
            using (var context = new DatabaseContext(ConnectionString))
            {
                //Da identifier in where klausel geprüft darf nur einer vorkommen somit .Single()
                auftrag = (from tblAuftrag in context.TblAuftrag
                           where tblAuftrag.AuftragNr == AuftragNr
                           select tblAuftrag).Single();
            }
            return auftrag;
        }



        public static void AddVersicherung(TblVersicherung versicherung)
        {
            using (var context = new DatabaseContext(ConnectionString))
            {
                if (context.DatabaseExists())
                {
                    context.TblVersicherung.InsertOnSubmit(versicherung);
                    context.SubmitChanges();
                }
            }
        }

        public static void UpdateVersicherung(TblVersicherung versicherung)
        {
            using (var context = new DatabaseContext(ConnectionString))
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

        public static IList<TblVersicherung> GetVersicherungen()
        {

            IList<TblVersicherung> versicherungen;

            using (var context = new DatabaseContext(ConnectionString))
            {

                versicherungen = (from tblVersicherung in context.TblVersicherung select tblVersicherung).ToList();

            }



            return versicherungen;

        }





        //public static void AddEmployee(Test testdaten)
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



        //public static IList<Test> GetEmployees()
        //{

        //    IList<Test> Testdaten;

        //    using (var context = new DatabaseContext(ConnectionString))
        //    {

        //        Testdaten = (from test in context.Test select test).ToList();

        //    }



        //    return Testdaten;

        //}

    }


}
