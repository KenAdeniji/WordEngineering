<%@ WebService Language="C#" Class="PhraseTwoOrMoreWordsThatReOccurWebService" %>

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
///	2016-08-12	Created.	PhraseTwoOrMoreWordsThatReOccur.asmx
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class PhraseTwoOrMoreWordsThatReOccurWebService : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }
	
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		string	biblePhrase,
		string	firstOccurrence,
		string	lastOccurrence,
		int		frequencyOfOccurrenceFrom,
		int		frequencyOfOccurrenceUntil,
		int		phraseTwoOrMoreWordsThatReOccurIDFrom,
		int		phraseTwoOrMoreWordsThatReOccurIDUntil,
		int		alphabetSequenceIndexFrom,
		int		alphabetSequenceIndexUntil
	)	
    {
		Collection<SqlParameter> sqlParameterCollection = new Collection<SqlParameter>();

		sqlParameterCollection.Add(new SqlParameter("@biblePhrase", biblePhrase.Trim()));
		sqlParameterCollection.Add(new SqlParameter("@firstOccurrence", firstOccurrence.Trim()));
		sqlParameterCollection.Add(new SqlParameter("@lastOccurrence", lastOccurrence.Trim()));

		if (frequencyOfOccurrenceFrom > -1)
		{
			sqlParameterCollection.Add(new SqlParameter("@frequencyOfOccurrenceFrom", frequencyOfOccurrenceFrom));
		}

		if (frequencyOfOccurrenceUntil > -1)
		{
			sqlParameterCollection.Add(new SqlParameter("@frequencyOfOccurrenceUntil", frequencyOfOccurrenceUntil));
		}

		if (phraseTwoOrMoreWordsThatReOccurIDFrom > -1)
		{
			sqlParameterCollection.Add(new SqlParameter("@phraseTwoOrMoreWordsThatReOccurIDFrom", phraseTwoOrMoreWordsThatReOccurIDFrom));
		}

		if (phraseTwoOrMoreWordsThatReOccurIDUntil > -1)
		{
			sqlParameterCollection.Add(new SqlParameter("@phraseTwoOrMoreWordsThatReOccurIDUntil", phraseTwoOrMoreWordsThatReOccurIDUntil));
		}
		
		if (alphabetSequenceIndexFrom > -1)
		{
			sqlParameterCollection.Add(new SqlParameter("@alphabetSequenceIndexFrom", alphabetSequenceIndexFrom));
		}

		if (alphabetSequenceIndexUntil > -1)
		{
			sqlParameterCollection.Add(new SqlParameter("@alphabetSequenceIndexUntil", alphabetSequenceIndexUntil));
		}
		
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			"Bible..usp_PhraseTwoOrMoreWordsThatReOccurSelect",
			CommandType.StoredProcedure,
			DataCommand.ResultType.DataSet,
			sqlParameterCollection
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}
}
