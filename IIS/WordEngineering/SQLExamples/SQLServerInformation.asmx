<%@ WebService Language="C#" Class="SQLServerInformation" %>

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
///	2025-08-22T12:52:00 xp_msver http://weblogs.sqlteam.com/phils/2015/02/25/sql-server-version-information-xp_msver
///	2025-08-23T09:00:00	Created.
///	2025-08-23T11:00:00	
///	dynamic dataSet = DataCommand.DatabaseCommand
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class SQLServerInformation : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String	serverName
	)
    {
		String serverNamePrefix = String.IsNullOrEmpty(serverName) ? "" : serverName + ".";
		dynamic dataSet = DataCommand.DatabaseCommand
		(
			String.Format(SQLStatementFormat, serverNamePrefix),
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}
	
	public const string SQLStatementFormat =
		@"
			--sp_databases
			--{0}sp_spaceused
			--{0}master.sys.xp_fixeddrives
			{0}xp_msver
			SELECT 
				cpu_count,
				hyperthread_ratio,
			--    physical_memory_in_bytes / 1048576 AS 'mem_MB',
			--    virtual_memory_in_bytes / 1048576 AS 'virtual_mem_MB',
				max_workers_count,
				os_error_mode,
				os_priority_class
			FROM
				{0}master.sys.dm_os_sys_info
			SELECT * FROM sys.databases ORDER BY database_id				
		";
}
