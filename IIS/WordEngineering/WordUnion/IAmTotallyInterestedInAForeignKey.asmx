<%@ WebService Language="C#" Class="IAmTotallyInterestedInAForeignKeyWebService" %>

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
///	2016-08-30	Created.	IAmTotallyInterestedInAForeignKey.asmx
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class IAmTotallyInterestedInAForeignKeyWebService : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }
	
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Population()	
    {
		string json = JsonConvert.SerializeObject(Creature.CreatureCollection, Formatting.Indented);
		json = JsonConvert.SerializeObject(Woman.WomanCollection, Formatting.Indented);
		json = JsonConvert.SerializeObject(Man.ManCollection, Formatting.Indented);
		return json;
	}
}
