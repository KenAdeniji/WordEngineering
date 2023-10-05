<%@ WebService Language="C#" Class="WillYouFindAManSuitableAsYourFutureWebService" %>
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
using System.Text;
using Newtonsoft.Json;
using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;
///<summary>
///	2021-06-01T13:38:00 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WillYouFindAManSuitableAsYourFutureWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query(String word)
    {
		DataTable dataTable = (DataTable) DataCommand.DatabaseCommand
		(
			String.Format(SQLStatement, word),
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		return json;
    }
	public const string SQLStatement = 
	@"
		SELECT Dated, Minor AS WordScriptureReference, Actor AS ActorBibleWord, ScriptureReference, URI, Commentary
		FROM WordEngineering..ActToGod
		WHERE Major LIKE '%Unified Modeling Language (UML)%' AND
			(Minor LIKE '%{0}%' OR Actor LIKE '%{0}%' OR ScriptureReference LIKE '%{0}%' OR Commentary LIKE '%{0}%' OR URI LIKE '%{0}%')
		ORDER BY Dated DESC	
	";	
}
