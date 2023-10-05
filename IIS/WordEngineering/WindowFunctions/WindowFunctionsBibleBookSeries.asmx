<%@ WebService Language="C#" Class="WindowFunctionsBibleBookSeriesWebService" %>

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
///	2019-12-28	Created.
///	2019-12-28	http://www.sqlservertutorial.net/sql-server-window-functions/sql-server-row_number-function/
///	2019-12-28	https://stackoverflow.com/questions/2558825/how-to-detect-if-a-string-contains-at-least-a-number
///	2019-12-28	https://stackoverflow.com/questions/2120544/how-to-get-cumulative-sum
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WindowFunctionsBibleBookSeriesWebService : System.Web.Services.WebService
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
   ROW_NUMBER() OVER ( ORDER BY BookID ) row_num,
   BookTitle,
   MAX(ChapterID) AS Chapters,
   SUM(MAX(ChapterID)) OVER(ORDER BY BookID ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) AS RunningChapters,
   COUNT(VerseID) AS Verses,
   SUM(COUNT(VerseID)) OVER(ORDER BY BookID ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) AS RunningVerses
FROM Bible..Scripture
WHERE BookTitle LIKE '%[0-9]%'
GROUP BY BookID, BookTitle
	";
}
