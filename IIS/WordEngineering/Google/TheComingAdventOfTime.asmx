<%@ WebService Language="C#" Class="TheComingAdventOfTimeWebService" %>

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

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class TheComingAdventOfTimeWebService : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }
	
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Language(string sourceOrDestination)
    {
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			"SELECT DISTINCT " + sourceOrDestination + " AS Language FROM WordEngineering..TheComingAdventOfTime ORDER BY " + sourceOrDestination + " ASC",
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);

		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
    }
	
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String TheComingAdventOfTimeSelect
	(
		string 	src,
		string	dst
	)
    {
		Collection<SqlParameter> sqlParameterCollection = new Collection<SqlParameter>();

		sqlParameterCollection.Add(new SqlParameter("@FromLanguage", src));
		sqlParameterCollection.Add(new SqlParameter("@DestinationLanguage", dst));
		
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			"WordEngineering.dbo.usp_TheComingAdventOfTimeSelect",
			CommandType.StoredProcedure,
			DataCommand.ResultType.DataSet,
			sqlParameterCollection
		);

		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
    }
}
