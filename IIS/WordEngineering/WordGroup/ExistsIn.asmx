<%@ WebService Language="C#" Class="ExistsInWebService" %>

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

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessCode;

///<summary>
/// 2020-02-22	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class ExistsInWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		string	bibleVersion,
		string	bibleWord,
		string	logic,
		string	scriptureReferenceIncluded,
		string	scriptureReferenceExcluded,
		bool	wholeWords
	)
    {
		DataSet dataSetFilter = ExistsIn.Query
		(
			bibleVersion,
			bibleWord,
			logic,
			scriptureReferenceIncluded,
			scriptureReferenceExcluded,
			wholeWords
		);
		string json = JsonConvert.SerializeObject(dataSetFilter, Formatting.Indented);
		return json;
    }
}
