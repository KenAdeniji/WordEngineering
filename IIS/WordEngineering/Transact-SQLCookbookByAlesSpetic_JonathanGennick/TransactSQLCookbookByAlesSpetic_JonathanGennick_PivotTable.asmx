<%@ WebService Language="C#" Class="TransactSQLCookbookByAlesSpetic_JonathanGennick_PivotTableWebService" %>

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
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2018-05-01 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class TransactSQLCookbookByAlesSpetic_JonathanGennick_PivotTableWebService : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }

   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		int digitsLength,
		int	asciiFrom,
		int	asciiUntil,
		int	dateAddFrom,
		int	dateAddUntil,
		int	dateAddStep
	)
    {
		DataSet result = TransactSQLCookbookByAlesSpetic_JonathanGennick_PivotTable.Query
		(
			digitsLength,
			asciiFrom,
			asciiUntil,
			dateAddFrom,
			dateAddUntil,
			dateAddStep
		);

		string json = JsonConvert.SerializeObject(result, Formatting.Indented);
		return json;
    }
}
