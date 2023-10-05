<%@ WebService Language="C#" Class="WhenLifeChooseAPathLifeIsMadeOfAPartWebService" %>

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
using InformationInTransit.UserInterface;

///<summary>
///	2017-09-29	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WhenLifeChooseAPathLifeIsMadeOfAPartWebService : System.Web.Services.WebService
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
		string	bibleVersion,
		string	direction,
		string	location,
		string	logic
	)
    {
		DataSet result = null;
		result = WhenLifeChooseAPathLifeIsMadeOfAPartHelper.Query
		(
			bibleVersion,
			direction,
			location,
			logic
		);
		string json = JsonConvert.SerializeObject(result, Formatting.Indented);
		return json;
    }
}
