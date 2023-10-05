<%@ WebService Language="C#" Class="GetSchemaWebService" %>

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
using System.Diagnostics;
using System.Globalization;
using System.Text;

using Newtonsoft.Json;

///<summary>
/// 2023-03-06T11:18:00	Created.	http://code-magazine.com/Article/2303031/Create-Your-Own-SQL-Compare-Utility-Using-GetSchema
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class GetSchemaWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string Query
	(
		string databaseConnectionString,
		string collectionName
	)
	{
		if (String.IsNullOrEmpty(databaseConnectionString))
		{
			databaseConnectionString = DatabaseConnectionString;
		}
		SqlConnection sqlConnection = new SqlConnection(databaseConnectionString);
		sqlConnection.Open();
		DataTable dataTable = sqlConnection.GetSchema(collectionName);
		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		return json;
	}
	
	public const string DatabaseConnectionString = "Data Source=(local);Initial Catalog=Master;Persist Security Info=True;Integrated Security=SSPI;Connect Timeout=60;Application Name=Master;MultipleActiveResultSets=True;";
}
