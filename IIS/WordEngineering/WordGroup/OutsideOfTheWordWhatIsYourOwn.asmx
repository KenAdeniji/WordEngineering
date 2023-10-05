<%@ WebService Language="C#" Class="OutsideOfTheWordWhatIsYourOwnWebService" %>

using System;
using System.Data;
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
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2020-08-28 Created.	https://stackoverflow.com/questions/54820970/ms-sql-count-the-occurrences-of-a-word-in-a-field
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class OutsideOfTheWordWhatIsYourOwnWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
	)	
    {
		DataTable dataTable = (DataTable) DataCommand.DatabaseCommand
		(
			QueryFormat,
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		return json;
    }
	
	public const string QueryFormat = 
	@"
		SELECT Value, COUNT(Value) AS Occurrences  
		FROM WordEngineering..HisWord
			CROSS APPLY STRING_SPLIT(REPLACE(REPLACE(REPLACE(Word,',',' '), '.', ' '),';', ' '), ' ')
		WHERE Value <> ' '
		GROUP BY Value
		ORDER BY Occurrences DESC, Value
	";
}
