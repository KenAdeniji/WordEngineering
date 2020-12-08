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
				selectQuery = String.Format(SelectWithNumberInFigure, bibleVersion, biblePhrase, bibleNumber);
				break;
			case "withNumberInText":
				selectQuery = String.Format(SelectWithNumberInText, bibleVersion, biblePhrase, bibleNumber);
				break;
		}
		
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
				FROM Bible..Scripture 
				WHERE {0} LIKE '%{1}%' AND 
				ScriptureReference IN (SELECT sct.ScriptureReference FROM @scriptureReferenceTable AS sct)
				ORDER BY BookID, ChapterID, VerseID
		";	
	public const String SelectWithNumberInText = "SELECT ScriptureReference, {0} AS VerseText FROM Bible..Scripture WHERE {0} LIKE '%{1}%' AND {0} LIKE '%{2}%' ORDER BY BookID, ChapterID, VerseID";
}
		