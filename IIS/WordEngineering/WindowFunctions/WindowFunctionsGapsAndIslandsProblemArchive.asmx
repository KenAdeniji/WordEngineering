<%@ WebService Language="C#" Class="WindowFunctionsGapsAndIslandsProblemWebService" %>

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
///	2019-02-11	Created.	https://www.mssqltips.com/sqlservertutorial/9130/sql-server-window-functions-gaps-and-islands-problem/
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WindowFunctionsGapsAndIslandsProblemWebService : System.Web.Services.WebService
{
	
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query()
    {
		DataSet dataSet = (DataSet)DataCommand.DatabaseCommand
		(
			SelectFormat,
			CommandType.Text,
			DataCommand.ResultType.DataSet
        );
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}
	
	public const string SelectFormat = 
	@"
SELECT
     gapStart = DATEADD(DAY,1,[current])
    ,gapEnd   = DATEADD(DAY,-1,[next])
FROM
(
SELECT
    [current] = [Dated]
   ,[next]    = LEAD([Dated]) OVER (ORDER BY [Dated])
FROM WordEngineering..[HisWord]
) tmp
WHERE DATEDIFF(DAY,[current],[next]) > 1;
		";
}
