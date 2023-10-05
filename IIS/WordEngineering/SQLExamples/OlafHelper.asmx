<%@ WebService Language="C#" Class="OlafHelperWebService" %>

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
///	2020-10-01	Created.	Olaf Helper, SQL Server, Germany domain name, reflection
///	2020-10-01	http://gallery.technet.microsoft.com/site/search?f[0].Type=RootCategory&f[0].Value=databases&f[1].Type=User&f[1].Value=Olaf%20Helper&f[1].Text=Olaf%20Helper
///	2020-10-01T17:15:00	https://stackoverflow.com/questions/33477163/get-value-of-constant-by-name
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class OlafHelperWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Queries()
    {
		IEnumerable<string> result = typeof(OlafHelperWebService).GetConstantNames<string>();
		string json = JsonConvert.SerializeObject(result, Formatting.Indented);

		return json;
    }

   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query(String query)
    {
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			(String) typeof(OlafHelperWebService).GetField(query).GetValue(null),		
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
    }
	
	public const string ConnectivityInformation = @"
	--	2020-10-01 https://gallery.technet.microsoft.com/Connectivity-informations-1e2f94ea
	/*
Connectivity to a SQL Server can be established in different ways
- Protocols: TCP/IP, named pipes or shared memory
- Client interface like ODBC, OleDB or Ado.Net
- To TSql or Soap endpoints
- authentification with SQL Account, Kerberos or NTLM
and so.
Do you know, which client and which application connects in which way?
With this Transact-SQL script you can get a detailed list with these informations for all current established connections.
Bases on this script you can also create small statistics about the parameter usage, like which applications uses OleDB?

TDS Version info:
   http://blogs.msdn.com/b/jenss/archive/2009/03/02/tds-protocol-versions-meet-client-stacks.aspx

TDS

Versions list:
   http://msdn.microsoft.com/en-us/library/dd339982(PROT.13).aspx
  
Connection failure because of mismatched TDS version:
   http://blogs.msdn.com/b/sql_protocols/archive/2008/07/15/connection-failure-because-of-mismatched-tds-version.aspx	
	*/	
;WITH con AS 
   (SELECT SES.host_name AS HostName 
          ,CON.client_net_address AS ClientAddress 
          ,SES.login_name AS LoginName 
          ,SES.program_name AS ProgramName 
          ,EP.name AS ConnectionTyp 
          ,CON.net_transport AS NetTransport 
          ,CON.protocol_type AS ProtocolType 
          ,CONVERT(VARBINARY(9), CON.protocol_version) AS TDSVersionHex 
          ,SES.client_interface_name AS ClientInterface 
          ,CON.encrypt_option AS IsEncryted 
          ,CON.auth_scheme AS Auth 
    FROM sys.dm_exec_connections AS CON 
         LEFT JOIN sys.endpoints AS EP 
             ON CON.endpoint_id = EP.endpoint_id 
         INNER JOIN sys.dm_exec_sessions as SES 
             ON CON.session_id = SES.session_id) 
-- Detailed list 
SELECT * 
FROM con 
-- Optional filter 
--WHERE con.ClientInterface = 'ODBC' 
ORDER by con.TDSVersionHex,con.HostName 
        ,con.LoginName 
        ,con.ProgramName; 
 
/* 
-- Count of different connectivity parameters 
SELECT COUNT(*) AS [Connections #] 
      ,COUNT(DISTINCT con.HostName) AS [Hosts #] 
      ,COUNT(DISTINCT con.LoginName) AS [Logins #] 
      ,COUNT(DISTINCT con.ProgramName) AS [Programs #] 
      ,COUNT(DISTINCT con.NetTransport) AS [NetTransport #] 
      ,COUNT(DISTINCT con.TDSVersionHex) AS [TdsVersions #] 
      ,COUNT(DISTINCT con.ClientInterface) AS [ClientInterfaces #] 
FROM con; 
*/
 	";
	
	public const string CurrentIOAndCPUWorkload = @"
	--	2020-10-01 https://gallery.technet.microsoft.com/Current-IO-and-CPU-Workload-8d946ed4
	-- 	This Transact-SQL script creates a snapshot of current processes list, waits a few seconds and then joins the snapshot and the current process to get the Cpu and Io value delta of each process to identify those is creating high workload.
		-- Current IO and CPU Workload 
		SET NOCOUNT ON; 
		 
		-- Clean up temp table, if still exists. 
		IF NOT OBJECT_ID('tempdb..#processes') IS NULL 
			DROP TABLE #processes; 
		GO 
		 
		-- Create snapshot of current processes in a temp table 
		SELECT PRC.spid 
			  ,PRC.login_time 
			  ,PRC.ecid 
			  ,PRC.[sid] 
			  ,PRC.cpu 
			  ,PRC.physical_io 
		INTO #processes 
		FROM sys.sysprocesses AS PRC 
		WHERE PRC.spid <> @@SPID; -- Exclude own process 
		GO 
		 
		-- Wait a few seconds before comparing snapshot 
		-- with current processes 
		WAITFOR DELAY '00:00:02';  -- 2 seconds 
		GO 
		 
		-- Get total difference to calculate percentage values. 
		DECLARE @cpuDiff int, @ioDiff int; 
		SELECT @cpuDiff = SUM(ACT.cpu - SNP.cpu) 
			  ,@ioDiff = SUM(ACT.physical_io - SNP.physical_io) 
		FROM sys.sysprocesses AS ACT 
			 INNER JOIN #processes AS SNP 
				 ON ACT.spid = SNP.spid 
					AND ACT.[sid] = SNP.[sid] 
		 WHERE ACT.spid <> @@SPID -- Exclude own process 
			  AND SNP.ecid <= 1      
		 
		-- Join snapshot and current process to get delta values. 
		SELECT ACT.cpu - SNP.cpu AS CpuDiff 
			  ,ACT.physical_io - SNP.physical_io AS IoDiff 
			  ,CASE WHEN @cpuDiff = 0.0 THEN 0.0 
					ELSE CONVERT(decimal(10, 2), 100.0 * (ACT.cpu - SNP.cpu) / @cpuDiff) 
					END AS [Cpu %] 
			  ,CASE WHEN @ioDiff = 0 THEN 0.0 
					ELSE CONVERT(decimal(10, 2), 100.0 * (ACT.physical_io - SNP.physical_io) / @ioDiff) 
					END AS [IO %] 
			  ,ACT.spid AS Spid 
			  ,ACT.waitresource AS WaitResource 
			  ,DB.name AS DataBaseName 
			  ,ACT.hostname AS HostName 
			  ,ACT.[program_name] AS ProgramName 
			  ,ACT.loginame AS LoginName 
			  ,ACT.cmd AS Command 
			  ,EST.[text] AS SQLStatement 
		FROM sys.sysprocesses AS ACT 
			 INNER JOIN #processes AS SNP 
				 ON ACT.spid = SNP.spid 
					AND ACT.[sid] = SNP.[sid] 
					AND ACT.login_time = SNP.login_time 
			 LEFT JOIN sys.databases AS DB 
				 ON ACT.dbid = DB.database_id 
			 CROSS APPLY sys.dm_exec_sql_text(ACT.sql_handle) AS EST 
		WHERE ACT.spid <> @@SPID -- Exclude own process 
			  AND SNP.ecid <= 1 
			  AND ((ACT.cpu - SNP.cpu) > 0 
				   OR 
				   (ACT.physical_io - SNP.physical_io) > 0 
				  ) 
		ORDER BY ACT.cpu - SNP.cpu 
			   + ACT.physical_io - SNP.physical_io DESC; 
		GO 
		 
		-- Clean up temp table 
		DROP TABLE #processes; 
		GO 
			";
			
			public const string DatabaseLocks = @"
			--	2020-10-01 https://gallery.technet.microsoft.com/List-all-Locks-of-the-2a751879
			-- 	List all Locks of the Current Database 
				SELECT TL.resource_type AS ResType 
					  ,TL.resource_description AS ResDescr 
					  ,TL.request_mode AS ReqMode 
					  ,TL.request_type AS ReqType 
					  ,TL.request_status AS ReqStatus 
					  ,TL.request_owner_type AS ReqOwnerType 
					  ,TAT.[name] AS TransName 
					  ,TAT.transaction_begin_time AS TransBegin 
					  ,DATEDIFF(ss, TAT.transaction_begin_time, GETDATE()) AS TransDura 
					  ,ES.session_id AS S_Id 
					  ,ES.login_name AS LoginName 
					  ,COALESCE(OBJ.name, PAROBJ.name) AS ObjectName 
					  ,PARIDX.name AS IndexName 
					  ,ES.host_name AS HostName 
					  ,ES.program_name AS ProgramName 
				FROM sys.dm_tran_locks AS TL 
					 INNER JOIN sys.dm_exec_sessions AS ES 
						 ON TL.request_session_id = ES.session_id 
					 LEFT JOIN sys.dm_tran_active_transactions AS TAT 
						 ON TL.request_owner_id = TAT.transaction_id 
							AND TL.request_owner_type = 'TRANSACTION' 
					 LEFT JOIN sys.objects AS OBJ 
						 ON TL.resource_associated_entity_id = OBJ.object_id 
							AND TL.resource_type = 'OBJECT' 
					 LEFT JOIN sys.partitions AS PAR 
						 ON TL.resource_associated_entity_id = PAR.hobt_id 
							AND TL.resource_type IN ('PAGE', 'KEY', 'RID', 'HOBT') 
					 LEFT JOIN sys.objects AS PAROBJ 
						 ON PAR.object_id = PAROBJ.object_id 
					 LEFT JOIN sys.indexes AS PARIDX 
						 ON PAR.object_id = PARIDX.object_id 
							AND PAR.index_id = PARIDX.index_id 
				WHERE TL.resource_database_id  = DB_ID()
					AND ES.Session_id <> @@Spid --Exclude my session		
					  -- optional filter  
					  AND TL.request_mode <> 'S' -- Exclude simple shared locks
				ORDER BY TL.resource_type 
						,TL.request_mode 
						,TL.request_type 
						,TL.request_status 
						,ObjectName 
						,ES.login_name;		
	";

	public const string CountObjectsExistsInASchema = @"
	--	2020-10-01 https://gallery.technet.microsoft.com/How-many-Objects-exists-in-d0006b1f
	/*
During development of a database solution with agile methods (like SCRUM) schemas with some objects are created, then objects are moved to other schemas and so on; a dynamically developing process like usally.
At the end of this process you may notice that some of these schemas are empty, means no objects are assoziated with this schema.
This Transact-SQL script lists all schemas and the count of objects in that schema.	
	*/
	;WITH usage AS 
    (SELECT OBJ.schema_id 
           ,COUNT(*) AS ObjectCount 
     FROM sys.objects AS OBJ 
     GROUP BY OBJ.schema_id 
    ) 
SELECT SCH.name AS SchemaName 
      ,ISNULL(PRC.name, N'n/a') AS SchemaOwner 
      ,ISNULL(USG.ObjectCount, 0) AS ObjectCount 
FROM sys.schemas AS SCH 
     LEFT JOIN sys.server_principals AS PRC 
         ON SCH.principal_id = PRC.principal_id 
     LEFT JOIN usage AS USG 
         ON SCH.schema_id = USG.schema_id 
ORDER BY SCH.name;
	";

	public const string DatabaseProcesses = @"
		--	2020-10-01 https://gallery.technet.microsoft.com/Databases-Processes-29bedd6a	
		-- This Transact-SQL script gives a brief overview of count of processes, count of distinct users and hosts connected to, last batch execution, total cpu, IO and memory usage and open transactions per database; it reflects the current activity.
		-- Databases Processes Overview 
		;WITH pro AS 
		   (SELECT PRO.dbid  
				  ,COUNT(*) AS Processes 
				  ,SUM(PRO.cpu) AS Cpu 
				  ,SUM(PRO.physical_io) AS PhysicalIo 
				  ,SUM(PRO.memusage) AS MemUsage 
				  ,MAX(PRO.last_batch) AS LastBatch 
				  ,SUM(PRO.open_tran) AS OpenTran 
				  ,COUNT(DISTINCT PRO.sid) AS Users 
				  ,COUNT(DISTINCT PRO.hostname) AS Host 
			FROM sys.sysprocesses AS PRO 
			GROUP BY PRO.dbid) 
		SELECT DB.name AS DatabaseName 
			  ,pro.* 
			  ,DB.log_reuse_wait_desc AS LogReUse 
		FROM sys.databases AS DB 
			 LEFT JOIN pro 
				 ON DB.database_id = pro.dbid 
		ORDER BY DB.name; 
 	";

	public const string DatabaseSizeGrowth = @"
		--	2020-10-01 https://gallery.technet.microsoft.com/f1df9f50-9cd9-4c75-a8d9-e2faba6b8574	
		-- Transact-SQL script to analyse the database size growth using backup history. 
		DECLARE @endDate datetime, @months smallint; 
		SET @endDate = GetDate();  -- Include in the statistic all backups from today 
		SET @months = 6;           -- back to the last 6 months. 
		;WITH HIST AS 
		   (SELECT BS.database_name AS DatabaseName 
				  ,YEAR(BS.backup_start_date) * 100 
				   + MONTH(BS.backup_start_date) AS YearMonth 
				  ,CONVERT(numeric(10, 1), MIN(BF.file_size / 1048576.0)) AS MinSizeMB 
				  ,CONVERT(numeric(10, 1), MAX(BF.file_size / 1048576.0)) AS MaxSizeMB 
				  ,CONVERT(numeric(10, 1), AVG(BF.file_size / 1048576.0)) AS AvgSizeMB 
			FROM msdb.dbo.backupset as BS 
				 INNER JOIN 
				 msdb.dbo.backupfile AS BF 
					 ON BS.backup_set_id = BF.backup_set_id 
			WHERE NOT BS.database_name IN 
					  ('master', 'msdb', 'model', 'tempdb') 
				  AND BF.file_type = 'D' 
				  AND BS.backup_start_date BETWEEN DATEADD(mm, - @months, @endDate) AND @endDate 
			GROUP BY BS.database_name 
					,YEAR(BS.backup_start_date) 
					,MONTH(BS.backup_start_date)) 
		SELECT MAIN.DatabaseName 
			  ,MAIN.YearMonth 
			  ,MAIN.MinSizeMB 
			  ,MAIN.MaxSizeMB 
			  ,MAIN.AvgSizeMB 
			  ,MAIN.AvgSizeMB  
			   - (SELECT TOP 1 SUB.AvgSizeMB 
				  FROM HIST AS SUB 
				  WHERE SUB.DatabaseName = MAIN.DatabaseName 
						AND SUB.YearMonth < MAIN.YearMonth 
				  ORDER BY SUB.YearMonth DESC) AS GrowthMB 
		FROM HIST AS MAIN 
		ORDER BY MAIN.DatabaseName 
				,MAIN.YearMonth	
	";

	public const string ExpensiveQueries = @"
	--	2020-10-01	https://gallery.technet.microsoft.com/List-expensive-queries-f6d63ac6
	-- List expensive queries
		DECLARE @MinExecutions int; 
		SET @MinExecutions = 5 
		 
		SELECT EQS.total_worker_time AS TotalWorkerTime 
			  ,EQS.total_logical_reads + EQS.total_logical_writes AS TotalLogicalIO 
			  ,EQS.execution_count As ExeCnt 
			  ,EQS.last_execution_time AS LastUsage 
			  ,EQS.total_worker_time / EQS.execution_count as AvgCPUTimeMiS 
			  ,(EQS.total_logical_reads + EQS.total_logical_writes) / EQS.execution_count  
			   AS AvgLogicalIO 
			  ,DB.name AS DatabaseName 
			  ,SUBSTRING(EST.text 
						,1 + EQS.statement_start_offset / 2 
						,(CASE WHEN EQS.statement_end_offset = -1  
							   THEN LEN(convert(nvarchar(max), EST.text)) * 2  
							   ELSE EQS.statement_end_offset END  
						 - EQS.statement_start_offset) / 2 
						) AS SqlStatement 
			  -- Optional with Query plan; remove comment to show, but then the query takes !!much longer time!! 
			  --,EQP.[query_plan] AS [QueryPlan] 
		FROM sys.dm_exec_query_stats AS EQS 
			 CROSS APPLY sys.dm_exec_sql_text(EQS.sql_handle) AS EST 
			 CROSS APPLY sys.dm_exec_query_plan(EQS.plan_handle) AS EQP 
			 LEFT JOIN sys.databases AS DB 
				 ON EST.dbid = DB.database_id      
		WHERE EQS.execution_count > @MinExecutions 
			  AND EQS.last_execution_time > DATEDIFF(MONTH, -1, GETDATE()) 
		ORDER BY AvgLogicalIo DESC 
				,AvgCPUTimeMiS DESC
	";

	public const string FileSizePerType = @"
	-- 2020-10-01	https://gallery.technet.microsoft.com/e1211fb4-2ef8-40c5-9485-3b6eb8699500
	/*
	To get an overview creates this statement a pivot table with all database and the total size of the files aggregated by the file type Row, Log, Filestream and Fulltext (for SQL Server versions before 2008).
	The order clause could be changed e.g. to ORDER BY [ROWS] DESC to sort the list descending by the row size.
	The size is measured in mega bytes (MB):
	*/
		SELECT DbName 
			  ,DbState 
			  ,DbRecovery 
			  ,[ROWS], [LOG], [FILESTREAM], [FULLTEXT] 
		FROM ( 
				SELECT DB.name AS DbName 
					  ,DB.state_desc AS DbState 
					  ,DB.recovery_model_desc AS DBRecovery 
					  ,MF.type_desc AS FileType 
					  ,CONVERT(int, ROUND(MF.size * 0.0078125, 0)) AS SizeMB 
				FROM sys.databases AS DB 
					 INNER JOIN sys.master_files AS MF 
						 ON DB.database_id = MF.database_id 
				WHERE HAS_DBACCESS(DB.name) = 1 
			 ) AS DBS 
		PIVOT (SUM(SizeMB) 
			   FOR FileType IN ([ROWS], [LOG], [FILESTREAM], [FULLTEXT])  
			  ) AS PVT 
		ORDER BY DbName	
	";

	public const string HeapTables = @"
	-- 2020-10-01	https://gallery.technet.microsoft.com/List-all-heap-tables-7ffaea35
	-- List all heap tables 
		SELECT SCH.name + '.' + TBL.name AS TableName 
		FROM sys.tables AS TBL 
			 INNER JOIN sys.schemas AS SCH 
				 ON TBL.schema_id = SCH.schema_id 
			 INNER JOIN sys.indexes AS IDX 
				 ON TBL.object_id = IDX.object_id 
					AND IDX.type = 0 -- = Heap 
		ORDER BY TableName
	";

	public const string LocksPerDatabaseAndType = @"
	-- 2020-10-01	https://gallery.technet.microsoft.com/Overview-of-Locks-per-0e7f8fee
	-- This Transact-SQL gives a quick overview of the counts of locks per database, lock type and status.
	-- It reflects the current activities on the databases.
SELECT DB.name AS DatabaseName 
      ,TL.request_mode AS ReqMode 
      ,TL.request_type AS ReqType 
      ,TL.request_status AS ReqStatus 
      ,TL.request_owner_type AS ReqOwner 
      ,COUNT(*) AS LocksCount 
FROM sys.databases AS DB 
     INNER JOIN sys.dm_tran_locks AS TL 
         ON DB.database_id = TL.resource_database_id 
GROUP BY DB.name 
        ,TL.request_mode 
        ,TL.request_type 
        ,TL.request_status 
        ,TL.request_owner_type;
	";

	public const string LogFileStatisticsForAllDatabases = @"
		-- 2020-10-01 https://gallery.technet.microsoft.com/Log-file-statistics-for-fbf22834
		-- file statistics for all databases
		/*
		This Transact-SQL script uses the DMV sys.dm_os_performance_counters to list log file information
		- allocated size in MB
		- used size in MB
		- free size in MB
		- percent of size used
		- count of VLF the log have been grown, shrink and truncated since last service start for all databases, similar to the DBCC SqlPerf(LogSpace) command.
		You could change the sort order e.g. to PVT.[Percent Log Used] DESC to get the database with to lowest free space in log file on top or filter for log files with to less free space.
		*/
		SELECT PVT.DatabaseName 
			  ,CONVERT(numeric(38, 1), PVT.[Log File(s) Size (KB)] / 1024.0) AS LogFileSizeMB 
			  ,CONVERT(numeric(38, 1), PVT.[Log File(s) Used Size (KB)] / 1024.0) AS LogFileUsedMB 
			  ,CONVERT(numeric(38, 1), (PVT.[Log File(s) Size (KB)] 
										- PVT.[Log File(s) Used Size (KB)]) / 1024.0) AS LogFileFreeMB 
			  ,PVT.[Percent Log Used] AS PercLogUsed 
			  ,PVT.[Log Growths] AS LogGrowths 
			  ,PVT.[Log Shrinks] AS LogShrinks 
			  ,PVT.[Log Truncations] AS LogTrunc 
		FROM 
			(SELECT RTRIM(SUB.counter_name) AS CounterName 
				   ,RTRIM(SUB.instance_name) AS DatabaseName 
				   ,SUB.cntr_value AS CounterValue 
			 FROM [master].[sys].[dm_os_performance_counters] AS SUB 
			 WHERE SUB.[object_name] LIKE 'MSSQL$%:Databases%'       -- To be independed of instance name. 
				   AND SUB.counter_name IN ('Log File(s) Size (KB)' 
										   ,'Log File(s) Used Size (KB)' 
										   ,'Percent Log Used' 
										   ,'Log Growths' 
										   ,'Log Shrinks' 
										   ,'Log Truncations') 
			) AS OPC 
		PIVOT 
			(SUM(OPC.CounterValue) 
			 FOR OPC.CounterName IN ([Log File(s) Size (KB)] 
									,[Log File(s) Used Size (KB)] 
									,[Percent Log Used] 
									,[Log Growths] 
									,[Log Shrinks] 
									,[Log Truncations]) 
			) AS PVT 
		ORDER BY PVT.DatabaseName;
 	";

	public const string LogGrowthRate = @"
		-- 2020-10-01 https://gallery.technet.microsoft.com/Log-Growth-Rate-3549096e
		-- Log Growth Rate 
/*
Log files should be sized well to avoid frequently resizes, which causes unnecessary IO workload and file fragmentation.
The log files should be large enough to store all transaction data occuring between two log backups and the growth size should be also set proper.
This Transact-SQL script list all log file related data and the log file growth counter from WMI performance counter statistic to show which log files are sized well and which one not.
*/
		;WITH 
		 logs AS 
		   (SELECT DB.name AS DatabaseName 
				  ,MAX(DB.recovery_model_desc) AS RecoveryModel 
				  ,SUM(size * 8) AS TotalSizeKB 
				  ,SUM(CASE WHEN MF.is_percent_growth = 0 
							THEN MF.growth 
							ELSE MF.size * MF.growth / 100 
							END * 8) AS TotalGrowthKB 
			FROM sys.master_files AS MF 
				 INNER JOIN sys.databases AS DB 
					 ON MF.database_id = DB.database_id 
			WHERE MF.[type] = 1 
			GROUP BY DB.name) 
		,total AS 
		   (SELECT OPC.[cntr_value] AS TotalCounter 
			FROM sys.dm_os_performance_counters AS OPC 
			WHERE OPC.[object_name] LIKE N'%SQL%:Databases%' 
			  AND OPC.[counter_name] = N'Log Growths' 
			  AND OPC.[instance_name] = N'_Total') 
		,growth AS 
		   (SELECT OPC.[instance_name] AS DatabaseName 
				  ,OPC.[cntr_value] AS Growths 
			FROM sys.dm_os_performance_counters AS OPC 
			WHERE OPC.[object_name] LIKE N'%SQL%:Databases%' 
				  AND OPC.[counter_name] = N'Log Growths' 
				  AND OPC.[instance_name] <> N'_Total') 
		,shrinks AS 
		   (SELECT OPC.[instance_name] AS DatabaseName 
				  ,OPC.[cntr_value] AS Shrinks 
			FROM sys.dm_os_performance_counters AS OPC 
			WHERE OPC.[object_name] LIKE N'%SQL%:Databases%' 
				  AND OPC.[counter_name] = N'Log Shrinks' 
				  AND OPC.[instance_name] <> N'_Total') 
		SELECT logs.DatabaseName 
			  ,logs.RecoveryModel 
			  ,logs.TotalSizeKB 
			  ,logs.TotalGrowthKB 
			  ,shrinks.Shrinks 
			  ,growth.Growths 
			  ,CONVERT(decimal(38, 2) 
					  ,CASE WHEN total.TotalCounter = 0 
					   THEN 0.0 
					   ELSE 100.0 * growth.Growths / total.TotalCounter 
					   END) AS [GrowthRate %] 
		FROM logs 
			 INNER JOIN growth 
				 ON logs.DatabaseName = growth.DatabaseName 
			 INNER JOIN shrinks 
				 ON logs.DatabaseName = shrinks.DatabaseName 
			 CROSS JOIN total 
		ORDER BY [GrowthRate %] DESC 
				,logs.DatabaseName ASC;
 	";
	
	public const string MissingIndexesAndCachedQueryPlans = @"
	-- 2020-10-01	https://gallery.technet.microsoft.com/Get-all-SQL-Statements-9af68abc
	-- Get all SQL Statements with missing indexes and their cached query plans 
		;WITH  
		 XMLNAMESPACES 
			 (DEFAULT N'http://schemas.microsoft.com/sqlserver/2004/07/showplan'   
					 ,N'http://schemas.microsoft.com/sqlserver/2004/07/showplan' AS ShowPlan)       
		SELECT ECP.[usecounts]    AS [UsageCounts] 
			  ,ECP.[refcounts]    AS [RefencedCounts] 
			  ,ECP.[objtype]      AS [ObjectType] 
			  ,ECP.[cacheobjtype] AS [CacheObjectType] 
			  ,EST.[dbid]         AS [DatabaseID] 
			  ,EST.[objectid]     AS [ObjectID] 
			  ,EST.[text]         AS [Statement]       
			  ,EQP.[query_plan]   AS [QueryPlan] 
		FROM sys.dm_exec_cached_plans AS ECP 
			 CROSS APPLY sys.dm_exec_sql_text(ECP.[plan_handle]) AS EST 
			 CROSS APPLY sys.dm_exec_query_plan(ECP.[plan_handle]) AS EQP 
		WHERE ECP.[usecounts] > 1  -- Plan should be used more then one time (= no AdHoc queries) 
			  AND EQP.[query_plan].exist(N'/ShowPlanXML/BatchSequence/Batch/Statements/StmtSimple/QueryPlan/MissingIndexes/MissingIndexGroup') <> 0 
		ORDER BY ECP.[usecounts] DESC
	";
	
	public const string MissingIndexesAndCreateStatement = @"
	-- 2020-10-01	https://gallery.technet.microsoft.com/Missing-indexes-with-34edd093
	-- Missing indexes with CREATE statement for it
		SELECT MID.[statement] AS ObjectName 
			  ,MID.equality_columns AS EqualityColumns 
			  ,MID.inequality_columns AS InequalityColms 
			  ,MID.included_columns AS IncludedColumns 
			  ,MIGS.last_user_seek AS LastUserSeek 
			  ,MIGS.avg_total_user_cost  
			   * MIGS.avg_user_impact  
			   * (MIGS.user_seeks + MIGS.user_scans) AS Impact 
			  ,N'CREATE NONCLUSTERED INDEX <Add Index Name here> ' +  
			   N'ON ' + MID.[statement] +  
			   N' (' + MID.equality_columns  
					 + ISNULL(', ' + MID.inequality_columns, N'') + 
			   N') ' + ISNULL(N'INCLUDE (' + MID.included_columns + N');', ';') 
			   AS CreateStatement 
		FROM sys.dm_db_missing_index_group_stats AS MIGS 
			 INNER JOIN sys.dm_db_missing_index_groups AS MIG 
				 ON MIGS.group_handle = MIG.index_group_handle 
			 INNER JOIN sys.dm_db_missing_index_details AS MID 
				 ON MIG.index_handle = MID.index_handle 
		WHERE database_id = DB_ID() 
			  AND MIGS.last_user_seek >= DATEDIFF(month, GetDate(), -1) 
		ORDER BY Impact DESC;
	";
	
	public const string OpenCursors = @"
	--	2020-10-01	https://gallery.technet.microsoft.com/List-all-open-Cursors-7ebec7f6
		SELECT CRS.name AS CursorName 
			  ,CRS.properties AS CursorProperties 
			  ,CRS.creation_time AS Creation 
			  ,CRS.is_open AS IsOpen 
			  ,CRS.reads AS Reads 
			  ,CRS.writes AS Writes 
			  ,CRS.dormant_duration AS DurationMs 
			  ,SES.cpu_time AS CpuTime 
			  ,SES.memory_usage AS MemUsage 
			  ,SES.login_name AS LoginName 
			  ,SUBSTRING(ST.text 
						,(CRS.statement_start_offset / 2) + 1 
						,((CASE CRS.statement_end_offset 
								WHEN -1 THEN DATALENGTH(st.text) 
								ELSE CRS.statement_end_offset 
								END  
						  - CRS.statement_start_offset) / 2) + 1) AS CursorSQL 
		FROM sys.dm_exec_cursors(0) AS CRS 
			 INNER JOIN 
			 sys.dm_exec_sessions AS SES 
				 ON CRS.session_id = SES.session_id 
			 CROSS APPLY 
			 sys.dm_exec_sql_text(CRS.sql_handle) AS ST	
			";

	public const string PendingIORequests = @"
	--	2020-10-01 https://gallery.technet.microsoft.com/Pending-IO-Requests-9b93c077
	-- 	Pending IO Requests 
		;WITH  
		 pir AS 
			(SELECT PIR.scheduler_address 
				   ,COUNT(*) AS PendIoRequests 
				   ,SUM(PIR.io_pending_ms_ticks) AS PendWaitTime 
			 FROM sys.dm_io_pending_io_requests AS PIR 
			 GROUP BY PIR.scheduler_address 
			 ) 
		,req AS 
			 (SELECT ER.task_address 
					,COUNT(*) AS ReqCnt 
					,COUNT(DISTINCT ER.database_id) AS ReqDbCnt 
					,SUM(ER.wait_time) AS ReqWaitTime 
			  FROM sys.dm_exec_requests AS ER 
			  GROUP BY ER.task_address 
			 ) 
		SELECT OS.scheduler_id AS Scheduler 
			  ,OS.cpu_id AS CpuId 
			  ,CASE WHEN OS.scheduler_id < 1048576 
					THEN 'Query' 
					ELSE 'Internal' END AS Scheduler 
			  ,OS.[status] AS OsStatus 
			  ,OS.current_workers_count AS CurrWrk 
			  ,OS.active_workers_count AS ActWrk 
			  ,OS.pending_disk_io_count AS pDiskIo 
			  ,OW.pending_io_count AS pIoCount 
			  ,OW.pending_io_byte_count AS pIoBytes 
			  ,OW.[state] AS WorkerState 
			  ,req.ReqDbCnt 
			  ,req.ReqCnt 
			  ,req.ReqWaitTime 
			  ,pir.PendIoRequests 
			  ,pir.PendWaitTime 
		FROM sys.dm_os_schedulers AS OS 
			 INNER JOIN sys.dm_os_workers AS OW 
				 ON OS.active_worker_address = OW.worker_address     
			 -- Change it to INNER join to get only pending schedulers 
			 LEFT JOIN pir 
				 ON pir.scheduler_address = OS.scheduler_address 
			 LEFT JOIN req 
				 ON req.task_address = OW.task_address 
		ORDER BY OS.scheduler_id;	
	";
			
	public const string SQLLoginPasswordExpire = @"
	--	2020-10-01	https://gallery.technet.microsoft.com/List-all-open-Cursors-7ebec7f6
		SELECT SL.name AS LoginName 
			  ,LOGINPROPERTY (SL.name, 'PasswordLastSetTime') AS PasswordLastSetTime 
			  ,LOGINPROPERTY (SL.name, 'DaysUntilExpiration') AS DaysUntilExpiration 
			  ,DATEADD(dd, CONVERT(int, LOGINPROPERTY (SL.name, 'DaysUntilExpiration')) 
						 , CONVERT(datetime, LOGINPROPERTY (SL.name, 'PasswordLastSetTime'))) AS PasswordExpiration 
			  ,SL.is_policy_checked AS IsPolicyChecked 
			  ,LOGINPROPERTY (SL.name, 'IsExpired') AS IsExpired 
			  ,LOGINPROPERTY (SL.name, 'IsMustChange') AS IsMustChange 
			  ,LOGINPROPERTY (SL.name, 'IsLocked') AS IsLocked 
			  ,LOGINPROPERTY (SL.name, 'LockoutTime') AS LockoutTime 
			  ,LOGINPROPERTY (SL.name, 'BadPasswordCount') AS BadPasswordCount 
			  ,LOGINPROPERTY (SL.name, 'BadPasswordTime') AS BadPasswordTime 
			  ,LOGINPROPERTY (SL.name, 'HistoryLength') AS HistoryLength 
		FROM sys.sql_logins AS SL 
		WHERE is_expiration_checked = 1 
		ORDER BY LOGINPROPERTY (SL.name, 'PasswordLastSetTime') DESC
	";	
	
	public const string SQLServerIOStatistics = @"
	--	2020-10-01	https://gallery.technet.microsoft.com/Various-SQL-Server-IO-3f9002f7
-- Various SQL Server IO Statistics 
;WITH  
 IOT AS    -- Total sums of all properties. 
   (SELECT SUM(IOS.num_of_reads) AS Reads 
          ,SUM(IOS.num_of_bytes_read) BytesRead 
          ,SUM(IOS.io_stall_read_ms) AS IoStallReadMs 
          ,SUM(IOS.num_of_writes) AS Writes 
          ,SUM(IOS.num_of_bytes_written) AS BytesWritten 
          ,SUM(IOS.io_stall_write_ms) AS IoStallWritesMs 
          ,SUM(IOS.io_stall) AS IoStall 
          ,SUM(IOS.size_on_disk_bytes) SizeOnDisk 
    FROM sys.dm_io_virtual_file_stats(default, default) AS IOS) 
,IOF AS    
   (SELECT DBS.name AS DatabaseName 
          ,MF.name AS [FileName] 
          ,MF.type_desc AS FileType 
          ,SUBSTRING(MF.physical_name, 1, 3) AS Drive 
          ,CASE WHEN DBS.name IN ('master', 'model', 'msdb', 'tempdb') 
                THEN 1 ELSE 0 END AS IsSystemDB 
          ,IOS.* 
    FROM sys.dm_io_virtual_file_stats(default, default) AS IOS 
         INNER JOIN sys.databases AS DBS 
             ON IOS.database_id = DBS.database_id 
         INNER JOIN sys.master_files AS MF 
             ON IOS.database_id = MF.database_id 
                AND IOS.file_id = MF.file_id) 
/* 
-- Detailed for each file 
SELECT IOF.DatabaseName 
      ,IOF.FileName 
      ,IOF.FileType 
      ,CONVERT(numeric(5,2), 100.0 * IOF.num_of_reads / IOT.Reads) AS [Reads%] 
      ,CONVERT(numeric(5,2), 100.0 * IOF.num_of_bytes_read / IOT.BytesRead) AS [BytesRead%] 
      ,CONVERT(numeric(5,2), 100.0 * IOF.io_stall_read_ms / IOT.IoStallReadMs) AS [IoStallReadMs%] 
      ,CONVERT(numeric(5,2), 100.0 * IOF.num_of_writes / IOT.Writes) AS [Writes%] 
      ,CONVERT(numeric(5,2), 100.0 * IOF.num_of_bytes_written / IOT.BytesWritten) AS [BytesWritten%] 
      ,CONVERT(numeric(5,2), 100.0 * IOF.io_stall_write_ms / IOT.IoStallWritesMs) AS [IoStallWritesMs%] 
      ,CONVERT(numeric(5,2), 100.0 * IOF.io_stall / IOT.IoStall) AS [IoStall%] 
      ,CONVERT(numeric(5,2), 100.0 * IOF.size_on_disk_bytes / IOT.SizeOnDisk) AS [SizeOnDisk%] 
FROM IOF CROSS APPLY IOT 
ORDER BY IOF.DatabaseName 
        ,IOF.FileType; 
*/ 
 
/* 
-- Overview by file type 
SELECT IOF.FileType 
      ,CONVERT(numeric(5,2), SUM(100.0 * IOF.num_of_reads / IOT.Reads)) AS [Reads%] 
      ,CONVERT(numeric(5,2), SUM(100.0 * IOF.num_of_bytes_read / IOT.BytesRead)) AS [BytesRead%] 
      ,CONVERT(numeric(5,2), SUM(100.0 * IOF.io_stall_read_ms / IOT.IoStallReadMs)) AS [IoStallReadMs%] 
      ,CONVERT(numeric(5,2), SUM(100.0 * IOF.num_of_writes / IOT.Writes)) AS [Writes%] 
      ,CONVERT(numeric(5,2), SUM(100.0 * IOF.num_of_bytes_written / IOT.BytesWritten)) AS [BytesWritten%] 
      ,CONVERT(numeric(5,2), SUM(100.0 * IOF.io_stall_write_ms / IOT.IoStallWritesMs)) AS [IoStallWritesMs%] 
      ,CONVERT(numeric(5,2), SUM(100.0 * IOF.io_stall / IOT.IoStall)) AS [IoStall%] 
      ,CONVERT(numeric(5,2), SUM(100.0 * IOF.size_on_disk_bytes / IOT.SizeOnDisk)) AS [SizeOnDisk%] 
FROM IOF CROSS APPLY IOT 
GROUP BY IOF.FileType 
ORDER BY IOF.FileType; 
*/ 
 
-- Overview per drive 
SELECT IOF.Drive 
      ,CONVERT(numeric(5,2), SUM(100.0 * IOF.num_of_reads / IOT.Reads)) AS [Reads%] 
      ,CONVERT(numeric(5,2), SUM(100.0 * IOF.num_of_bytes_read / IOT.BytesRead)) AS [BytesRead%] 
      ,CONVERT(numeric(5,2), SUM(100.0 * IOF.io_stall_read_ms / IOT.IoStallReadMs)) AS [IoStallReadMs%] 
      ,CONVERT(numeric(5,2), SUM(100.0 * IOF.num_of_writes / IOT.Writes)) AS [Writes%] 
      ,CONVERT(numeric(5,2), SUM(100.0 * IOF.num_of_bytes_written / IOT.BytesWritten)) AS [BytesWritten%] 
      ,CONVERT(numeric(5,2), SUM(100.0 * IOF.io_stall_write_ms / IOT.IoStallWritesMs)) AS [IoStallWritesMs%]      ,CONVERT(numeric(5,2), SUM(100.0 * IOF.io_stall / IOT.IoStall)) AS [IoStall%] 
      ,CONVERT(numeric(5,2), SUM(100.0 * IOF.size_on_disk_bytes / IOT.SizeOnDisk)) AS [SizeOnDisk%] 
FROM IOF CROSS APPLY IOT 
GROUP BY IOF.Drive 
ORDER BY IOF.Drive; 
	";	
	
	public const string TablesSize = @"
	-- 2020-10-01 https://gallery.technet.microsoft.com/fb515c14-be6c-48f8-b8f4-8fd60de82f05
	-- Detailed list of all tables and their size
	-- List all database tables and there indexes with  
	-- detailed information about row count and  
	-- used + reserved data space.  
		SELECT SCH.name AS SchemaName 
			  ,OBJ.name AS ObjName 
			  ,OBJ.type_desc AS ObjType 
			  ,INDX.name AS IndexName 
			  ,INDX.type_desc AS IndexType 
			  ,PART.partition_number AS PartitionNumber 
			  ,PART.rows AS PartitionRows 
			  ,STAT.row_count AS StatRowCount 
			  ,STAT.used_page_count * 8 AS UsedSizeKB 
			  ,STAT.reserved_page_count * 8 AS RevervedSizeKB 
		FROM sys.partitions AS PART 
			 INNER JOIN sys.dm_db_partition_stats AS STAT 
				 ON PART.partition_id = STAT.partition_id 
					AND PART.partition_number = STAT.partition_number 
			 INNER JOIN sys.objects AS OBJ 
				 ON STAT.object_id = OBJ.object_id 
			 INNER JOIN sys.schemas AS SCH 
				 ON OBJ.schema_id = SCH.schema_id 
			 INNER JOIN sys.indexes AS INDX 
				 ON STAT.object_id = INDX.object_id 
					AND STAT.index_id = INDX.index_id 
		ORDER BY SCH.name 
				,OBJ.name 
				,INDX.name 
				,PART.partition_number 		
	";
}