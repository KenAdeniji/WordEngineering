<%@ WebService Language="C#" Class="ToHaveLiveALifeIAmAProveOfWebService" %>

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
using InformationInTransit.ProcessCode;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2018-04-23 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class ToHaveLiveALifeIAmAProveOfWebService : System.Web.Services.WebService
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
		string 	bibleWord,
		string 	bibleVersion,
		bool 	wholeWords
	)
    {
		DataSet result = ToHaveLiveALifeIAmAProveOf.Query
		(
			bibleWord,
			bibleVersion,
			wholeWords
		);

		string json = JsonConvert.SerializeObject(result, Formatting.Indented);
		return json;
    }
}
