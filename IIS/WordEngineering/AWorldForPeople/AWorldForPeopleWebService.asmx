<%@ WebService Language="C#" Class="AWorldForPeopleWebService" %>

using System;
using System.Data;
using System.Numerics;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;

using System.Data;
using System.Data.SqlClient;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.UserInterface;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class AWorldForPeopleWebService : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }
	
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String AWorldForPeopleSelect()
    {
		DataSet dataSet = (DataSet) Repository.DatabaseCommand
		(
			"uspAWorldForPeopleSelect",
			CommandType.StoredProcedure,
			Repository.ResultSet.DataSet
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);

		return json;
    }
	
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String PersonnelBuiltPersonSelect()
    {
		DataSet dataSet = (DataSet) Repository.DatabaseCommand
		(
			"SELECT * FROM PersonnelBuiltPerson",
			CommandType.Text,
			Repository.ResultSet.DataSet
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);

		return json;
    }
	
}
