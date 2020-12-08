<%@ WebService Language="C#" Class="ThisWordCanBeDoneWebService" %>

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

using System.Linq;

using Newtonsoft.Json;

using InformationInTransit.LanguageIntegratedQueryLINQ;

///<summary>
///	2019-12-10	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class ThisWordCanBeDoneWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String GroupByBookSeries()
    {
		string json = JsonConvert.SerializeObject
		(
			ThisWordCanBeDone.GroupByBookSeries(), 
			Formatting.Indented
		);
		return json;
    }
}	
