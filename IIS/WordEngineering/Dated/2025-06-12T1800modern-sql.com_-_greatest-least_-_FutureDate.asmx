<%@ WebService Language="C#" Class="FutureDateWebService" %>

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

using InformationInTransit.DataAccess;

using Newtonsoft.Json;

/*
	http://modern-sql.com/caniuse/greatest-least
*/
///<summary>
///	2025-06-12T18:00:00 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class FutureDateWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string Query
	(
	)
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
		SELECT	'2008-03-11' AS DatedFrom, '2008-09-11' AS DatedUntil, LEAST('2008-03-11', '2008-09-22') DatedLeast, GREATEST('2008-03-11', '2008-09-22') DatedGreatest, DATEDIFF(DAY, '2008-03-11', '2008-09-22') AS FromUntil
		UNION
		SELECT	'2021-01-04' AS DatedFrom, '2024-12-31' AS DatedUntil, LEAST('2021-01-04', '2024-12-31') DatedLeast, GREATEST('2021-01-04', '2024-12-31') DatedGreatest, DATEDIFF(DAY, '2021-01-04', '2024-12-31') AS FromUntil
	";
}
