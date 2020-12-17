using System;
using System.Data;
using System.Data.OleDb;

namespace InformationInTransit.ProcessLogic
{
    public static partial class ExcelHelper
    {
        public static void Main(string[] argv)
        {
            DataTable dataTable = RetrieveExcelTable(argv[0], argv[1]);
            dataTable.DumpDataTable();
        }

        
        /// <summary>
        /// 2014-04-03 http://codekeep.net/snippets/f5db170a-809e-4e26-8f74-928f8f053b25.aspx
        /// wu jun. read excel to datatable.
        /// </summary>
        /// <returns></returns>
        public static DataTable RetrieveExcelTable(string ExcelFile, string SheetName)
        {
            string connectionString = string.Format("provider=Microsoft.Jet.OLEDB.4.0;data source={0};Extended Properties=Excel 8.0;", ExcelFile);
            OleDbConnection connection = new System.Data.OleDb.OleDbConnection();
            connection.ConnectionString = connectionString;

            // Select the data from Sheet1 of the workbook.
            string sql = string.Format("select * from [{0}$]", SheetName);
            OleDbCommand command = new OleDbCommand(sql, connection);

            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            connection.Close();

            return dataTable;
        }
    }
}
