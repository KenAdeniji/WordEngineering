<%@ WebService Language="C#" Class="HowLifeBoundsMeWebService" %>

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

using System.Linq;
using System.Xml.Linq;

using System.Collections.Specialized;

using System.Text.RegularExpressions;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;

///<summary>
///	2024-03-04T17:10:00	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class HowLifeBoundsMeWebService : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query(String passageTitle)
    {
		DataTable dataTable = (DataTable) DataCommand.DatabaseCommand
		(
			String.Format
			(
				QueryStatement,
				passageTitle == "" 
				? "" 
				: String.Format
				(
					" WHERE Title LIKE '%{0}%' ",
					passageTitle
				)	
			),	
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		return json;
	}
	
	public const string QueryStatement = 
	@"
		SELECT 	*
		FROM 	WordEngineering..SacredText
		{0}
		ORDER BY Title ASC
	";
}
