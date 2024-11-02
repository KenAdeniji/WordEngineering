<%@ WebService Language="C#" Class="ToKnowAPeriodAsYouWebService" %>

using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;

using System.Data.SqlClient;
using System.Text;	
using System.Text.RegularExpressions;	

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessCode;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

using Newtonsoft.Json;

///<summary>
///	2024-04-01T13:53:00...2024-04-01T15:20:00 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class ToKnowAPeriodAsYouWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public string Query
	(
		String	bibleVersion,
		int bookID,
		int chapterID
	)
    {
		String queryStatement = String.Format
		(
			QueryStatement,
			bibleVersion,
			bookID,
			chapterID
		);

		//return queryStatement;
		
		DataTable resultTable = (DataTable) DataCommand.DatabaseCommand
		(
			queryStatement,
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(resultTable, Formatting.Indented);
		return json;
    }

	public const String QueryStatement = @"
		SELECT ScriptureReference, {0} AS VerseText
		FROM Bible..Scripture_View Scripture_View1
		WHERE 
			BookID = {1} 
			AND
			(
				( {2} > 0 AND Scripture_View1.ChapterID = {2} )
				OR
				(
					Scripture_View1.ChapterID =
					(
						SELECT
							MAX(Scripture_View2.ChapterID) + {2} + 1
						FROM Bible..Scripture_View Scripture_View2
						WHERE Scripture_View2.BookID = {1}
					)
				)	
			)	
		ORDER BY VerseIDSequence
	";
}
