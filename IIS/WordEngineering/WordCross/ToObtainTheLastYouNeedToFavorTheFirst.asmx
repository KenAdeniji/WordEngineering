<%@ WebService Language="C#" Class="ToObtainTheLastYouNeedToFavorTheFirstWebService" %>

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

using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2021-12-04T12:28:00 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class ToObtainTheLastYouNeedToFavorTheFirstWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String bibleWord
	)
    {
		DataTable resultSet = (DataTable) DataCommand.DatabaseCommand
		(
			String.Format(QueryStatement, bibleWord),
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(resultSet, Formatting.Indented);
		return json;
    }
	
	public const string QueryStatement = @"
SELECT Dated, Title, ProphecyScriptureReference, FulfillmentScriptureReference, Keyword, Variation, Commentary, URI
FROM WordEngineering..ToObtainTheLastYouNeedToFavorTheFirst
WHERE
	Title LIKE '%{0}%' 
OR	ProphecyScriptureReference LIKE '%{0}%' 
OR	FulfillmentScriptureReference LIKE '%{0}%' 
OR	Keyword LIKE '%{0}%' 
OR	Variation LIKE '%{0}%' 
OR	Commentary LIKE '%{0}%' 
OR	URI LIKE '%{0}%' 
ORDER BY Dated
	";
}
