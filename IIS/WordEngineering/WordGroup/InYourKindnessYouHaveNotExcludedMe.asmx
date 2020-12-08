<%@ WebService Language="C#" Class="InYourKindnessYouHaveNotExcludedMeWebService" %>

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
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

using Newtonsoft.Json;

///<summary>
///	2020-12-03 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class InYourKindnessYouHaveNotExcludedMeWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
	)
    {
		DataTable result = (DataTable) DataCommand.DatabaseCommand
		(
			SelectStatement,
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		string json = JsonConvert.SerializeObject(result, Formatting.Indented);
		return json;
    }
	
	public const string SelectStatement = @"
		SELECT Minor AS Keyword, Actor, ScriptureReference, Commentary AS Day
		FROM WordEngineering..ActToGod
		WHERE Major = 'In Your kindness; You have not excluded me.'
		ORDER BY Minor
";
}
