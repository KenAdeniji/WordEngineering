<%@ WebService Language="C#" Class="ToLookAtOnesRelationAsAPlaceWebService" %>

using System;
using System.Data;
using System.Numerics;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;

using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2023-07-02T20:50:00 ... 2023-07-02T21:12:00 Created. To look at one's relation as a place. 
///	Bernadette. Lucy dog. South Bay Community Church.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class ToLookAtOnesRelationAsAPlaceWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
	)
    {
		DataTable resultTable = (DataTable) DataCommand.DatabaseCommand
		(
			QueryStatement,
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(resultTable, Formatting.Indented);
		return json;
    }
	
	public const String QueryStatement =
	@"
		SELECT 
			'Testament' AS Division,
			COUNT(DISTINCT Testament) AS Count,
			1.0 / COUNT(DISTINCT Testament) AS Ratio
		FROM
			Bible..Scripture_View
		UNION
		SELECT 
			'Book' AS Division,
			COUNT(DISTINCT BookID) AS Count,
			1.0 / COUNT(DISTINCT BookID) AS Ratio
		FROM
			Bible..Scripture_View
		UNION
		SELECT 
			'Chapter' AS Division,
			COUNT(DISTINCT ChapterIDSequence) AS Count,
			1.0 / COUNT(DISTINCT ChapterIDSequence) AS Ratio
		FROM
			Bible..Scripture_View
		UNION
		SELECT 
			'Verse' AS Division,
			COUNT(DISTINCT VerseIDSequence) AS Count,
			1.0 / COUNT(DISTINCT VerseIDSequence) AS Ratio
		FROM
			Bible..Scripture_View
	";
}

