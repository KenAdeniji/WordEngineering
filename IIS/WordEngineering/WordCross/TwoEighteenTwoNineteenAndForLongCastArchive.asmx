<%@ WebService Language="C#" Class="TwoEighteenTwoNineteenAndForLongCastWebService" %>
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
///	2022-07-29	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class TwoEighteenTwoNineteenAndForLongCastWebService : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string Query
	(
		int bookIDFrom,
		int bookIDUntil,
		int chapterIDFrom,
		int chapterIDUntil,
		int verseIDFrom,
		int verseIDUntil,
		String bibleVersion
	)
    {
		StringBuilder sb = new StringBuilder();
		
		sb.AppendFormat
		(
			SelectQuery,
			bibleVersion
		);
		
		if (bookIDFrom > 0)
		{
			sb.AppendFormat(" AND BookID >= {0}", bookIDFrom);
		}

		if (bookIDUntil > 0)
		{
			sb.AppendFormat(" AND BookID <= {0}", bookIDUntil);
		}

		if (chapterIDFrom > 0)
		{
			sb.AppendFormat(" AND ChapterID >= {0}", chapterIDFrom);
		}

		if (chapterIDUntil > 0)
		{
			sb.AppendFormat(" AND ChapterID <= {0}", chapterIDUntil);
		}
		
		if (verseIDFrom > 0)
		{
			sb.AppendFormat(" AND VerseID >= {0}", verseIDFrom);
		}

		if (verseIDUntil > 0)
		{
			sb.AppendFormat(" AND VerseID <= {0}", verseIDUntil);
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
		FROM Bible..Scripture_View
		WHERE 1 = 1
	";
}
