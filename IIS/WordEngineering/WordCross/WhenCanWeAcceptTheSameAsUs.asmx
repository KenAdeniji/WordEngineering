<%@ WebService Language="C#" Class="WhenCanWeAcceptTheSameAsUsWebService" %>

using System;
using System.Data;
using System.Numerics;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;

using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2023-08-19T14:04:00 ... 2023-08-19T14:19:00 Created.
///	2023-08-19T14:28:00 ... 2023-08-19T14:32:00 Continued.
///	When can we accept the same as us?
///	2023-08-19T14:44:00 ... 2023-08-19T15:16:00 TryParse()
///	2023-08-19T16:46:00 ... 2023-08-19T17:22:00 FromUntilFirst = 
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WhenCanWeAcceptTheSameAsUsWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String bibleWord
	)
    {
		String queryStatement = null;
		
		String queryDefault = null;
		Boolean queryBoolean = true;
		DateTime queryDateTime = DateTime.MinValue;
		Int64 queryNumber = Int64.MinValue;
		
		if (Int64.TryParse(bibleWord, out queryNumber)) 
		{
			queryStatement = QueryStatementNumber;
		}
		else if (DateTime.TryParse(bibleWord, out queryDateTime)) 
		{
			queryStatement = QueryStatementDateTime;
		}
		else if (Boolean.TryParse(bibleWord, out queryBoolean)) 
		{
			queryStatement = QueryStatementBoolean;
			bibleWord = bibleWord.ToLower() == "true" ? "1" : "0"; 
		}
		else
		{
			queryStatement = QueryStatementDefault;
		}
		
		DataSet resultSet = (DataSet) DataCommand.DatabaseCommand
		(
			String.Format
			(
				queryStatement,
				bibleWord
			),
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(resultSet, Formatting.Indented);
		return json;
    }

	public const String QueryStatementBoolean =
	@"
SELECT * FROM WordEngineering..Remember_View WHERE FromUntilFirst = {0} ORDER BY RememberID DESC;
	";
	
	public const String QueryStatementDateTime =
	@"
SELECT * FROM WordEngineering..HisWord_View WHERE CONVERT(date, Dated) = '{0}' ORDER BY HisWordID DESC;
	";

	public const String QueryStatementNumber =
	@"
SELECT TOP 1 * FROM WordEngineering..NumberSign WHERE Number = {0} ORDER BY Number;
SELECT * FROM WordEngineering..HisWord_View WHERE AlphabetSequenceIndex = {0} ORDER BY HisWordID DESC;
	";
	
	public const String QueryStatementDefault =
	@"
SELECT * FROM WordEngineering..HisWord_View WHERE Word LIKE '%{0}%' ORDER BY HisWordID DESC;
	";

}

