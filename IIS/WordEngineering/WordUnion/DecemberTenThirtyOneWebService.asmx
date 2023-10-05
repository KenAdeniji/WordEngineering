<%@ WebService Language="C#" Class="DecemberTenThirtyOneWebService" %>

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
using System.Text;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2017-07-10 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class DecemberTenThirtyOneWebService : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }

   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query(DateTime dated, string bibleVersion)
    {
		bibleVersion = bibleVersion.ToUpper();
		if (String.IsNullOrEmpty(bibleVersion) || bibleVersion == "KJV")
		{
			bibleVersion = "VerseText";
		}	
		DataSet dataSet = DecemberTenThirtyOne.Query(dated, bibleVersion);
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
    }
}
