<%@ WebService Language="C#" Class="usp_CensusWebService" %>

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
/*
	2017-03-21	Sams Teach Yourself SQL in 24 Hours Sixth Edition
	2017-03-21	http://www.informit.com/store/sql-in-24-hours-sams-teach-yourself-9780672337598
	2017-03-22	Created.
	2017-03-22	CensusRollupCubeManOWar.html
	2017-03-22	We went shopping for clothes, and the trend is Man O War long sleeve vest shirt.
	2017-03-25	To help, one another; choose the choosing of our time.
	2017-03-26	Ever since life knows you; I pretend to be the same.
	2017-07-01	http://www.techonthenet.com/sql_server/pivot.php
*/
///<summary>
///	2015-10-26	Created.	Census.asmx
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class usp_CensusWebService : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }

	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String CensusPopulationPivot()
    {
		DataSet dataSet = null;
		dataSet = (DataSet)DataCommand.DatabaseCommand
		(
			"WordEngineering..usp_CensusPopulationPivot",
			CommandType.StoredProcedure,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}
	
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String EverSinceLifeKnowsYouIPretendToBeTheSame()
    {
		DataSet dataSet = null;
		dataSet = (DataSet)DataCommand.DatabaseCommand
		(
			"WordEngineering..usp_EverSinceLifeKnowsYouIPretendToBeTheSame" ,
			CommandType.StoredProcedure,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}
	
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String RollupCubeManOWar()
    {
		DataSet dataSet = null;
		dataSet = (DataSet)DataCommand.DatabaseCommand
		(
			"SELECT FirstCensus.Tribe, SUM(FirstCensus.CensusPopulation) AS TotalFirstCensus, SUM(SecondCensus.CensusPopulation) AS TotalSecondCensus FROM WordEngineering..[CensusFirstNumbers1OceanSenior] AS FirstCensus JOIN WordEngineering..CensusSecondNumbers26 AS SecondCensus ON FirstCensus.Tribe = SecondCensus.Tribe GROUP BY FirstCensus.Tribe WITH ROLLUP ORDER BY FirstCensus.Tribe",
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}

	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String RunningAggregation()
    {
		DataSet dataSet = null;
		dataSet = (DataSet)DataCommand.DatabaseCommand
		(
			"WordEngineering..usp_CensusRunningAggregation",
			CommandType.StoredProcedure,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}
	
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query()
    {
		DataSet dataSet = null;
		dataSet = (DataSet)DataCommand.DatabaseCommand
		(
			"SELECT * FROM WordEngineering..Census_View" ,
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}
	
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String ToHelpOneAnotherChooseTheChoosingOfOurTime()
    {
		DataSet dataSet = null;
		dataSet = (DataSet)DataCommand.DatabaseCommand
		(
			"WordEngineering..usp_ToHelpOneAnotherChooseTheChoosingOfOurTime" ,
			CommandType.StoredProcedure,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}
}
