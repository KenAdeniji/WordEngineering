<%@ WebService Language="C#" Class="ToMostExpectMyNameWebService" %>

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
///	2019-02-02	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class ToMostExpectMyNameWebService : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String	bibleVersion,
		int bookID,
		int	chapterID,
		int	verseID
	)
    {
		StringBuilder sb = new StringBuilder();
		sb.AppendFormat(QueryFormat, bibleVersion);
		if (bookID >= 1)
		{
			sb.AppendFormat(" AND BookID = {0}", bookID);
		}
		if (chapterID >= 1)
		{
			sb.AppendFormat(" AND ChapterID = {0}", chapterID);
		}
		if (verseID >= 1)
		{
			sb.AppendFormat(" AND VerseID = {0}", verseID);
		}
		sb.Append(" ORDER BY BookID, ChapterID, VerseID ");
		DataTable dataTable = (DataTable) DataCommand.DatabaseCommand
		(
			sb.ToString(),
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		return json;
	}
	public const String QueryFormat = "SELECT ScriptureReference, {0} AS VerseText FROM Bible..Scripture WHERE 1=1";
}
