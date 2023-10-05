<%@ WebService Language="C#" Class="KitanWebService" %>

using System;
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
///	2016-03-07	Created.	KitanWebService.asmx
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class KitanWebService : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query(int number)
    {
		Collection<SqlParameter> sqlParameterCollection = new Collection<SqlParameter>();
		sqlParameterCollection.Add(new SqlParameter("@ID", number));
		String scriptureReference = (String)DataCommand.DatabaseCommand
		(
			"WordEngineering..usp_kitan",
			CommandType.StoredProcedure,
			DataCommand.ResultType.Scalar,
			sqlParameterCollection
		);
		string json = String.Format
		(
			JsonFormat,
			scriptureReference
		);
		return json;
	}
	
	public const string JsonFormat = "{{\"scriptureReference\": \"{0}\"}}";
}
