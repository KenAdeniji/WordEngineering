<%@ WebService Language="C#" Class="HoweverOurProgressArePersonalWebService" %>

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
///	2020-08-13 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class HoweverOurProgressArePersonalWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String 	word
	)	
    {
		DataTable dataTable = (DataTable) DataCommand.DatabaseCommand
		(
			String.Format
			(
				QueryFormat,
				word
			),
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		return json;
    }
	
	public const string QueryFormat = 
	@"
		SELECT Actor, Minor AS Question, Commentary, ScriptureReference
		FROM WordEngineering..ActToGod
		WHERE 
			Major = 'However, our progress, are personal.' AND
		(	
				Actor LIKE '%{0}%'
			OR	Minor LIKE '%{0}%'	
			OR	Commentary LIKE '%{0}%'	
		)	
		ORDER BY Actor, Minor, Commentary
	";
}
