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
using System.Data;

namespace MIS_TDP.TestField
{
    public class DataSetController
    {
        /**
         private string ConvertToCSV(DataSet objDataSet)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();            
                var columnNames = objDataset.Columns.Cast<datacolumn>().Select(column => column.ColumnName).ToArray();
                sb.AppendLine(string.Join(",", columnNames));
                foreach (DataRow row in objDataSet.Rows)
                {
                    var fields = row.ItemArray.Select(field => field.ToString()).ToArray();
                    sb.AppendLine(string.Join(",", fields));
                }            
            return sb.ToString();
        }
        </datacolumn>
        **/
    }
}
