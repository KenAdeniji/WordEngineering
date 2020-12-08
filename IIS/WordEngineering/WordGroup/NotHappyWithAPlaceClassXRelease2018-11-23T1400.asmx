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

using Newtonsoft.Json;

using InformationInTransit.DataAccess;

///<summary>
///	2018-11-23 Created.
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
		string	biblePhrase,
		string	logic,
		string	bibleNumber,
		string	bibleVersion
	)
    {
		String selectQuery = null;
		
		switch(logic)
		{
			case "biblePhraseOnly":
				selectQuery = String.Format(SelectBibleWordOnly, bibleVersion, biblePhrase);
				break;
			case "withNumberInFigure":
/*
I want to return all scripture reference that contain the name David, and the number 30.
SELECT ScriptureReference, KingJamesVersion AS VerseText 
	FROM Bible..Scripture 
	WHERE 
		ScriptureReference IN 
		(
			SELECT ScriptureReference
			FROM WordEngineering..NumberSign
			WHERE KingJamesVersion LIKE '%Jesus%' AND Number = 30
		) 
	ORDER BY BookID, ChapterID, VerseID
*/			
				selectQuery = String.Format(SelectWithNumberInFigureTest, bibleVersion, biblePhrase, bibleNumber);
				break;
			case "withNumberInText":
				selectQuery = String.Format(SelectWithNumberInText, bibleVersion, biblePhrase, bibleNumber);
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
	
	public const String SelectBibleWordOnly = "SELECT ScriptureReference, {0} AS VerseText FROM Bible..Scripture WHERE {0} LIKE '%{1}%' ORDER BY BookID, ChapterID, VerseID";
	public const String SelectWithNumberInFigure = 
		@"SELECT ScriptureReference, {0} AS VerseText 
			FROM Bible..Scripture 
			WHERE 
				ScriptureReference IN 
				(
					SELECT ScriptureReference
					FROM WordEngineering..NumberSign
					WHERE {0} LIKE '%{1}%' AND Number = {2}
				) 
			ORDER BY BookID, ChapterID, VerseID";	
	public const String SelectWithNumberInFigureTest = 
		@"
			DECLARE @scriptureReference VARCHAR(MAX);
			SELECT @scriptureReference = ScriptureReference
				FROM WordEngineering..NumberSign
				WHERE Number = @2;
			SELECT ScriptureReference, {0} AS VerseText 
				FROM Bible..Scripture 
				WHERE {0} LIKE '%{1}%' AND 
				ScriptureReference IN (SELECT value FROM STRING_SPLIT(@scriptureReference, ','))
				ORDER BY BookID, ChapterID, VerseID				
		";	
	public const String SelectWithNumberInText = "SELECT ScriptureReference, {0} AS VerseText FROM Bible..Scripture WHERE {0} LIKE '%{1}%' AND {0} LIKE '%{2}%' ORDER BY BookID, ChapterID, VerseID";
}
