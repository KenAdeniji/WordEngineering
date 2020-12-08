<%@ WebService Language="C#" Class="ToPretendThereIsNoOneElseAboveYouIsToSeeNoOneBelowYou" %>

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

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2016-11-15 	Created. ToPretendThereIsNoOneElseAboveYouIsToSeeNoOneBelowYou.asmx
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class ToPretendThereIsNoOneElseAboveYouIsToSeeNoOneBelowYou : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }

   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		int		groupByIndex,
		string	bibleVersion
	)
    {
		String	sqlStatement = String.Format
		(
			SQLSelect,
			bibleVersion,
			GroupBy[groupByIndex]
		);
		
        DataSet resultSet = (DataSet) DataCommand.DatabaseCommand
		(
			sqlStatement,
			System.Data.CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(resultSet, Formatting.Indented);
		return json;
    }

	public static readonly string[] GroupBy = new string[] 
	{
		"Testament", 
		"BookID",
		"BookID, ChapterID",
	};
	
	public const String SQLSelect =
	@"	
		SELECT 
			ScriptureReference,
			{0} AS VerseText
		FROM
			Bible..Scripture_View
		WHERE
			verseIdSequence IN
			(
				SELECT
					MIN(verseIdSequence)
				FROM
					Bible..Scripture_View
				GROUP BY
					{1}
			)
			OR
			verseIdSequence IN
			(
				SELECT
					MAX(verseIdSequence)
				FROM
					Bible..Scripture_View
				GROUP BY
					{1}
			)
		ORDER BY
			verseIdSequence
	";
}
