<%@ WebService Language="C#" Class="TheResponsibilityPlacedOnReasoningWebService" %>

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
using InformationInTransit.ProcessCode;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2020-09-30 	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class TheResponsibilityPlacedOnReasoningWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String	bibleWord
	)
    {
		DataTable dataTable = (DataTable) DataCommand.DatabaseCommand
		(
			String.Format
			(
				QueryFormat,
				bibleWord
			),	
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		return json;
    }
	
	public const string QueryFormat = 
	@"
		SELECT
			Title, Actor, Location, Duration, Law, ScriptureReference, Commentary, Uri
		FROM
			WordEngineering..TheResponsibilityPlacedOnReasoning
		WHERE
			Title LIKE '%{0}%'
		OR	Actor LIKE '%{0}%'
		OR	Location LIKE '%{0}%'
		OR	Duration LIKE '%{0}%'
		OR	Law LIKE '%{0}%'
		OR	ScriptureReference LIKE '%{0}%'
		OR	Commentary LIKE '%{0}%'
		ORDER BY 
			Title

	";
}
