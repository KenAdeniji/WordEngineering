<%@ WebService Language="C#" Class="Number15431WebService" %>

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

using System.Text;
using	System.Text.RegularExpressions;

using InformationInTransit.DataAccess;

using Newtonsoft.Json;

/*
	2025-03-14T13:43:00...2025-03-14T13:58:00	http://stackoverflow.com/questions/273141/regex-for-numbers-only
*/
///<summary>
///	2025-03-14T13:43:00 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class Number15431WebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string Query
	(
		bool	partialMatch
	)
    {
		DataTable selectTable = (DataTable) DataCommand.DatabaseCommand
		(
			SQLSelectStatement,
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		DataTable filterTable = 
			selectTable.AsEnumerable()
			.Where
			(
				row => Regex.IsMatch
				(
					row["Word"].ToString(),
					partialMatch ? NumberPatternPartialMatch : NumberPatternFullMatch
				)
			)
			.CopyToDataTable();	
		
		string json = JsonConvert.SerializeObject(filterTable, Formatting.Indented);
		return json;
    }

	public const String SQLSelectStatement = @"SELECT * FROM WordEngineering..HisWord ORDER BY HisWordID DESC";
	public const String NumberPatternFullMatch = @"^\d+$";
	public const String NumberPatternPartialMatch = @"\d+";	
}
