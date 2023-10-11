<%@ WebService Language="C#" Class="WhenWeDevelopACertainRepresentationWebService" %>

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
using InformationInTransit.ProcessCode;

///<summary>
///	2023-10-11T08:47:00	When we develop a certain representation.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class WhenWeDevelopACertainRepresentationWebService : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query(string word)
    {
		WhenWeDevelopACertainRepresentation	whenWeDevelopACertainRepresentation =
			new WhenWeDevelopACertainRepresentation();
		
		string json = JsonConvert.SerializeObject
		(
			whenWeDevelopACertainRepresentation.Query(word),
			Formatting.Indented
		);
		return json;
	}
}
