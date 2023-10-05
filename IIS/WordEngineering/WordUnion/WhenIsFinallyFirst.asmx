<%@ WebService Language="C#" Class="WhenIsFinallyFirst" %>

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
///	2017-02-09	Created.	WhenIsFinallyFirst.asmx
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WhenIsFinallyFirst : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }

	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query()
    {
 		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			SQLStatementWhenIsFinallyFirst,
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}
	
	public const string SQLStatementWhenIsFinallyFirst = "SELECT TOP 1 ScriptureReference AS LastOccurrenceOfFirst, FirstOccurrenceOfLast = (SELECT TOP 1 ScriptureReference FROM Bible..KJV WHERE VerseText LIKE '%Last%' ORDER BY VerseIDSequence), LastOccurrenceOfOne = (SELECT TOP 1 ScriptureReference FROM Bible..KJV WHERE VerseText LIKE '%One%' ORDER BY VerseIDSequence DESC), FirstOccurrenceOfNine = (SELECT TOP 1 ScriptureReference FROM Bible..KJV WHERE VerseText LIKE '%Nine%' ORDER BY VerseIDSequence) FROM Bible..KJV WHERE VerseText LIKE '%First%' ORDER BY VerseIDSequence DESC";
}
