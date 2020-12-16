<%@ WebService Language="C#" Class="YouJustFakeOneTakeOneWebService" %>

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
///	2018-08-14 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class YouJustFakeOneTakeOneWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query()
    {
		DataSet result = (DataSet) DataCommand.DatabaseCommand
		(
			SelectQuery,
			System.Data.CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(result, Formatting.Indented);
		return json;
    }
	
	public const string SelectQuery = @"
SELECT 
	BookTitle,
	MAX(ChapterIDSequence) AS Chapters,
	MAX(VerseIDSequence) AS Verses
FROM
	Bible..Scripture_View
GROUP BY
	BookID,
	BookTitle
ORDER BY
	BookID
	";
}
