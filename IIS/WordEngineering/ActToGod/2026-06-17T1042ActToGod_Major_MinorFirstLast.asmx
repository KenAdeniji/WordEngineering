<%@ WebService Language="C#" Class="ActToGod_Major_MinorFirstLastWebService" %>

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
///	2026-06-18T14:51:00...2026-06-18T16:41:00 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class ActToGod_Major_MinorFirstLastWebService : System.Web.Services.WebService
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
        (
            SELECT TOP 1 Minor
            FROM WordEngineering..ActToGod ActToGod2
            WHERE ActToGod2.Major = ActToGod1.Major
            ORDER BY ActToGodID
        ) MinorFirst,
        (
            SELECT TOP 1 Dated
            FROM WordEngineering..ActToGod ActToGod2
            WHERE ActToGod2.Major = ActToGod1.Major
            ORDER BY ActToGodID
        ) DatedFirst,
        (
            SELECT TOP 1 Minor
            FROM WordEngineering..ActToGod ActToGod2
            WHERE ActToGod2.Major = ActToGod1.Major
            ORDER BY ActToGodID DESC
        ) MinorLast,
        (
            SELECT TOP 1 Dated
            FROM WordEngineering..ActToGod ActToGod2
            WHERE ActToGod2.Major = ActToGod1.Major
            ORDER BY ActToGodID DESC
        ) DatedLast
    FROM
        WordEngineering..ActToGod ActToGod1
    GROUP BY
        Major
	";
}
