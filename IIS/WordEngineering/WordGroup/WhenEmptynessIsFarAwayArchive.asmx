<%@ WebService Language="C#" Class="WhenEmptynessIsFarAwayWebService" %>

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
///	2018-10-03 Created.	Is for identifying the main actor, in a book.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WhenEmptynessIsFarAwayWebService : System.Web.Services.WebService
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
	
	public const String SelectQuery = @"
SELECT 
	BookTitle AS ScriptureReference,
	Actor AS BibleWord
FROM
	Bible..BibleBook
WHERE
	Actor IS NOT NULL
ORDER BY
	BookID
	";
}
