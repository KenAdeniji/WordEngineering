<%@ WebService Language="C#" Class="WantingMeToTheGrooveButTheGrooveDontTakeControlOfMeWantingMeToControlOfMyselfWebService" %>

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
///	2018-09-29 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WantingMeToTheGrooveButTheGrooveDontTakeControlOfMeWantingMeToControlOfMyselfWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query(string top)
    {
		String selectQuery = String.Format(SelectQuery, top);
		
		DataSet result = (DataSet) DataCommand.DatabaseCommand
		(
			selectQuery,
			System.Data.CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(result, Formatting.Indented);
		return json;
    }
	
	public const String SelectQuery = @"
SELECT TOP {0}
	BookTitle + ' ' + CONVERT(VARCHAR, ChapterID) AS ScriptureReference,
	MAX(VerseID) AS VerseIDMax
FROM
	Bible..Scripture_View
GROUP BY
	BookTitle,
	ChapterID
ORDER BY
	VerseIDMax DESC
	";
}
