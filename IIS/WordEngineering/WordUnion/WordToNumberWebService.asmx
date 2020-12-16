<%@ WebService Language="C#" Class="WordToNumberWebService" %>

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
using System.Web.Script.Serialization;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2015-12-12	Created.	
///	2015-12-14	ParseEnglish().
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WordToNumberWebService : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }
	
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String RetrieveScriptureReference
	(
		String	word
	)
    {
		int number = -1;
		string scriptureReference = WordToNumberHelper.RetrieveScriptureReference
		(
				word,
			ref number
		);
	
		string json = String.Format
		(
			JsonFormat,
			number,
			scriptureReference
		);
		
		return json;
    }
	
	public const string JsonFormat = "{{\"number\": {0}, \"scriptureReference\": \"{1}\"}}";
}
