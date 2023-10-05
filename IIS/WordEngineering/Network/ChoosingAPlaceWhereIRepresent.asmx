<%@ WebService Language="C#" Class="ChoosingAPlaceWhereIRepresentWebService" %>

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

using System.Web.Script.Serialization;

using System.Text;

using System.Net;
using System.Net.NetworkInformation;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Script.Services;

using Newtonsoft.Json;

using InformationInTransit.ProcessCode;
using InformationInTransit.ProcessLogic;

/*
2019-10-01	Created.	Essential SNMP. O'Reilly. Douglas R. Mauro and Kevin S. Schmidt ping host. ipconfig. arp -a. netstat - rn. traceroute versus tracert. nslookup versus dig. whois versus jwhois. Ethereal.com.
*/
///<summary>
///	2019-10-01 Created.
///</summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[ScriptService]
public class ChoosingAPlaceWhereIRepresentWebService : System.Web.Services.WebService
{
   	[WebMethod]
	[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
	public String Query
	(
		String	command,
		String 	host
	)
    {
		string json = "";
		switch (command)
		{
			case "Ping":
				return Ping(host);
				break;
			case "TraceRoute":
				return TraceRoute(host);
				break;
			case "WhoIs":	
				return WhoIs(host);
				break;
		}
		return json;
	}

	public string Ping(string host)
	{
		PingReply reply = InformationInTransit.ProcessCode.PingHelper.Query(host);
		String json = String.Format
		(
			PingJsonFormat,
			reply.Address.ToString(),
			reply.RoundtripTime,
			reply.Options.Ttl,
			reply.Buffer.Length,
			reply.Options.DontFragment
		);
		return json;
	}
	
	public string TraceRoute(string host)
    {
		IEnumerable<IPAddress> ipAddresses = TraceRouteHelper.Query(host);
        var settings = new JsonSerializerSettings();
        settings.Converters.Add(new IPAddressConverter());
        settings.Converters.Add(new IPEndPointConverter());
        settings.Formatting = Formatting.Indented;

        string json = JsonConvert.SerializeObject(ipAddresses, settings);
		return json;
	}
	
	public string WhoIs(string host)
	{
		string info =	WhoIsHelper.WhoIs
		(
			"whois.internic.net",
			43,
			host
		);
		
		info = info.Replace("\n", "");
		info = info.Replace("\"", "");
		info = info.Replace("\\", "");
		info = info.Replace(">", "");
		info = info.Replace("<", "");
		info = info.Replace("\r", "");

		String json = String.Format(WhoIsJsonFormat, info);
		
		//string json = JsonConvert.SerializeObject(info);
		
		return json;
	}
	
	public const string PingJsonFormat = "{{\"Address\": \"{0}\", \"RoundtripTime\": {1}, \"Options.Ttl\": {2}, \"Buffer.Length\": {3}, \"Options.DontFragment\": \"{4}\"}}";
	public const string WhoIsJsonFormat = "{{\"WhoIs\": \"{0}\"}}";
}
