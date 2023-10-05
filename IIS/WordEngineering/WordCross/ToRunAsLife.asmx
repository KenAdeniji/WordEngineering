<%@ WebService Language="C#" Class="ToRunAsLifeWebService" %>

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
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2023-05-30T19:46:00 Created.
///	2023-05-30T21:18:00 SQL.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class ToRunAsLifeWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String	bibleWord,
		String	bibleVersion
	)
    {
		StringBuilder sb = new StringBuilder();
		String[] bibleWords = bibleWord.Split
		(
			BibleWordHelper.SplitSeparator,
			StringSplitOptions.RemoveEmptyEntries
		);
		foreach(String currentWord in bibleWords)
		{
			if (sb.Length > 0 )
			{
				sb.Append(" UNION ");
			}
			
			sb.AppendFormat
			(
				QueryStatement,
				bibleVersion,
				currentWord
			);	
		}
		
		//return sb.ToString();
		
		DataTable resultTable = (DataTable) DataCommand.DatabaseCommand
		(
			sb.ToString(),
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(resultTable, Formatting.Indented);
		return json;
    }
	
	public const String QueryStatement =
	@"
SELECT
	'{1}' AS BibleWord,
	(
		SELECT COUNT(*)
		FROM
			Bible..Scripture_View
		CROSS APPLY
			string_split
			(
				Bible..Scripture_View.{0},
				' '
			) AS tableView
		WHERE
			tableView.Value = '{1}'
	)	AS WordOccurrence,
	(
		SELECT TOP 1 ScriptureReference
		FROM
			Bible..Scripture_View
		WHERE
			 Bible..Scripture_View.{0} LIKE '%[^a-z]{1}[^a-z]%'
		ORDER BY
			VerseIDSequence	
	)	AS ScriptureReferenceFirst,
	(
		SELECT TOP 1 VerseIDSequence
		FROM
			Bible..Scripture_View
		WHERE
			 Bible..Scripture_View.{0} LIKE '%[^a-z]{1}[^a-z]%'
		ORDER BY
			VerseIDSequence	
	)	AS VerseIDSequenceFirst,
	(
		SELECT TOP 1 ScriptureReference
		FROM
			Bible..Scripture_View
		WHERE
			 Bible..Scripture_View.{0} LIKE '%[^a-z]{1}[^a-z]%'
		ORDER BY
			VerseIDSequence DESC	
	)	AS ScriptureReferenceLast,
	(
		SELECT TOP 1 VerseIDSequence
		FROM
			Bible..Scripture_View
		WHERE
			 Bible..Scripture_View.{0} LIKE '%[^a-z]{1}[^a-z]%'
		ORDER BY
			VerseIDSequence	DESC
	)	AS VerseIDSequenceLast
	";
}
