<%@ WebService Language="C#" Class="MakingTodayAMemoryOfTomorrowWebService" %>

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

using InformationInTransit.ProcessLogic;

///<summary>
///	2016-09-26	Created.	MakingTodayAMemoryOfTomorrow.asmx
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class MakingTodayAMemoryOfTomorrowWebService : System.Web.Services.WebService
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
		string	firstLetters,
		string	bibleVersion
	)	
    {
 		DataSet dataSet = (DataSet) MakingTodayAMemoryOfTomorrow.Query
		(
			firstLetters,
			bibleVersion
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}
}
