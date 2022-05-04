<%@ WebService Language="C#" Class="LightweightDirectoryAccessProtocolLDAPWebService" %>

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

using Newtonsoft.Json;

using InformationInTransit.ProcessCode;

///<summary>
///	2022-05-03T11:07:00 https://www.codemag.com/article/1312041/Using-Active-Directory-in-.NET
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class LightweightDirectoryAccessProtocolLDAPWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String	selectOption
	)
    {
		string json = JsonConvert.SerializeObject
		(
			LightweightDirectoryAccessProtocolLDAPHelper.Query(selectOption),
			Formatting.Indented
		);
		return json;
    }
}
