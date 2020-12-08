<%@ WebService Language="C#" Class="OpenBucketWebService" %>

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

using Microsoft.SqlServer.Server;
using Microsoft.SqlServer.Management.Sdk.Sfc;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;

using System.Linq;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessCode;
using InformationInTransit.UserInterface;

///<summary>
///	2018-09-10 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class OpenBucketWebService : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			"Select Distinct Country FROM WordEngineering..ToRememberHisConversationAsMine ORDER BY Country ASC",
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);

		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
    }

   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Authentication
	(
		String	serverName,
		String	authentication,
		String	login,
		String 	password
	)
    {
        //string connectionString = null;
/*
        SqlConnection sqlConnection = new SqlConnection(ConnectionString);
        sqlConnection.Open();
		
		string json = JsonConvert.SerializeObject("'resultSet:'resultSet'", Formatting.Indented);
		return json;
*/		
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			"Select Distinct Country FROM WordEngineering..ToRememberHisConversationAsMine ORDER BY Country ASC",
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);

		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
    }
	
	public const string ConnectionString = "Data Source=(local);Initial Catalog=Master;Persist Security Info=True;Integrated Security=SSPI;Connect Timeout=36000;";
}
