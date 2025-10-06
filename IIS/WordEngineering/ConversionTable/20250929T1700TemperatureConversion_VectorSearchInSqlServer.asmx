<%@ WebService Language="C#" Class="TemperatureConversion_VectorSearchInSqlServerWebService" %>

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
///	2025-09-29T20:36:00	mssqltips.com/sqlservertip/8299/vector-search-in-sql-server/
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class TemperatureConversion_VectorSearchInSqlServerWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query(int celsuisTemperature)
    {
		DataTable dataTable = (DataTable) DataCommand.DatabaseCommand
		(
			String.Format
			(
				"usp_20250929T1700TemperatureConversion_VectorSearchInSqlServer {0}",
				celsuisTemperature
			),	
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		return json;
    }
}
