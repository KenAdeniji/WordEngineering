using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;

namespace InformationInTransit.ProcessCode
{
	///<summary>
	/// 2019-01-13	https://stackoverflow.com/questions/142614/traceroute-and-ping-in-c-sharp
	/// 2019-01-13	https://stackoverflow.com/questions/142614/traceroute-and-ping-in-c-sharp/45565253#45565253
	///</summary>
	public static partial class TraceRouteHelper
	{
		public static void Main(string[] argv)
		{
			IEnumerable<IPAddress> ipAddresses = Query(argv[0]);
		}
		
		public static IEnumerable<IPAddress> Query(string hostname)
		{
			// following are the defaults for the "traceroute" command in unix.
			const int timeout = 10000;
			const int maxTTL = 30;
			const int bufferSize = 32;

			byte[] buffer = new byte[bufferSize];
			new Random().NextBytes(buffer);
			Ping pinger = new Ping();

			for (int ttl = 1; ttl <= maxTTL; ttl++)
			{
				PingOptions options = new PingOptions(ttl, true);
				PingReply reply = pinger.Send(hostname, timeout, buffer, options);

				if (reply.Status == IPStatus.TtlExpired)
				{
					// TtlExpired means we've found an address, but there are more addresses
					yield return reply.Address;
					continue;
				}
				if (reply.Status == IPStatus.TimedOut)
				{
					// TimedOut means this ttl is no good, we should continue searching
					continue;
				}
				if (reply.Status == IPStatus.Success)
				{
					// Success means the tracert has completed
					yield return reply.Address;
				}

				// if we ever reach here, we're finished, so break
				break;
			}
		}		
	}
}
