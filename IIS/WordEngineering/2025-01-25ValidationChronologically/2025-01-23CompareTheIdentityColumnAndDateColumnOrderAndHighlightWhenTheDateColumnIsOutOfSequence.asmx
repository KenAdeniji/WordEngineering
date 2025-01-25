<%@ WebService Language="C#" Class="CompareIdentityColumnAndDateColumn_OutOfSequenceWebService" %>

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
using System.Web.Script.Serialization;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2025-01-25 SQL
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class CompareIdentityColumnAndDateColumn_OutOfSequenceWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query()
    {
		DataTable dataTable = (DataTable) DataCommand.DatabaseCommand
		(
			QueryStatement,
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		return json;
    }
	
	public const String QueryStatement = @"
SELECT * FROM WordEngineering..HisWord HisWordLead
WHERE Dated >
(
	SELECT TOP 1 Dated
	FROM WordEngineering..HisWord HisWordLag
	WHERE HisWordLead.HisWordID < HisWordLag.HisWordID
	ORDER BY HisWordLead.HisWordID 
)
ORDER BY HisWordID DESC
	";	
}
