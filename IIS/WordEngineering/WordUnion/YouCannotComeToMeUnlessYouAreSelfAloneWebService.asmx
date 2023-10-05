<%@ WebService Language="C#" Class="YouCannotComeToMeUnlessYouAreSelfAloneWebService" %>
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
using InformationInTransit.ProcessLogic;	

///<summary>
///	2016-12-05	Created.	YouCannotComeToMeUnlessYouAreSelfAloneWebService.asmx
///	2016-12-05	http://www.red-gate.com/library/troubleshooting-sql-server-a-guide-for-accidental-dbas
/// 2016-12-05	https://msdn.microsoft.com/en-us/library/yt2fy5zk(v=vs.110).aspx
///	2016-12-05	http://stackoverflow.com/questions/18673822/how-to-search-in-2d-array-by-linq-version2
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class YouCannotComeToMeUnlessYouAreSelfAloneWebService : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }
	
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Menu()
    {
		Dictionary<string, string>.KeyCollection menu = Choices.Keys;
		string json = JsonConvert.SerializeObject(menu, Formatting.Indented);
		return json;
	}
	
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Choice(string choice)
    {
		string query = Choices[choice];
		DataSet dataSet = (DataSet)DataCommand.DatabaseCommand
		(
			query,
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		dataSet.Tables[0].TableName = choice;
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}
	
	public static readonly Dictionary<string, string> Choices = new Dictionary<string, string>();
	
	static YouCannotComeToMeUnlessYouAreSelfAloneWebService()
	{
		Choices.Add	//DBCC SQLPERF('sys.dm_os_wait_stats', clear)
		(
			"sys.dm_os_wait_stats. Returns information about all the waits encountered by threads that executed.",
			"SELECT * FROM sys.dm_os_wait_stats ORDER BY Wait_Type"
		);
		Choices.Add	//This dynamic management view replaces the fn_virtualfilestats function.
		(
			"sys.dm_io_virtual_file_stats. Returns I/O statistics for data and log files.",
			@"SELECT  
	sysdatabases.name AS DatabaseName,
	sysfiles.filename AS FileName,
	dm_io_virtual_file_stats_1.*
FROM
	sys.dm_io_virtual_file_stats(NULL, NULL) AS dm_io_virtual_file_stats_1
	JOIN master..sysdatabases on sysdatabases.dbid = dm_io_virtual_file_stats_1.database_id
	JOIN master..sysfiles on sysfiles.fileid = dm_io_virtual_file_stats_1.file_id
"
		);	
		Choices.Add
		(
			"sys.dm_exec_query_stats. Returns aggregate performance statistics for cached query plans in SQL Server.", // The view contains one row per query statement within the cached plan, and the lifetime of the rows are tied to the plan itself. When a plan is removed from the cache, the corresponding rows are eliminated from this view.",
			@"SELECT query_stats.query_hash AS QueryHash,   
				SUM(query_stats.total_worker_time) / SUM(query_stats.execution_count) AS AverageCPUTime,  
				MIN(query_stats.statement_text) AS StatementText  
			FROM   
				(SELECT QS.*,   
				SUBSTRING(ST.text, (QS.statement_start_offset/2) + 1,  
				((CASE statement_end_offset   
					WHEN -1 THEN DATALENGTH(ST.text)  
					ELSE QS.statement_end_offset END   
						- QS.statement_start_offset)/2) + 1) AS statement_text  
				 FROM sys.dm_exec_query_stats AS QS  
				 CROSS APPLY sys.dm_exec_sql_text(QS.sql_handle) as ST) as query_stats  
			GROUP BY query_stats.query_hash  
			ORDER BY 2 DESC
			"
		);
		Choices.Add
		(
			"Virtual file statistics",
			@"SELECT
	DB_NAME(vfs.database_id)	AS	database_name,
	vfs.database_id,
	vfs.File_ID,
	io_stall_read_ms / NULLIF(num_of_reads, 0) AS avg_read_latency,
	io_stall_write_ms / NULLIF(num_of_writes, 0) AS avg_write_latency,
	io_stall / NULLIF(num_of_reads + num_of_writes, 0) AS avg_total_latency,
	num_of_bytes_read / NULLIF(num_of_reads, 0) AS avg_bytes_per_read,
	num_of_bytes_written / NULLIF(num_of_writes, 0) AS avg_bytes_per_write,
	vfs.io_stall,
	vfs.num_of_reads,
	vfs.num_of_bytes_read,
	vfs.io_stall_read_ms,
	vfs.num_of_writes,
	vfs.num_of_bytes_written,
	vfs.io_stall_write_ms,
	size_on_disk_bytes / 1024 / 1024 AS size_on_disk_mbytes,
	physical_name
FROM
	sys.dm_io_virtual_file_stats(NULL, NULL) AS vfs
	JOIN sys.master_files AS mf ON vfs.database_id = mf.database_id
									AND vfs.FILE_ID = mf.file_id
ORDER BY
	avg_total_latency DESC
			"
		);

		Choices.Add
		(
			"sys.dm_os_performance_counters",
			@"		
DECLARE	@CounterPrefix NVARCHAR(30)
SET	@CounterPrefix =
	CASE 
		WHEN @@SERVICENAME = 'MSSQLSERVER'
			THEN 'SQLSERVER:'
		ELSE
			'MSSQL$' + @@SERVICENAME + ':'
	END;

-- Capture the first counter set
SELECT
	CAST(1 AS INT)	AS	Collection_Instance,
	[OBJECT_NAME],
	Counter_Name,
	instance_name,
	cntr_value,
	cntr_type,
	CURRENT_TIMESTAMP AS Collection_Time
INTO
	#perf_counters_init
FROM
	sys.dm_os_performance_counters
WHERE
	( OBJECT_NAME = @CounterPrefix + 'Access Methods' AND counter_name = 'Full Scans/sec' )
OR	( OBJECT_NAME = @CounterPrefix + 'Access Methods' AND counter_name = 'Index Searches/sec' )
OR	( OBJECT_NAME = @CounterPrefix + 'Buffer Manager' AND counter_name = 'Lazy Writes/sec' )
OR	( OBJECT_NAME = @CounterPrefix + 'Buffer Manager' AND counter_name = 'Page life expectancy' )
OR	( OBJECT_NAME = @CounterPrefix + 'General Statistics' AND counter_name = 'Processes Blocked' )
OR	( OBJECT_NAME = @CounterPrefix + 'General Statistics' AND counter_name = 'User Connections' )
OR	( OBJECT_NAME = @CounterPrefix + 'Locks' AND counter_name = 'Lock Waits/sec' )
OR	( OBJECT_NAME = @CounterPrefix + 'Locks' AND counter_name = 'Lock Wait Time (ms)' )
OR	( OBJECT_NAME = @CounterPrefix + 'SQL Statistics' AND counter_name = 'SQL Re-Compilations/sec' )
OR	( OBJECT_NAME = @CounterPrefix + 'Memory Manager' AND counter_name = 'Memory Grants Pending' )
OR	( OBJECT_NAME = @CounterPrefix + 'SQL Statistics' AND counter_name = 'Batch Requests/sec' )
OR	( OBJECT_NAME = @CounterPrefix + 'SQL Statistics' AND counter_name = 'SQL Compilations/sec' )

-- Wait on second between data collection
WAITFOR DELAY '00:00:01'

-- Capture the second counter set
SELECT
	CAST(2 AS INT)	AS	Collection_Instance,
	[OBJECT_NAME],
	Counter_Name,
	instance_name,
	cntr_value,
	cntr_type,
	CURRENT_TIMESTAMP AS Collection_Time
INTO
	#perf_counters_second
FROM
	sys.dm_os_performance_counters
WHERE
	( OBJECT_NAME = @CounterPrefix + 'Access Methods' AND counter_name = 'Full Scans/sec' )
OR	( OBJECT_NAME = @CounterPrefix + 'Access Methods' AND counter_name = 'Index Searches/sec' )
OR	( OBJECT_NAME = @CounterPrefix + 'Buffer Manager' AND counter_name = 'Lazy Writes/sec' )
OR	( OBJECT_NAME = @CounterPrefix + 'Buffer Manager' AND counter_name = 'Page life expectancy' )
OR	( OBJECT_NAME = @CounterPrefix + 'General Statistics' AND counter_name = 'Processes Blocked' )
OR	( OBJECT_NAME = @CounterPrefix + 'General Statistics' AND counter_name = 'User Connections' )
OR	( OBJECT_NAME = @CounterPrefix + 'Locks' AND counter_name = 'Lock Waits/sec' )
OR	( OBJECT_NAME = @CounterPrefix + 'Locks' AND counter_name = 'Lock Wait Time (ms)' )
OR	( OBJECT_NAME = @CounterPrefix + 'SQL Statistics' AND counter_name = 'SQL Re-Compilations/sec' )
OR	( OBJECT_NAME = @CounterPrefix + 'Memory Manager' AND counter_name = 'Memory Grants Pending' )
OR	( OBJECT_NAME = @CounterPrefix + 'SQL Statistics' AND counter_name = 'Batch Requests/sec' )
OR	( OBJECT_NAME = @CounterPrefix + 'SQL Statistics' AND counter_name = 'SQL Compilations/sec' )

-- Calculate the cumulative counter values
SELECT
	i.OBJECT_Name,
	i.counter_Name,
	i.instance_name,
	CASE	WHEN	i.cntr_type = 272696576 THEN s.cntr_value - i.cntr_value
			WHEN	i.cntr_type = 65792 THEN s.cntr_value
	END AS cntr_value
FROM
	#perf_counters_init AS i
	JOIN
		#perf_counters_second AS s
		ON i.Collection_Instance + 1 = s.Collection_Instance
			AND i.OBJECT_Name = s.OBJECT_Name
			AND i.counter_Name = s.counter_Name
			AND i.instance_name = s.instance_name
	ORDER BY
		OBJECT_NAME

--Cleanup tables
DROP TABLE #perf_counters_init
DROP TABLE #perf_counters_second
"
);
		
	}
}
