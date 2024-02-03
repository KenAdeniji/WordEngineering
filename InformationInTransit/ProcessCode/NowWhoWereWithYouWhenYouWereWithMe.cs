using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;

using System.Globalization;
using System.Threading;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessCode;
using InformationInTransit.ProcessLogic;

namespace InformationInTransit.ProcessCode
{
	///<summary>
	///	2024-01-31T20:33:09 Robert Rouse. Minister of Data. viz.bible
	///	2024-02-02	Now, who were with you, when you were with me?
	///	2024-02-02T11:45:00	Created.
	///		http://stackoverflow.com/questions/8257319/retrieving-table-schema-information-using-c-sharp
	///		http://stackoverflow.com/questions/3005095/can-i-get-the-names-of-all-the-tables-of-a-sql-server-database-in-a-c-sharp-appl
	///</summary>
	public partial class NowWhoWereWithYouWhenYouWereWithMe
	{
		public static System.Collections.Generic.Dictionary<string, string> Tables
		(
			string connectionString
		)
		{
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();

			System.Data.DataTable dataTable = sqlConnection.GetSchema("Tables");
			System.Collections.Generic.Dictionary<string, string> tables
				= new System.Collections.Generic.Dictionary<string, string>();

			foreach (System.Data.DataRow dataRow in dataTable.Rows)
			{
				if 
				(
					dataRow[3].ToString().Equals
					(
						"BASE TABLE",
						StringComparison.OrdinalIgnoreCase
					)
				)
				{
					string schema = dataRow[1].ToString();
					string tableName = dataRow[2].ToString();
					tables.Add(tableName, schema);
				}
			}

			sqlConnection.Close();

			return tables;
		}

        public static DataTable TableSchema
        (
            string connectionString,
            string tableOrViewName
        )
        {
			SqlConnection sqlConnection = new SqlConnection(connectionString);
			sqlConnection.Open();
			SqlCommand sqlCommand = new SqlCommand
			(
				String.Format
				(
					"SELECT TOP 0 * FROM {0}",
					tableOrViewName
				),	
				sqlConnection
			);
			DataTable tableOrViewSchema = sqlCommand.ExecuteReader().GetSchemaTable();
			sqlConnection.Close();
			return tableOrViewSchema;
        }
		
		public static StringBuilder WhereClause
		(
			DataTable tableOrViewSchema,
			string word,
			bool wholeWords
		)
		{
			String columnName;
			String dataTypeName;

			String columnCondition;
			
			StringBuilder sb = new StringBuilder();
			
			foreach(DataRow dataRow in tableOrViewSchema.Rows)
			{
				columnName = (string) dataRow["ColumnName"];
				dataTypeName = (string) dataRow["DataTypeName"];
				
				columnCondition = null;
				
				if 
				(	
					( String.Compare(dataTypeName, "nvarchar") == 0 )
					||
					( String.Compare(dataTypeName, "varchar") == 0 )
				)
				{	
					columnCondition = String.Format
					(
						(
							!wholeWords 
							? PartialWordsQueryFormat 
							: WholeWordsWildCardSearchQueryFormat
						),	
						columnName,
						word
					);
				}	

				if (sb.Length > 0 && !String.IsNullOrEmpty(columnCondition))
				{
					sb.Append(" OR ");
				}		
				
				if (!String.IsNullOrEmpty(columnCondition))
				{
					sb.Append(columnCondition);
				}		
			}	
			
			if (sb.Length > 0)
			{
				sb.Insert(0, " WHERE ");
			}		
			
			return ( sb );
		}
		
		public const string PartialWordsQueryFormat = " ( {0} LIKE '%{1}%' ) ";
		public const string WholeWordsWildCardSearchQueryFormat = " ( {0} LIKE '%[^a-z]{1}[^a-z]%' ) ";
	}
}
