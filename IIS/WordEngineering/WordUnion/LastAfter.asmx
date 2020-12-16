<%@ WebService Language="C#" Class="LastAfterWebService" %>

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
///	2018-01-25	Created.
///	2018-01-25	https://stackoverflow.com/questions/26464706/how-to-return-the-second-to-last-character-in-a-string-using-sql
///	2018-01-25	https://stackoverflow.com/questions/4161157/check-if-string-contains-leading-letters
///	2018-01-25	http://www.sqlteam.com/forums/topic.asp?TOPIC_ID=75051
///	2018-01-25	https://stackoverflow.com/questions/707610/extract-the-first-word-of-a-string-in-a-sql-server-query
///	2018-01-25	https://stackoverflow.com/questions/2742845/how-do-i-search-for-the-comma-character-within-data-stored-in-sql-server
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class LastAfterWebService : System.Web.Services.WebService
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
		String bibleVersion
	)	
    {
		string sqlStatement = String.Format
		(
			LastLetterQuery,
			bibleVersion
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

	public const string LastLetterQuery =
	@"SELECT 
		SUBSTRING({0}, LEN({0})-1,1) AS LastLetter,
		COUNT(SUBSTRING({0}, LEN({0})-1,1)) AS Count
	FROM
		Bible..Scripture
	WHERE
		SUBSTRING({0}, LEN({0})-1,1) like '[A-Za-z]'
	GROUP BY
		SUBSTRING({0}, LEN({0})-1,1)
	;
	SELECT 
		LEFT({0}, 1) AS FirstLetter,
		COUNT(LEFT({0}, 1)) AS Count
	FROM
		Bible..Scripture
	WHERE
		LEFT({0}, 1) like '[A-Za-z]'
	GROUP BY
		LEFT({0}, 1)
	;
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
		)
	FROM
		Bible..Scripture
	WHERE
		Case patIndex ('%[ /-/,/(/;]%', LTrim ({0}))
			When 0 Then LTrim ({0})
			Else substring (LTrim ({0}), 1, patIndex ('%[ /-/,/(/;]%', LTrim ({0})) - 1)
		End <> ''
	GROUP BY
		Case patIndex ('%[ /-/,/(/;]%', LTrim ({0}))
			When 0 Then LTrim ({0})
			Else substring (LTrim ({0}), 1, patIndex ('%[ /-/,/(/;]%', LTrim ({0})) - 1)
		End
	;
	";
}
