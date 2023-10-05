<%@ WebService Language="C#" Class="DistributedLedgerAlsoCalledASharedLedgerOrDistributedLedgerTechnologyOrDLTWebService" %>

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

using System.Reflection;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessCode;

///<summary>
/// 2020-12-10T15:27:00 ... 2020-12-10T15:55:00	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class DistributedLedgerAlsoCalledASharedLedgerOrDistributedLedgerTechnologyOrDLTWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
	)
    {
        DataTable result = (DataTable) DataCommand.DatabaseCommand
        (
            SqlStatement,
            CommandType.Text,
            DataCommand.ResultType.DataTable
        );
		string json = JsonConvert.SerializeObject(result, Formatting.Indented);
		return json;
    }
	
	public const string SqlStatement = 
	@"
	SELECT Minor, Commentary
	FROM WordEngineering..ActToGod
	WHERE Major = 'distributed ledger (also called a shared ledger or distributed ledger technology or DLT)'
	ORDER BY Minor
	";
}
