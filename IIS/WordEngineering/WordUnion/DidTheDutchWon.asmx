<%@ WebService Language="C#" Class="DidTheDutchWonWebService" %>

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

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;

///<summary>
///	2018-02-04	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class DidTheDutchWonWebService : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }
	
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String 	bibleVersion,
		String	scriptureReferenceFirst,
		String	scriptureReferenceSecond

	)	
    {
		DataSet	resultSet = DidTheDutchWonHelper.DidTheDutchWon
		(
			bibleVersion,
			scriptureReferenceFirst,
			scriptureReferenceSecond
		);
		
		string json = JsonConvert.SerializeObject(resultSet, Formatting.Indented);
		return json;
	}
}
