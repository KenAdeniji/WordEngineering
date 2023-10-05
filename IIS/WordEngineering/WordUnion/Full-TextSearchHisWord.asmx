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
2016-11-02	https://msdn.microsoft.com/en-us/library/ms189520.aspx
2016-11-02 	Researched. (man NEAR God) OR (woman NEAR God)
2016-11-14	Full-TextSearchHisWord.asmx
2016-11-14	Query string.

USE WordEngineering;  
GO

--DROP FULLTEXT INDEX ON KJV;

CREATE FULLTEXT CATALOG FullTextCatalogWordEngineering
	IN PATH 'E\SQLServerDataFiles\WordEngineering'
GO  

CREATE FULLTEXT INDEX ON HisWord
(
	Word
)
KEY INDEX IDX_HisWord_SequenceOrderID ON FullTextCatalogWordEngineering
WITH CHANGE_TRACKING AUTO
GO  

--ALTER FULLTEXT INDEX ON HisWord SET CHANGE_TRACKING AUTO;  
--GO  
*/

///<summary>
///	2016-11-02 	Researched.
///	2016-11-14 	Created.
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
		String	fulltext
	)
    {
		String	sqlStatement = String.Format
		(
			SQLSelect[searchIndex],
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
		"SELECT * FROM WordEngineering..HisWord WHERE CONTAINS(Word, '{0}') ORDER BY Dated DESC", 
		"SELECT * FROM WordEngineering..HisWord WHERE FREETEXT(Word, '{0}') ORDER BY Dated DESC", 
		@"	SELECT 
				FreeText_Table_HisWord.*,  
				Key_Table.RANK  
			FROM 
				WordEngineering.dbo.HisWord AS FreeText_Table_HisWord INNER JOIN  
				CONTAINSTABLE ( WordEngineering.dbo.HisWord, Word, '{0}' ) AS Key_Table  
				ON FreeText_Table_HisWord.SequenceOrderID = Key_Table.[KEY]  
			WHERE Key_Table.RANK > 2  
			ORDER BY Key_Table.RANK DESC;  
		",
		@"
		SELECT
			FreeText_Table_HisWord.*,  
			KEY_TBL.RANK As Rank
		FROM 
			WordEngineering.dbo.HisWord AS FreeText_Table_HisWord
		INNER JOIN  
			FREETEXTTABLE(WordEngineering.dbo.HisWord, Word, '{0}') AS KEY_TBL  
		ON 
			FreeText_Table_HisWord.SequenceOrderID = KEY_TBL.[KEY]  
		WHERE 
			KEY_TBL.RANK >= 2  
		ORDER BY
			KEY_TBL.RANK DESC 
		"	
	};
}
