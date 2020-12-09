<%@ WebService Language="C#" Class="TypeViewerWebService"%>

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

using Newtonsoft.Json;

using InformationInTransit.ProcessCode;

///<summary>
///	2018-11-02 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class TypeViewerWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query(string question)
    {
		var resultSet = TypeViewerHelper.Query
		(
			question.Split
			(
				new char[] {' ', ',', ';'}, 
				StringSplitOptions.RemoveEmptyEntries
			)
		);
		string json = JsonConvert.SerializeObject(resultSet.ToString(), Formatting.Indented);
		return json;
    }
}
