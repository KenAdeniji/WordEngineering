<%@ WebService Language="C#" Class="DaterWebService" %>

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
///	2015-12-28	Created.	Dater.asmx
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class DaterWebService : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }
	
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String DaterSelect
	(
		string	calendar,
		int		biblicalYear,
		int		biblicalMonth,
		int		biblicalDay
	)
    {
		Collection<SqlParameter> sqlParameterCollection = new Collection<SqlParameter>();

		sqlParameterCollection.Add(new SqlParameter("@calendar", calendar));
  		
		if (biblicalYear > 0)
		{
			sqlParameterCollection.Add(new SqlParameter("@biblicalYear", biblicalYear));
		}

		if (biblicalMonth > 0)
		{
			sqlParameterCollection.Add(new SqlParameter("@biblicalMonth", biblicalMonth));
		}

		if (biblicalDay > 0)
		{
			sqlParameterCollection.Add(new SqlParameter("@biblicalDay", biblicalDay));
		}
		
      	DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			"WordEngineering..usp_DaterSelect",
			CommandType.StoredProcedure,
			DataCommand.ResultType.DataSet,
			sqlParameterCollection
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
    }
	
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String DaterCalendarSelect()
    {
      	DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			"WordEngineering..usp_DaterCalendarSelect",
			CommandType.StoredProcedure,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
    }
}
