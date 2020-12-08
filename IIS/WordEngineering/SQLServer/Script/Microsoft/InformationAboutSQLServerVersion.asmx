<%@ WebService Language="C#" Class="InformationAboutSQLServerVersionWebService" %>

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
public class InformationAboutSQLServerVersionWebService : System.Web.Services.WebService
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
		@"SELECT    SERVERPROPERTY('MachineName') AS Host,          SERVERPROPERTY('InstanceName') AS Instance,          DB_NAME() AS DatabaseContext,          SERVERPROPERTY('Edition') AS Edition,          SERVERPROPERTY('ProductLevel') AS ProductLevel,          CASE SERVERPROPERTY('IsClustered')            WHEN 1 THEN 'CLUSTERED'            ELSE 'STANDALONE' END AS ServerType,          @@VERSION AS VersionNumber;"
		+ @"SELECT    SERVERPROPERTY('ProductVersion') AS ProductVersion,            SERVERPROPERTY('ProductLevel') AS ProductLevel,            SERVERPROPERTY('Edition') AS Edition,            SERVERPROPERTY('EngineEdition') AS EngineEdition;"		
		+ @"SELECT  DATEDIFF(DAY, login_time, getdate()) AS UpDays FROM    master..sysprocesses WHERE   spid = 1" 
		;
}
