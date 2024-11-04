<%@ WebService Language="C#" Class="ScriptureReferenceWebService" %>

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
///	2015-07-17 Created.
///	2017-04-20	Mo fe ma lole; mo niyawo le. MoFeMaLoleMoNiyawoLe.html
///				Danny, got out of Wienerschnitzel, exit westward.
/// 2017-12-16	IAmAfraidOfTheMarkHelper.cs Created.
/// 2022-01-15  SequenceQuery added.
///	2024-11-04T02:01:00...2024-11-04T02:25:00 ScriptureReference_JoseGalera_MarinaFood_OneFiveNine20241104
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class ScriptureReferenceWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Approach
	(
		String 	scriptureReference,
		string	bibleWord,
		string	firstScriptureReference,
		string	lastScriptureReference,
		int		fromOccurrence,
		int		untilOccurrence,
		int		exactIDFrom,
		int		exactIDUntil,
		int		alphabetSequenceIndexFrom,
		int		alphabetSequenceIndexUntil
	)
    {
		String[] scriptureReferenceSubset = null;
		DataSet result = null;
		
		if (fromOccurrence == -1)
		{
			fromOccurrence = Int32.MinValue;
		}

		if (untilOccurrence == -1)
		{
			untilOccurrence = Int32.MaxValue;
		}
		
		if (exactIDFrom == -1)
		{
			exactIDFrom = Int32.MinValue;
		}

		if (exactIDUntil == -1)
		{
			exactIDUntil = Int32.MaxValue;
		}		

		if (alphabetSequenceIndexFrom == -1)
		{
			alphabetSequenceIndexFrom = Int32.MinValue;
		}

		if (alphabetSequenceIndexUntil == -1)
		{
			alphabetSequenceIndexUntil = Int32.MaxValue;
		}		
		
		DataTable answer = (DataTable) ScriptureReferenceHelper.Approach
		(
				scriptureReference,
			ref	scriptureReferenceSubset,
			ref result,
				bibleWord,
				firstScriptureReference,
				lastScriptureReference,
				fromOccurrence,
				untilOccurrence,
				exactIDFrom,
				exactIDUntil,
				alphabetSequenceIndexFrom,
				alphabetSequenceIndexUntil
		);

		string json = JsonConvert.SerializeObject(answer, Formatting.Indented);
		return json;
    }

   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String BillInDate
	(
		String 	scriptureReference,
		//String	commentary,
		String	umlType,
		String	umlSource,
		String	umlTarget
	)
    {
		String[] scriptureReferenceSubset = null;
		DataSet result = null;
		
		var answer = ScriptureReferenceHelper.BillInDate
		(
				scriptureReference,
			ref	scriptureReferenceSubset,
			ref result,
				//commentary,
				umlType,
				umlSource,
				umlTarget
		);
		
		string json = JsonConvert.SerializeObject(answer, Formatting.Indented);
		return json;
    }
	
/*
	2020-03-21	https://stackoverflow.com/questions/12668528/sql-server-group-by-clause-to-get-comma-separated-values
	2020-03-23	Added Category
	2020-04-06	Added TimeSpan	
*/
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String BibleBookGroupAuthor
	(
	)
    {
		DataTable result = (DataTable) DataCommand.DatabaseCommand
		(
            "Bible..usp_BibleBooksAuthor",
            CommandType.StoredProcedure,
            InformationInTransit.DataAccess.DataCommand.ResultType.DataTable
        );
		string json = JsonConvert.SerializeObject(result, Formatting.Indented);
		return json;
    }
	
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String MoFeMaLoleMoNiyawoLe
	(
		String 	scriptureReference
	)
    {
		String[] scriptureReferenceSubset = null;
		DataSet result = null;
		
		ScriptureReferenceHelper.BibleDistinctQuery
		(
				scriptureReference,
			ref	scriptureReferenceSubset,
			ref result
		);
		
		string json = JsonConvert.SerializeObject(result, Formatting.Indented);
		return json;
    }
	
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query(String scriptureReference, string bibleVersion)
    {
		String[] scriptureReferenceSubset = null;
		DataSet result = null;
		ScriptureReferenceHelper.Process
		(
				scriptureReference,
			ref	scriptureReferenceSubset,
			ref result,
				ScriptureReferenceHelper.BibleQueryFormat,
				bibleVersion
		);
		string json = JsonConvert.SerializeObject(result, Formatting.Indented);
		return json;
    }
	
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String QueryCommentary(String scriptureReference)
    {
		String[] scriptureReferenceSubset = null;
		DataSet result = null;
		ScriptureReferenceHelper.Process 
		(
				scriptureReference,
			ref	scriptureReferenceSubset,
			ref result,
				ScriptureReferenceHelper.BibleCommentaryQueryFormat,
				"KingJamesVersion"
		);
		string json = JsonConvert.SerializeObject(result, Formatting.Indented);
		return json;
    }

   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String ScriptureReference_JoseGalera_MarinaFood_OneFiveNine20241104
	(
		int bookID,
		int chapterID,
		int verseID
	)
    {
		String scriptureReference = (String) DataCommand.DatabaseCommand
		(
            String.Format
			(
				@"SELECT WordEngineering.dbo.udf_ScriptureReference_JoseGalera_MarinaFood_OneFiveNine20241104
				(
					{0},
					{1},
					{2}
				)
				",
				bookID,
				chapterID,
				verseID
			),
            CommandType.Text,
            InformationInTransit.DataAccess.DataCommand.ResultType.Scalar
        );

		string json = String.Format
		(
			"{{\"scriptureReference\": \"{0}\"}}",
			scriptureReference
		);

		return json;
    }

   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String SequenceQuery(String scriptureReference, string bibleVersion)
    {
		String[] scriptureReferenceSubset = null;
		DataSet result = null;
		ScriptureReferenceHelper.Process
		(
				scriptureReference,
			ref	scriptureReferenceSubset,
			ref result,
				ScriptureReferenceHelper.BibleSequenceQueryFormat,
				bibleVersion
		);
		string json = JsonConvert.SerializeObject(result, Formatting.Indented);
		return json;
    }

   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String WhatChildrenOurGroom
	(
		String 	scriptureReference,
		String 	bibleVersion,
		bool	combinedResult
	)
    {
		String[] scriptureReferenceSubset = null;
		DataSet result = null;
		String sqlStatement = null;
		var exactWords = ScriptureReferenceHelper.WhatChildrenOurGroom
		(
				scriptureReference,
			ref	scriptureReferenceSubset,
			ref result,
				bibleVersion,
				combinedResult,
			ref	sqlStatement	
		);
		
		string json = JsonConvert.SerializeObject(exactWords, Formatting.Indented);
		return json;
    }
}
