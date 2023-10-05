<%@ WebService Language="C#" Class="DrawingParallelWebService" %>

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

using Newtonsoft.Json;

using InformationInTransit.DataAccess;

///<summary>
///	2021-01-25 	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class DrawingParallelWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String	bibleWord
	)
    {
		DataTable dataTable = (DataTable) DataCommand.DatabaseCommand
        (
            String.Format(SQLSelectStatement, bibleWord),
            CommandType.Text,
            DataCommand.ResultType.DataTable
        );
		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		return json;
    }

	public const string SQLSelectStatement = @"
		SELECT
			Minor, Actor, Commentary, ScriptureReference
		FROM
			WordEngineering..ActToGod
		WHERE
			Major = 'Drawing parallel.'
		AND	
		(
				Minor LIKE '%{0}%'
			OR	Actor LIKE '%{0}%'
			OR	Commentary LIKE '%{0}%'
		)
		ORDER BY
			Minor, Actor
	";
}
