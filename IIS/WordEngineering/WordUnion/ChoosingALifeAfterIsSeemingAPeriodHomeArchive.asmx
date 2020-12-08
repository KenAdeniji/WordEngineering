<%@ WebService Language="C#" Class="ChoosingALifeAfterIsSeemingAPeriodHomeWebService" %>

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
///	2018-04-08 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class ChoosingALifeAfterIsSeemingAPeriodHomeWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query(String scriptureReference, string bibleVersion)
    {
		string sqlStatement = String.Format
		(
			SelectFormat,
			scriptureReference,
			bibleVersion
		);
		DataSet result = (DataSet) DataCommand.DatabaseCommand
		(
			sqlStatement,
			System.Data.CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(result, Formatting.Indented);
		return json;
    }
	
	public const string SelectFormat = "SELECT ScriptureReference, {1} AS VerseText FROM Bible..Scripture_View WHERE ScriptureReference LIKE '%{0}%' ORDER BY VerseIDSequence";
}
