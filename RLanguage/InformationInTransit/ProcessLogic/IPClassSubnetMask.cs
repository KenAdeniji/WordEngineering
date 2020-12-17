/*
2016-01-20	Created.	http://weblogs.asp.net/razan/finding-subnet-mask-from-ip4-address-using-c
2016-01-20				http://www.java2s.com/Code/CSharp/Network/GetSubnetMask.htm
*/

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.IO;

public static partial class IPClassSubnetMask
{
	public static IPAddress DetermineSubnetMask(IPAddress address)
	{
		foreach (NetworkInterface adapter in NetworkInterface.GetAllNetworkInterfaces())
		{
			foreach (UnicastIPAddressInformation unicastIPAddressInformation in adapter.GetIPProperties().UnicastAddresses)
			{
				if (unicastIPAddressInformation.Address.AddressFamily == AddressFamily.InterNetwork)
				{
					if (address.Equals(unicastIPAddressInformation.Address))
					{
						return unicastIPAddressInformation.IPv4Mask;
					}
				}
			}
		}
		throw new ArgumentException(string.Format("Can't find subnetmask for IP address '{0}'", address));
	}
	
	static public string RetrieveSubnetMask(String ipaddress)
	{
		uint firstOctet = RetrieveFirstOctet(ipaddress);
		if (firstOctet >= 0 && firstOctet <= 127)
			return "255.0.0.0";
		else if (firstOctet >= 128 && firstOctet <= 191)
			return "255.255.0.0";
		else if (firstOctet >= 192 && firstOctet <= 223)
			return "255.255.255.0";
		else return "0.0.0.0";
	}

	static public uint  RetrieveFirstOctet(string ipAddress)
	{
		System.Net.IPAddress iPAddress = System.Net.IPAddress.Parse(ipAddress);
		byte[] byteIP = iPAddress.GetAddressBytes();
		uint ipInUint = (uint)byteIP[0];     
		return ipInUint;
	}
}

