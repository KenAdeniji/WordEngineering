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

using System.Data.Odbc;
//using System.Data.SqlClient;

using System.Text;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;

///<summary>
///	2017-02-13	Created.	Exact.asmx
///	2017-02-14	Added.	 	OurFixationOnNumber()
///	2017-02-19	Added.		Query()
///	2021-08-07	QueryPre20210807 stored procedure versus Query dynamic sql
/// 2021-08-07T14:26:00	https://h3manth.com/content/javascript-one-liner-extracting-unique-words-webpages
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
	public String QueryPre20210807
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
		Collection<OdbcParameter> sqlParameterCollection = new Collection<OdbcParameter>();

		sqlParameterCollection.Add(new OdbcParameter("@bibleWord", bibleWord));
		sqlParameterCollection.Add(new OdbcParameter("@firstOccurrenceScriptureReference", firstOccurrenceScriptureReference));
		sqlParameterCollection.Add(new OdbcParameter("@lastOccurrenceScriptureReference", lastOccurrenceScriptureReference));
		
		if (frequencyOfOccurrenceFrom > -1)
		{
			sqlParameterCollection.Add(new OdbcParameter("@frequencyOfOccurrenceFrom", frequencyOfOccurrenceFrom));
		}

		if (frequencyOfOccurrenceUntil > -1)
		{
			sqlParameterCollection.Add(new OdbcParameter("@frequencyOfOccurrenceUntil", frequencyOfOccurrenceUntil));
		}

		if (exactIDFrom > -1)
		{
			sqlParameterCollection.Add(new OdbcParameter("@exactIDFrom", exactIDFrom));
		}

		if (exactIDUntil > -1)
		{
			sqlParameterCollection.Add(new OdbcParameter("@exactIDUntil", exactIDUntil));
		}
		
		if (alphabetSequenceIndexFrom > -1)
		{
			sqlParameterCollection.Add(new OdbcParameter("@alphabetSequenceIndexFrom", alphabetSequenceIndexFrom));
		}

		if (alphabetSequenceIndexUntil > -1)
		{
			sqlParameterCollection.Add(new OdbcParameter("@alphabetSequenceIndexUntil", alphabetSequenceIndexUntil));
		}
		
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			"Bible..usp_ExactSelect",
			CommandType.StoredProcedure,
			DataCommand.ResultType.DataSet,
			sqlParameterCollection
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
		StringBuilder sb = new StringBuilder ( SQLStatementQuery );

		if (!String.IsNullOrEmpty(bibleWord)) { sb.AppendFormat(" AND BibleWord LIKE '%{0}%' ", bibleWord); }	
		if (!String.IsNullOrEmpty(firstOccurrenceScriptureReference)) { sb.AppendFormat(" AND firstOccurrenceScriptureReference LIKE '%{0}%' ", firstOccurrenceScriptureReference); }	
		if (!String.IsNullOrEmpty(lastOccurrenceScriptureReference)) { sb.AppendFormat(" AND lastOccurrenceScriptureReference LIKE '%{0}%' ", lastOccurrenceScriptureReference); }

		if (frequencyOfOccurrenceFrom > -1) { sb.AppendFormat(" AND frequencyOfOccurrence >= {0} ", frequencyOfOccurrenceFrom); }
		if (frequencyOfOccurrenceUntil > -1) { sb.AppendFormat(" AND frequencyOfOccurrence <= {0} ", frequencyOfOccurrenceUntil); }

		if (exactIDFrom > -1) { sb.AppendFormat(" AND exactID >= {0} ", exactIDFrom); }
		if (exactIDUntil > -1) { sb.AppendFormat(" AND exactID <= {0} ", exactIDUntil); }
		
		if (alphabetSequenceIndexFrom > -1) { sb.AppendFormat(" AND alphabetSequenceIndex >= {0} ", alphabetSequenceIndexFrom); }
		if (alphabetSequenceIndexUntil > -1) { sb.AppendFormat(" AND alphabetSequenceIndex <= {0} ", alphabetSequenceIndexUntil); }
		
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			sb.ToString(),
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}
	
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String WordBehindOurPages
	(
		string	bibleWord
	)
    {
		string replaced = "'"+bibleWord.Replace(" ", "','")+"'";	
		string sqlStatement = SQLStatementQuery + " AND BibleWord IN " + '(' + replaced + ')';
		
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			sqlStatement,
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}
	
	public const string SQLStatementHalfIncluded = "SELECT * FROM Bible..Exact WHERE BibleWord LIKE '{0}%' AND BibleWord LIKE '%{1}' ORDER BY BibleWord";
	
	public const string SQLStatementQuery = "SELECT * FROM Bible..Exact WHERE 1 = 1 ";	
}
