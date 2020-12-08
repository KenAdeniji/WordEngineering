<%@ WebService Language="C#" Class="SystemFunction" %>

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
using InformationInTransit.ProcessCode;

///<summary>
///	2019-04-10	Created.	http://www.apress.com/us/book/9781590599808?token=cyberweek18&utm_campaign=3_fjp8312_Apress_US_PLA_cyberweek18#otherversion=9781430206255
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class SystemFunction : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query()
    {
		DataSet dataSet = (DataSet)DataCommand.DatabaseCommand
		(
			SelectStatement,
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}
	
	public const string SelectStatement = 
@"
	  SELECT '@@CONNECTIONS' AS Question, CONVERT(VARCHAR, @@CONNECTIONS) AS Answer
UNION SELECT '@@CPU_BUSY', CONVERT(VARCHAR, @@CPU_BUSY)
UNION SELECT '@@DATEFIRST' AS Question, CONVERT(VARCHAR, @@DATEFIRST) AS Answer
UNION SELECT '@@IDLE', CONVERT(VARCHAR, @@IDLE)
UNION SELECT '@@IO_BUSY', CONVERT(VARCHAR, @@IO_BUSY)
UNION SELECT '@@LANGID', CONVERT(VARCHAR, @@LANGID)
UNION SELECT '@@LANGUAGE', @@LANGUAGE
UNION SELECT '@@LOCK_TIMEOUT', CONVERT(VARCHAR, @@LOCK_TIMEOUT)
UNION SELECT '@@PACKET_ERRORS', CONVERT(VARCHAR, @@PACKET_ERRORS)
UNION SELECT '@@PACK_RECEIVED', CONVERT(VARCHAR, @@PACK_RECEIVED)
UNION SELECT '@@PACK_SENT', CONVERT(VARCHAR, @@PACK_SENT)
UNION SELECT '@@ROWCOUNT', CONVERT(VARCHAR, @@ROWCOUNT)
UNION SELECT '@@SERVERNAME', @@SERVERNAME
UNION SELECT '@@SPID', CONVERT(VARCHAR, @@SPID)
UNION SELECT '@@TIMETICKS', CONVERT(VARCHAR, @@TIMETICKS)
UNION SELECT '@@TOTAL_ERRORS', CONVERT(VARCHAR, @@TOTAL_ERRORS)
UNION SELECT '@@TOTAL_READ', CONVERT(VARCHAR, @@TOTAL_READ)
UNION SELECT '@@TOTAL_WRITE', CONVERT(VARCHAR, @@TOTAL_WRITE)
UNION SELECT '@@TRANCOUNT', CONVERT(VARCHAR, @@TRANCOUNT)
UNION SELECT '@@VERSION', CONVERT(VARCHAR, @@VERSION)
UNION SELECT 'APP_NAME()' AS Question, APP_NAME() AS Answer
UNION SELECT 'HOST_ID()' AS Question, CONVERT(VARCHAR, HOST_ID()) AS Answer
UNION SELECT 'HOST_NAME()' AS Question, CONVERT(VARCHAR, HOST_NAME()) AS Answer
ORDER BY Question
";
}
