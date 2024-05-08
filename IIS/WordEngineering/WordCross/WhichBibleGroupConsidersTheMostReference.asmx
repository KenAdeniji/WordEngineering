<%@ WebService Language="C#" Class="WhichBibleGroupConsidersTheMostReferenceWebService" %>

using System;
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
///	2024-05-08T07:58:00	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WhichBibleGroupConsidersTheMostReferenceWebService : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String	bibleVersion
	)
    {
		String queryStatement = String.Format
		(
			QueryFormat,
			bibleVersion
		);	

		DataSet resultSet = (DataSet) DataCommand.DatabaseCommand
		(
			queryStatement,
			System.Data.CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(resultSet, Formatting.Indented);
		return json;
	}	

	public const string QueryFormat = @"
		SELECT
			BookTitle,
			BookID,
			COUNT(*) Occurrences,
			COUNT(DISTINCT ChapterID) Chapters,
			COUNT(*) / COUNT(DISTINCT ChapterID) BookChapterAverage
		FROM
			Bible..Scripture_View
		WHERE 
			EXISTS (SELECT * FROM BibleDictionaryWord_View WHERE {0} LIKE '%' + DictionaryWord + '%')
		GROUP BY
			BookTitle,
			BookID
		ORDER BY
			Occurrences DESC
	";
}


