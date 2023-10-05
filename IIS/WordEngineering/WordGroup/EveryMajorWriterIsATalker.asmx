<%@ WebService Language="C#" Class="EveryMajorWriterIsATalkerWebService" %>

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

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessCode;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

///<summary>
///	2021-01-31T16:20:00 ... 2021-01-31T23:25:00	Created.	https://stackoverflow.com/questions/43502193/find-longest-word-in-string-with-sql
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class EveryMajorWriterIsATalkerWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String	bibleBookGroup,
		String	bibleVersion,
		String	bibleWord,		
		String	logic,
		String	scriptureReference,
		bool	wholeWords
	)
    {
		StringBuilder sb;
		DataSet dataSet = EveryMajorWriterIsATalker.Query
		(
				bibleBookGroup,
				bibleVersion,
				bibleWord,				
				logic,
				scriptureReference,
				wholeWords,
			out sb
		);
		//return sb.ToString();
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
    }
}
