<%@ WebService Language="C#" Class="IWillBringAsMuchAsMyselfWebService" %>

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

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessCode;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;

using Newtonsoft.Json;

///<summary>
///	2022-12-27T09:18:00 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class IWillBringAsMuchAsMyselfWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String scriptureReference,
		string scriptureReferenceIn
	)
    {
		StringBuilder sb = IWillBringAsMuchAsMyself.Query
		(
				scriptureReference,
				scriptureReferenceIn
		);
		string json = JsonConvert.SerializeObject(sb.ToString(), Formatting.Indented);
		return json;
    }
}
