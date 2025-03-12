<%@ WebService Language="C#" Class="Hour4Minute44WebService" %>

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
http://stackoverflow.com/questions/57226263/c-sharp-regex-to-match-time
2025-03-11T11:04:00...2025-03-11T11:09:00 \d{,2}\:\d{,2}\:\d{,2} 
string timepattern = @"(?:2[0-3]|[01]?[0-9])[:.][0-5]?[0-9][:.][0-5]?[0-9]";
    string value = "30.Jul.2019 This the line I want to match 15:04:09";
    var returnedValue = Regex.Match(value, timepattern);

http://stackoverflow.com/questions/53749593/c-sharp-how-to-filtered-datatable-rows-which-containing-alphanumeric-with-specia	
var matches =
    dt.AsEnumerable()
    .Where(row => Regex.IsMatch(row["Empolyee_CRC"].ToString(),
                                "^[a-zA-Z0-9!@#$&()\\-`.+,/\"]*$"))
    .CopyToDataTable();	
*/
///<summary>
///	2025-03-11T11:19:00...2025-03-11T11:56:00 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class Hour4Minute44WebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string Query()
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
					TimePatternFullMatch
				)
			)
			.CopyToDataTable();	
		
		string json = JsonConvert.SerializeObject(filterTable, Formatting.Indented);
		return json;
    }

	public const String SQLSelectStatement = @"SELECT * FROM WordEngineering..HisWord ORDER BY HisWordID DESC";
	public const String TimePatternFullMatch = @"^\d{1,2}\:\d{1,2}$";
	public const String TimePatternPartialMatch = @"\d{1,2}\:\d{1,2}";	
}
