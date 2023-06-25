<%@ WebService Language="C#" Class="DiagnosticsHelperWebService" %>

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

using System.Diagnostics;

//using Newtonsoft.Json;

//using System.Text.Json;

using System.Web.Script.Serialization;

///<summary>
///	2023-06-22T17:42:00 Created. 
///	2023-06-22T18:00:00 ... 2023-06-22T19:40:00 Debug. UWP platform.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class DiagnosticsHelperWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query()
    {
		String exceptionMessage = "";
		String json = "";
		
		try
		{
			var processes = System.Diagnostics.Process.GetProcesses();
			/*
			json = JsonSerializer.Serialize
			(
				processes,
				Formatting.Indented
			);
			*/
			json = new JavaScriptSerializer().Serialize(processes);
		}
		catch(Exception ex)
		{
			json = ex.Message;
		}
		
		return json;
    }
}
