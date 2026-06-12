<%@ WebService Language="C#" Class="ActToGod_BarnesAndNoble_BN_DublinPleasanton_DateOfOpeningWebService" %>

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

using System.Text;
using	System.Text.RegularExpressions;

using InformationInTransit.DataAccess;

using Newtonsoft.Json;

///<summary>
///	2026-06-11T22:26:00 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class ActToGod_BarnesAndNoble_BN_DublinPleasanton_DateOfOpeningWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string Query()
    {
		DataTable selectTable = (DataTable) DataCommand.DatabaseCommand
		(
			SQLSelectStatement,
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(selectTable, Formatting.Indented);
		return json;
    }

	public const String SQLSelectStatement = @"
		SELECT 
			Major,
			MIN(Dated)		DatedMinimum,
			MAX(Dated)		DatedMaximum,
			COUNT(Major)	MajorCount
		FROM
			WordEngineering..ActToGod
		GROUP BY
			Major
		ORDER BY 
			MIN(Dated) ASC
	";
}
