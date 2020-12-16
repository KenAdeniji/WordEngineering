<%@ WebService Language="C#" Class="GreekWebService" %>

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
///	2017-08-18 	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class GreekWebService : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }

   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Alphabets()
    {
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			"Select * FROM WordEngineering..GreekLinguistics ORDER BY GreekLinguisticsID ASC",
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);

		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);

		return json;
    }
}
