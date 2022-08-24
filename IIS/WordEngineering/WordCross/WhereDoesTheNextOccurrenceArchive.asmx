<%@ WebService Language="C#" Class="WhereDoesTheNextOccurrenceWebService" %>
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

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;

///<summary>
///	2022-08-23T21:02:00	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WhereDoesTheNextOccurrenceWebService : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string Query
	(
		string word
	)
    {
		DataTable dataTable = (DataTable) DataCommand.DatabaseCommand
		(
			String.Format( SelectQuery, word ),
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		return json;
	}
	
	public const String SelectQuery = @"
		SELECT UseCase, Sender, Recipient, ScriptureReference, Commentary, URI
		FROM WordEngineering..WhereDoesTheNextOccurrence
		WHERE 
			UseCase LIKE '%{0}%' OR
			Sender LIKE '%{0}%' OR
			Recipient LIKE '%{0}%' OR
			ScriptureReference LIKE '%{0}%' OR 
			Commentary LIKE '%{0}%'
		ORDER BY
			UseCase, Sender, Recipient, ScriptureReference, Commentary
	";
}
