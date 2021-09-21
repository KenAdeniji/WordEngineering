<%@ WebService Language="C#" Class="BibleWithoutHandsWebService" %>

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
using System.Data.Odbc;
using System.Data.SqlClient;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2021-09-20T19:36:00 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class BibleWithoutHandsWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String word
	)
    {
		DataTable resultSet = (DataTable) DataCommand.DatabaseCommand
		(
			String.Format(QueryStatement, word),
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(resultSet, Formatting.Indented);
		return json;
    }
	
	public const string QueryStatement = @"
SELECT *
FROM WordEngineering..BibleWithoutHands
WHERE 
	ScriptureReference LIKE '%{0}%'
	OR What LIKE '%{0}%'
	OR [When] LIKE '%{0}%'
	OR [Where] LIKE '%{0}%'
	OR Who LIKE '%{0}%'
	OR Commentary LIKE '%{0}%'
	OR Keyword LIKE '%{0}%'	
	OR URI LIKE '%{0}%'
ORDER BY BibleWithoutHandsID DESC
";	
}
