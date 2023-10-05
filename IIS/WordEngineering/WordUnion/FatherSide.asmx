<%@ WebService Language="C#" Class="FatherSideWebService" %>

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
using InformationInTransit.ProcessLogic;

///<summary>
///	2018-03-04	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class FatherSideWebService : System.Web.Services.WebService
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
		String	bibleVersion,
		String	bibleWord,
		String	limit,
		bool	forwardDirection,
		String	scriptureReference,
		bool	wholeWords
	)	
    {
		DataSet			resultSet = null;
		String[]		scriptureReferenceSubset = null;
		StringBuilder	sql = null;
	
		DataSet	filterSet = FatherSideHelper.Filter
		(
			BibleQuery.BibleQueryFormat,
			bibleVersion,
			bibleWord,
			forwardDirection,
			limit,
			"phrase", //logic
			ref resultSet,
			scriptureReference,
			ref scriptureReferenceSubset,
			ref sql,
			wholeWords
		);

		string json = JsonConvert.SerializeObject(filterSet, Formatting.Indented);
		return json;
	}
}
