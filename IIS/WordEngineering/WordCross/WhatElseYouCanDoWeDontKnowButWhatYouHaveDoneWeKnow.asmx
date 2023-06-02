<%@ WebService Language="C#" Class="WhatElseYouCanDoWeDontKnowButWhatYouHaveDoneWeKnowWebService" %>

using System;
using System.Data;
using System.Numerics;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;

using Newtonsoft.Json;

using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2023-06-01T16:31:00 Created. What else You can do we don't know ... but what You have done we know.
///	2023-06-01T16:50:00	http://LarryRockoff.com The Language of SQL
///	2023-06-01T16:50:00	http://learn.microsoft.com/en-us/sql/t-sql/queries/select-group-by-transact-sql?view=sql-server-ver16
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WhatElseYouCanDoWeDontKnowButWhatYouHaveDoneWeKnowWebService : System.Web.Services.WebService
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
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(resultTable, Formatting.Indented);
		return json;
    }
	
	public const String QueryStatement =
	@"
		SELECT
			Testament,
			BookTitle,
			ChapterID,
			COUNT(VerseID) AS CountVerses
		FROM
			Bible..Scripture_View
		GROUP BY ROLLUP
		(
			Testament,
			BookTitle,
			ChapterID
		)	
	";
}
