<%@ WebService Language="C#" Class="InTimeAnswerPastWebService" %>

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
///	2018-09-20 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class InTimeAnswerPastWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query(string question, string scriptureReference)
    {
		String selectQuery = String.Format(SelectQuery, question, scriptureReference);
		
		DataSet result = (DataSet) DataCommand.DatabaseCommand
		(
			selectQuery,
			System.Data.CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(result, Formatting.Indented);
		return json;
    }
	
	public const String SelectQuery = "SELECT Minor AS Question, ScriptureReference FROM WordEngineering..ActToGod WHERE Major = 'In time, answer past.' AND Minor LIKE '%{0}%'  AND ScriptureReference LIKE '%{1}%' ORDER BY Minor, Actor ";
}
