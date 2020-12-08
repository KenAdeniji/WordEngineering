<%@ WebService Language="C#" Class="SQLServerInfo" %>

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
///	2020-06-13	Created.	books.goalkicker.com/MicrosoftSQLServerBook
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class SQLServerInfo : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String DatabaseQuery()
    {
		DataTable dataTable = null;
		dataTable = (DataTable)DataCommand.DatabaseCommand
		(
			//"EXEC sp_MSForEachDB 'SELECT ''?'' AS DatabaseName'",
			"SELECT name AS text FROM sys.databases ORDER BY name",
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		return json;
	}

	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String ObjectQuery(String databaseName)
    {
		DataSet dataSet = null;
		dataSet = (DataSet)DataCommand.DatabaseCommand
		(
			String.Format(ObjectSQLStatement, databaseName),
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}

	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String ServerQuery()
    {
		DataSet dataSet = null;
		dataSet = (DataSet)DataCommand.DatabaseCommand
		(
			ServerSQLStatement,
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}

	public const string ObjectSQLStatement =
		@"
			USE {0};
			SELECT
			s.name AS [schema],
			t.object_id AS [table_object_id],
			t.name AS [table_name],
			c.column_id,
			c.name AS [column_name],
			i.name AS [index_name],
			i.type_desc AS [index_type]
			FROM sys.schemas AS s
			INNER JOIN sys.tables AS t
			ON s.schema_id = t.schema_id
			INNER JOIN sys.columns AS c
			ON t.object_id = c.object_id
			LEFT JOIN sys.index_columns AS ic
			ON c.object_id = ic.object_id and c.column_id = ic.column_id
			LEFT JOIN sys.indexes AS i
			ON ic.object_id = i.object_id and ic.index_id = i.index_id
			ORDER BY [schema], [table_name], c.column_id;
		";
		
	public const string ServerSQLStatement =
		@"
SELECT SERVERPROPERTY('MachineName') AS Host,
SERVERPROPERTY('InstanceName') AS Instance,
DB_NAME() AS DatabaseContext,
SERVERPROPERTY('Edition') AS Edition,
SERVERPROPERTY('ProductLevel') AS ProductLevel,
CASE SERVERPROPERTY('IsClustered')
WHEN 1 THEN 'CLUSTERED'
ELSE 'STANDALONE' END AS ServerType,
@@VERSION AS VersionNumber;

SELECT SERVERPROPERTY('ProductVersion') AS ProductVersion,
SERVERPROPERTY('ProductLevel') AS ProductLevel,
SERVERPROPERTY('Edition') AS Edition,
SERVERPROPERTY('EngineEdition') AS EngineEdition;

SELECT DATEDIFF(DAY, login_time, getdate()) UpDays
FROM master..sysprocesses
WHERE spid = 1;

EXEC sp_helpserver;

SELECT d.name AS 'Database',
d.database_id,
SF.fileid,
SF.name AS 'LogicalFileName',
CASE SF.status & 0x100000
WHEN 1048576 THEN 'Percentage'
WHEN 0 THEN 'MB'
END AS 'FileGrowthOption',
Growth AS GrowthUnit,
ROUND(((CAST(Size AS FLOAT)*8)/1024)/1024,2) [SizeGB], -- Convert 8k pages to GB
Maxsize,
filename AS PhysicalFileName
FROM Master.SYS.SYSALTFILES SF
Join Master.SYS.Databases d on sf.fileid = d.database_id
Order by d.name;

		";
}
