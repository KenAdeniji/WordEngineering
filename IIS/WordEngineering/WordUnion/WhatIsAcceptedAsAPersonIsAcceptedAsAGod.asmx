﻿<%@ WebService Language="C#" Class="WhatIsAcceptedAsAPersonIsAcceptedAsAGod" %>

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
using InformationInTransit.ProcessLogic;

///<summary>
///	2016-12-27	Created.	WhatIsAcceptedAsAPersonIsAcceptedAsAGod.asmx
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WhatIsAcceptedAsAPersonIsAcceptedAsAGod : System.Web.Services.WebService
{
    [WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string Hello()
    {
        return "Hello World!";
    }
	
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String BibleWordQuery(string bibleVersion, string word)
    {
		DataSet dataSet = WhatIsAcceptedAsAPersonIsAcceptedAsAGodHelper.BibleWordQuery(bibleVersion, word);	
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}

	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String ScriptureReferenceQuery(string bibleVersion, string word)
    {
		DataSet dataSet = WhatIsAcceptedAsAPersonIsAcceptedAsAGodHelper.ScriptureReferenceQuery(bibleVersion, word);	
		string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
		return json;
	}
}
