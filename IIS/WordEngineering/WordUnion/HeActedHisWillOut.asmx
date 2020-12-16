<%@ WebService Language="C#" Class="HeActedHisWillOutWebService" %>

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
using System.Text;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessCode;
using InformationInTransit.ProcessLogic;

///<summary>
///	2018-03-05	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class HeActedHisWillOutWebService : System.Web.Services.WebService
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
		String	bibleVersion,
		String	scriptureReference
	)	
    {
		DataSet		resultSet 					=	null;
		DataSet		statisticsSet				=	null;
		String[]	scriptureReferenceSubset 	= 	null;
	
		HeActedHisWillOut.Query
		(
				scriptureReference,
				bibleVersion,
			ref	scriptureReferenceSubset,
			ref	resultSet,
			ref	statisticsSet
		);

		string json = JsonConvert.SerializeObject(statisticsSet, Formatting.Indented);
		return json;
	}
}
