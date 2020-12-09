<%@ WebService Language="C#" Class="TheLoveOfResemblanceWebService" %>

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

using System.Reflection;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessCode;

///<summary>
/// 2020-03-29	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class TheLoveOfResemblanceWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		string	bibleVersion
	)
    {
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			String.Format
			(
				QueryFormat,
				bibleVersion
			),
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
    }
	public const string QueryFormat =
	@"
;with cte
as
(
	SELECT --top 100 percent
		  {0} AS VerseText
		, ROW_NUMBER() OVER (ORDER BY {0}) AS RowNumber
		, COUNT(*) AS Occurrences
	FROM Bible..Scripture
	GROUP BY {0}
	HAVING COUNT(*) > 1
	/*
	order by
		[count] desc
	*/
)
SELECT 
	  cte.VerseText
	, cte.Occurrences
	, SUM ( cte.Occurrences) 
		OVER 
		(
			ORDER BY 
				  cte.Occurrences desc
				, cte.RowNumber asc

		) AS OccurrencesRunningTotal
FROM cte
order by
	  cte.Occurrences desc
	, cte.RowNumber asc
	";
}
