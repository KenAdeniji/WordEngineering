<%@ WebService Language="C#" Class="DetailAndCustomerAggregatesReturningThePercentageAndDifferenceWebService" %>

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
using InformationInTransit.ProcessCode;

///<summary>
///	2019-02-10	Created.	http://the-eye.eu/public/Books/IT%20Various/microsoft_sql_server_2012_high-performance_t-sql_using_window_functions.pdf
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class DetailAndCustomerAggregatesReturningThePercentageAndDifferenceWebService : System.Web.Services.WebService
{
	
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query()
    {
		DataSet dataSet = (DataSet)DataCommand.DatabaseCommand
		(
			SelectFormat,
			CommandType.Text,
			DataCommand.ResultType.DataSet
        );
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}
	
	public const string SelectFormat = 
	@"
SELECT 
	CONVERT(char(10), Dated, 126) AS Dated,
	ContactID,
	Expense,
	CAST(100. * Expense / SUM(Expense) OVER(PARTITION BY ContactID) AS NUMERIC(5, 2)) AS pctcust,
	Expense - AVG(Expense) OVER(PARTITION BY ContactID) AS diffcust 
FROM 
	WordEngineering..CaseBasedReasoning
WHERE
	ContactID IS NOT NULL AND Expense IS NOT NULL
ORDER BY
	ContactID DESC, Dated DESC
		";
}
