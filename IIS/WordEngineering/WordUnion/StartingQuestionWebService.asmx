<%@ WebService Language="C#" Class="StartingQuestionWebService" %>

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
using InformationInTransit.UserInterface;

///<summary>
///	2017-07-20 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class StartingQuestionWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		string punctuationMark,
		int top,
		string bibleVersion,
		string scriptureReference,
		string bibleWord
	)
    {
		object resultSet = null;
		
		if (punctuationMark == "'")
		{
			punctuationMark = "''";
		}	
		
		String verseIDSequenceQuery = String.Format
		(
			VerseIDSequenceQueryFormat,
			scriptureReference,
			bibleVersion,
			bibleWord
		);
		
		int? verseIDSequence = (int?) DataCommand.DatabaseCommand
		(
			verseIDSequenceQuery,
			CommandType.Text,
			DataCommand.ResultType.Scalar
		);

		if (verseIDSequence == null) { return null; }

		String startingQuestionQuery = String.Format
		(
			StartingQuestionQueryFormat,
			top,
			bibleVersion,
			verseIDSequence,
			punctuationMark
		);

		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			startingQuestionQuery,
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
    }
	
	public const string StartingQuestionQueryFormat = "SELECT TOP {0} BookID, ChapterID, VerseID, {1} AS VerseText FROM Bible..Scripture_View WHERE VerseIDSequence <= {2} AND {1} LIKE '%{3}%' ORDER BY VerseIDSequence DESC";
	public const string VerseIDSequenceQueryFormat = "SELECT TOP 1 VerseIDSequence FROM Bible..Scripture_View WHERE ScriptureReference LIKE '%{0}%' AND {1} LIKE '%{2}%' ORDER BY VerseIDSequence DESC";	
}
