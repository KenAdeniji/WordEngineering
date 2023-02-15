<%@ WebService Language="C#" Class="DontFeelLeftAloneWebService" %>

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
using System.Data.Odbc;
using System.Data.SqlClient;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessCode;
using InformationInTransit.UserInterface;

///<summary>
///	2023-02-14T19:16:00 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class DontFeelLeftAloneWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String		contactID,
		DateTime	dated,
		String		scriptureReference
	)
    {
		DataSet resultSetContact = DontFeelLeftAlone.Query
		(
			contactID,
			dated,
			scriptureReference
		);
		
		string json = JsonConvert.SerializeObject(resultSetContact, Formatting.Indented);
		return json;
    }
}
