<%@ WebService Language="C#" Class="APerhapsCompareWebService" %>

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

using Newtonsoft.Json;

using InformationInTransit.ProcessCode;

///<summary>
/// 2020-01-18	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class APerhapsCompareWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String	scriptureReference,
		String 	bibleVersion,
		String	bibleWord
	)
    {
		Dictionary<string, InformationInTransit.ProcessCode.APerhapsCompareHelper.Participation> result = APerhapsCompareHelper.Query
		(
				scriptureReference,
				bibleVersion,
				bibleWord
		);
		DataTable dataTable = InformationInTransit.ProcessCode.APerhapsCompareHelper.ToDataTable(result);
		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		return json;
    }
}
