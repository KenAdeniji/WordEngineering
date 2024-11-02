<%@ WebService Language="C#" Class="ContributionMetricWebService" %>

using System;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;

using System.Data;
using System.Data.SqlClient;
using System.Text;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;

///<summary>
///	2024-06-01T19:37:00	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class ContributionMetricWebService : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
	)
    {
		DataTable resultTable = (DataTable) DataCommand.DatabaseCommand
		(
			QueryStatement,
			System.Data.CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(resultTable, Formatting.Indented);
		return json;
	}	

	public const string QueryStatement = @"
SELECT
	MIN(HisWord.Dated) HisWordDated,
	HisWord.HisWordID HisWordID,
	COUNT(DISTINCT Software.SoftwareID) SoftwareCount,
	COUNT(DISTINCT APass.APassID) APassCount,
	COUNT(DISTINCT Remember.RememberID) RememberCount,
	COUNT(DISTINCT ActToGod.ActToGodID) ActToGodCount
FROM WordEngineering..HisWord HisWord
FULL OUTER JOIN	WordEngineering..Software ON HisWord.HisWordID = Software.HisWordID
FULL OUTER JOIN WordEngineering..APass ON HisWord.HisWordID = APass.HisWordID
FULL OUTER JOIN WordEngineering..Remember ON HisWord.HisWordID = Remember.HisWordID
FULL OUTER JOIN WordEngineering..ActToGod ON HisWord.HisWordID = ActToGod.HisWordID
WHERE		HisWord.HisWordID IS NOT NULL
GROUP BY	HisWord.HisWordID
HAVING
			COUNT(DISTINCT Software.SoftwareID) > 0
OR			COUNT(DISTINCT APass.APassID) > 0
OR			COUNT(DISTINCT Remember.RememberID) > 0
OR			COUNT(DISTINCT ActToGod.ActToGodID) > 0
ORDER BY
	SoftwareCount DESC,
	APassCount DESC,
	RememberCount DESC,
	ActToGodCount DESC
	";
}


