<%@ WebService Language="C#" Class="WhatRolesAreMentionMostInTheBibleWebService" %>

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
///	2019-02-09	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WhatRolesAreMentionMostInTheBibleWebService : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query(string bibleVersion, string word)
    {
		//return InformationInTransit.ProcessCode.WhatRolesAreMentionMostInTheBible.Query(bibleVersion, word);	
		DataSet dataSet = InformationInTransit.ProcessCode.WhatRolesAreMentionMostInTheBible.Query(bibleVersion, word);	
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}
}
