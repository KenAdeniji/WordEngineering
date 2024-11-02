<%@ WebService Language="C#" Class="IWantToBringAllTheFamiliesTogetherWebService" %>

using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;

using System.Data.SqlClient;
using System.Text;	
using System.Text.RegularExpressions;	

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessCode;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

using Newtonsoft.Json;

///<summary>
///	2024-02-22T08:25:00...2024-02-22T09:52:00 Created.
///		http://stackoverflow.com/questions/8784517/counting-number-of-words-in-c-sharp
///			Regex.Matches(str, @"((\w+(\s?)))").Count;
///	2024-02-22T08:44:00	http://stackoverflow.com/questions/13012585/how-i-can-filter-a-datatable
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class IWantToBringAllTheFamiliesTogetherWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string Query
	(
		int wordsCountMinimum,
		int wordsCountMaximum
	)
    {
		DataTable resultTable = (DataTable) DataCommand.DatabaseCommand
		(
			QueryStatement,
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		DataTable linqTable = resultTable
			.AsEnumerable()
            .Where
			(
				x => 
				Regex.Matches(x.Field<string>("Word"), @"((\w+(\s?)))").Count >= wordsCountMinimum
				&&
				Regex.Matches(x.Field<string>("Word"), @"((\w+(\s?)))").Count <= wordsCountMaximum
			)			
			.CopyToDataTable();
		
		string json = JsonConvert.SerializeObject(linqTable, Formatting.Indented);
		return json;
    }
	
	public const String QueryStatement = @"
		SELECT Dated, HisWordID, Word, Commentary 
		FROM WordEngineering..HisWord 
		WHERE Word IS NOT NULL
	";
}
