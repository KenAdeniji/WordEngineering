<%@ WebService Language="C#" Class="WhatDoesHeWantToSeeAsUsWebService" %>

using System;
using System.Data;
using System.Numerics;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;
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
///	2022-01-03 23:38:22.360 What does He want to see, as us?
///	2022-02-04T10:33:00 Created.
/// Bible Book word occurrences.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WhatDoesHeWantToSeeAsUsWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String bibleVersion,
		String bibleWord,
		String bookIDs
	)
    {
		DataTable resultTable = (DataTable) DataCommand.DatabaseCommand
		(
			String.Format
			(
				QueryStatement,
				bibleVersion,
				bibleWord,
				bookIDs
			),
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		List<Occurrence> occurrences = new List<Occurrence>();
		foreach(DataRow dataRow in resultTable.Rows)
		{
			WhatDoesHeWantToSeeAsUsWebService.Occurrence occurrence = new WhatDoesHeWantToSeeAsUsWebService.Occurrence
			{
				BookID = (int) dataRow["BookID"],
				BookTitle = (string) dataRow["BookTitle"],
				BookOccurrence = Regex.Matches(dataRow["Concatenated"].ToString(), bibleWord, RegexOptions.IgnoreCase ).Count
			};	
			occurrences.Add(occurrence);
		}
		
		string json = JsonConvert.SerializeObject(occurrences, Formatting.Indented);
		return json;
    }
	
	public class Occurrence
	{
		public int BookID { get; set; }
		public string BookTitle { get; set; }
		public int BookOccurrence { get; set; }
	}
	
	public const string QueryStatement = @"
;WITH CTE as
(
  SELECT distinct BookID, BookTitle
  FROM Bible..Scripture_View
  WHERE BookID IN ({2})
)
SELECT 
    BookID,
	BookTitle,
    STUFF((
        SELECT ',' + {0}
        FROM Bible..Scripture_View t2
        WHERE t2.BookID = t1.BookID AND {0} LIKE '%{1}%' AND BookID IN ({2})
        FOR XML PATH('')
    ), 1,1,'') Concatenated
FROM CTE t1
ORDER BY BookID
";
}
