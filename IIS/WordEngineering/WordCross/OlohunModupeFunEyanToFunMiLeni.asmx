<%@ WebService Language="C#" Class="OlohunModupeFunEyanToFunMiLeniWebService" %>

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
///	2023-10-12T21:19:00 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class OlohunModupeFunEyanToFunMiLeniWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		string 	scriptureReference,
		string 	bibleVersion,
		string	bibleWord,	
		bool	includeOrdinalNumbers,
		bool	includeCardinalNumbers
	)
    {
		DataTable resultDataTable = OlohunModupeFunEyanToFunMiLeni.Query
		(
			scriptureReference,
			bibleVersion,
			bibleWord,
			includeOrdinalNumbers,
			includeCardinalNumbers
		);
		string json = JsonConvert.SerializeObject(resultDataTable, Formatting.Indented);
		return json;
    }
}
