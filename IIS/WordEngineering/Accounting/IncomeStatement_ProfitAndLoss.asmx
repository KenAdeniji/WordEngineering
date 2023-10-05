<%@ WebService Language="C#" Class="IncomeStatement_ProfitAndLossWebService" %>
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
using System.Linq;

using System.Text;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessCode;
using InformationInTransit.ProcessLogic;

///<summary>
///	2019-08-17 06:37:27.153	Accounting of the Bible - General Ledger, Balance Sheet, Profit/Loss
///	2019-08-17	https://en.wikipedia.org/wiki/Income_statement
///	2019-08-18	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class IncomeStatement_ProfitAndLossWebService : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string Query()
    {
		DataTable dataTable = (DataTable)DataCommand.DatabaseCommand
		(
			SqlStatement,
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		String	json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		
		return json;
	}
	
	public const String SqlStatement = 
	@"	SELECT Debit, Credit, Unit, Giver, Taker, Commentary, ScriptureReference
		FROM IShallBeTheirInheritance..IncomeStatement_ProfitAndLoss
	";	
}
