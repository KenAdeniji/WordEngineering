<%@ WebService Language="C#" Class="WhereIsGodAbsentWebService" %>

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
using System.Web.Script.Serialization;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2025-03-24T13:19:00...2025-03-24T14:02:00 SQL.
///	http://stackoverflow.com/questions/28370295/sql-server-how-to-test-if-a-string-has-only-digit-characters
///	http://www.sqlshack.com/sql-percentage-calculation-examples-in-sql-server
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WhereIsGodAbsentWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query()
    {
		DataTable dataTable = (DataTable) DataCommand.DatabaseCommand
		(
			QueryStatement,
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		return json;
    }
	
	public const String QueryStatement = @"
		SELECT	'Alpha' AS InfoType, COUNT(*) CountInfo, 
		(
			Count(*) * 100.0 / (SELECT COUNT(*) FROM WordEngineering..HisWord)
		) PercentageOfTotal
		FROM WordEngineering..HisWord WHERE Word NOT LIKE '%[0-9]%'
		UNION
		SELECT	'Numeric' AS InfoType, COUNT(*) CountInfo, 
		(
			Count(*) * 100.0 / (SELECT COUNT(*) FROM WordEngineering..HisWord)
		) PercentageOfTotal
		FROM WordEngineering..HisWord WHERE Word LIKE '%[0-9]%'
		UNION
		SELECT	'NULL' AS InfoType, COUNT(*) CountInfo, 
		(
			Count(*) * 100.0 / (SELECT COUNT(*) FROM WordEngineering..HisWord)
		) PercentageOfTotal
		FROM WordEngineering..HisWord WHERE Word IS NULL
		UNION
		SELECT	'Total' AS InfoType, COUNT(*) CountInfo, 
		(
			Count(*) * 100.0 / (SELECT COUNT(*) FROM WordEngineering..HisWord)
		) PercentageOfTotal
		FROM WordEngineering..HisWord
	";	
}
