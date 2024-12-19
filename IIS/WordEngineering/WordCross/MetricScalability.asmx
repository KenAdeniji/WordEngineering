<%@ WebService Language="C#" Class="MetricScalabilityWebService" %>

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
///	2024-12-16T09:07:00...2024-12-16T09:46:00 SQL.
///	2024-12-15 sqlservercentral.com/articles/getting-started-with-the-data-api-builder
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class MetricScalabilityWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query()
    {
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			QueryStatement,
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
    }
	
	public const String QueryStatement = @"
		SELECT 		*
		FROM		Bible..Exact_View
		WHERE 		BibleWord IN ('beginning', 'evening', 'morning', 'day', 'season', 'year', 'generation', 'month', 'die')
		ORDER BY 	FirstOccurrenceVerseIDSequence
		;
		SELECT 		*
		FROM		Bible..Exact_View
		WHERE 		BibleWord IN ('earth', 'city', 'house', 'kingdom', 'country', 'tribe')
		ORDER BY 	FirstOccurrenceVerseIDSequence
		;
	";	
}
