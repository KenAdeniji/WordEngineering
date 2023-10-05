<%@ WebService Language="C#" Class="SimpleMapsWebService" %>

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
using InformationInTransit.UserInterface;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class SimpleMapsWebService : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }
	
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String QueryCitiesZip(string state)
    {
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			String.Format
			(
				"SELECT City + ', ' + Zip AS CityZip FROM AManDevelopedInAll..MITUnitedStatesCitiesAndZipCodes WHERE State = '{0}' ORDER BY City, Zip",
				state
			),	
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
    }
	
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String QueryLocations(string sourceState, string sourceCityZip, string targetState, string targetCityZip)
    {
		int indexOfSeparatorSource = sourceCityZip.IndexOf(',');
		string sourceCity = sourceCityZip.Substring(0, indexOfSeparatorSource);
		string sourceZip = sourceCityZip.Substring(indexOfSeparatorSource + 1);
		
		int indexOfSeparatorTarget = targetCityZip.IndexOf(',');
		string targetCity = targetCityZip.Substring(0, indexOfSeparatorTarget);
		string targetZip = targetCityZip.Substring(indexOfSeparatorTarget + 1);

		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			String.Format
			(
				"SELECT Latitude, Longitude FROM AManDevelopedInAll..MITUnitedStatesCitiesAndZipCodes WHERE State = '{0}' AND City = '{1}' AND Zip = {2}; " +
				"SELECT Latitude, Longitude FROM AManDevelopedInAll..MITUnitedStatesCitiesAndZipCodes WHERE State = '{3}' AND City = '{4}' AND Zip = {5}",
				sourceState,
				sourceCity,
				sourceZip,
				targetState,
				targetCity,
				targetZip
			),	
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
    }

   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String QueryStates()
    {
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			"SELECT DISTINCT State FROM AManDevelopedInAll..MITUnitedStatesCitiesAndZipCodes ORDER BY State",
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
    }
}
