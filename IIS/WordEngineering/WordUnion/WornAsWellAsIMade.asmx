<%@ WebService Language="C#" Class="WornAsWellAsIMadeWebService" %>

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
///	2016-09-24	Created.	Worn, as well, as I made. WornAsWellAsIMade.asmx
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WornAsWellAsIMadeWebService : System.Web.Services.WebService
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
		string	scriptureReference,
		string	word,
		string	fromUntil,
		string	bibleVersion,
		string	topLimit
	)	
    {
		string json = null;
		string selectStatement = String.Format
		(
			SelectStatement,
			scriptureReference,
			word,
			fromUntil,
			bibleVersion,
			topLimit
		);

 		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			selectStatement,
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}
	
	public const string SelectStatement = "SELECT TOP {4} ScriptureReference, {3} AS VerseText FROM Bible..Scripture_View WHERE {3} LIKE '%{1}%' AND verseIDSequence {2} ( SELECT TOP 1 verseIDSequence FROM Bible..Scripture WHERE ScriptureReference = '{0}' ) ORDER BY VerseIDSequence ASC";
}
