<%@ WebService Language="C#" Class="IAmNotForgotten" %>

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
using InformationInTransit.ProcessLogic;

///<summary>
///	2017-04-17	Created.	IAmNotForgotten.asmx
///	2017-04-18	http://stackoverflow.com/questions/938259/how-to-display-user-databases-only-in-sqlserver
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class IAmNotForgotten : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }

    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String SysColumns
	(
		string database_name,
		string table_name
	)
    {
		DataSet dataSet = null;
		dataSet = (DataSet)DataCommand.DatabaseCommand
		(
			String.Format
			(
				SQLCommandColumnFormat,
				database_name,
				table_name
			),	
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}

    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String SysDatabases()
    {
		DataSet dataSet = null;
		dataSet = (DataSet)DataCommand.DatabaseCommand
		(
			"select Name from sys.sysdatabases where dbid>4 and [name] not like '$' ORDER BY Name",
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}
	
	
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String SysIndexes
	(
		string database_name,
		string table_name
	)
    {
		DataSet dataSet = null;
		
		String strSQL = String.Format(SQLCommandIndexFormat, database_name, table_name);
		
		dataSet = (DataSet)DataCommand.DatabaseCommand
		(
	        strSQL,
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
	
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}	
	
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String SysObjects
	(
		string database_name
	)
    {
		DataSet dataSet = null;
		dataSet = (DataSet)DataCommand.DatabaseCommand
		(
			String.Format
			(
				SQLCommandObjectFormat,
				database_name
			),	
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}	
	
	
	public const string SQLCommandColumnFormat = 
		@"SELECT ORDINAL_POSITION, COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, IS_NULLABLE, COLUMN_DEFAULT, 
		columnproperty(object_id('{1}'),COLUMN_NAME,'IsIdentity') AS IsIdentity
		FROM {0}.INFORMATION_SCHEMA.COLUMNS
		WHERE table_name = '{1}'
		ORDER BY ORDINAL_POSITION";	
	
	public const string SQLCommandIndexFormat = @"							
		SELECT IndexTable.name, IndexTable.type_desc, IndexTable.is_unique, IndexTable.is_primary_key, IndexTable.is_unique_constraint
		FROM {0}.sys.indexes IndexTable
		inner join {0}.sys.objects ObjectTable on IndexTable.object_id = ObjectTable.object_id
		where ObjectTable.[name] = '{1}'
		ORDER BY IndexTable.Name
		";	

	public const string SQLCommandObjectFormat = 
		@"SELECT Name FROM {0}..SysObjects WHERE sysobjects.xtype = 'U' OR sysobjects.xtype = 'V' ORDER BY Name"; 		
}
