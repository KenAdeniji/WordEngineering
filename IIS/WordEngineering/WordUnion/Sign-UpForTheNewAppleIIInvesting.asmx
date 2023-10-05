<%@ WebService Language="C#" Class="SignUpForTheNewAppleIIInvestingWebService" %>

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
///	2016-09-28	Created.	Sign-up for the new Apple II, investing. Sign-UpForTheNewAppleIIInvesting.asmx
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class SignUpForTheNewAppleIIInvestingWebService : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		string	word,
		string	bibleVersion
	)	
    {
		string	selectStatement = String.Format(SelectFormat, word, bibleVersion);
		
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			selectStatement,
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}
	
	public const string SelectFormat = "SELECT ScriptureReference, {1} AS VerseText FROM Bible..Scripture_View WHERE {1} LIKE '%[^a-z]{0}[^a-z]%'";
}
