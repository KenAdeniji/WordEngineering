<%@ WebService Language="C#" Class="TheFansMayThinkYouAreFromADifferentCompanyYouAreFromADifferentKindWebService" %>

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

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2020-10-07 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class TheFansMayThinkYouAreFromADifferentCompanyYouAreFromADifferentKindWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query()
    {
		DataTable result = (DataTable) DataCommand.DatabaseCommand
		(
			SelectQuery,
			System.Data.CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(result, Formatting.Indented);
		return json;
    }
	
	public const String SelectQuery = @"
SELECT
	Minor
	,WordEngineering.dbo.udf_splitSelectRandom(ScriptureReference) AS ScriptureReference
FROM
	WordEngineering..ActToGod
WHERE
	Major = 'Prayer'
AND	ScriptureReference IS NOT NULL
ORDER BY
	Minor
	";
}
