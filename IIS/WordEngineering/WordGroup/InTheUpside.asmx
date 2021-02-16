<%@ WebService Language="C#" Class="InTheUpsideWebService" %>

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
///	2021-02-06T11:21:00 ... 2021-02-06T13:02:00 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class InTheUpsideWebService : System.Web.Services.WebService
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
		bool	wholeWords,
		int		wordCount
	)
    {
		StringBuilder sb;
		DataSet dataSet = InTheUpside.Query
		(
				bibleBookGroup,
				bibleVersion,
				bibleWord,				
				logic,
				scriptureReference,
				wholeWords,
				wordCount,
			out sb
		);
		//return sb.ToString();
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
    }
}
