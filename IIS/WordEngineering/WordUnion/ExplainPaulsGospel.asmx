<%@ WebService Language="C#" Class="ExplainPaulsGospelWebService" %>

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

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class ExplainPaulsGospelWebService : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }
	
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Explain(string question)
    {
		string answer = ExplainPaulsGospel.Explain(question);
		return answer;
    }
	
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String SacredText()
    {
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			"SELECT ScriptureReference, Title FROM WordEngineering..SacredText ORDER BY SacredTextID ASC",
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);

		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);

		return json;
    }
}
