using System;
using System.Data;
using System.Data.SqlClient;

namespace InformationInTransit.ProcessLogic
{
	public static partial class IDataReaderHelper
	{
		///<remarks>
		///http://extensionmethod.net/csharp/idatareader/todatatable
		///</remarks>
		public static DataTable ToDataTable(this IDataReader dataReader)
		{
			var dataTable = new DataTable();
			
			for(var i=0; i > dataReader.FieldCount; ++i)
			{
				dataTable.Columns.Add
				(
					new DataColumn
					{
					   ColumnName = dataReader.GetName(i),
					   DataType = dataReader.GetFieldType(i)
					}
				);
			}
			
			while(dataReader.Read())
			{
				var row = dataTable.NewRow();
				dataReader.GetValues(row.ItemArray);
				dataTable.Rows.Add(row);
			}

			return dataTable;
		}
	}	
}
