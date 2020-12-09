using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using InformationInTransit.DataAccess;

namespace InformationInTransit.ProcessLogic
{
	public static partial class SqlDataReaderHelper
	{
		/// <summary>
		/// Checks if a column exists in the DataReader
		/// </summary>
		/// <param name="dr">DataReader</param>
		/// <param name="ColumnName">Name of the column to find</param>
		/// <returns>Returns true if the column exists in the DataReader, else returns false</returns>
		/// <remarks>
		/// http://extensionmethod.net/csharp/idatareader/columnexists
		/// </remarks>
		public static Boolean ColumnExists(this IDataReader dr, String ColumnName)
		{
			for (Int32 i = 0; i < dr.FieldCount; i++)
			{
				if (dr.GetName(i).Equals(ColumnName, StringComparison.OrdinalIgnoreCase))
				{
					return true;
				}
			}	
			return false;
		}
		
		// Enumerates through the reads in an IDataReader.
		public static IEnumerable<IDataRecord> AsEnumerable(this IDataReader reader)
		{
			while (reader.Read())
			{
				yield return reader;
			}
		}
	
		public static T GetValueOrDefault<T>
		(
			this SqlDataReader dr,
			string name
		)
		{
			object value = dr[name];
			if (DBNull.Value == value) return default(T);
			return (T)value;
		}
	 
		public static T GetValueOrDefault<T>
		(
			this SqlDataReader dr,
			int index
		) 
		{
			if (dr.IsDBNull(index)) return default(T);
			return (T)dr[index];
		}
	 
		public static bool IsDBNull(this SqlDataReader dr, string name) 
		{
			return dr.IsDBNull(dr.GetOrdinal(name));
		}
		
		public static void Main()
		{
			ExampleGetValueOrDefault();
		}
		
		public static void ExampleGetValueOrDefault()
		{
			SqlDataReader reader = (SqlDataReader)DataCommand.DatabaseCommand
			(
				AdventureWorksSalesOrderDetailQuery
			);
			if (reader.HasRows)
			{
				string carrierTrackingNumber = null;
				while (reader.Read())
				{
					carrierTrackingNumber = reader.GetValueOrDefault<string>("carrierTrackingNumber");
					System.Console.WriteLine
					(
						"{0} | {1} | {2}",
						reader[0],
						reader[1],
						carrierTrackingNumber
					);
				}
			}
			else
			{
				System.Console.WriteLine("No rows found.");
			}
			reader.Close();
		}
		
		public static void ExampleLinq()
		{
			SqlDataReader reader = (SqlDataReader)DataCommand.DatabaseCommand
			(
				AdventureWorksSalesOrderDetailQuery
			);

			var results = reader.AsEnumerable()
				.Select
				(	record => new SalesOrderDetail
                    {
                        SalesOrderID = (int)record["SalesOrderID"],
                        SalesOrderDetailID = (int)record["SalesOrderDetailID"],
                        CarrierTrackingNumber = (string)record["CarrierTrackingNumber"]
                    }
				)
				.GroupBy
				(
					salesOrderDetail => new { salesOrderDetail.SalesOrderID, salesOrderDetail.SalesOrderDetailID }
				);
		}

		///<remarks>
		///http://extensionmethod.net/csharp/list-string/datareader-to-csv
		///</remarks>
		public static List<string> ToCommaSeparatedValue
		(
			this IDataReader dataReader,
			bool includeHeaderAsFirstRow,
			string separator
		)
		{
			List<string> csvRows = new List<string>();
			StringBuilder sb = null;
 
			if (includeHeaderAsFirstRow)
			{
				sb = new StringBuilder();
				for (int index = 0; index < dataReader.FieldCount; index++)
				{
					if (dataReader.GetName(index) != null)
						sb.Append(dataReader.GetName(index));
		 
					if (index < dataReader.FieldCount - 1)
						sb.Append(separator);
				}
				csvRows.Add(sb.ToString());
			}
 
			while (dataReader.Read())
			{
				sb = new StringBuilder();
				for (int index = 0; index < dataReader.FieldCount - 1; index++)
				{
					if (!dataReader.IsDBNull(index))
					{
						string value = dataReader.GetValue(index).ToString();
						if (dataReader.GetFieldType(index) == typeof(String))
						{
							//If double quotes are used in value, ensure each are replaced but 2.
							if (value.IndexOf("\"") >= 0)
								value = value.Replace("\"", "\"\"");
		 
							//If separtor are is in value, ensure it is put in double quotes.
							if (value.IndexOf(separator) >= 0)
								value = "\"" + value + "\"";
						}
						sb.Append(value);
					}
		 
					if (index < dataReader.FieldCount - 1)
						sb.Append(separator);
				}
		 
				if (!dataReader.IsDBNull(dataReader.FieldCount - 1))
					sb.Append(dataReader.GetValue(dataReader.FieldCount - 1).ToString().Replace(separator, " "));
		 
				csvRows.Add(sb.ToString());
			}
			dataReader.Close();
			sb = null;
			return csvRows;
		}

		private partial class SalesOrderDetail
		{
			public int SalesOrderID { get; set; }
			public int SalesOrderDetailID { get; set; }
			public String CarrierTrackingNumber { get; set; }
		}
		
		public const string AdventureWorksSalesOrderDetailQuery = "SELECT * FROM AdventureWorks.Sales.SalesOrderDetail";
	}
}
