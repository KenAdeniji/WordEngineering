<%@ WebService Language="C#" Class="Isaiah35v3_7WebService" %>

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

using System.Data.SqlClient;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;

using MySql.Data.MySqlClient;

///<summary>
///	2021-04-24T17:49:00 Created.
///	providerName=MySql.Data.MySqlClient;Data Source=adriel;User Id=kadeniji;Password=NorikoYoshida19990118;
/// Provider=SQLOLEDB;providerName=MySql.Data.MySqlClient;Data Source=adriel;User Id=kadeniji;Password=NorikoYoshida19990118;
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class Isaiah35v3_7WebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String SelectDatabases
	(
		string connectionString
	)
    {
		String dataTable = (String) DataCommand.DatabaseCommand
		(
			QueryFormatSelectDatabases,
			connectionString,			
			CommandType.Text,
			DataCommand.ResultType.Scalar
		);

		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);

		return json;
    }
	
	public const string QueryFormatSelectDatabases = "select current_user();";
}
