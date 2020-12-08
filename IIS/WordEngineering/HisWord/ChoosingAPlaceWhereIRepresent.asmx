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

using System.Data;
using System.Data.SqlClient;
using System.Text;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using InformationInTransit.ProcessCode;

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
		string resultSet = "";
		switch (command)
		{
			case "ping":
				PingReply reply = PingHelper.Query(hostNameOrAddress);
				string json = ""; //JsonConvert.SerializeObject(reply, Formatting.Indented);
				json = String.Format
				(
					PingJsonFormat,
					reply.Address.ToString(),
					reply.RoundtripTime,
					reply.Options.Ttl,
					reply.Buffer.Length,
					reply.Options.DontFragment
				);	
				return json;
				break;
		}
	}
	public const string PingJsonFormat = "{{\"Address\": \"{0}\", \"RoundtripTime\": {1}, \"Options.Ttl\": {2}, \"Buffer.Length\": {3}, \"Options.DontFragment\": \"{4}\"}}";
}
