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
	///	2024-02-02	Now, who were with you, when you were with me?
	///	2024-02-02T11:45:00	Created.
	///		http://stackoverflow.com/questions/8257319/retrieving-table-schema-information-using-c-sharp
	///</summary>
	public partial class NowWhoWereWithYouWhenYouWereWithMe
	{
        public static DataTable QuerySchema
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
			return tableOrViewSchema;
        }
		
		public static StringBuilder WhereClause
		(
			DataTable tableOrViewSchema,
			string	word
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
						" {0} LIKE '%{1}%' ",
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
	}
}
