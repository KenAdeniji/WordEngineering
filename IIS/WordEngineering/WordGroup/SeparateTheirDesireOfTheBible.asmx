<%@ WebService Language="C#" Class="SeparateTheirDesireOfTheBibleWebService" %>

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
///	2020-11-08 	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class SeparateTheirDesireOfTheBibleWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String	bibleVersion,
		String	bibleWord,		
		String	bibleBookGroup,
		String	logic,
		String	scriptureReference,
		bool	wholeWords
	)
    {
		StringBuilder sb;
		DataSet dataSet = SeparateTheirDesireOfTheBible.Query
		(
				bibleBookGroup,
				bibleVersion,
				bibleWord,				
				logic,
				scriptureReference,
				wholeWords,
			out sb,
				"ScriptureReference"
		);
		//return sb.ToString();
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
    }
}
