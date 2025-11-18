<%@ WebService Language="C#" Class="AHomeIClaimWebService" %>

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

///<summary>
///	2016-09-01	Created.	AHomeIClaim.asmx
///	2025-11-12	@"EXEC WordEngineering..usp_AHomeIClaim '{0}', '{1}'";
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class AHomeIClaimWebService : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		string	firstScriptureReferenceVerse,
		string	secondScriptureReferenceVerse
	)	
    {
		//string selectStatement = String.Format(SelectStatement, firstScriptureReferenceVerse, secondScriptureReferenceVerse);
		
		DataTable dataTable = (DataTable) DataCommand.DatabaseCommand
		(
			String.Format(StoredProcedure, firstScriptureReferenceVerse, secondScriptureReferenceVerse),
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		return json;
	}
	
	public const string SelectStatement = @"
		SELECT 
			NULL AS Metric,
			ChapterIDSequence,
			ChapterIDSequencePercent,
			VerseIDSequence,
			VerseIDSequencePercent
		FROM Bible..Scripture_View
		WHERE ScriptureReference IN ('{0}', '{1}') 
		ORDER BY verseIDSequence
	";
	
	public const string StoredProcedure = @"EXEC WordEngineering..usp_AHomeIClaim '{0}', '{1}'";
}
