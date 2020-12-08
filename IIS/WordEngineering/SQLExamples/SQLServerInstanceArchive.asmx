<%@ WebService Language="C#" Class="SQLServerInstance" %>

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
public class SQLServerInstance : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query()
    {
		DataSet dataSet = null;
		dataSet = (DataSet)DataCommand.DatabaseCommand
		(
			SQLStatement,
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}
	
	public const string SQLStatement =
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

SELECT * FROM dbo.sysdatabases;

SELECT * FROM sys.tables ORDER BY name;

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

--SELECT * FROM sys.dm_db_persisted_sku_features;
		";
}
