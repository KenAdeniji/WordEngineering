<%@ WebService Language="C#" Class="YouDontNeedAHornetWebService" %>

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
///	2018-09-21 Created.	Will accept a word and determine the vowel percentage for a scripture reference.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class YouDontNeedAHornetWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query(string word)
    {
		word = word.Replace("'", "''");
		String selectQuery = String.Format(SelectQuery, word);
		
		String result = (String) DataCommand.DatabaseCommand
		(
			selectQuery,
			System.Data.CommandType.Text,
			DataCommand.ResultType.Scalar
		);
		
		string json = JsonConvert.SerializeObject(result, Formatting.Indented);
		return json;
    }
	
	public const String SelectQuery = @"SELECT WordEngineering.dbo.udf_AlphabetSequenceYouDontNeedAHornet('{0}')";
}
