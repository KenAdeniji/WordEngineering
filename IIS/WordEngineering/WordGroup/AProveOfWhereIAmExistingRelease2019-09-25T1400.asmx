<%@ WebService Language="C#" Class="AProveOfWhereIAmExistingWebService" %>

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
///	2019-09-22 Idea conceived. 2019-09-23 Created. The Jewish days starts at 6P.M.
/// 2019-09-24 https://stackoverflow.com/questions/2006828/possible-to-invoke-asmx-service-with-parameter-via-url-query-string
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class AProveOfWhereIAmExistingWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet=true)]
	public String Query(long verseIDSequence)
    {
		DataTable result = (DataTable) DataCommand.DatabaseCommand
		(
			String.Format(SelectQuery, verseIDSequence),
			System.Data.CommandType.Text,
			DataCommand.ResultType.DataTable
		);
		string json = JsonConvert.SerializeObject(result, Formatting.Indented);
		return json;
    }
	
	public const String SelectQuery = 
		@"SELECT 
			'Set 1: Verse Forward' AS Direction, * FROM Bible..Scripture WHERE VerseIDSequence = {0} 
			UNION SELECT 'Set 2: Chapter Forward' AS Direction, * FROM Bible..Scripture WHERE ChapterIDSequence = {0} 
			UNION SELECT 'Set 3: Chapter Backward' AS Direction, * FROM Bible..Scripture WHERE ChapterIDSequence = 1190 - {0} 
			UNION SELECT 'Set 4: Verse Backward' AS Direction, * FROM Bible..Scripture WHERE VerseIDSequence = 31103 - {0} 
			ORDER BY Direction, BookID, ChapterID, VerseID			
		";
}
