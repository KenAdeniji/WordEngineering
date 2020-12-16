<%@ WebService Language="C#" Class="WhoIsYourManagerCrazyMisterMartinMisterMartinAsAGoodWebService" %>

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

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2019-12-22 Created. Who is your manager? Crazy mister Martin. Mister Martin as a good.
///	2019-12-21 BookID, ChapterID, VerseID.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WhoIsYourManagerCrazyMisterMartinMisterMartinAsAGoodWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		int bookID,
		int chapterID,
		int	verseID
	)
    {
		String resultSet = (String) DataCommand.DatabaseCommand
		(
			String.Format
			(
				SelectFormat,
				bookID,
				chapterID,
				verseID
			),
			CommandType.Text,
			DataCommand.ResultType.Scalar
		);

		string json = String.Format
		(
			JsonFormat,
			resultSet
		);	

		return json;
    }
	
	public const string SelectFormat = "EXECUTE WordEngineering..usp_WhoIsYourManagerCrazyMisterMartinMisterMartinAsAGood @bookID = {0}, @chapterID = {1}, @verseID = {2}";
	public const string JsonFormat = "{{\"scriptureReference\": \"{0}\"}}";
}
