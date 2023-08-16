<%@ WebService Language="C#" Class="ComingToAManOnlyBecauseOfHelpWebService" %>

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

using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2023-08-15T18:22:00 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class ComingToAManOnlyBecauseOfHelpWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String	bibleVersion,
		String	bibleWord
	)
    {
		DataTable resultTable = (DataTable) DataCommand.DatabaseCommand
		(
			String.Format
			(
				QueryStatement,
				bibleVersion,
				bibleWord
			),
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(resultTable, Formatting.Indented);
		return json;
    }
	
	public const String QueryStatement =
	@"
SELECT
	BookID,
	BookTitle,
	COUNT(*) Occurrences
FROM
	Bible..Scripture_View
WHERE
	{0} LIKE '%{1}%'
GROUP BY
	BookID,
	BookTitle
ORDER BY
	BookID,
	BookTitle
	";
}

