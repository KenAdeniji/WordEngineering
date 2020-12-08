 <%@ WebService Language="C#" Class="LivedBeyondTheWildernessWebService" %>
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
///	2019-08-13	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class LivedBeyondTheWildernessWebService : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string Query
	(
		String bibleVersion,
		String bibleWord,
		String groupBy
	)
    {
		StringBuilder sb = new StringBuilder();
		
		String scriptureReference = "BookTitle";
		
		if (groupBy == "BookTitle, ChapterID")
		{
			scriptureReference = "BookTitle + ' ' + CONVERT(VARCHAR, ChapterID)";
		}
		
		sb.AppendFormat
		(
			SelectQuery,
			bibleVersion,
			bibleWord,
			groupBy,
			scriptureReference
		);
		
		DataSet dataSet = (DataSet)DataCommand.DatabaseCommand
		(
			sb.ToString(),
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}
	
	public const String SelectQuery = @"
		SELECT BookID, {3} AS ScriptureReference, COUNT(*) AS Count
		FROM Bible..Scripture
		WHERE {0} LIKE '%{1}%'
		GROUP BY BookID, {2}
		ORDER BY BookID, {2}
	";
}
