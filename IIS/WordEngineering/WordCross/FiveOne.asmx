<%@ WebService Language="C#" Class="FiveOneWebService" %>
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
using InformationInTransit.ProcessLogic;

///<summary>
///	2022-08-11T07:51:00	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class FiveOneWebService : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string Query
	(
		string word,
		String bibleVersion
	)
    {
		string[] words = BibleWordHelper.Split(word);
		StringBuilder sb = new StringBuilder();

		sb.AppendFormat
		(
			SelectQuery,
			bibleVersion
		);
		
		for 
		(
			int wordIndex = 1, wordLength = words.Length;
			wordIndex < wordLength;
			++wordIndex
		)
		{
			sb.AppendFormat
			(
				" AND CHARINDEX('{0}', {2}) < CHARINDEX('{1}', {2}) ",
				words[wordIndex - 1],
				words[wordIndex],
				bibleVersion
			);
		}	

		sb.AppendFormat
		(
			" AND CHARINDEX('{0}', {1}) > 0 ",
			words[0],
			bibleVersion
		);

		sb.AppendFormat(" ORDER BY VerseIDSequence ");
		
		sb.ToString();
		
		DataTable dataTable = (DataTable)DataCommand.DatabaseCommand
		(
			sb.ToString(),
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		return json;
	}
	
	public const String SelectQuery = @"
		SELECT ScriptureReference, {0} AS VerseText, VerseIDSequence
		FROM Bible..Scripture_View
		WHERE 1 = 1
	";
}
