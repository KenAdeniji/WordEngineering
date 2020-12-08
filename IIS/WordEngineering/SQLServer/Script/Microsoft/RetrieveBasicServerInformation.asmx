<%@ WebService Language="C#" Class="RetrieveBasicServerInformationWebService" %>

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
///	2018-08-20	https://goalkicker.com/MicrosoftSQLServerBook/MicrosoftSQLServerNotesForProfessionals.pdf
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class RetrieveBasicServerInformationWebService : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }
	
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query()	
    {
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			SelectStatement,
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}
	
	public const string SelectStatement = 
		@"SELECT '@@SERVERNAME' AS Variable,  @@SERVERNAME AS Value" +
		" UNION SELECT '@@SERVICENAME' AS Variable, @@SERVICENAME AS Value" +
		" UNION SELECT '@@Version' AS Variable, @@VERSION AS Value" +
		" UNION SELECT 'serverproperty(ComputerNamePhysicalNetBIOS)' AS Variable, serverproperty(\'ComputerNamePhysicalNetBIOS\') AS Value";
}
