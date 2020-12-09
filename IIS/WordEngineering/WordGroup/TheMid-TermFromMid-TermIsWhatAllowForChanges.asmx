<%@ WebService Language="C#" Class="TheMidTermFromMidTermIsWhatAllowForChangesWebService" %>

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
///	2018-08-31 	Created.
///	2018-09-01	https://social.msdn.microsoft.com/Forums/sqlserver/en-US/6bd2da08-af9e-4216-bec3-1e859415d800/find-number-of-occurences-of-character-in-given-string?forum=transactsql
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class TheMidTermFromMidTermIsWhatAllowForChangesWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		string bibleVersion
	)
    {
		DataSet result = (DataSet) DataCommand.DatabaseCommand
		(
			String.Format(SelectQuery, bibleVersion),
			System.Data.CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		
		string json = JsonConvert.SerializeObject(result, Formatting.Indented);
		return json;
    }
	
	public const String SelectQuery = 
	@"
		DECLARE @scriptureReferenceSabbath VARCHAR(8000);
		SELECT @scriptureReferenceSabbath = COALESCE(@scriptureReferenceSabbath + ', ', '') + ScriptureReference
		FROM Bible..Scripture_View
		WHERE {0} LIKE '%Sabbath%'
		ORDER BY bookId, chapterId, verseId;
		
		DECLARE @scriptureReferenceNewMoon VARCHAR(8000);
		SELECT @scriptureReferenceNewMoon = COALESCE(@scriptureReferenceNewMoon + ', ', '') + ScriptureReference
		FROM Bible..Scripture_View
		WHERE {0} LIKE '%New Moon%'
		ORDER BY bookId, chapterId, verseId;
		
		SELECT 'Sabbath' AS Occasion, Len(@scriptureReferenceSabbath) - Len(Replace(@scriptureReferenceSabbath, ',', '')) + 1 AS Occurrences, @scriptureReferenceSabbath AS ScriptureReference
		UNION
		SELECT 'New Moon', Len(@scriptureReferenceNewMoon) - Len(Replace(@scriptureReferenceNewMoon, ',', '')) + 1 AS Occurrences, @scriptureReferenceNewMoon
	";
}
