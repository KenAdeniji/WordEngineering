<%@ WebService Language="C#" Class="OnJustThatOneColumnWebService" %>

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
///	2025-12-14T14:38:00	 
///		Umika Sushi Inc Charter Square. 34129 Fremont Boulevard. Fremont, California (CA) 94555. United States of America (USA).
///		Regular Expression on the WordEngineering..HisWord.Word column. Alpha, number, date, month name and day of month. List the month names, and number between 1 and 31.
///	http://stackoverflow.com/questions/28370295/sql-server-how-to-test-if-a-string-has-only-digit-characters
///	http://www.sqlshack.com/sql-percentage-calculation-examples-in-sql-server
/// 2025-03-24T1242WhereIsGod...Absent.asmx
///	http://stackoverflow.com/questions/7957423/finding-rows-that-dont-contain-numeric-data-in-oracle
///		Occurrences: 4
///		InfoType	CountInfo	PercentageOfTotal
///		Alpha		114015		93.895921006036
///		Numeric		925			0.761774564141
///		NULL		7251		5.971489042799
///		Total		121427		100		
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class OnJustThatOneColumnWebService : System.Web.Services.WebService
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
		FROM WordEngineering..HisWord WHERE REGEXP_LIKE(Word, '[^0-9]+')
		UNION
		SELECT	'Numeric' AS InfoType, COUNT(*) CountInfo, 
		(
			Count(*) * 100.0 / (SELECT COUNT(*) FROM WordEngineering..HisWord)
		) PercentageOfTotal
		FROM WordEngineering..HisWord WHERE REGEXP_LIKE(Word, '[0-9]+')
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
