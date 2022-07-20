<%@ WebService Language="C#" Class="PeopleLivingAlikeWebService" %>

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
using InformationInTransit.ProcessCode;
using InformationInTransit.UserInterface;

///<summary>
///	2022-07-20 Created. Find all the same values, in a column?
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class PeopleLivingAlikeWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String	filterColumnName,
		String	bibleWord
	)
    {
		DataTable resultTable = (DataTable) DataCommand.DatabaseCommand
		(
			String.Format
			( 
				QueryStatement,
				filterColumnName,
				bibleWord
			),
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		string json = JsonConvert.SerializeObject(resultTable, Formatting.Indented);
		return json;
    }

	public const string QueryStatement = @"
SELECT
	BibleExact.BibleWord,
	{0} AS Filter
FROM
	Bible..Exact AS BibleExact
WHERE
	BibleExact.{0} IN
	(
		SELECT BibleExtra.{0}
		FROM Bible..Exact AS BibleExtra 
		WHERE BibleExtra.BibleWord LIKE '%{1}%'
		GROUP BY BibleExtra.{0}
		HAVING COUNT( * ) > 1
	)	
ORDER BY
	BibleWord	
";
	
}

