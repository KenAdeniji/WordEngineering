<%@ WebService Language="C#" Class="ToRememberHisConversationAsMineWebService" %>

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
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2018-07-31 	Created.
///	2018-08-01	stackoverflow.com/questions/889629/how-to-get-a-date-in-yyyy-mm-dd-format-from-a-tsql-datetime-field
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class ToRememberHisConversationAsMineWebService : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }

   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Country()
    {
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			"Select Distinct Country FROM WordEngineering..ToRememberHisConversationAsMine ORDER BY Country ASC",
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);

		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);

		return json;
    }
	
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		DateTime	referenceDate,
		String 		country
	)
    {
		String query = String.Format(QueryFormat, referenceDate, country);
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			query,
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);

		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);

		return json;
    }
	
//	public const string QueryFormat = "Select CONVERT(NVARCHAR(MAX), CAST('{0}' as date), 120) AS ReferenceDate, FORMAT(Dated, 'yyyy-MM-dd') AS Dated, DateDiff(day, dated, '{0}') AS Days, Commentary FROM WordEngineering..ToRememberHisConversationAsMine Where Country LIKE '%{1}%' OR Country IS NULL ORDER BY Country, Dated ASC";
	public const string QueryFormat = "Select FORMAT(Dated, 'yyyy-MM-dd') AS Dated, DateDiff(day, dated, '{0}') AS Days, Commentary FROM WordEngineering..ToRememberHisConversationAsMine Where Country LIKE '%{1}%' OR Country IS NULL ORDER BY Country, Dated ASC";	
}
