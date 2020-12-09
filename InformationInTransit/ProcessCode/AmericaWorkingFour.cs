using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

/*
	2020-02-19 	Created.		https://docs.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlconnection.getschema?view=netframework-4.8
	2020-02-18 	pscp
	2020-02-18	WinSCP-5.17-Setup.exe
*/
namespace InformationInTransit.ProcessCode
{
	public static partial class AmericaWorkingFour
	{
		public static void Main(string[] argv)
		{
			RetrieveTableSchema("BibleBook");
		}
		
		public static DataTable RetrieveTableSchema(String tableName)
		{
			using 
			(
				SqlConnection conn = new SqlConnection("Data Source=(local);Initial Catalog=AmericaWorkingFour;Integrated Security=True;Asynchronous Processing=true;")) {
				conn.Open();

				// You can specify the Catalog, Schema, Table Name, Table Type to get
				// the specified table(s).
				// You can use four restrictions for Table, so you should create a 4 members array.
				String[] tableRestrictions = new String[4];

				// For the array, 0-member represents Catalog; 1-member represents Schema;
				// 2-member represents Table Name; 3-member represents Table Type.
				// Now we specify the Table Name of the table what we want to get schema information.
				tableRestrictions[2] = tableName;

				DataTable schemaTable = conn.GetSchema("Columns", tableRestrictions);

				//ShowColumns(schemaTable);
				return schemaTable;
			}
		}

		private static void ShowDataTable(DataTable table, Int32 length) {
		  foreach (DataColumn col in table.Columns) {
			 Console.Write("{0,-" + length + "}", col.ColumnName);
		  }
		  Console.WriteLine();

		  foreach (DataRow row in table.Rows) {
			 foreach (DataColumn col in table.Columns) {
				if (col.DataType.Equals(typeof(DateTime)))
				   Console.Write("{0,-" + length + ":d}", row[col]);
				else if (col.DataType.Equals(typeof(Decimal)))
				   Console.Write("{0,-" + length + ":C}", row[col]);
				else
				   Console.Write("{0,-" + length + "}", row[col]);
			 }
			 Console.WriteLine();
		  }
		}

		private static void ShowDataTable(DataTable table) {
		  ShowDataTable(table, 14);
		}

		private static void ShowColumns(DataTable columnsTable) {
		  var selectedRows = from info in columnsTable.AsEnumerable()
							 select new {
								TableCatalog = info["TABLE_CATALOG"],
								TableSchema = info["TABLE_SCHEMA"],
								TableName = info["TABLE_NAME"],
								ColumnName = info["COLUMN_NAME"],
								DataType = info["DATA_TYPE"]
							 };

		  Console.WriteLine("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}", "TableCatalog", "TABLE_SCHEMA",
			  "TABLE_NAME", "COLUMN_NAME", "DATA_TYPE");
		  foreach (var row in selectedRows) {
			 Console.WriteLine("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}", row.TableCatalog,
				 row.TableSchema, row.TableName, row.ColumnName, row.DataType);
		  }
		}

		private static void ShowIndexColumns(DataTable indexColumnsTable) {
		  var selectedRows = from info in indexColumnsTable.AsEnumerable()
							 select new {
								TableSchema = info["table_schema"],
								TableName = info["table_name"],
								ColumnName = info["column_name"],
								ConstraintSchema = info["constraint_schema"],
								ConstraintName = info["constraint_name"],
								KeyType = info["KeyType"]
							 };

		  Console.WriteLine("{0,-14}{1,-11}{2,-14}{3,-18}{4,-16}{5,-8}", "table_schema", "table_name", "column_name", "constraint_schema", "constraint_name", "KeyType");
		  foreach (var row in selectedRows) {
			 Console.WriteLine("{0,-14}{1,-11}{2,-14}{3,-18}{4,-16}{5,-8}", row.TableSchema,
				 row.TableName, row.ColumnName, row.ConstraintSchema, row.ConstraintName, row.KeyType);
		  }
		}		
    }
}
