<%@ WebService Language="C#" Class="PaulWhoCouldTalkAboutYouIndividualProsperityWebService" %>

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
using InformationInTransit.ProcessCode;
using InformationInTransit.ProcessLogic;

///<summary>
///	2018-12-01 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class PaulWhoCouldTalkAboutYouIndividualProsperityWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		int contactID,
		String	word,
		String	logic
	)
    {
		String result = PaulWhoCouldTalkAboutYouIndividualProsperity.Query
		(
			contactID,
			word,
			logic
		);
		string json = JsonConvert.SerializeObject(result, Formatting.Indented);
		return json;
	}
}
