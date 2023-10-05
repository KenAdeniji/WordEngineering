<%@ WebService Language="C#" Class="ProperNamesWebService" %>

using System;
using System.Data;
using System.Numerics;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;

using Newtonsoft.Json;

using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessCode;
using InformationInTransit.UserInterface;

///<summary>
///	2022-07-17T23:22:00 Created.
/// 2022-07-17	https://stackoverflow.com/questions/10394680/how-to-create-dynamic-datatable
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class ProperNamesWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		List<string>	words
	)
    {
		StringBuilder sb;
		
		DataTable resultTable = new DataTable();
		
		resultTable.Columns.Add("BibleWord", typeof(string));
		resultTable.Columns.Add("SoundexWord", typeof(string));
		
		DataRow resultRow;
		
		DataTable soundexTable;
		
		foreach(String word in words)
		{
			DataTable existsTable = (DataTable) DataCommand.DatabaseCommand
			(
				String.Format
				( 
					"SELECT BibleWord FROM Bible..Exact WHERE BibleWord = '{0}'",
					word
				),
				CommandType.Text,
				DataCommand.ResultType.DataTable
			);
			if ( existsTable.Rows.Count == 0 )
			{
				soundexTable = (DataTable) DataCommand.DatabaseCommand
				(
					String.Format
					( 
						"SELECT BibleWord FROM Bible..Exact WHERE SOUNDEX(BibleWord) = SOUNDEX('{0}')",
						word
					),
					CommandType.Text,
					DataCommand.ResultType.DataTable
				);
				sb = new StringBuilder();
				foreach(DataRow dataRow in soundexTable.Rows)
				{
					if (sb.Length > 0)
					{
						sb.Append(", ");
					}
					sb.Append((String)dataRow["BibleWord"]);
				}
				
				resultRow = resultTable.NewRow();
				resultRow["BibleWord"] = word;
				resultRow["SoundexWord"] = sb.ToString();
				resultTable.Rows.Add(resultRow);
			}
		}

		resultTable.AcceptChanges();
		string json = JsonConvert.SerializeObject(resultTable, Formatting.Indented);
		return json;
    }

   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String QueryEarlier
	(
		List<string>	words
	)
    {
		DataTable resultSet = (DataTable) DataCommand.DatabaseCommand
		(
			String.Format( QueryStatement, string.Join(", ", words) ),
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(resultSet, Formatting.Indented);
		return json;
    }
	
	public const string QueryStatement = @"
SELECT
	BibleExact.BibleWord,
	SoundAlike = STUFF((
        SELECT ',' + SubQuery.BibleWord
        FROM Bible..Exact AS SubQuery
        WHERE SOUNDEX(BibleExact.BibleWord) = SOUNDEX(SubQuery.BibleWord)
		FOR XML PATH('')),1,1,'')
FROM
	Bible..Exact AS BibleExact
WHERE
	1 = 1 and
	BibleWord NOT IN ( '{0}' )
GROUP BY
	BibleWord
ORDER BY
	BibleWord	
";
	
}

