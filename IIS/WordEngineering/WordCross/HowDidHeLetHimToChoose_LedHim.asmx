<%@ WebService Language="C#" Class="HowDidHeLetHimToChoose_LedHimWebService" %>

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
using InformationInTransit.ProcessCode;

///<summary>
///	2024-07-06T13:46:00	Created.
///	2024-07-06T13:46:00...2024-07-06T13:54:00 1st select query.	
///	2024-07-06T13:54:00...2024-07-06T14:05:00 1st select query, debug.
///	2024-07-06T15:54:00...2024-07-06T18:10:00 2nd select query, debug.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class HowDidHeLetHimToChoose_LedHimWebService : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String 	bibleVersion
	)
    {
		StringBuilder sb = new StringBuilder();
		
		for 
		(
			int index = 0, length = InformationInTransit.ProcessCode.FiveWs.JaggedArray2.Length;
			index < length;
			++index
		)
		{
			if (sb.Length > 0)
			{
				sb.Append(" UNION ");
			}
			sb.AppendFormat
			(
				QueryStatementBibleScripture_View_Format,
				InformationInTransit.ProcessCode.FiveWs.QueryLike
				(
					bibleVersion,
					InformationInTransit.ProcessCode.FiveWs.JaggedArray2[index][0]
				),
				InformationInTransit.ProcessCode.FiveWs.JaggedArray2[index][0]		
			);	
		} 
		
		String queryStatement = QueryStatementBibleExact + sb.ToString();
	
		DataSet resultSet = (DataSet) DataCommand.DatabaseCommand
		(
			queryStatement,
			System.Data.CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(resultSet, Formatting.Indented);
		return json;
	}	

	public const string QueryStatementBibleExact = @"
SELECT
	BibleWord,
	FirstOccurrenceScriptureReference,
	LastOccurrenceScriptureReference,
	Difference,
	FrequencyOfOccurrence
FROM
	Bible..Exact
WHERE
	BibleWord IN ('What', 'When', 'Where', 'Who', 'Why')
ORDER BY
	BibleWord
;	
	";
	
	public const string QueryStatementBibleScripture_View_Format = @"	
SELECT
	'{1}' BibleWord,
    (
		SELECT		TOP 1 ScriptureReference
	    FROM		Bible..Scripture_View
		{0}
		ORDER BY	VerseIDSequence
	)	FirstOccurrenceScriptureReference,
    (
		SELECT		TOP 1 ScriptureReference
	    FROM		Bible..Scripture_View
		{0}
		ORDER BY	VerseIDSequence DESC
	)	LastOccurrenceScriptureReference,
    (
		SELECT		MAX(VerseIDSequence) - MIN(VerseIDSequence)
	    FROM		Bible..Scripture_View
		{0}
	)	Difference,
    (
		SELECT		COUNT(*)
	    FROM		Bible..Scripture_View
		{0}
	)	FrequencyOfOccurrence
FROM 
	Bible..Scripture_View
	";
}


