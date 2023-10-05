<%@ WebService Language="C#" Class="BibleWordWebService" %>

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
using InformationInTransit.ProcessCode;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2015-07-17 	Created.
///	2015-11-15	GetAPage();
///	2018-08-02	MakeMeKnow();
///	2022-12-28	WhatRemembranceOfMan()
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class BibleWordWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String AssociativeWords
	(
		String	question,
		String	bibleVersion,
		int		logic,
		int		wordsCount
	)
    {
		String	sqlStatement = String.Format
		(
			SQLSelectAssociativeWordsFormat,
			bibleVersion,
			question,
			logic,
			wordsCount
		);
		
		//return sqlStatement;
		
        DataSet resultSet = (DataSet) DataCommand.DatabaseCommand
		(
			sqlStatement,
			System.Data.CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(resultSet, Formatting.Indented);
		return json;
    }

   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String OccurrenceOfTheMotion
	(
		String	logic,
		String	bibleBookGroup,
		String	question,
		bool	wholeWords,
		string	bibleVersion
	)
    {
		DataSet result = null;
		result = BibleWordHelper.OccurrenceOfTheMotion
		(
			logic,
			bibleBookGroup,
			question,
			wholeWords,
			bibleVersion
		);
		string json = JsonConvert.SerializeObject(result, Formatting.Indented);
		return json;
    }
	
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String DifferencingFromMyNeed
	(
		String	question
	)
    {
		Dictionary<string, int> result = 
			InformationInTransit.ProcessLogic.DifferencingFromMyNeed.WordPermutationEricLippert(question);
		string json = JsonConvert.SerializeObject(result, Formatting.Indented);
		return json;
    }

   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String GetAPage
	(
		String	question
	)
    {
		DataSet dataSet = null;
		dataSet = BibleWordHelper.GetAPage
		(
			question,
			ScriptureReferenceHelper.BibleVersionDefault
		);
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
    }
	
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String MakeMeKnow
	(
		string	bibleVersion,
		string	word
	)
    {
		DataSet result = InformationInTransit.ProcessCode.MakeMeKnow.Query
		(
			bibleVersion,
			word
		);
		string json = JsonConvert.SerializeObject(result, Formatting.Indented);
		return json;
    }
	
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String	logic,
		String	bibleBookGroup,
		String	question,
		bool	wholeWords,
		string	bibleVersion
	)
    {
		String[] scriptureReferenceSubset = null;
		DataSet result = null;
		result = BibleWordHelper.Query
		(
			logic,
			bibleBookGroup,
			question,
			wholeWords,
			bibleVersion
		);
		string json = JsonConvert.SerializeObject(result, Formatting.Indented);
		return json;
    }
	
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String StoryOutOfLine
	(
		String	logic,
		String	bibleBookGroup,
		String	question,
		bool	wholeWords,
		string	bibleVersion
	)
    {
		DataSet dataSet = BibleWordHelper.Query
		(
			logic,
			bibleBookGroup,
			question,
			wholeWords,
			bibleVersion
		);

		String resultSet = (dataSet == null) ? "" : ScriptureReferenceHelper.StoryOutOfLine(dataSet).ToString();
		
		return resultSet;
		
    }

   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String WhatRemembranceOfMan
	(
		String	logic,
		String	bibleBookGroup,
		String	question,
		bool	wholeWords,
		string	bibleVersion,
		string	scriptureReference,
		bool	scriptureReferenceIn
	)
    {
		string json = null;
		DataSet bibleWordDataSet = BibleWordHelper.Query
		(
			logic,
			bibleBookGroup,
			question,
			wholeWords,
			bibleVersion
		);
		if (String.IsNullOrEmpty(scriptureReference))
		{
			json = JsonConvert.SerializeObject(bibleWordDataSet, Formatting.Indented);
		}
		else
		{	
			DataSet resultSet = InformationInTransit.ProcessCode.WhatRemembranceOfMan.Query
			(
				bibleVersion,
				bibleWordDataSet,
				scriptureReference,
				scriptureReferenceIn
			);
			json = JsonConvert.SerializeObject(resultSet, Formatting.Indented);
		}
		return json;
    }
	
	public const String SQLSelectAssociativeWordsFormat = 
		"SELECT WordEngineering.dbo.AssociativeWords({0}, '{1}', {2}, {3}) AS	Words, " +
		" COUNT(*) AS Occurrences " +
		" FROM Bible..Scripture_View GROUP BY WordEngineering.dbo.AssociativeWords({0}, '{1}', {2}, {3}) ORDER BY " +
		" WordEngineering.dbo.AssociativeWords({0}, '{1}', {2}, {3}) ";

}
