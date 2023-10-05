<%@ WebService Language="C#" Class="YouHaveIncludedInYouWebService" %>

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
using System.Web.Script.Serialization;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2016-03-09	Created.	YouHaveIncludedInYou.asmx
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class YouHaveIncludedInYouWebService : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }
	
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String YouHaveIncludedInYouSelect
	(
		string	actor,
		string	operation
	)
    {
		Collection<SqlParameter> sqlParameterCollection = new Collection<SqlParameter>();

		if (String.IsNullOrEmpty(actor) == false && actor != "(all)") 
		{
			sqlParameterCollection.Add(new SqlParameter("@actor", actor));
		}

		if (String.IsNullOrEmpty(operation) == false && operation != "(all)") 
		{
			sqlParameterCollection.Add(new SqlParameter("@operation", operation));
		}

      	DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			"WordEngineering..usp_YouHaveIncludedInYouSelect",
			CommandType.StoredProcedure,
			DataCommand.ResultType.DataSet,
			sqlParameterCollection
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
    }
	
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String SelectFeature(string feature)
    {
      	DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			"SELECT DISTINCT " + feature + " FROM WordEngineering..YouHaveIncludedInYou " + " ORDER BY " + feature,
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
    }
}
