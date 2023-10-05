<%@ WebService Language="C#" Class="AjaxWebService" %>

using System;
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

using InformationInTransit.ProcessLogic;

///<summary>
///	2017-12-15	http://www.devx.com/tips/dot-net/check-if-a-httprequest-is-an-ajax-request-170117062005.html
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class AjaxWebService : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }

	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String IsAjaxRequest()	
    {
		bool isAjaxRequest = InformationInTransit.ProcessLogic.AjaxHelper.IsAjaxRequest();
		string json = JsonConvert.SerializeObject(isAjaxRequest, Formatting.Indented);
		return json;
	}
}
