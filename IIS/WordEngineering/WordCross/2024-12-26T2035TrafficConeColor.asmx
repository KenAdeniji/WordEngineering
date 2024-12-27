<%@ WebService Language="C#" Class="TrafficConeColorWebService" %>

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
///	2024-12-26T21:44:00...2024-12-26T22:19:00 SQL.
///	http://stackoverflow.com/questions/12927268/sum-of-grouped-count-in-sql-query
///	http://stackoverflow.com/questions/41735085/how-to-use-count-like-and-group-by-in-single-query
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class TrafficConeColorWebService : System.Web.Services.WebService
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
SELECT	
		CASE	
				WHEN Word LIKE '%Blue%'		THEN 'Blue'
				WHEN Word LIKE '%Green%'	THEN 'Green'
				WHEN Word LIKE '%Orange%'	THEN 'Orange'
				WHEN Word LIKE '%Pink%'		THEN 'Pink'
				WHEN Word LIKE '%Red%'		THEN 'Red'
				WHEN Word LIKE '%White%'	THEN 'White'
				WHEN Word LIKE '%Yellow%'	THEN 'Yellow'
		END 
		Color,
		COUNT(*) AS Count,
		COUNT(*) * 100
		/
		SUM
		(
			COUNT
			(
				CASE	
					WHEN Word LIKE '%Blue%'		THEN 'Blue'
					WHEN Word LIKE '%Green%'	THEN 'Green'
					WHEN Word LIKE '%Orange%'	THEN 'Orange'
					WHEN Word LIKE '%Pink%'		THEN 'Pink'
					WHEN Word LIKE '%Red%'		THEN 'Red'
					WHEN Word LIKE '%White%'	THEN 'White'
					WHEN Word LIKE '%Yellow%'	THEN 'Yellow'
				END 
			)
		)	OVER() AS Percentage
FROM WordEngineering..HisWord
GROUP BY 
		CASE	
				WHEN Word LIKE '%Blue%'		THEN 'Blue'
				WHEN Word LIKE '%Green%'	THEN 'Green'
				WHEN Word LIKE '%Orange%'	THEN 'Orange'
				WHEN Word LIKE '%Pink%'		THEN 'Pink'
				WHEN Word LIKE '%Red%'		THEN 'Red'
				WHEN Word LIKE '%White%'	THEN 'White'
				WHEN Word LIKE '%Yellow%'	THEN 'Yellow'
		END 
ORDER BY Color
	";	
}
