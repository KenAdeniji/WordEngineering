<%@ WebService Language="C#" Class="DBCCDatabaseConsoleCommandBalindaWindowWebService" %>

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
using InformationInTransit.ProcessCode;
using InformationInTransit.ProcessLogic;

///<summary>
///	2018-05-10	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class DBCCDatabaseConsoleCommandBalindaWindowWebService : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }

	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Command(string command)
    {
		int index = Array.IndexOf
		(
			InformationInTransit.ProcessCode.DBCCDatabaseConsoleCommandBalindaWindow.DBCCDatabaseConsoleCommand,
			command
		);
		if (index < 0)
		{
			return "";
		}	
 		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			command,
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);

		string json = JsonConvert.SerializeObject
		(
			dataSet,
			Formatting.Indented
		);
		
		return json;
	}
	
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query()
    {
		string json = JsonConvert.SerializeObject
		(
			InformationInTransit.ProcessCode.DBCCDatabaseConsoleCommandBalindaWindow.DBCCDatabaseConsoleCommand,
			Formatting.Indented
		);
		return json;
	}
}
