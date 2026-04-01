<%@ WebService Language="C#" Class="AileenANielsen_PracticalTimeSeriesAnalysis_HowCanIQueryByPeriod_WeekMonthOrYearWebService" %>

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
using System.Web.Script.Serialization;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

/*
	SELECT
		MIN(Dated),
		MAX(Dated),
		ContactID,
		COUNT(*) AS Occurrences
	FROM
		WordEngineering..CaseBasedReasoning
	UNION
	SELECT
		MIN(Dated),
		MAX(Dated)
		ContactID,
		COUNT(*)
	FROM
		WordEngineering..HisWord
)
AS JoinedSet --2026-03-31T13:53:00
WHERE
	ContactID BETWEEN {0} AND {1}
GROUP BY
	JoinedSet.DATEPART ( {2}, Dated ),
	JoinedSet.ContactID
ORDER BY
	DATEPART ( {2}, JoinedSet.Dated ),
	JoinedSet.ContactID
*/
/*
set statistics io on;
go
*/
///<summary>
///	2026-03-31T05:55:00...2026-03-31T06:04:00
///	Aileen.A.Nielsen@gmail.com
///	http://www.oreilly.com/library/view/practical-time-series/9781492041641
///	WordEngineering..CaseBasedReasoning ... WordEngineering..HisWord
///	Meeting who I am... is justifying who He will be.
///		Genesis 16:13-14
///	2026-03-31T13:47:00	http://stackoverflow.com/questions/1604815/how-to-use-group-by-with-union-in-t-sql
///	2026-03-31T14:19:00 http://learn.microsoft.com/en-us/answers/questions/594719/group-and-order-with-union
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class AileenANielsen_PracticalTimeSeriesAnalysis_HowCanIQueryByPeriod_WeekMonthOrYearWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		Int64 	contactIDMinimum,
		Int64 	contactIDMaximum,
		String	datePart
	)
    {
		DataTable dataTable = (DataTable) DataCommand.DatabaseCommand
		(
			String.Format
			(
				SQLStatement,
				contactIDMinimum,
				contactIDMaximum,
				datePart
			),	
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		return json;
    }
	
	public const String SQLStatement =
	@"
;WITH cte_JoinedSet
AS
(	
	SELECT
		MIN(Dated)	AS	MinimumDate,
		MAX(Dated)	AS	MaximumDate,
		ContactID,
		COUNT(*) AS Occurrences
	FROM
		WordEngineering..CaseBasedReasoning
	WHERE
		ContactID BETWEEN {0} AND {1}
	GROUP BY
		DATEPART ( {2}, Dated ),
		ContactID
	UNION
	SELECT
		MIN(Dated)	AS	MinimumDate,
		MAX(Dated)	AS	MaximumDate,
		ContactID,
		COUNT(*) AS Occurrences
	FROM
		WordEngineering..HisWord
	WHERE
		ContactID BETWEEN {0} AND {1}
	GROUP BY
		DATEPART ( {2}, Dated ),
		ContactID
)
SELECT *
FROM cte_JoinedSet
ORDER BY
	MinimumDate,
	MaximumDate,
	ContactID
	";
}
