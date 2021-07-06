<%@ WebService Language="C#" Class="HowDoILiveForThePurposeOfTheWordWebService" %>
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;
using System.Xml;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessCode;

///<summary>
///	2021-07-05 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class HowDoILiveForThePurposeOfTheWordWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String question
	)
    {
		List<HowDoILiveForThePurposeOfTheWord> resultSet = HowDoILiveForThePurposeOfTheWord.Query
		(
			question
		);
		string json = JsonConvert.SerializeObject(resultSet, Newtonsoft.Json.Formatting.Indented);
		return json;
    }
}
