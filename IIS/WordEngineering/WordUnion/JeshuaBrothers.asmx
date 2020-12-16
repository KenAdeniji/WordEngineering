<%@ WebService Language="C#" Class="JeshuaBrothersWebService" %>
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

///<summary>
///	2016-07-20	Created.	JeshuaBrothers.asmx
///				https://msdn.microsoft.com/en-us/library/zkcaxw5y%28v=vs.110%29.aspx
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class JeshuaBrothersWebService : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }
	
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Executable(string storedProcedureName)
    {
		string json = "";
		if (String.Compare(storedProcedureName, 0, "usp_", 0, 4, true) == 0);
		{	
			DataSet dataSet = (DataSet)DataCommand.DatabaseCommand
			(
				"WordEngineering.."+storedProcedureName,
				CommandType.StoredProcedure,
				DataCommand.ResultType.DataSet
			);
			json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		}	
		return json;
	}
}
