<%@ WebService Language="C#" Class="IRealizeMyFullSenseInMakingMan" %>

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
///	2017-03-05	Created.	IRealizeMyFullSenseInMakingMan.asmx
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class IRealizeMyFullSenseInMakingMan : System.Web.Services.WebService
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
		String 	bibleVersion,
		String	who,
		String	bodyPart,
		String	activity
	)
    {
		DataSet dataSet = (DataSet) InformationInTransit.ProcessLogic.IRealizeMyFullSenseInMakingManHelper.Query
        (
			bibleVersion,
			who,
			bodyPart,
			activity
        );
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}
}
