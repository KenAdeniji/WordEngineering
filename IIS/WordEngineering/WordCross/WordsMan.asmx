<%@ WebService Language="C#" Class="WordsManWebService" %>

using System;
using System.Data;
using System.Numerics;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;

using System.Data;
using System.Data.SqlClient;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessCode;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

using Newtonsoft.Json;

///<summary>
///	2023-11-28T16:58:00...2023-11-28T19:33:00 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WordsManWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string Query
	(
	)
    {
		DataTable resultTable = (DataTable) DataCommand.DatabaseCommand
		(
			QueryStatement,
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		object[] fullNames = DataTableHelper.ConvertDataTableToArray
		(
			resultTable,
			"FullName"
		);
		
		string json = JsonConvert.SerializeObject(fullNames, Formatting.Indented);
		return json;
    }

   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String QueryByName
	(
		string	bibleWord
	)
    {
		DataTable resultTable = (DataTable) DataCommand.DatabaseCommand
		(
			String.Format
			( 
				QueryByNameStatement,
				bibleWord
			),	
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(resultTable, Formatting.Indented);
		return json;
    }
	
	public const string QueryStatement = 
	@"
		SELECT 		FullName
		FROM 		WordEngineering.dbo.WordsManName()
		ORDER BY	FullName
	";

	public const string QueryByNameStatement = 
	@"
		SELECT TOP 1 FullTable.*
		FROM 	WordEngineering.dbo.WordsManName() CriteriaTable
		INNER JOIN WordEngineering.dbo.WordsMan FullTable 
			ON CriteriaTable.WordsManID = FullTable.WordsManID
		WHERE	CriteriaTable.FullName = '{0}'
	";
}
