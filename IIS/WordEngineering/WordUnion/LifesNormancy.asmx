<%@ WebService Language="C#" Class="LifesNormancyWebService" %>

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

///<summary>
///	2017-05-22	Created.	LifesNormancy.asmx
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class LifesNormancyWebService : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }

	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query(string word)
    {
		string selectStatement = String.Format(SelectStatement, word);

 		string scriptureReference = (String) DataCommand.DatabaseCommand
		(
			selectStatement,
			CommandType.Text,
			DataCommand.ResultType.Scalar
		);
		
		string json = String.Format
		(
			JsonFormat,
			scriptureReference
		);

		return json;
	}
	
	public const string JsonFormat = "{{\"scriptureReference\": \"{0}\"}}";
	public const string SelectStatement = "SELECT WordEngineering.dbo.udf_LifesNormancy('{0}')";
}
