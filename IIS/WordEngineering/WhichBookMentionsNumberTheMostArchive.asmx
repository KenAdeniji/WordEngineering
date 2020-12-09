<%@ WebService Language="C#" Class="WhichBookMentionsNumberTheMostWebService" %>

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
using InformationInTransit.UserInterface;

///<summary>
///	2020-04-22T06:00:00	Created.	https://stackoverflow.com/questions/14290857/sql-select-where-field-contains-words
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WhichBookMentionsNumberTheMostWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String	bibleVersion
	)
    {
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			String.Format
			(
				QueryFormat,
				bibleVersion
			),
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
    }
	
	public const string QueryFormat = 
	@"
		DECLARE @FilterTable TABLE (Data VARCHAR(MAX))

		INSERT 	INTO @FilterTable (Data)
		SELECT 	DISTINCT S.Data
		FROM 	Bible.dbo.udf_WordSplit(' ', 'one two three four five six seven eight nine ten twenty thirty forty fifty sixty seventy eighty ninety hundred thousand million billion') S -- Contains words

		SELECT 
			  (Bible.dbo.[udf_BookTitle]([bookID])) AS ScriptureReference,
			  COUNT(*) AS NumberOccurrences
		FROM
			  Bible..Scripture T
			  INNER JOIN @FilterTable F1 ON T.{0} LIKE '%' + F1.Data + '%'
		GROUP BY BookId
	";
}
