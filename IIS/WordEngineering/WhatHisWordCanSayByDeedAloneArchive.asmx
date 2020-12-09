<%@ WebService Language="C#" Class="WhatHisWordCanSayByDeedAloneWebService" %>

using System;
using System.Data;
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
using InformationInTransit.UserInterface;

///<summary>
///	2020-08-27 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WhatHisWordCanSayByDeedAloneWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
	)	
    {
		DataTable dataTable = (DataTable) DataCommand.DatabaseCommand
		(
			QueryFormat,
			CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		
		string json = JsonConvert.SerializeObject(dataTable, Formatting.Indented);
		return json;
    }
	
	public const string QueryFormat = 
	@"
		SELECT BookID, BookTitle,
		WordEngineering.dbo.udf_AlphabetSequenceIndex(BookTitle) AS AlphabetSequenceIndex,
		WordEngineering.dbo.udf_AlphabetSequenceIndexScriptureReference
		(
			BookTitle
		)	AS AlphabetSequenceIndexScriptureReference,
		MAX(ChapterID) AS Chapters,
		COUNT(VerseID) AS Verses
		FROM Bible.dbo.Scripture_View
		GROUP BY BookID, BookTitle
		ORDER BY BookID
	";
}
