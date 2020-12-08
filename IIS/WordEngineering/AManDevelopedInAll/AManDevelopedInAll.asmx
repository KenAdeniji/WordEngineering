<%@ WebService Language="C#" Class="AManDevelopedInAll" %>

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
using InformationInTransit.UserInterface;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class AManDevelopedInAll : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }
	
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String OrganizationSelect
	(
		string	organizationName,
		string 	uri
	)
    {
		Collection<SqlParameter> sqlParameterCollection = new Collection<SqlParameter>();

		if (!String.IsNullOrEmpty(organizationName))
		{
			sqlParameterCollection.Add(new SqlParameter("@organizationName", organizationName));
		}	
		
		if (!String.IsNullOrEmpty(uri))
		{
			sqlParameterCollection.Add(new SqlParameter("@uri", uri));
		}	
		
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			"AManDevelopedInAll.dbo.usp_OrganizationSelect",
			CommandType.StoredProcedure,
			DataCommand.ResultType.DataSet,
			sqlParameterCollection
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
    }
	
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public String TermSelect
	(
		long organizationId
	)
    {
		Collection<SqlParameter> sqlParameterCollection = new Collection<SqlParameter>();
		sqlParameterCollection.Add(new SqlParameter("@organizationId", organizationId));
		
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			"AManDevelopedInAll.dbo.usp_TermSelect",
			CommandType.StoredProcedure,
			DataCommand.ResultType.DataSet,
			sqlParameterCollection
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
    }
	
}
