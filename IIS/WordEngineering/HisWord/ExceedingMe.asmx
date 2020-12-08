<%@ WebService Language="C#" Class="ExceedingMeWebService" %>

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
using Newtonsoft.Json.Linq;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessCode;
using InformationInTransit.UserInterface;

/*
2018-07-21	https://stackoverflow.com/questions/873393/sql-server-query-to-find-all-current-database-names
2019-09-29T22:34:00	https://stackoverflow.com/questions/4535840/deserialize-json-object-into-dynamic-object-using-json-net
2019-09-29T23:39:00 https://weblog.west-wind.com/posts/2012/aug/30/using-jsonnet-for-dynamic-json-parsing
*/
///<summary>
///	2019-09-26 Idea conceived. 2019-09-27 Implemented.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class ExceedingMeWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String QueryColumnNames
	(
		String	serverName,
		String	databaseName,
		String	schemaName,
		String 	tableName
	)
    {
		string sqlStatement = String.Format
		(
			SQLStatementColumnNames,
			databaseName,
			tableName
		);
		
		DataSet resultSet = (DataSet) Repository.DatabaseCommand
		(
			sqlStatement,
			CommandType.Text,
			Repository.ResultSet.DataSet
		);
		
		string json = JsonConvert.SerializeObject(resultSet, Formatting.Indented);
		return json;
    }

   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	//2019-09-26 Idea conceived. 2019-09-27 Implemented.
	public String QuerySchemaNames
	(
		String serverName,
		String databaseName
	)
    {
		if (String.IsNullOrEmpty(databaseName))
		{
			databaseName = "master";
		}
		
		DataSet resultSet = (DataSet) Repository.DatabaseCommand
		(
			String.Format
			(
				SQLStatementSchemaNames, 
				serverName,
				databaseName
			),
			CommandType.Text,
			Repository.ResultSet.DataSet
		);
		
		string json = JsonConvert.SerializeObject(resultSet, Formatting.Indented);
		return json;
    }
   	
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String QuerySQL
	(
		String 	serverName,
		String	databaseName,
		String	schemaName,
		String	tableName,
		String 	jsonInput
	)
    {
		//dynamic jsonObject = JsonConvert.DeserializeObject(jsonInput);
	
		dynamic jsonObject = JObject.Parse(jsonInput);

		string whereClause = "";
		
		foreach (var property in jsonObject)
		{
			if (String.IsNullOrEmpty(whereClause) == false)
			{
				whereClause += " AND ";
			}
			whereClause += property.Name + " LIKE '%" + property.Value + "%'";
		}

		if (String.IsNullOrEmpty(databaseName))
		{
			databaseName = "master";
		}
		if (String.IsNullOrEmpty(schemaName))
		{
			schemaName = "sys";
		}
		if (whereClause != "")
		{
			whereClause = " WHERE " + whereClause;
		}

		string sqlStatement = "SELECT * FROM " +
			String.Format(SQLSource, databaseName, schemaName, tableName) + whereClause;
		DataTable resultTable = (DataTable) Repository.DatabaseCommand
		(
			sqlStatement,
			CommandType.Text,
			Repository.ResultSet.DataTable
		);
		
		string json = JsonConvert.SerializeObject(resultTable, Formatting.Indented);
		return json;
    }
	
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String QueryTableNames
	(
		String 	serverName,
		String	databaseName,
		String	schemaName	
	)
    {
		if (String.IsNullOrEmpty(databaseName))
		{
			databaseName = "master";
		}
		if (String.IsNullOrEmpty(schemaName))
		{
			schemaName = "sys";
		}
		string sqlStatement = String.Format
		(
			SQLStatementTableNames,
			databaseName,
			schemaName
		);
		DataSet resultSet = (DataSet) Repository.DatabaseCommand
		(
			sqlStatement,
			CommandType.Text,
			Repository.ResultSet.DataSet
		);
		
		string json = JsonConvert.SerializeObject(resultSet, Formatting.Indented);
		return json;
    }

	public const string SQLSource = "{0}.{1}.{2}";
	//public const string SQLStatementColumnNames = @"SELECT TABLE_NAME, COLUMN_NAME FROM {0}.INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME IN ({1}) ORDER BY TABLE_NAME, COLUMN_NAME";	
	public const string SQLStatementColumnNames = @"
select
	sys.columns.name as name
from sys.columns join sys.tables on sys.tables.object_id = sys.columns.object_id
where sys.tables.name = '{1}'
order by sys.columns.column_id
	";
	public const string SQLStatementSchemaNames = @"SELECT SCHEMA_NAME FROM {1}.INFORMATION_SCHEMA.SCHEMATA ORDER BY SCHEMA_NAME";
	public const string SQLStatementTableNames = "SELECT name FROM {0}.{1}.Tables ORDER BY name";
}
