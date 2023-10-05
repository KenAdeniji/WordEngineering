<%@ WebService Language="C#" Class="QuickStartsRLanguageWebService" %>

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
///	2018-12-13	Created.	https://docs.microsoft.com/en-us/sql/advanced-analytics/tutorials/rtsql-using-r-code-in-transact-sql-quickstart?view=sql-server-2017
///	2018-12-13	https://docs.microsoft.com/en-us/sql/advanced-analytics/tutorials/rtsql-using-r-functions-with-sql-server-data?view=sql-server-2017
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class QuickStartsRLanguageWebService : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query()	
    {
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			@"WordEngineering..usp_QuickStartsRLanguage",
			CommandType.StoredProcedure,
			DataCommand.ResultType.DataSet
		);
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}

	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String RandomNumberGenerator
	(
		int	countLength,
		decimal meanAverage,
		decimal standardDeviation
	)	
    {
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			String.Format
			(
				usp_QuickStartsRLanguageRandomNumberGenerator,
				countLength,
				meanAverage,
				standardDeviation
			),	
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}
	
	public const string usp_QuickStartsRLanguageRandomNumberGenerator =
		"EXECUTE WordEngineering..usp_QuickStartsRLanguageRandomNumberGenerator {0}, {1}, {2}";
}
