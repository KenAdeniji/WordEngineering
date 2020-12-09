using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;

using System.Linq;

///<remarks>
///	https://msdn.microsoft.com/en-us/library/tst0kwb1%28v=vs.110%29.aspx
///	http://stackoverflow.com/questions/777617/calculate-broadcast-address-from-ip-and-subnet-mask
///</remarks>
namespace InformationInTransit.ProcessLogic
{
	class UsingUserDatagramProtocolUDPServicesClient
	{
		static void Main(string[] args) 
		{
			string 	ipAddressLoopback = "127.0.0.1";
			string	ipAddressUse = null;
			
			Socket 	s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram,
				ProtocolType.Udp);

			IPAddress ipAddressDetected = null;
			
			if (args.Length < 2)
			{
				ipAddressUse = ipAddressLoopback;
				ipAddressDetected = IPAddressHelper.RetrieveLocalIPv4(NetworkInterfaceType.Ethernet);
				if (ipAddressDetected == null)
				{
					ipAddressDetected = IPAddressHelper.RetrieveLocalIPv4(NetworkInterfaceType.Wireless80211);
				}
				if (ipAddressDetected != null)
				{
					ipAddressUse = ipAddressDetected.ToString();
				}
			}		
			else	
			{
				ipAddressUse = args[1];
			}

			IPAddress ipAddressLocal = IPAddress.Parse(ipAddressUse);
			
			IPAddress subnetMask = IPAddressHelper.DetermineSubnetMask(ipAddressLocal);
			
			string ipBroadcastAddress = IPAddressHelper.DetermineBroadcastAddress
										(
											ipAddressLocal.ToString(),
											subnetMask.ToString()
										);	
		
			IPAddress broadcastAddress = IPAddress.Parse(ipBroadcastAddress);
			
			byte[] sendbuf = Encoding.ASCII.GetBytes(args[0]);
			IPEndPoint ep = new IPEndPoint(broadcastAddress, 11000);

			s.SendTo(sendbuf, ep);

			System.Console.WriteLine
			(
				"IP Address: {0}. Subnet mask: {1}. Broadcast Address: {2}.",
				ipAddressUse,
				subnetMask,
				broadcastAddress
			);
		}
	}
}
