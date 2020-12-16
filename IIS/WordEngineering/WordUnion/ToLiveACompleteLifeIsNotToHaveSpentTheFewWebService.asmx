<%@ WebService Language="C#" Class="ToLiveACompleteLifeIsNotToHaveSpentTheFew" %>
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

using System.Linq;

using Newtonsoft.Json;

using InformationInTransit.ProcessLogic;

///<summary>
///	2017-09-03	Created.
///	2017-09-04	stackoverflow.com/questions/5074575/what-is-the-best-way-in-c-sharp-to-convert-string-into-int
///	2017-09-04	https://weblogs.asp.net/scottgu/optional-parameters-and-named-arguments-in-c-4-and-a-cool-scenario-w-asp-net-mvc-2
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class ToLiveACompleteLifeIsNotToHaveSpentTheFew : System.Web.Services.WebService
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
		String	bibleVersion,	
		String	bibleWord,
		String	scriptureReference,
		String 	wordPositions
	)
    {
		int[] array = wordPositions.Split(new char[] {',', ';'}).Select(str => int.Parse(str) - 1).ToArray();
		DataSet dataSet = (DataSet) InformationInTransit.ProcessLogic.ToLiveACompleteLifeIsNotToHaveSpentTheFew.Query
		(
			bibleVersion,
			bibleWord,
			scriptureReference,
			wordPositions: array
		);
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}
}
