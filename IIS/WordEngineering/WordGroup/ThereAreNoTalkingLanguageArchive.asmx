<%@ WebService Language="C#" Class="ThereAreNoTalkingLanguageWebService" %>
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
///	2019-09-01T16:23:00	Created.
///	7230
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class ThereAreNoTalkingLanguageWebService : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string Query
	(
		String		contactID
	)
    {
		char[] delimiterChars = { ' ', ',', '.', ':', '\t' };

		string[] words = contactID.Split(delimiterChars, System.StringSplitOptions.RemoveEmptyEntries);
		
		string contactIDs = string.Join(",", words);
		
		String 	sqlStatement = String.Format
		(
			SqlStatement,
			contactIDs
		);	
	
		DataTable dataTable = (DataTable)DataCommand.DatabaseCommand
		(
			sqlStatement,
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		String	json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		
		return json;
	}
	
	String 	SqlStatement = 
	@"SELECT Dated, Company, Commentary, ContactID, ScriptureReference
		FROM WordEngineering..Contact
		WHERE ContactID IN ({0})
		ORDER BY Dated DESC
	";
}
