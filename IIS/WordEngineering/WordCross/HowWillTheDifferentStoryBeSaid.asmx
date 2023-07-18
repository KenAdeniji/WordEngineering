<%@ WebService Language="C#" Class="HowWillTheDifferentStoryBeSaidWebService" %>

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
///	2023-07-18T12:18:00 ... 2023-07-18T12:46:00 Created.
///	2023-07-18T12:18:00 ... 2023-07-18T12:41:00 SQL.
///	2023-07-18T12:41:00 ... 2023-07-18T13:01:00 Web service (.ASMX)
///	There needs to be a part, taken out? Sexuality.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class HowWillTheDifferentStoryBeSaidWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String bibleVersion
	)
    {
		DataTable resultTable = (DataTable) DataCommand.DatabaseCommand
		(
			String.Format
			(
				QueryStatement,
				bibleVersion
			),
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(resultTable, Formatting.Indented);
		return json;
    }
	
	public const String QueryStatement =
	@"
SELECT
	BookID,
	BookTitle,
	(
		SELECT COUNT(*) Said
		FROM Bible..Scripture_View ScriptureGroup
		WHERE ScriptureAll.BookID = ScriptureGroup.BookID 
		AND	
		(
			ScriptureGroup.{0} LIKE '%Beseech%'
		OR	ScriptureGroup.{0} LIKE '%Plead%'
		OR	ScriptureGroup.{0} LIKE '%Said%'
		OR	ScriptureGroup.{0} LIKE '%Say%'
		OR	ScriptureGroup.{0} LIKE '%Spoke%'
		OR	ScriptureGroup.{0} LIKE '%Talk%'
		)
	) Said,
	(
		SELECT COUNT(*) Prophecy
		FROM Bible..Scripture_View ScriptureGroup
		WHERE ScriptureAll.BookID = ScriptureGroup.BookID 
		AND	ScriptureGroup.{0} LIKE '%Prophe%'
	) Prophecy,
	(
		SELECT COUNT(*) Pray
		FROM Bible..Scripture_View ScriptureGroup
		WHERE ScriptureAll.BookID = ScriptureGroup.BookID 
		AND	ScriptureGroup.{0} LIKE '%Pray%'
	) Pray
FROM
	Bible..Scripture_View ScriptureAll
GROUP BY
	BookID,
	BookTitle
ORDER BY
	BookID,
	BookTitle
	";
}

