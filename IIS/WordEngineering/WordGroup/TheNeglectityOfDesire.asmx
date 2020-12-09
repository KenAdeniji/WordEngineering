<%@ WebService Language="C#" Class="TheNeglectityOfDesireWebService" %>

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

using System.Reflection;

using System.Text;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessCode;

///<summary>
/// 2020-03-30	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class TheNeglectityOfDesireWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String 	bibleVersion,
		String 	scriptureReference,
		String	wordsLengthsText,
		String	phrase
	)
    {
		StringBuilder sb = new StringBuilder();
	
		List<TheNeglectityOfDesireHelper.Participation> resultSet = TheNeglectityOfDesireHelper.Query
		(
			bibleVersion,
			scriptureReference,
			wordsLengthsText,
			phrase,
			ref sb
		);
		
		string json = JsonConvert.SerializeObject(resultSet, Formatting.Indented);
		return json;
    }
}
