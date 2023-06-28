<%@ WebService Language="C#" Class="WhatWillIFormWebService" %>

using System;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;

using System.Data;
using System.Data.Odbc;

using Newtonsoft.Json;

using InformationInTransit.DatabaseUtility;

///<summary>
///	2023-06-27T16:06:00 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WhatWillIFormWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String QueryColumns
	(
		String	connectionString,
		String 	tableName
	)
    {
		return
		(
			JsonConvert.SerializeObject
			(
				InformationInTransit.DatabaseUtility.WhatWillIForm.QueryColumns
				(
					connectionString,
					tableName
				),	
				Formatting.Indented
			)
		);
    }
	
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String QueryTables
	(
		String	connectionString
	)
    {
		return
		(
			JsonConvert.SerializeObject
			(
				InformationInTransit.DatabaseUtility.WhatWillIForm.QueryTables
				(
					connectionString
				),	
				Formatting.Indented
			)
		);
    }	
}

