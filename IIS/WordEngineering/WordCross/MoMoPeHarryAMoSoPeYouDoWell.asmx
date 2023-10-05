<%@ WebService Language="C#" Class="MoMoPeHarryAMoSoPeYouDoWellWebService" %>

using System;
using System.Data;
using System.Numerics;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;

using System.Data.Odbc;
using System.Data.SqlClient;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessCode;
using InformationInTransit.ProcessLogic;

/*
2023-07-13T16:53:00 ... 2023-07-13T16:58:00 Created.
*/
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class MoMoPeHarryAMoSoPeYouDoWellWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String word
	)
    {
		DataView resultView = InformationInTransit.ProcessCode.MoMoPeHarryAMoSoPeYouDoWell.Query
		(
			word
		);
		string json = JsonConvert.SerializeObject(resultView, Formatting.Indented);
		return json;
    }
}

