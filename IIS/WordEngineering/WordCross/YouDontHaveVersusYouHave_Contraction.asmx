<%@ WebService Language="C#" Class="YouDontHaveVersusYouHave_ContractionWebService" %>

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

///<summary>
///	2024-03-03T16:34:00...2024-03-03T19:19:00	Created.
///	2024-03-03T18:37:00...2024-03-03T19:19:00	Truncated string.
///	WHERE Minor LIKE '%' + SUBSTRING( Commentary, 1, 4000 ) + '%'
///	WHERE Word LIKE '%' + SUBSTRING( Commentary, 1, 4000 ) + '%'
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class YouDontHaveVersusYouHave_ContractionWebService : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query()
    {
		DataTable dataTable = (DataTable) DataCommand.DatabaseCommand
		(
			QueryStatement,
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		return json;
	}
	
	public const string QueryStatement = @" 
	SELECT 
		Minor Phrase, 
		(
			SELECT COUNT(*) 
			FROM WordEngineering..HisWord 
			WHERE Word LIKE '%' + SUBSTRING( Minor, 1, 4000 ) + '%'
		) PhraseVerseCount,
		(
			SELECT CONVERT(Date, MIN(Dated))
			FROM WordEngineering..HisWord 
			WHERE Word LIKE '%' + SUBSTRING( Minor, 1, 4000 ) + '%'
		) PhraseFrom,
		(
			SELECT CONVERT(Date, MAX(Dated))
			FROM WordEngineering..HisWord 
			WHERE Word LIKE '%' + SUBSTRING( Minor, 1, 4000 ) + '%'
		) PhraseUntil,
		Commentary Opposite, 
		(
			SELECT COUNT(*) 
			FROM WordEngineering..HisWord 
			WHERE Word LIKE '%' + SUBSTRING( Commentary, 1, 4000 ) + '%'
		) OppositeVerseCount,
		(
			SELECT CONVERT(Date, MIN(Dated))
			FROM WordEngineering..HisWord 
			WHERE Word LIKE '%' + SUBSTRING( Commentary, 1, 4000 ) + '%'
		) OppositeFrom,
		(
			SELECT CONVERT(Date, MAX(Dated))
			FROM WordEngineering..HisWord 
			WHERE Word LIKE '%' + SUBSTRING( Commentary, 1, 4000 ) + '%'
		) OppositeUntil
		FROM WordEngineering..ActToGod 
		WHERE Major = 'Contraction'
		ORDER BY Minor, Commentary	
	";
}
