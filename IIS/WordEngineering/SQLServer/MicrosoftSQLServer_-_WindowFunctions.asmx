<%@ WebService Language="C#" Class="MicrosoftSQLServerWindowFunctionsWebService" %>

using System;
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

///<summary>
///	2024-12-08T23:31:00	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class MicrosoftSQLServerWindowFunctionsWebService : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String 	selectQueryStatement
	)
    {
		DataSet resultSet = (DataSet) DataCommand.DatabaseCommand
		(
			selectQueryStatement,
			System.Data.CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		string json = JsonConvert.SerializeObject(resultSet, Formatting.Indented);
		return json;
	}	
}