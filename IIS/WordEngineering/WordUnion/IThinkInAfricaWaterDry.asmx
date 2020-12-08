<%@ WebService Language="C#" Class="IThinkInAfricaWaterDryWebService" %>

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
///	2016-09-11	Created.	I think in Africa, water dry. IThinkInAfricaWaterDry.asmx
///		https://www.techonthenet.com/sql_server/intersect.php
///		http://stackoverflow.com/questions/194852/concatenate-many-rows-into-a-single-text-string
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class IThinkInAfricaWaterDryWebService : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }
	
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query()	
    {
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			SelectStatement,
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}
	
	public const string SelectStatement = @"
		SELECT KingJamesVersion AS verseText, 
			COUNT(*) AS Occurrences,
			STUFF((SELECT ', ' + ScriptureReference 
		FROM 
			Bible..Scripture_View Columns
		WHERE Tables.KingJamesVersion = Columns.KingJamesVersion
		ORDER BY
			ScriptureReference FOR XML PATH ('')), 1, 1, '') Columns
		FROM Bible..Scripture_View Tables 
		GROUP BY 
			KingJamesVersion 
		HAVING
			COUNT(*) > 1 ORDER BY Occurrences DESC
	";
}
