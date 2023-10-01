<%@ WebService Language="C#" Class="MentioningThingsWebService" %>

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

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessCode;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

using Newtonsoft.Json;

///<summary>
///	2023-09-29T12:57:00 Created. Exact table?
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class MentioningThingsWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		string 	scriptureReference,
		string 	bibleVersion,
		string	bibleWord	
	)
    {
		DataTable resultDataTable = MentioningThings.Query
		(
				scriptureReference,
				bibleVersion,
				bibleWord
		);
		string json = JsonConvert.SerializeObject(resultDataTable, Formatting.Indented);
		return json;
    }
}
