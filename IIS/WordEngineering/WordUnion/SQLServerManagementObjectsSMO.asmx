<%@ WebService Language="C#" Class="SQLServerManagementObjectsSMOWebService" %>

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

/*
2018-07-21	https://stackoverflow.com/questions/873393/sql-server-query-to-find-all-current-database-names
*/
///<summary>
///	2018-07-21 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class SQLServerManagementObjectsSMOWebService : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }

   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String DataDefinitionLanguageDDL
	(
		String serverName,
		String databaseName
	)
    {
		String sqlScript = "";
		try
		{
			sqlScript = SQLServerManagementObjectsSMOHelper.DataDefinitionLanguageDDL
			(
				serverName,
				databaseName
			);	
		}
		catch (SmoException ex)
		{
			sqlScript = "SmoException: " + ex.Message;
		}
		catch (SqlServerManagementException ex)
		{
			sqlScript = "SqlServerManagementException: " + ex.Message;
		}
/*
		catch (FailedOperationException ex)
		{
			sqlScript = "FailedOperationException: " + ex.Message;
		}
*/
		catch (NullReferenceException ex)
		{
			sqlScript = "NullReferenceException: " + ex.Message;
		}
		catch (Exception ex)
		{
			sqlScript = "Exception: " + ex.Message;
		}
		string json = JsonConvert.SerializeObject(sqlScript, Formatting.Indented);
		return json;
    }

   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String QueryColumnNames
	(
		String	serverName,
		String	databaseName,
		String 	tableNames
	)
    {
		var tableNamesSplit = tableNames.Split(',');
		string tableNamesJoined = String.Join(", ", from l in tableNamesSplit select String.Format("'{0}'", l));

		string sqlStatement = String.Format
		(
			SQLStatementColumnNames,
			databaseName,
			tableNamesJoined
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
	public String QueryDatabaseNames
	(
		String serverName
	)
    {
		DataSet resultSet = (DataSet) Repository.DatabaseCommand
		(
			"SELECT name FROM sys.sysdatabases ORDER BY name",
			CommandType.Text,
			Repository.ResultSet.DataSet
		);
		
		string json = JsonConvert.SerializeObject(resultSet, Formatting.Indented);
		return json;
    }

   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String QueryTableNames
	(
		String serverName,
		String databaseName
	)
    {
		string sqlStatement = String.Format
		(
			SQLStatementTableNames,
			databaseName
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

	public const string SQLStatementColumnNames = @"SELECT TABLE_NAME, COLUMN_NAME FROM {0}.INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME IN ({1}) ORDER BY TABLE_NAME, COLUMN_NAME";	
	public const string SQLStatementTableNames = "SELECT name FROM {0}.sys.Tables ORDER BY name";
}
