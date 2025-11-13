<%@ WebService Language="C#" Class="ActToGodWebService" %>

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

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2015-11-01 	Created.
///	2017-03-08	QueryMajor
///	2025-11-12T10:24:00 "EXEC WordEngineering..usp_getActToGods '" + major + "'"
///	2025-11-12T20:01:00 major = major.Replace("'", "''");
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class ActToGodWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Major()
    {
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			"Select Distinct Major FROM WordEngineering..ActToGod ORDER BY Major ASC",
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);

		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);

		return json;
    }
	
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String MightyMenOfDavid2Samuel23()
    {
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			"SELECT BibleDictionaryWord_View.*, ActToGod.ScriptureReference FROM WordEngineering..BibleDictionaryWord_View JOIN WordEngineering..ActToGod ON BibleDictionaryWord_View.DictionaryWord = ActToGod.Actor WHERE ActToGod.Major like '%Mighty men of David%' ORDER BY ActToGodID ASC",
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);

		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);

		return json;
    }
	
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query(String major)
    {
		major = major.Replace("'", "''");
		DataTable dataTable = (DataTable) DataCommand.DatabaseCommand
		(
			"EXEC WordEngineering..usp_getActToGods '" + major + "'",
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);

		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);

		return json;
    }
	
	public const string QueryFormatWithoutMajor = "Select Major, Minor, Commentary, ScriptureReference, URI FROM WordEngineering..ActToGod ORDER BY Major, Minor ASC";
	public const string QueryFormatWithMajor = "Select Minor, Commentary, ScriptureReference, URI FROM WordEngineering..ActToGod Where Major LIKE '%{0}%' ORDER BY Major, Minor ASC";	
}
