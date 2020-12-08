<%@ WebService Language="C#" Class="NorthCarolinaWantToHaveOurOwnNavy_CarolWasVotingForChiefLeyeWebService" %>

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
///	2019-01-30	Created.	http://alistapart.com/article/taming-data-with-javascript
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class NorthCarolinaWantToHaveOurOwnNavy_CarolWasVotingForChiefLeyeWebService : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query(int groupID)
    {
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			Queries[groupID],
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}
	public static readonly String[] Queries = new String[]
	{
		"SELECT ContactID, COUNT(*) AS Count FROM WordEngineering..HisWord WHERE ContactID IS NOT NULL GROUP BY ContactID HAVING COUNT(*) > 0 ORDER BY Count DESC",
		"SELECT Convert(Date, Dated) AS Dated, COUNT(*) AS Count FROM WordEngineering..HisWord GROUP BY Convert(Date, Dated) ORDER BY Count DESC",
		"SELECT URI, COUNT(*) AS Count FROM WordEngineering..HisWord WHERE URI IS NOT NULL GROUP BY URI HAVING COUNT(*) > 0 ORDER BY Count DESC",
		"SELECT Year(Dated) AS Year, COUNT(*) AS Count FROM WordEngineering..HisWord GROUP BY Year(Dated) ORDER BY Count DESC",
		"SELECT CAST(YEAR(dated) AS VARCHAR(4)) + '-' + right('00' + CAST(MONTH(dated) AS VARCHAR(2)), 2) AS YearMonth, COUNT(*) AS Count FROM WordEngineering..HisWord GROUP BY CAST(YEAR(dated) AS VARCHAR(4)) + '-' + right('00' + CAST(MONTH(dated) AS VARCHAR(2)), 2) ORDER BY Count DESC",
		"SELECT CAST(YEAR(dated) AS VARCHAR(4)) + 'Q' + CAST(datepart(qq, dated) AS VARCHAR(1)) AS YearQuarter, COUNT(*) AS Count FROM WordEngineering..HisWord GROUP BY CAST(YEAR(dated) AS VARCHAR(4)) + 'Q' + CAST(datepart(qq, dated) AS VARCHAR(1)) ORDER BY Count DESC",
		"SELECT CAST(YEAR(dated) AS VARCHAR(4)) + 'W' + right('00' + CAST(datepart(ISO_WEEK, dated) AS VARCHAR(2)), 2) AS YearMonth, COUNT(*) AS Count FROM WordEngineering..HisWord GROUP BY CAST(YEAR(dated) AS VARCHAR(4)) + 'W' + right('00' + CAST(datepart(ISO_WEEK, dated) AS VARCHAR(2)), 2) ORDER BY Count DESC"
	};
}
