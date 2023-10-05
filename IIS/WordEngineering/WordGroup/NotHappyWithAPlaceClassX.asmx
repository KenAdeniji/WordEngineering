<%@ WebService Language="C#" Class="NotHappyWithAPlaceClassXWebService" %>

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
///	2018-11-22 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class NotHappyWithAPlaceClassXWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		string	bibleWord,
		string	logic,
		string	bibleNumber,
		string	bibleVersion
	)
    {
		String selectQuery = null;
		StringBuilder sb = new StringBuilder();
		
		switch(logic)
		{
			case "bibleWordOnly":
				selectQuery = String.Format(SelectBibleWordOnlyFormat, bibleVersion, bibleWord);
				break;
			case "numberIncluded":
				foreach(String amount in Numbers)
				{
					if (sb.Length > 0)
					{
						sb.Append(" OR ");
					}
					sb.AppendFormat(BibleNumberFormat, bibleVersion, amount);
				}	
				selectQuery = String.Format(SelectNumberInSeriesFormat, bibleVersion, bibleWord, sb);
				break;
			case "withNumberInFigure":
				selectQuery = String.Format(SelectWithNumberInFigureFormat, bibleVersion, bibleWord, bibleNumber);
				break;
			case "withNumberInText":
				selectQuery = String.Format(SelectWithNumberInTextFormat, bibleVersion, bibleWord, bibleNumber);
				break;
		}
		
		//return selectQuery;
		
		DataSet result = (DataSet) DataCommand.DatabaseCommand
		(
			selectQuery,
			System.Data.CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(result, Formatting.Indented);
		return json;
    }

    public static string[] Numbers = 
	{ 
		"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen",
		"twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety",
		"thousand", "million", "billon", "trillion", "quadrillion"
	};
	
	public const String SelectBibleWordOnlyFormat = "SELECT ScriptureReference, {0} AS VerseText FROM Bible..Scripture_View WHERE {0} LIKE '%{1}%' ORDER BY BookID, ChapterID, VerseID";
	public const String SelectNumberInSeriesFormat = "SELECT ScriptureReference, {0} AS VerseText FROM Bible..Scripture_View WHERE {0} LIKE '%{1}%' AND ({2}) ORDER BY BookID, ChapterID, VerseID";	
	public const String SelectWithNumberInFigureFormat = 
		@"
			DECLARE @scriptureReferenceVariable VARCHAR(MAX)
			SELECT @scriptureReferenceVariable = ScriptureReference
			FROM WordEngineering..NumberSign
			WHERE Number = {2}
			DECLARE @scriptureReferenceTable Table
			(
				ScriptureReference VARCHAR(MAX)
			)	
			INSERT @scriptureReferenceTable(ScriptureReference)
			SELECT trim(value)
			FROM STRING_SPLIT(@scriptureReferenceVariable, ',')
			SELECT ScriptureReference, {0} AS VerseText 
				FROM Bible..Scripture_View 
				WHERE {0} LIKE '%{1}%' AND 
				ScriptureReference IN (SELECT sct.ScriptureReference FROM @scriptureReferenceTable AS sct)
				ORDER BY BookID, ChapterID, VerseID
		";	
	public const String SelectWithNumberInTextFormat = "SELECT ScriptureReference, {0} AS VerseText FROM Bible..Scripture_View WHERE {0} LIKE '%{1}%' AND {0} LIKE '%{2}%' ORDER BY BookID, ChapterID, VerseID";
	public const String BibleNumberFormat = "{0} LIKE '%[^a-z]{1}[^a-z]%' ";	
}
		