<%@ WebService Language="C#" Class="FivePointFourEightOnePointFourEight" %>

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
using InformationInTransit.ProcessCode;

///<summary>
///	2019-04-16	Created.	https://stackoverflow.com/questions/273238/how-to-use-group-by-to-concatenate-strings-in-sql-server
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class FivePointFourEightOnePointFourEight : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query(String bibleWord, String soundexCode)
    {
		DataSet dataSet = (DataSet)DataCommand.DatabaseCommand
		(
			String.Format(SelectStatement, bibleWord, soundexCode),
			CommandType.Text,
			DataCommand.ResultType.DataSet
		);
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}
	
	/*
My accounts manager needs you to add that 1 year of React experience to your resume. It will help keep the integrity of your resume for the hiring manager when he looks at it.

Can you send me an updated resume with a single line of text added to your current position, just talking a little about your React experience?

Thanks,

-- 
Stephen Hyland
Technical Recruiter
Smart Synergies, Inc.
steve@smart-synergies.com
703-881-8306
	*/
	public const string SelectStatement = 
		@"
SELECT 
  SOUNDEX(BibleWord) AS SoundexCode,
  STUFF((
    SELECT ', ' + BibleWord
    FROM Bible..Exact
    WHERE (SOUNDEX(BibleWord) = SOUNDEX(Results.BibleWord))
	AND BibleWord LIKE '%{0}%' AND SOUNDEX(BibleWord) LIKE '%{1}%'
    FOR XML PATH(''),TYPE).value('(./text())[1]','VARCHAR(MAX)')
  ,1,2,'') AS Words
FROM Bible..Exact AS Results
WHERE BibleWord LIKE '%{0}%' AND SOUNDEX(BibleWord) LIKE '%{1}%'
GROUP BY SOUNDEX(BibleWord)
ORDER BY SOUNDEX(BibleWord)
		";
}
