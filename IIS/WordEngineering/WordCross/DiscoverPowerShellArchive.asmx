<%@ WebService Language="C#" Class="DiscoverPowerShellWebService" %>

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
///	2021-11-08T12:32:00 Created. https://docs.microsoft.com/en-us/powershell/scripting/learn/tutorials/01-discover-powershell?view=powershell-7.2#powershell-cmdlets
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class DiscoverPowerShellWebService : System.Web.Services.WebService
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
	SELECT Dated, Minor, Actor, ScriptureReference, HisWordID, Commentary, URI, ContactID
	FROM WordEngineering..ActToGod
	WHERE 
		Major = 'PowerShell' AND
		(
			Minor LIKE '%{0}%' OR
			Actor LIKE '%{0}%' OR
			ScriptureReference LIKE '%{0}%' OR
			Commentary LIKE '%{0}%' OR
			URI LIKE '%{0}%'
		)	
	ORDER BY ActToGodID
	";	
}
