<%@ WebService Language="C#" Class="TraceRouteWebService" %>

using System;

using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;

using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;

using System.Web.Script.Serialization;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using InformationInTransit.ProcessCode;

///<summary>
///	2019-01-13	Created.
///	2019-01-13	https://stackoverflow.com/questions/18668617/json-net-error-getting-value-from-scopeid-on-system-net-ipaddress
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class TraceRouteWebService : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		string hostNameOrAddress
	)	
    {
		IEnumerable<IPAddress> ipAddresses = TraceRouteHelper.Query(hostNameOrAddress);
//		string json = JsonConvert.SerializeObject(ipAddresses, Formatting.Indented);

        var settings = new JsonSerializerSettings();
        settings.Converters.Add(new IPAddressConverter());
        settings.Converters.Add(new IPEndPointConverter());
        settings.Formatting = Formatting.Indented;

        string json = JsonConvert.SerializeObject(ipAddresses, settings);
		
		return json;
		
		//var serializer = new JavaScriptSerializer();
        //var serializedResult = serializer.Serialize(ipAddresses);
		//return serializedResult;
	}
}
