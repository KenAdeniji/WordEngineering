<%@ WebService Language="C#" Class="FullPositionWebService" %>

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
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2017-07-09 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class FullPositionWebService : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }

   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query(String scriptureReference)
    {
		String[] 		scriptureReferenceSubset = null;
		DataSet 		result = null;
		StringBuilder	fullPosition = null;

		ScriptureReferenceHelper.FullPosition
		(
				scriptureReference,
			ref	scriptureReferenceSubset,
			ref result,
			ref	fullPosition
		);

		string json = String.Format
		(
			FullPositionJsonFormat,
			fullPosition
		);	

		return json;
    }
	
	public const string FullPositionJsonFormat = "{{\"scriptureReference\": \"{0}\"}}";
}
