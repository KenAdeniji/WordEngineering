<%@ WebService Language="C#" Class="WordOccurrencesWebService" %>

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

using System.Linq;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;

///<summary>
///	2020-01-08	Created.
///	2020-01-08	http://www.sql-server-helper.com/functions/count-words.aspx
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WordOccurrencesWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
        String bibleVersion,
		String bibleWord
	)
    {
		DataTable dataTable = (DataTable) DataCommand.DatabaseCommand
		(
			String.Format
			(
				SelectFormat,
				bibleVersion,
				bibleWord
			),
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		return json;
    }
	
	public const string SelectFormat = @"
		SELECT
			'{1}' AS BibleWord,
			COUNT
			(
				(LEN({0}) - 
				LEN(REPLACE({0}, '{1}', ''))) /
				LEN('{1}')
			)	
			AS Occurrence,
			(
				SELECT ScriptureReference
				FROM Bible..Scripture_View
				WHERE VerseIDSequence =
					(
						SELECT TOP 1 VerseIDSequence
						FROM	Bible..Scripture AS SubQuery
						WHERE	SubQuery.{0} LIKE '%[^a-z]{1}[^a-z]%'	
						ORDER BY VerseIDSequence
					)	
			)
			AS FirstScriptureReference,
			(
				SELECT ScriptureReference
				FROM Bible..Scripture_View
				WHERE VerseIDSequence =
					(
						SELECT TOP 1 VerseIDSequence
						FROM	Bible..Scripture AS SubQuery
						WHERE	SubQuery.{0} LIKE '%[^a-z]{1}[^a-z]%'	
						ORDER BY VerseIDSequence DESC
					)	
			)
			AS LastScriptureReference
		FROM
			Bible..Scripture_View
		WHERE
			{0} LIKE '%[^a-z]{1}[^a-z]%'
	";
}	
