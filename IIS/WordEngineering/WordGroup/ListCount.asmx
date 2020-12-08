<%@ WebService Language="C#" Class="ListCountWebService" %>

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
///	2020-09-08 	Created.	https://www.youtube.com/watch?v=0Dj6C_2tqaY
///	2020-09-08	https://stackoverflow.com/questions/14818596/sql-comma-separated-string-total-count
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class ListCountWebService : System.Web.Services.WebService
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
	
	public const string SelectQuery = @"
		SELECT
			Minor,
			Actor,
			Commentary,
			ScriptureReference,
			LEN(Commentary) - LEN(replace(Commentary, ',', '')) + 1 AS Generations
		FROM WordEngineering..ActToGod
		WHERE Major LIKE '%List Count%'
		ORDER BY Minor
	";
}
