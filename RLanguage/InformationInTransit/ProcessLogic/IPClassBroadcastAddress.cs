using System;
using System.Net;
using System.Net.Sockets;

public static partial class IPClassBroadcastAddress
{
	public static string RetrieveBroadcastAddress(string ipAddress, string subnetMask)
	{
		//determines a broadcast address from an ip and subnet
		var ip = IPAddress.Parse(ipAddress);
		var mask = IPAddress.Parse(subnetMask);

		byte[] ipAdressBytes = ip.GetAddressBytes();
		byte[] subnetMaskBytes = mask.GetAddressBytes();

		if (ipAdressBytes.Length != subnetMaskBytes.Length)
			throw new ArgumentException("Lengths of IP address and subnet mask do not match.");

		byte[] broadcastAddress = new byte[ipAdressBytes.Length];
		for (int i = 0; i < broadcastAddress.Length; i++) {
			broadcastAddress[i] = (byte)(ipAdressBytes[i] | (subnetMaskBytes[i] ^ 255));
		}
		return new IPAddress(broadcastAddress).ToString();
	}
}
