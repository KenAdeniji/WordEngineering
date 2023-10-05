<%@ WebService Language="C#" Class="BibleBookQuery" %>

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

///<summary>
///	2016-12-09	https://technet.microsoft.com/en-us/library/ms174408(v=sql.90).aspx
///	2016-12-09	Created.	BibleBookQuery.asmx
///	2017-02-04	BookGroup() added.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class BibleBookQuery : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }

	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String BookGroup()
    {
 		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			SQLStatementBookGroup,
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}
	
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		int		bookIDMinimum,
		int		bookIDMaximum,
		string 	bookTitle,
		string	testament
	)
    {
		DataSet dataSet = BibleBookHelper.Query
		(
			bookIDMinimum,
			bookIDMaximum,
			bookTitle,
			testament
		);
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}
	
	public const string SQLStatementBookGroup = "SELECT BookID, BookTitle, ChapterCount = (SELECT COUNT(DISTINCT ChapterID) FROM Bible..Scripture_View AS ScriptureInner WHERE ScriptureInner.BookID = ScriptureOuter.BookID), VerseCount = (SELECT COUNT(VerseID) FROM Bible..Scripture AS ScriptureInner WHERE ScriptureInner.BookID = ScriptureOuter.BookID) FROM Bible..Scripture_View AS ScriptureOuter GROUP BY BookID, BookTitle ORDER BY BookID";
}
