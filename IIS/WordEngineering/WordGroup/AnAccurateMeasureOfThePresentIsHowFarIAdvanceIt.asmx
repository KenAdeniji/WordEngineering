<%@ WebService Language="C#" Class="AnAccurateMeasureOfThePresentIsHowFarIAdvanceItWebService" %>

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
///	2018-08-24 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class AnAccurateMeasureOfThePresentIsHowFarIAdvanceItWebService : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }

   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query(string measure)
    {
		bool isNumber = false;	
		decimal alphabetSequenceIndex = -1;
		
		string filler = "";
		string selectQuery = "";
		
		isNumber = Decimal.TryParse(measure, out alphabetSequenceIndex);
		
		if (isNumber)
		{
			filler = "AlphabetSequenceIndex = " + alphabetSequenceIndex; 
		}
		else
		{
			filler = "AlphabetSequenceIndexScriptureReference LIKE '%" + measure + "%'";
		}
		
		selectQuery = String.Format(SelectQuery, filler);
		
		DataSet result = (DataSet) DataCommand.DatabaseCommand
		(
			selectQuery,
			System.Data.CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(result, Formatting.Indented);
		return json;
    }
	
	public const String SelectQuery = "SELECT Dated, Word FROM WordEngineering..HisWord_View WHERE {0} ORDER BY HisWordID DESC";
}
