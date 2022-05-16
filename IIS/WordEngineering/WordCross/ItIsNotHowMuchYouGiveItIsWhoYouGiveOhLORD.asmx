<%@ WebService Language="C#" Class="ItIsNotHowMuchYouGiveItIsWhoYouGiveOhLORDWebService" %>

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
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2022-05-15T12:52:00 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class ItIsNotHowMuchYouGiveItIsWhoYouGiveOhLORDWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String	bibleVersion,
		String	logic,
		String 	word
	)
    {
		StringBuilder sbWord;
		StringBuilder sbWhereClause;
		
		if (String.IsNullOrEmpty(logic))
		{
			logic = " AND, OR ";
		}	
		
		StringBuilder sqlStatement = new StringBuilder();
		
		String[] logics = logic.Split(',');
		char[] delimiterChars = { ',', ';' };
		String[] words = word.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);
		
		foreach(String logicCurrent in logics)
		{
			sbWord = new StringBuilder();
			sbWhereClause = new StringBuilder();
			
			foreach(String wordCurrent in words)
			{
				if (sbWord.Length > 0)
				{
					sbWord.AppendFormat
					(
						" {0} ",
						logicCurrent
					);
				}
				sbWord.Append(wordCurrent);
				
				if (sbWhereClause.Length == 0)
				{
					sbWhereClause.Append(" WHERE ");
				}
				else
				{
					sbWhereClause.Append(' ' + logicCurrent + ' ');
				}
				
				sbWhereClause.AppendFormat
				(
					" {0} LIKE '%{1}%' ",
					bibleVersion,
					wordCurrent
				);

				if (sqlStatement.Length > 0)
				{
					sqlStatement.Append(" UNION " );
				}

				sqlStatement.AppendFormat(QueryStatement, sbWord, sbWhereClause);
			}
		}
		
		sqlStatement.Append(" ORDER BY Word ");
		
		DataTable resultSet = (DataTable) DataCommand.DatabaseCommand
		(
			sqlStatement.ToString(),
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(resultSet, Formatting.Indented);
		return json;
    }
	
	public const String QueryStatement =
	@"
		SELECT
			'{0}' AS Word,		
			COUNT(*) AS Occurrences
		FROM
			Bible..Scripture_View
		{1}
		HAVING COUNT(*) > 0 
	";
}
