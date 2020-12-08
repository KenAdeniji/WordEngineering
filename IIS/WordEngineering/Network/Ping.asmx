<%@ WebService Language="C#" Class="PingWebService" %>

using System;
using System.Net.NetworkInformation;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;

using Newtonsoft.Json;

using InformationInTransit.ProcessCode;

///<summary>
///	2019-01-12	Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class PingWebService : System.Web.Services.WebService
{
	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		string hostNameOrAddress
	)	
    {
		PingReply reply = PingHelper.Query(hostNameOrAddress);
		string json = ""; //JsonConvert.SerializeObject(reply, Formatting.Indented);
		
		json = String.Format
		(
			JsonFormat,
			reply.Address.ToString(),
			reply.RoundtripTime,
			reply.Options.Ttl,
			reply.Buffer.Length,
			reply.Options.DontFragment
		);	
		
		return json;
	}

	public const string JsonFormat = "{{\"Address\": \"{0}\", \"RoundtripTime\": {1}, \"Options.Ttl\": {2}, \"Buffer.Length\": {3}, \"Options.DontFragment\": \"{4}\"}}";
}
