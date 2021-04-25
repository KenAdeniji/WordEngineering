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
///	providerName=MySql.Data.MySqlClient;Data Source=mydb;User Id=myUsername;Password=myPassword;
///</summary>
public class Isaiah35v3_7
{
	public static void Main(string[] argv)
	{
		string json = SelectDatabases(argv[0]);
		System.Console.WriteLine(json);
	}
	
	public static String SelectDatabases
	(
		string connectionString
	)
    {
		DataTable dataTable = (DataTable) DataCommand.DatabaseCommand
		(
			QueryFormatSelectDatabases,
			connectionString,			
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);

		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);

		return json;
    }
	
	public const string QueryFormatSelectDatabases = "SELECT * FROM Bible.Key_English;"; // "SHOW DATABASES;";
}
