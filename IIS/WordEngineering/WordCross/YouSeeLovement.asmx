<%@ WebService Language="C#" Class="YouSeeLovementWebService" %>
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
using InformationInTransit.ProcessLogic;
using InformationInTransit.ProcessLogic;

///<summary>
///	2022-08-23T22:43:00	You see lovement.
///	2022-08-24			Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class YouSeeLovementWebService : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string Query
	(
		string	bibleVersion,
		string	bibleWord,
		string 	scriptureReference
	)
    {
		String uniqueWords = InformationInTransit.ProcessCode.YouSeeLovement.Query
		(
			bibleVersion,
			bibleWord,
			scriptureReference
		);
		
		DataTable dataTable = (DataTable) DataCommand.DatabaseCommand
		(
			String.Format(SelectQuery, uniqueWords),
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		return json;
	}
	
	public const String SelectQuery = @"
		SELECT 
			BibleDictionaryWord AS BibleWord,
			BibleDatabaseEastonCommentary AS Easton,
			BibleDatabaseHitchcockBiblicalNameCommentary AS Hitchcock,
			BibleFoundationNaveTopicalBibleCommentary AS Nave,
			BibleFoundationRATorreyTheNewTopicalTextBookCommentary AS RATorrey
		FROM BibleDictionary..BibleDictionary_View
		WHERE BibleDictionaryWord IN ({0})
		ORDER BY BibleDictionaryWord
	";
}
