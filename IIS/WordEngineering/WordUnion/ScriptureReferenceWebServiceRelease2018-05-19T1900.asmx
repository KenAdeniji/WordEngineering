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
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class ScriptureReferenceWebService : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }

   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Approach
	(
		String 	scriptureReference,
		string	bibleWord,
		string	firstOccurrence,
		string	lastOccurrence,
		int		frequencyOfOccurrenceFrom,
		int		frequencyOfOccurrenceUntil,
		int		exactIDFrom,
		int		exactIDUntil,
		int		alphabetSequenceIndexFrom,
		int		alphabetSequenceIndexUntil
	)
    {
		String[] scriptureReferenceSubset = null;
		DataSet result = null;
		
		if (frequencyOfOccurrenceFrom == -1)
		{
			frequencyOfOccurrenceFrom = Int32.MinValue;
		}

		if (frequencyOfOccurrenceUntil == -1)
		{
			frequencyOfOccurrenceUntil = Int32.MaxValue;
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
		
		var answer = ScriptureReferenceHelper.Approach
		(
				scriptureReference,
			ref	scriptureReferenceSubset,
			ref result,
				bibleWord,
				firstOccurrence,
				lastOccurrence,
				frequencyOfOccurrenceFrom,
				frequencyOfOccurrenceUntil,
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
}
