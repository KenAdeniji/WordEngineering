<%@ WebService Language="C#" Class="OurConnectionWithPeopleAreOurPastimeWebService" %>

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

using System.Text;

using System.Linq;	

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;

///<summary>
///	2021-05-27T10:30:00 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class OurConnectionWithPeopleAreOurPastimeWebService : System.Web.Services.WebService
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
			String.Format(SQLStatement, bibleVersion),
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);

		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
    }
	
	public const string SQLStatement = 
	@"
--		Date Created: 2021-05-27
		SELECT 	
			'Hour' AS BibleWord,
			(SELECT COUNT(*) FROM Bible..Scripture_View WHERE {0} LIKE '%Hour%') AS Occurrences,
			(
				SELECT ScriptureReference FROM Bible..Scripture_View WHERE VerseIDSequence = 
					(SELECT MIN(VerseIDSequence) FROM Bible..Scripture_View WHERE {0} LIKE '%Hour%') 
			)	AS ScriptureReferenceFirstOccurrence,
			(
				SELECT ScriptureReference FROM Bible..Scripture_View WHERE VerseIDSequence = 
					(SELECT MAX(VerseIDSequence) FROM Bible..Scripture_View WHERE {0} LIKE '%Hour%') 
			)	AS ScriptureReferenceLastOccurrence
		UNION SELECT
			'Day' AS BibleWord,
			(SELECT COUNT(*) FROM Bible..Scripture_View WHERE {0} LIKE '%Day%') AS Occurrences,
			(
				SELECT ScriptureReference FROM Bible..Scripture_View WHERE VerseIDSequence = 
					(SELECT MIN(VerseIDSequence) FROM Bible..Scripture_View WHERE {0} LIKE '%Day%') 
			)	AS ScriptureReferenceFirstOccurrence,
			(
				SELECT ScriptureReference FROM Bible..Scripture_View WHERE VerseIDSequence = 
					(SELECT MAX(VerseIDSequence) FROM Bible..Scripture_View WHERE {0} LIKE '%Day%') 
			)	AS ScriptureReferenceLastOccurrence
		UNION SELECT
			'Week' AS BibleWord,
			(SELECT COUNT(*) FROM Bible..Scripture_View WHERE {0} LIKE '%Week%') AS Occurrences,
			(
				SELECT ScriptureReference FROM Bible..Scripture_View WHERE VerseIDSequence = 
					(SELECT MIN(VerseIDSequence) FROM Bible..Scripture_View WHERE {0} LIKE '%Week%') 
			)	AS ScriptureReferenceFirstOccurrence,
			(
				SELECT ScriptureReference FROM Bible..Scripture_View WHERE VerseIDSequence = 
					(SELECT MAX(VerseIDSequence) FROM Bible..Scripture_View WHERE {0} LIKE '%Week%') 
			)	AS ScriptureReferenceLastOccurrence
		UNION SELECT
			'Month' AS BibleWord,
			(SELECT COUNT(*) FROM Bible..Scripture_View WHERE {0} LIKE '%Month%') AS Occurrences,
			(
				SELECT ScriptureReference FROM Bible..Scripture_View WHERE VerseIDSequence = 
					(SELECT MIN(VerseIDSequence) FROM Bible..Scripture_View WHERE {0} LIKE '%Month%') 
			)	AS ScriptureReferenceFirstOccurrence,
			(
				SELECT ScriptureReference FROM Bible..Scripture_View WHERE VerseIDSequence = 
					(SELECT MAX(VerseIDSequence) FROM Bible..Scripture_View WHERE {0} LIKE '%Month%') 
			)	AS ScriptureReferenceLastOccurrence
		UNION SELECT
			'Year' AS BibleWord,
			(SELECT COUNT(*) FROM Bible..Scripture_View WHERE {0} LIKE '%Year%') AS Occurrences,
			(
				SELECT ScriptureReference FROM Bible..Scripture_View WHERE VerseIDSequence = 
					(SELECT MIN(VerseIDSequence) FROM Bible..Scripture_View WHERE {0} LIKE '%Year%') 
			)	AS ScriptureReferenceFirstOccurrence,
			(
				SELECT ScriptureReference FROM Bible..Scripture_View WHERE VerseIDSequence = 
					(SELECT MAX(VerseIDSequence) FROM Bible..Scripture_View WHERE {0} LIKE '%Year%') 
			)	AS ScriptureReferenceLastOccurrence
	";	
}
