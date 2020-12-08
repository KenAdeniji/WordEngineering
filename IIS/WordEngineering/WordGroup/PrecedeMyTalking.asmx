<%@ WebService Language="C#" Class="PrecedeMyTalkingWebService" %>

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
using InformationInTransit.ProcessCode;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2020-10-24 Created. https://essential-sql.programming-books.io/selecting-with-case-5877a0715ae140c99a31bdda0413cde5
///	2020-10-25 Catholic Letters. 2020-10-26 BookIDs.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class PrecedeMyTalkingWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query()
    {
        DataTable resultSet = (DataTable) DataCommand.DatabaseCommand
		(
			SQLSelect,
			System.Data.CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(resultSet, Formatting.Indented);
		return json;
    }

	public const String SQLSelect = 
	@"
		;with cteBibleBook
		(
			  BookID
			, BookTitle
			, BookGroup
		)
		as
		(
			SELECT
				  BookID
				, BookTitle
				, BookGroup
			FROM   
				Bible..Scripture_View
			GROUP BY
				  BookID
				, BookTitle
				, BookGroup
		)

		SELECT
			BookGroup
			, STRING_AGG
			(
				bookTitle
				, ', '
			)
			WITHIN GROUP
			(
				ORDER BY
				BookID asc
			) AS GroupTitle
			, STRING_AGG
			(
				CONVERT(Varchar, BookID)
				, ', '
			)
			WITHIN GROUP
			(
				ORDER BY
				BookID asc
			) AS BookIDs
			, COUNT(*) AS GroupCount
			, MIN(BookID) AS BookIDMinimum
			, MAX(BookID) AS BookIDMaximum
		FROM  
			cteBibleBook
		GROUP BY
			BookGroup
	";
}
