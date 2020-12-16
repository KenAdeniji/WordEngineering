<%@ WebService Language="C#" Class="MeISupposeInTimeWebService" %>

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
///	2016-07-13	Created.	MeISupposeInTime.asmx
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class MeISupposeInTimeWebService : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }
	
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query(string bibleVersion, int checker)
    {
		DataSet dataSet = null;
		dataSet = MeISupposeInTime.YouKnowTheSound(bibleVersion,checker);
	
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}
}
