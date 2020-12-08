<%@ WebService Language="C#" Class="AndThePriestSaidAreOneOnlyForMeWebService" %>

using System;
using System.Data;
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
///	2020-08-25 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class AndThePriestSaidAreOneOnlyForMeWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
	)	
    {
		DataTable dataTable = (DataTable) DataCommand.DatabaseCommand
		(
			QueryFormat,
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		return json;
    }
	
	public const string QueryFormat = 
	@"
		SELECT Title, Commentary, ScriptureReference, Hebrew,
		WordEngineering.dbo.udf_AndThePriestSaidAreOneOnlyForMe(Hebrew) AS AlphabetSequenceIndex,
		WordEngineering.dbo.udf_AlphabetSequenceIndexScriptureReference
		(
			WordEngineering.dbo.udf_AndThePriestSaidAreOneOnlyForMe(Hebrew)
		)	AS AlphabetSequenceIndexScriptureReference
		FROM WordEngineering..GodTitle
		WHERE Hebrew IS NOT NULL
		ORDER BY Title
	";
}
