<%@ WebService Language="C#" Class="InternetDictionaryProjectIDP" %>

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
using InformationInTransit.UserInterface;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class InternetDictionaryProjectIDP : System.Web.Services.WebService
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
		string 	word
	)
    {
		String	sqlStatement = String.Format
		(
			SelectStatement,
			word
		);	
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			sqlStatement,
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
    }
	
	public const String SelectStatement = 
		@"SELECT * FROM InternetDictionaryProjectIDP..InternetDictionaryProject WHERE " +
		"EnglishWord LIKE '%{0}%' OR " +
		"FrenchCommentary LIKE '%{0}%' OR " +
		"GermanCommentary LIKE '%{0}%' OR " +
		"ItalianCommentary LIKE '%{0}%' OR " +
		"LatinCommentary LIKE '%{0}%' OR " +
		"PortugueseCommentary LIKE '%{0}%' OR " +
		"SpanishCommentary LIKE '%{0}%'";
}
