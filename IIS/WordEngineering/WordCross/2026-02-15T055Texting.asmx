<%@ WebService Language="C#" Class="TextingWebService" %>

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
using System.Web.Script.Serialization;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2026-02-15T05:55:00
///	2026-02-14	http://sfbay.craigslist.org/eby/cpg/d/walnut-creek-walnut-creek-petition/7915226685.html
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class TextingWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query(string word)
    {
		DataTable dataTable = (DataTable) DataCommand.DatabaseCommand
		(
			String.Format
			(
				"EXEC usp_20260215T0555Texting @word = '{0}'",
				word
			),	
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		return json;
    }
}
