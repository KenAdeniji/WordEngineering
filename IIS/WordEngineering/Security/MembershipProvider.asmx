<%@ WebService Language="C#" Class="MembershipProviderWebService" %>

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
using System.Web.Security;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.UserInterface;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class MembershipProviderWebService : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }
	
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Login(string userName, string password)
    {
		bool validUser = Membership.ValidateUser(userName, password);
		
		System.Uri currentUrl = System.Web.HttpContext.Current.Request.Url; 
		
		if (!validUser && !currentUrl.IsLoopback)
		{
			return JsonConvert.SerializeObject(null, Formatting.Indented);
		}	
		
		Collection<SqlParameter> sqlParameterCollection = new Collection<SqlParameter>();

		sqlParameterCollection.Add(new SqlParameter("@userName", userName));
			
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			"WordEngineering.dbo.uspMembershipProviderSelect",
			CommandType.StoredProcedure,
			DataCommand.ResultType.DataSet,
			sqlParameterCollection
		);

		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);

		return json;
    }
}
