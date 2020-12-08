<%@ WebService Language="C#" Class="Exact" %>

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
///	2017-02-13	Created.	Exact.asmx
///	2017-02-14	Added.	 	OurFixationOnNumber()
///	2017-02-19	Added.		Query()
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class Exact : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }

	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String HalfIncluded
	(
		string left,
		string right
	)
    {
 		String sql = String.Format
		(
			SQLStatementHalfIncluded,
			left,
			right
		);	
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			sql,
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}
	
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String OurFixationOnNumber
	(
		string bibleWord
	)
    {
		DataSet dataSet = InformationInTransit.ProcessLogic.ExactHelper.OurFixationOnNumber
		(
			bibleWord
		);
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}
	
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		string	bibleWord,
		string	firstOccurrenceScriptureReference,
		string	lastOccurrenceScriptureReference,
		int		frequencyOfOccurrenceFrom,
		int		frequencyOfOccurrenceUntil,
		int		exactIDFrom,
		int		exactIDUntil,
		int		alphabetSequenceIndexFrom,
		int		alphabetSequenceIndexUntil
	)
    {
		List<SqlParameter> sqlParameterCollection = new List<SqlParameter>();

		sqlParameterCollection.Add(new SqlParameter("@bibleWord", bibleWord));
		sqlParameterCollection.Add(new SqlParameter("@firstOccurrenceScriptureReference", firstOccurrenceScriptureReference));
		sqlParameterCollection.Add(new SqlParameter("@lastOccurrenceScriptureReference", lastOccurrenceScriptureReference));
		
		if (frequencyOfOccurrenceFrom > -1)
		{
			sqlParameterCollection.Add(new SqlParameter("@frequencyOfOccurrenceFrom", frequencyOfOccurrenceFrom));
		}

		if (frequencyOfOccurrenceUntil > -1)
		{
			sqlParameterCollection.Add(new SqlParameter("@frequencyOfOccurrenceUntil", frequencyOfOccurrenceUntil));
		}

		if (exactIDFrom > -1)
		{
			sqlParameterCollection.Add(new SqlParameter("@exactIDFrom", exactIDFrom));
		}

		if (exactIDUntil > -1)
		{
			sqlParameterCollection.Add(new SqlParameter("@exactIDUntil", exactIDUntil));
		}
		
		if (alphabetSequenceIndexFrom > -1)
		{
			sqlParameterCollection.Add(new SqlParameter("@alphabetSequenceIndexFrom", alphabetSequenceIndexFrom));
		}

		if (alphabetSequenceIndexUntil > -1)
		{
			sqlParameterCollection.Add(new SqlParameter("@alphabetSequenceIndexUntil", alphabetSequenceIndexUntil));
		}
		
		DataSet dataSet = (DataSet) Repository.DatabaseCommand
		(
			"Bible..usp_ExactSelect",
			CommandType.StoredProcedure,
			Repository.ResultSet.DataSet,
			sqlParameterCollection
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}
	
	public const string SQLStatementHalfIncluded = "SELECT * FROM Bible..Exact WHERE BibleWord LIKE '{0}%' AND BibleWord LIKE '%{1}' ORDER BY BibleWord";
}
