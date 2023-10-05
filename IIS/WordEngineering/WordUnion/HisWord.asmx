<%@ WebService Language="C#" Class="HisWordWebService" %>

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
///	2016-01-28 Created.	APairingOfOurSum(String word)
///	2017-10-02 RandomWord().	
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class HisWordWebService : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }
	
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String APairingOfOurSum(String word)
    {
		DataSet dataSet = HisWordHelper.APairingOfOurSum(word);
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
    }
	
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String RandomWord()
	{	
		String word = (String)DataCommand.DatabaseCommand
		(
			"SELECT TOP 1 Word FROM WordEngineering..HisWord ORDER BY NewID()",
			CommandType.Text,
			DataCommand.ResultType.Scalar
		);
		
		string json = JsonConvert.SerializeObject(word, Formatting.Indented);
		return json;
	}
}
