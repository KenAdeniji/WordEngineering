<%@ WebService Language="C#" Class="ProcessViewerWebService"%>

using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;

using System.Data;
using System.Data.SqlClient;

using System.ComponentModel;
using System.Diagnostics;

using Newtonsoft.Json;

using InformationInTransit.ProcessLogic;

///<summary>
///	2018-11-03 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class ProcessViewerWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Running()
    {
		List<String> resultSet = ProcessHelper.Running();
		string json = JsonConvert.SerializeObject(resultSet, Formatting.Indented);
		return json;
    }
}
