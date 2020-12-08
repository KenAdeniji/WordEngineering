<%@ WebService Language="C#" Class="IWontBringWhereIAmToSeeWhereIAmYoursWebService" %>

using System;
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

using InformationInTransit.ProcessLogic;

///<summary>
///	2017-12-30	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class IWontBringWhereIAmToSeeWhereIAmYoursWebService : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		string 	scriptureReference,
		string	bibleVersion
	)
    {
		DataTable iWontBringWhereIAmToSeeWhereIAmYours = IWontBringWhereIAmToSeeWhereIAmYoursHelper.Query
		(
			scriptureReference,
			bibleVersion
		);

		string json = JsonConvert.SerializeObject(iWontBringWhereIAmToSeeWhereIAmYours, Formatting.Indented);
		return json;
	}
}
