using System;
using System.Net.NetworkInformation;

namespace InformationInTransit.ProcessCode
{
	///<summary>
	/// 2019-01-12 	Created.	https://docs.microsoft.com/en-us/dotnet/api/system.net.networkinformation.ping.send?view=netframework-4.7.2#System_Net_NetworkInformation_Ping_Send_System_String_
	///</summary>
	public static partial class PingHelper
	{
		public static void Main(string[] argv)
		{
			Query(argv[0]);
		}
		
		public static PingReply Query(string hostNameOrAddress)
		{
			Ping pingSender = new Ping();
			PingReply reply = pingSender.Send(hostNameOrAddress);

/*
			if (reply.Status == IPStatus.Success)
			{
				Console.WriteLine("Address: {0}", reply.Address.ToString ());
				Console.WriteLine("RoundTrip time: {0}", reply.RoundtripTime);
//				Console.WriteLine("Time to live: {0}", reply.Options.Ttl);
//				Console.WriteLine("Don't fragment: {0}", reply.Options.DontFragment);
				Console.WriteLine("Buffer size: {0}", reply.Buffer.Length);
			}
			else
			{
				Console.WriteLine (reply.Status);
			}		
*/
			return reply;
		}
	}
}
