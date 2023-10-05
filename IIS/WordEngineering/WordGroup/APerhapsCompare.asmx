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

using System.Reflection;

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
		Dictionary<String, InformationInTransit.ProcessLogic.Exact.Participation> result = APerhapsCompareHelper.Query
		(
				scriptureReference,
				bibleVersion,
				bibleWord
		);
/*
        Type ex = typeof(InformationInTransit.ProcessLogic.DataTableHelper);
        MethodInfo mi = ex.GetMethod("DictionaryToDataTable");
		MethodInfo miConstructed = mi.MakeGenericMethod(typeof(Dictionary<String, InformationInTransit.ProcessLogic.Exact.Participation>));
		
        object[] args = {result};
        DataTable dataTable = (DataTable) miConstructed.Invoke(null, args);
*/
		DataTable dataTable = APerhapsCompareHelper.ToDataTable(result);	
		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		return json;
    }
}
