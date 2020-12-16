<%@ WebService Language="C#" Class="FullTextSearch" %>

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

/*
2016-11-02 https://msdn.microsoft.com/en-us/library/ms189520.aspx
2016-11-02 	Researched. (man NEAR God) OR (woman NEAR God)
2016-11-09	Full-TextSearch.html
2016-11-13	Query string.

USE Bible;  
GO

--DROP FULLTEXT INDEX ON KJV;

CREATE FULLTEXT CATALOG FullTextCatalogBible
	IN PATH 'E\SQLServerDataFiles\Bible'
GO  

CREATE FULLTEXT INDEX ON KJV
(
	VerseText,
	AmericanStandardBible,
	YoungLiteralTranslation
)
KEY INDEX IDX_VerseIDSequence ON FullTextCatalogBible
WITH CHANGE_TRACKING AUTO
GO  

--ALTER FULLTEXT INDEX ON KJV SET CHANGE_TRACKING AUTO;  
--GO  
*/

///<summary>
///	2016-11-02 	Researched.
///	2016-11-09 	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class FullTextSearch : System.Web.Services.WebService
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
		int		searchIndex,
		String	fulltext,
		String	bibleVersion
	)
    {
		/*
		bibleVersion = string.IsNullOrEmpty(bibleVersion) ? "VerseText" : bibleVersion;
		
		String columnName = "VerseText";
		
		if (bibleVersion != "KJV")
		{
			columnName = bibleVersion;
		}	
		*/
		String	sqlStatement = String.Format
		(
			SQLSelect[searchIndex],
			bibleVersion,
			fulltext
		);
		
        DataSet resultSet = (DataSet) DataCommand.DatabaseCommand
		(
			sqlStatement,
			System.Data.CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(resultSet, Formatting.Indented);
		return json;
    }

	public static readonly string[] SQLSelect = new string[] 
	{
		"SELECT ScriptureReference, {0} AS VerseText FROM Bible..KJV WHERE CONTAINS({0}, '{1}') ORDER BY VerseIDSequence", 
		"SELECT ScriptureReference, {0} AS VerseText FROM Bible..KJV WHERE FREETEXT({0}, '{1}') ORDER BY VerseIDSequence",
		@"	SELECT 
				FreeText_Table_KJV.ScriptureReference AS ScriptureReference,  
				FreeText_Table_KJV.{0} AS VerseText,   
				Key_Table.RANK  
			FROM 
				Bible.dbo.KJV AS FreeText_Table_KJV INNER JOIN  
				CONTAINSTABLE ( Bible.dbo.KJV, VerseText, '{1}' ) AS Key_Table  
				ON FreeText_Table_KJV.VerseIDSequence = Key_Table.[KEY]  
			WHERE Key_Table.RANK > 2  
			ORDER BY Key_Table.RANK DESC;  
		",
		@"
		SELECT
			FreeText_Table_KJV.ScriptureReference AS ScriptureReference,  
			FreeText_Table_KJV.{0} AS VerseText,
			KEY_TBL.RANK As Rank
		FROM 
			Bible.dbo.KJV AS FreeText_Table_KJV
		INNER JOIN  
			FREETEXTTABLE(Bible.dbo.KJV, {0}, '{1}') AS KEY_TBL  
		ON 
			FreeText_Table_KJV.VerseIDSequence = KEY_TBL.[KEY]  
		WHERE 
			KEY_TBL.RANK >= 2  
		ORDER BY
			KEY_TBL.RANK DESC 
		"	
	};
}
