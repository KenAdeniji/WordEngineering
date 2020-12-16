<%@ WebService Language="C#" Class="ShowingAPersonHowHeIsTrulyIsWebService" %>

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
///	2018-01-26	Created.
///	2018-01-26	https://stackoverflow.com/questions/26464706/how-to-return-the-second-to-last-character-in-a-string-using-sql
///	2018-01-26	https://stackoverflow.com/questions/4161157/check-if-string-contains-leading-letters
///	2018-01-26	http://www.sqlteam.com/forums/topic.asp?TOPIC_ID=75051
///	2018-01-26	https://stackoverflow.com/questions/707610/extract-the-first-word-of-a-string-in-a-sql-server-query
///	2018-01-26	https://stackoverflow.com/questions/2742845/how-do-i-search-for-the-comma-character-within-data-stored-in-sql-server
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class ShowingAPersonHowHeIsTrulyIsWebService : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }
	
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String bibleVersion,
		String bibleWord
	)	
    {
		string sqlStatement = String.Format
		(
			ShowingAPersonHowHeIsTrulyIsQuery,
			bibleVersion,
			bibleWord
		);

		//return sqlStatement;
		
		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
		(
			sqlStatement,
			System.Data.CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}

	public const string ShowingAPersonHowHeIsTrulyIsQuery =
	@"
	SELECT * FROM Bible..Exact WHERE BibleWord LIKE '%{1}%';
	SELECT
		LEFT
		( 
			reverse(substring(reverse({0}),1, charindex(' ', reverse({0})) -1)),
			LEN(reverse(substring(reverse({0}),1, charindex(' ', reverse({0})) -1))) - 1
		) AS LastWord,
		COUNT
		(
			LEFT
			( 
				reverse(substring(reverse({0}),1, charindex(' ', reverse({0})) -1)),
				LEN(reverse(substring(reverse({0}),1, charindex(' ', reverse({0})) -1))) - 1
			)
		)	AS Count
	FROM
		Bible..Scripture
	WHERE
		LEFT
		( 
			reverse(substring(reverse({0}),1, charindex(' ', reverse({0})) -1)),
			LEN(reverse(substring(reverse({0}),1, charindex(' ', reverse({0})) -1))) - 1
		) <> ''
	AND
		LEFT
		( 
			reverse(substring(reverse({0}),1, charindex(' ', reverse({0})) -1)),
			LEN(reverse(substring(reverse({0}),1, charindex(' ', reverse({0})) -1))) - 1
		) 
		LIKE '%{1}%'		
	GROUP BY
		LEFT
		( 
			reverse(substring(reverse({0}),1, charindex(' ', reverse({0})) -1)),
			LEN(reverse(substring(reverse({0}),1, charindex(' ', reverse({0})) -1))) - 1
		)
	;	
	SELECT
		Case patIndex ('%[ /-/,/(/;]%', LTrim ({0}))
			When 0 Then LTrim ({0})
			Else substring (LTrim ({0}), 1, patIndex ('%[ /-/,/(/;]%', LTrim ({0})) - 1)
		End AS FirstWord,
		COUNT
		(
			Case patIndex ('%[ /-/,/(/;]%', LTrim ({0}))
				When 0 Then LTrim ({0})
				Else substring (LTrim ({0}), 1, patIndex ('%[ /-/,/(/;]%', LTrim ({0})) - 1)
			End
		) AS Count
	FROM
		Bible..Scripture
	WHERE
		Case patIndex ('%[ /-/,/(/;]%', LTrim ({0}))
			When 0 Then LTrim ({0})
			Else substring (LTrim ({0}), 1, patIndex ('%[ /-/,/(/;]%', LTrim ({0})) - 1)
		End <> ''
		AND
		Case patIndex ('%[ /-/,/(/;]%', LTrim ({0}))
			When 0 Then LTrim ({0})
			Else substring (LTrim ({0}), 1, patIndex ('%[ /-/,/(/;]%', LTrim ({0})) - 1)
		End LIKE '%{1}%'
	GROUP BY
		Case patIndex ('%[ /-/,/(/;]%', LTrim ({0}))
			When 0 Then LTrim ({0})
			Else substring (LTrim ({0}), 1, patIndex ('%[ /-/,/(/;]%', LTrim ({0})) - 1)
		End
	;
	";
}
