<%@ WebService Language="C#" Class="EnvironmentVariablesHelperWebService" %>

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

using Newtonsoft.Json;

///<summary>
///	2023-06-24T20:57:00 ... 2023-06-24T21:08:00 Created
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class EnvironmentVariablesHelperWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query()
    {
		String json = "";
		
		try
		{
			/*
			foreach (DictionaryEntry de in Environment.GetEnvironmentVariables())
			{
				Console.WriteLine("  {0} = {1}", de.Key, de.Value);
			}
			*/		
			json = JsonConvert.SerializeObject
			(
				Environment.GetEnvironmentVariables(),
				Formatting.Indented
			);
		}
		catch(Exception ex)
		{
			json = ex.Message;
		}
		
		return json;
    }
}
