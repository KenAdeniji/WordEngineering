using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

using InformationInTransit.DataAccess;

/*
2014-01-29 Terminus.cs
*/
namespace InformationInTransit.ProcessLogic
{
	public static partial class Terminus
	{
		public static void Main(string[] argv)
		{
			int firstWordId = -1;
			int secondWordId = -1;
			
			DataTable dataTable = ReadExact();

			DataCommand.DatabaseCommand
			(
				"TRUNCATE TABLE Bible..Terminus; DBCC CHECKIDENT('Bible..Terminus', RESEED, 1);",
				CommandType.Text,
				DataCommand.ResultType.NonQuery
			);
			
			for(int currentRow = 0, lastRow = dataTable.Rows.Count; currentRow < lastRow; ++currentRow)
			{
				for(int nextRow = currentRow + 1; nextRow < lastRow; ++nextRow)
				{
					firstWordId = (int) dataTable.Rows[currentRow]["SequenceOrderId"];
					secondWordId = (int) dataTable.Rows[nextRow]["SequenceOrderId"];
		
					Collection<SqlParameter> sqlParameterCollection = new Collection<SqlParameter>();
					sqlParameterCollection.Add(new SqlParameter("@firstWordId", firstWordId));
					sqlParameterCollection.Add(new SqlParameter("@secondWordId", secondWordId));

					DataCommand.DatabaseCommand
					(
						"Bible..usp_TerminusInsert",
						CommandType.StoredProcedure,
						DataCommand.ResultType.NonQuery,
						sqlParameterCollection
					);
				}	
			}
		}
		
		public static DataTable ReadExact()
		{
			DataTable dataTable = (DataTable) DataCommand.DatabaseCommand
			(
				"SELECT SequenceOrderId FROM Bible..Exact ORDER BY sequenceOrderId",
				CommandType.Text,
				DataCommand.ResultType.DataTable
			);
			return dataTable;
		}
	}
}
