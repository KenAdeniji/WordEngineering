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

///<summary>
///	2026-03-31T05:55:00...2026-03-31T06:04:00
///	Aileen.A.Nielsen@gmail.com
///	http://www.oreilly.com/library/view/practical-time-series/9781492041641
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
SELECT
	MIN(Dated) AS MinimumDated,
	MAX(Dated) AS MaximumDated,
	ContactID,
	COUNT(*) AS Occurrences
FROM
	WordEngineering..CaseBasedReasoning
WHERE
	ContactID BETWEEN {0} AND {1}
GROUP BY
	DATEPART ( {2}, Dated ),
	ContactID
ORDER BY
	DATEPART ( {2}, Dated ),
	ContactID
	";
}
