<%@ WebService Language="C#" Class="TheVoiceOfGermanyTheEndOfGermanyWebService" %>

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
using System.Data.Odbc;
using System.Data.SqlClient;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2021-09-18T20:00:00 Created.
/// 2010-08-30T10:08:00	The voice of Germany, the end of Germany.			
/// http://stackoverflow.com/questions/27827376/sql-count-number-of-words-in-field
/// 2021-09-18T20:00:00 ... 2021-09-19 04:31:18.207 Wait error.
/// 2021-09-19T09:32:00 Query restriction by count of words.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class TheVoiceOfGermanyTheEndOfGermanyWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		int wordCount
	)
    {
		DataTable resultSet = (DataTable) DataCommand.DatabaseCommand
		(
			String.Format(QueryStatement, wordCount),
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(resultSet, Formatting.Indented);
		return json;
    }
	
	public const string QueryStatement = @"
SELECT HisWordID, Dated, Word, Commentary, ScriptureReference, URI, AlphabetSequenceIndex, AlphabetSequenceIndexScriptureReference
FROM WordEngineering..HisWord_View
WHERE {0} = LEN(RTRIM(LTRIM(REPLACE(Word,'  ', ' ')))) - LEN(REPLACE(RTRIM(LTRIM(REPLACE(Word, '  ', ' '))), ' ', '')) + 1
ORDER BY HisWordID DESC
";	
	
}
