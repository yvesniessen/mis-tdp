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
        public void ExportToCsvAndXml()
        {            
            using (var context = new DatabaseContext(DatabaseContext.ConnectionString))
            {
                databaseController.ReportDatabase();
            }            
        }
    }
}