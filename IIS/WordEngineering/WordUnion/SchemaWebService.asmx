<%@ WebService Language="C#" Class="SchemaWebService" %>
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

///<summary>
///	2016-02-07	Created.	SchemaWebService.asmx
///	2016-02-07	http://www.techrepublic.com/article/understanding-sql-servers-sysobjects-table/
///	2017-09-01	"EXEC WordEngineering..usp_ProtectingAgainstSqlInjection " + tableName
///	2017-09-02	UNION SELECT TABLE_NAME FROM WordEngineering.INFORMATION_SCHEMA.VIEWS
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class SchemaWebService : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }
	
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Information_Schema_Tables()
    {
		DataTable dataTable = (DataTable)DataCommand.DatabaseCommand
		(
			"SELECT TABLE_NAME FROM WordEngineering.INFORMATION_SCHEMA.TABLES UNION SELECT TABLE_NAME FROM WordEngineering.INFORMATION_SCHEMA.VIEWS ORDER BY TABLE_NAME",
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		return json;
	}
	
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Information_Schema_Table_Select(string tableName)
    {
		DataSet dataSet = (DataSet)DataCommand.DatabaseCommand
		(
			"EXEC WordEngineering..usp_ProtectingAgainstSqlInjection " + tableName,
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		dataSet.Tables[0].TableName = tableName;
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}
}
