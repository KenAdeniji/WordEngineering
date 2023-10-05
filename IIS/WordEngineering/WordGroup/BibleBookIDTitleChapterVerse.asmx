<%@ WebService Language="C#" Class="BibleBookIDTitleChapterVerseWebService" %>

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
///	2018-09-13 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class BibleBookIDTitleChapterVerseWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query()
	{
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			SQLStatement,
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
    }
	public const String SQLStatement = 
	@"
		SELECT
			BookID AS ID,
			BookTitle AS Title,
			COUNT(DISTINCT ChapterID) AS Chapters,
			COUNT(VerseID) AS Verses
		FROM
			Bible..Scripture_View
		GROUP BY
			BookID,
			BookTitle
		ORDER BY
			BookID
	";
}
