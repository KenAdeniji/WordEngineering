<%@ WebService Language="C#" Class="SternIsTheBloodyNameOfTheSinWebService" %>

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

///<summary>
///	2016-09-21	Created.	Stern is the bloody name, of the sin. SternIsTheBloodyNameOfTheSin.asmx
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class SternIsTheBloodyNameOfTheSinWebService : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }
	
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		DateTime datedFrom,
		String unit,
		double quantity,
		string word,
		bool singleDay	
	)	
    {
		double days = 1;
		string json = "";
		switch(unit)
		{
			case "Weeks of Years":
				days = 360 * 7;
				break;
			case "Biblical Years":
				days = 360;
				break;
			case "Biblical Months":
				days = 30;
				break;
		}
		double interval = days * quantity;
		DateTime datedUntil = datedFrom.AddDays(-interval);
		
		if (singleDay)
		{
			datedFrom = datedUntil.AddDays(-1);
		}
		
		json = String.Format(jsonFormat, datedFrom, datedUntil, singleDay);
		//return json;
		
		String selectStatement = String.Format(SelectStatement, datedFrom, datedUntil, word);
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			selectStatement,
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}
	
	public const string jsonFormat = "{{\"datedFrom\": {0}, \"datedUntil\": \"{1}\", \"singleDay\": \"{2}\"}}";
	public const string SelectStatement = "SELECT * FROM WordEngineering..HisWord WHERE Dated BETWEEN '{0}' AND '{1}' AND Word LIKE '%{2}%' ORDER BY HisWordID DESC";
}
