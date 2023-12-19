<%@ WebService Language="C#" Class="WhatDidIFitIntoAPlaceWebService" %>

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

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessCode;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

using Newtonsoft.Json;

///<summary>
///	2023-12-18T19:59:00...2023-12-18T20:30:00 Created.
///	bibleWord, for example, Ark, Temple, Jerusalem, Judah, Israel
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WhatDidIFitIntoAPlaceWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string Query
	(
		string	bibleWord,
		string	bibleVersion,
		bool	wholeWords	
	)
    {
		StringBuilder sb = new StringBuilder();
		String[] bibleWords = bibleWord.Split
		(
			InformationInTransit.ProcessLogic.BibleWordHelper.SplitSeparator,
			StringSplitOptions.RemoveEmptyEntries
		);
		String bibleWordCurrent;
		for 
		(
			int bibleWordIndex = 0, bibleWordLength = bibleWords.Length;
			bibleWordIndex < bibleWordLength;
			++bibleWordIndex
		)
		{
			bibleWordCurrent = bibleWords[bibleWordIndex].Trim();
			if (sb.Length > 0)
			{
				sb.Append(" OR ");
			}
			sb.AppendFormat
			(
				wholeWords ? 
					WholeWordsWildCardSearchQueryFormat : 
					NotWholeWordsWildCardSearchQueryFormat,
				bibleWordCurrent,
				bibleVersion
			);	
		}
		String queryStatement = String.Format
		(
			QueryFormat,
			bibleVersion,
			sb.ToString()
		);
		DataTable resultTable = (DataTable) DataCommand.DatabaseCommand
		(
			queryStatement,
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(resultTable, Formatting.Indented);
		return json;
    }


	public const String WholeWordsWildCardSearchQueryFormat = " {1} LIKE '%[^a-z]{0}[^a-z]%' ";
	public const String NotWholeWordsWildCardSearchQueryFormat = " {1} LIKE '%{0}%' ";

	public const String QueryFormat = 
	@"
		SELECT 
			{0}	VerseText,
			ScriptureReference,
			VerseIDSequence
		FROM 	Bible..Scripture_View
		WHERE	{1}
		ORDER BY
			VerseIDSequence
	";
}
