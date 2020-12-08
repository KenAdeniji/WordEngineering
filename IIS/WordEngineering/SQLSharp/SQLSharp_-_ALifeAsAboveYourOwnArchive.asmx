<%@ WebService Language="C#" Class="SQLSharpALifeAsAboveYourOwnWebService" %>

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
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2020-06-14T20:00:00	Created.	sqlsharp.com
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class SQLSharpALifeAsAboveYourOwnWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String	bibleVersion,
		String	wordLength
	)
    {
		String[] wordsLength = wordLength.Split
		(
			BibleWordHelper.SplitSeparator, StringSplitOptions.RemoveEmptyEntries
		);
		
		StringBuilder sb = new StringBuilder();
		
		foreach(String wordLengthCurrent in wordsLength)
		{
			sb.AppendFormat(RestrictionFormat, wordLengthCurrent);
		}	
	
		String sqlStatement = String.Format(QueryFormat, sb);
		
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			sqlStatement,
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
    }
	
	public const string QueryFormat = 
	@"
SELECT	ScriptureReference, KingJamesVersion AS VerseText
FROM	Bible..Scripture
WHERE	SQLSharp.SQL#.RegEx_IsMatch
(
	REPLACE
	(
		REPLACE
		(
			REPLACE
			(
				REPLACE 
				(
					REPLACE
					(
						REPLACE(KingJamesVersion, ' ', '1'),
						',', '1'
					),
					';', '1'
				),
				':', '1'
			),
			'.', '1'
		),
		'and', '1'
	),
	'{0}',
	1,
	'IgnoreCase'
) >= 1
	";
	
	public const string RestrictionFormat = @"[^a-z][a-z]{{{0}}}[^a-z]";
	
}
