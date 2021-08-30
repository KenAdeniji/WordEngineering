<%@ WebService Language="C#" Class="TheOnlyTwoCaseThatIsGoingToSucceedAreTheCasePioneerWebService" %>

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
using System.Data.Odbc;
using System.Data.SqlClient;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2021-08-30T13:50:00 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class TheOnlyTwoCaseThatIsGoingToSucceedAreTheCasePioneerWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
	)
    {
		DataTable resultSet = (DataTable) DataCommand.DatabaseCommand
		(
			QueryStatement,
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(resultSet, Formatting.Indented);
		return json;
    }
	
	public const string QueryStatement = @"
SELECT
	Dated,
	CaseBasedReasoningID,
	Commentary,
	Income,
	Expense,
    SUM
	(
		ISNULL(Income, 0) - ISNULL(Expense, 0)
	) 
		OVER
		(
            ORDER BY Dated
            ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW
		) AS RunningTotal
FROM 
	WordEngineering..CaseBasedReasoning
WHERE Income IS NOT NULL OR Expense IS NOT NULL	
";	
	
}
