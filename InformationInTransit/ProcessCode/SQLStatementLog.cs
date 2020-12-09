using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;

using InformationInTransit.DataAccess;

/*
	2018-05-02	Created.	https://msdn.microsoft.com/en-us/library/system.data.datatable(v=vs.110).aspx
*/
namespace InformationInTransit.ProcessCode
{
	public static partial class SQLStatementLog
	{
		public static void Append
		(
			ref 	DataSet dataSet,
					String	sqlStatement
		)
		{
			// Create a new DataTable.
			System.Data.DataTable table = new DataTable("SQLStatementLog");
			// Declare variables for DataColumn and DataRow objects.
			DataColumn column;
			DataRow row;

			// Create new DataColumn, set DataType, 
			// ColumnName and add to DataTable.    
			column = new DataColumn();
			column.DataType = System.Type.GetType("System.DateTime");
			column.ColumnName = "Datetime";
			column.ReadOnly = true;
			column.Unique = true;
			// Add the Column to the DataColumnCollection.
			table.Columns.Add(column);
			
			// Create second column.
			column = new DataColumn();
			column.DataType = System.Type.GetType("System.String");
			column.ColumnName = "SQLStatement";
			column.AutoIncrement = false;
			column.Caption = "SQLStatement";
			column.ReadOnly = false;
			column.Unique = false;
			// Add the column to the table.
			table.Columns.Add(column);

			// Make the ID column the primary key column.
			DataColumn[] PrimaryKeyColumns = new DataColumn[1];
			PrimaryKeyColumns[0] = table.Columns["datetime"];
			table.PrimaryKey = PrimaryKeyColumns;

			// Add the new DataTable to the DataSet.
			dataSet.Tables.Add(table);

			row = table.NewRow();
			row["Datetime"] = DateTime.Now;
			row["SQLStatement"] = sqlStatement;
			table.Rows.Add(row);
		}		
	}	
}	
