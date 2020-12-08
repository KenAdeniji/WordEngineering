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
///	2019-08-06	Created.
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
		int bookID,
		int chapterID,
		int verseID,
		String bibleVersion
	)
    {
		StringBuilder sb = new StringBuilder();
		
		sb.AppendFormat
		(
			SelectQuery,
			bibleVersion
		);
		
		if (bookID > 0)
		{
			sb.AppendFormat(" AND BookID = {0}", bookID);
		}

		if (chapterID > 0)
		{
			sb.AppendFormat(" AND ChapterID = {0}", chapterID);
		}
		
		if (verseID > 0)
		{
			sb.AppendFormat(" AND VerseID = {0}", verseID);
		}
		
		sb.AppendFormat(" ORDER BY VerseIDSequence ");
		
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
		SELECT ScriptureReference, {0} AS VerseText
		FROM Bible..Scripture
		WHERE 1 = 1
	";
}
