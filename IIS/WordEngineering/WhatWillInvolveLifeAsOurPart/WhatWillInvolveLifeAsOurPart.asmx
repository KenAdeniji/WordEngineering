<%@ WebService Language="C#" Class="WhatWillInvolveLifeAsOurPartWebService" %>

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

using InformationInTransit.WhatWillInvolveLifeAsOurPart;

using Newtonsoft.Json;

/*
	2023-10-22T22:04:00 Created.
*/
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WhatWillInvolveLifeAsOurPartWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		string 	scriptureReference,
		string 	bibleVersion
	)
    {
		DataTable resultDataTable = WhatWillInvolveLifeAsOurPartHelper.Query
		(
				scriptureReference,
				bibleVersion
		);
		string json = JsonConvert.SerializeObject(resultDataTable, Formatting.Indented);
		return json;
    }
}
