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
	///	2024-02-03T12:11:00	Reign of Ahaziah
	///	HisWord table. 159455	2024-02-03 11:10:39.553	He chose to do it...base on activity.	11:35 Headache. 11:59 Urine. 12:10 Urine. 12:32 NowWhoWereWithYouWhenYouWereWithMe.html word input now...king. 13:07 Urine. 2024-02-02...2024-02-03T14:12:00 microsoft windows operating system, mozilla firefox browser NowWhoWereWithYouWhenYouWereWithMe.html word=king no response error, freeze, wait error. 13:49 Pegasus Center, 34245 Fremont Boulevard, State Farm, Christina Zeng agent. 13:49 Urine Wienerschnitzel 99 Ranch Market (Ofe ke?) (A mo pe ko da be). 14:19 Thirst (We are proving difficult) (A mo pe ko da be).	NULL	NULL	NULL	NULL	NULL	NULL	NULL
	///	2024-02-03T15:23:00	http://learn.microsoft.com/en-us/dotnet/framework/data/adonet/sql-server-data-type-mappings
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
			
			bool isDateTime;
			DateTime dateTimeValue;

			bool isNumeric;
			decimal numericValue;
			
			isDateTime = DateTime.TryParse(word, out dateTimeValue);
			isNumeric = Decimal.TryParse(word, out numericValue);
			
			foreach(DataRow dataRow in tableOrViewSchema.Rows)
			{
				columnName = (string) dataRow["ColumnName"];
				dataTypeName = (string) dataRow["DataTypeName"];
				
				columnCondition = null;
				
				if 
				(	
					isDateTime	
					&&
					( 
						String.Compare(dataTypeName, "datetime") == 0 
						||
						String.Compare(dataTypeName, "datetime2") == 0 
						||
						String.Compare(dataTypeName, "smalldatetime") == 0 
					)
				)
				{	
					columnCondition = String.Format
					(
						DateTimeQueryFormat,	
						columnName,
						dateTimeValue
					);
				}	
				else if 
				(	
					isNumeric
					&&
					( 
						String.Compare(dataTypeName, "bigint") == 0 
						||
						String.Compare(dataTypeName, "decimal") == 0 
						||
						String.Compare(dataTypeName, "float") == 0 
						||
						String.Compare(dataTypeName, "int") == 0 
						||
						String.Compare(dataTypeName, "money") == 0 
						||
						String.Compare(dataTypeName, "numeric") == 0 
						||
						String.Compare(dataTypeName, "real") == 0 
						||
						String.Compare(dataTypeName, "smallint") == 0 
						||
						String.Compare(dataTypeName, "smallmoney") == 0 
						||
						String.Compare(dataTypeName, "tinyint") == 0 
					)
				)
				{	
					columnCondition = String.Format
					(
						NumericQueryFormat,	
						columnName,
						numericValue
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
		
		public const string DateTimeQueryFormat = " ( CONVERT(DATE, {0}) = '{1}' ) ";
		public const string NumericQueryFormat = " ( CONVERT(DECIMAL, {0}) = '{1}' ) ";
	}
}
