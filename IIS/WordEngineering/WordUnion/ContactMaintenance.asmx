<%@ WebService Language="C#" Class="ContactMaintenanceWebService" %>

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
///	2017-09-30	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class ContactMaintenanceWebService : System.Web.Services.WebService
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
		string	question
	)
    {
		Collection<SqlParameter> sqlParameterCollection = new Collection<SqlParameter>();
		sqlParameterCollection.Add(new SqlParameter("@query", question));

		
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			"WordEngineering..usp_ContactMaintenanceQuery",
			CommandType.StoredProcedure,
			DataCommand.ResultType.DataSet,
			sqlParameterCollection
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);

		return json;
    }

   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Select
	(
		string	contactID
	)
    {
		Collection<SqlParameter> sqlParameterCollection = new Collection<SqlParameter>();
		sqlParameterCollection.Add(new SqlParameter("@contactID", contactID));
		
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			"WordEngineering..usp_ContactMaintenanceSelect",
			CommandType.StoredProcedure,
			DataCommand.ResultType.DataSet,
			sqlParameterCollection
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);

		return json;
    }
}
