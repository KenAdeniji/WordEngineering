<%@ WebService Language="C#" Class="SQLServerTableSize" %>

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
public class SQLServerTableSize : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query(String databaseName)
    {
		DataTable dataTable = null;
		dataTable = (DataTable)DataCommand.DatabaseCommand
		(
			String.Format(TableSizeSQLStatement, databaseName),
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		return json;
	}

	public const string TableSizeSQLStatement =
		@"
			USE {0};
SELECT
s.name + '.' + t.NAME AS TableName,
SUM(a.used_pages)*8 AS 'TableSizeKB' --a page in SQL Server is 8kb
FROM sys.tables t
JOIN sys.schemas s on t.schema_id = s.schema_id
LEFT JOIN sys.indexes i ON t.OBJECT_ID = i.object_id
LEFT JOIN sys.partitions p ON i.object_id = p.OBJECT_ID AND i.index_id = p.index_id
LEFT JOIN sys.allocation_units a ON p.partition_id = a.container_id
GROUP BY
s.name, t.name
ORDER BY
--Either sort by name:
s.name + '.' + t.NAME
--Or sort largest to smallest:
--SUM(a.used_pages) desc
;
		";
}
