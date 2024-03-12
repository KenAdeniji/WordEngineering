<%@ WebService Language="C#" Class="WordInterpretationWebService" %>

using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;

using System.Data.SqlClient;
using System.Text;	

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessCode;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

using Newtonsoft.Json;

///<summary>
///	2024-03-11T20:07:00...2024-03-11T21:04:00 Created.
///	2024-03-07 16:21:37.170 HisWordID 160844. ContactID 5080 Dulhan Grocery.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WordInterpretationWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string Query
	(
		string	word
	)
    {
		StringBuilder whereOrClause = new StringBuilder();

		string[] words = word.Split
		(
			BibleWordHelper.SplitSeparator, 
			StringSplitOptions.RemoveEmptyEntries
		);

		foreach(String wordCurrent in words)
		{
			whereOrClause.AppendFormat
			(
				WordOrFormat,
				wordCurrent.Trim()
			);
		}
		
		String queryStatement = String.Format
		(
			QueryFormat,
			whereOrClause.ToString()
		);
		
		DataTable resultTable = (DataTable) DataCommand.DatabaseCommand
		(
			queryStatement.ToString(),
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(resultTable, Formatting.Indented);
		return json;
    }
	
	const String QueryFormat = @"
		SELECT 		Word, Commentary
		FROM 		WordEngineering..WordInterpretation
		WHERE		1 <> 1 {0}
		ORDER BY 	Word, Commentary
	";
	
	const String WordOrFormat = @" OR ( Word LIKE '%{0}' OR Commentary LIKE '%{0}' ) ";
}
