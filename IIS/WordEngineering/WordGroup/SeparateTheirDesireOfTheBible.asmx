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
		String	bibleWord,
		String	bibleVersion,
		String	limitChosen,
		String	logic,
		String	scriptureReference,
		bool	wholeWords
	)
    {
		StringBuilder sb;
		DataSet dataSet = SeparateTheirDesireOfTheBible.Query
		(
				bibleWord,
				bibleVersion,
				limitChosen,
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