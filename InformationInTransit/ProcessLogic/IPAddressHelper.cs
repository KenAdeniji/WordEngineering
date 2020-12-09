#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
#endregion

namespace InformationInTransit.ProcessLogic
{
    #region IPAddressHelper definition
    public static partial class IPAddressHelper
    {
        #region Methods
        public static void Main(string[] argv)
        {
            IPAddress ipAddress = IPAddress.Parse("10.0.0.0");
			IPAddress ipAddressLoopback = IPAddress.Loopback;
            System.Console.WriteLine(Inet_Aton(ipAddress));
			System.Console.WriteLine(IsIPLocal(ipAddress));
            System.Console.WriteLine(RetrieveExternalIP(null));
			System.Console.WriteLine("ipAddress: {0}, IsLoopback: {1}", ipAddress, ipAddress.IsLoopback());
			System.Console.WriteLine("ipAddress: {0}, IsLoopback: {1}", ipAddressLoopback, ipAddressLoopback.IsLoopback());
			System.Console.WriteLine(RetrieveExternalIP("http://api.ipify.org"));
			System.Console.WriteLine(RetrieveExternalIP(null));
        }

		static public string CalculateSubnetMask(String ipaddress)
		{
			uint firstOctet = CalculateFirstOctet(ipaddress);
			if (firstOctet >= 0 && firstOctet <= 127)
				return "255.0.0.0";
			else if (firstOctet >= 128 && firstOctet <= 191)
				return "255.255.0.0";
			else if (firstOctet >= 192 && firstOctet <= 223)
				return "255.255.255.0";
			else return "0.0.0.0";
		}

		static public uint  CalculateFirstOctet(string ipAddress)
		{
			System.Net.IPAddress iPAddress = System.Net.IPAddress.Parse(ipAddress);
			byte[] byteIP = iPAddress.GetAddressBytes();
			uint ipInUint = (uint)byteIP[0];     
			return ipInUint;
		}

		/// <see>
		///		<a href="http://stackoverflow.com/questions/777617/calculate-broadcast-address-from-ip-and-subnet-mask">calculate broadcast address from ip and subnet mask</a>
		/// </see>
		public static string DetermineBroadcastAddress(string ipAddress, string subnetMask)
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

		/// <see>
		///		<a href="java2s.com/Code/CSharp/Network/GetSubnetMask.htm">Get subnet mask</a>
		/// </see>
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
		
        /// <summary>
        /// Csharp equivalent of Linux / Unix Command: inet_aton. The inet_aton() extension method converts the specified ipaddress, in the Internet standard dot notation, to a network address.
        /// </summary>
        /// <example>
        /// IPAddress ipAddressLocalHost = IPAddress.Parse("127.0.0.1");
        /// IPAddress ipAddressRemote = IPAddress.Parse(HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]);
		/// System.Console.WriteLine(Inet_Aton(ipAddressLocalHost));
        /// <example>
        public static double Inet_Aton(this IPAddress ipaddress)
        {
            int i;
            double num = 0;
            if (ipaddress.ToString() == "")
            {
                return 0;
            }
            string[] arrDec = ipaddress.ToString().Split('.');
            for (i = arrDec.Length - 1; i >= 0; i--)
            {
                num += ((int.Parse(arrDec[i]) % 256) * Math.Pow(256, (3 - i)));
            }
            return num;
        }
		
		///<summary>
		///<a href="http://stackoverflow.com/questions/8113546/how-to-determine-whether-an-ip-address-in-private">how to determine whether an IP address in private?</a>
		///The private address ranges are defined in RFC1918. They are:
		///10.0.0.0 - 10.255.255.255 (10/8 prefix)
		///172.16.0.0 - 172.31.255.255 (172.16/12 prefix)
		///192.168.0.0 - 192.168.255.255 (192.168/16 prefix)
		///You might also want to filter out link-local addresses (169.254/16) as defined in RFC3927.
		///</summary>
		///<example>
        ///IPAddress ipAddressLocalHost = IPAddress.Parse("10.0.0.0");
        ///IPAddress ipAddressRemote = IPAddress.Parse(HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]);
		///System.Console.WriteLine(IsIPLocal(ipAddressLocalHost));
        ///<example>
		public static bool IsIPLocal(this IPAddress ipaddress)
		{
			String[] straryIPAddress = ipaddress.ToString().Split(new String[] { "." }, StringSplitOptions.RemoveEmptyEntries);
			int[] iaryIPAddress = new int[] { int.Parse(straryIPAddress[0]), int.Parse(straryIPAddress[1]), int.Parse(straryIPAddress[2]), int.Parse(straryIPAddress[3]) };
			if (iaryIPAddress[0] == 10 || (iaryIPAddress[0] == 192 && iaryIPAddress[1] == 168) || (iaryIPAddress[0] == 172 && (iaryIPAddress[1] >= 16 && iaryIPAddress[1] <= 31)))
			{
				return true;
			}
			else
			{
				// IP Address is "probably" public. This doesn't catch some VPN ranges like OpenVPN and Hamachi.
				return false;
			}
		}

		///<summary>
		///	2016-06-27	http://www.java2s.com/Tutorial/CSharp/0580__Network/IsLoopbackIPaddress.htm
		///</summary>
		public static bool IsLoopback(this IPAddress ipAddress)
		{
			return IPAddress.IsLoopback(ipAddress);
		}

		///<summary>
		///	2017-06-05	http://extensionmethod.net/1581/csharp/string/isvalidipaddress
		///</summary>
		public static bool IsValidIPv4Address(this string s)
		{
			return Regex.IsMatch(s, 
					@"\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b");
		}
		
        ///<remarks>
		///		2017-07-14	RetrieveExternalIP("http://api.ipify.org")
		///<remarks>
		public static string RetrieveExternalIP(string provider)
        {
            try
            {
                if (string.IsNullOrEmpty(provider))
				{	
                    provider = "http://automation.whatismyip.com/n09230945.asp";
					provider = "http://api.ipify.org";
				}
                HttpWebRequest WebReq = (HttpWebRequest)HttpWebRequest.Create(provider);
                HttpWebResponse WebRes = (HttpWebResponse)WebReq.GetResponse();

                System.IO.Stream ResStream = WebRes.GetResponseStream();
                StreamReader ResStreamReader = new StreamReader(ResStream, Encoding.UTF8);

                string IP = ResStreamReader.ReadToEnd();

                ResStream.Close();
                WebRes.Close();

                return IP;
            }
            catch (Exception ex)
            {
                return "127.0.0.1";
                //throw;
            }
        }
		
		/// <remarks>
		///		Now to get the IPv4 address of your Ethernet network interface call:
		///			RetrieveLocalIPv4(NetworkInterfaceType.Ethernet);
		///		Or your Wireless interface:
		///			RetrieveLocalIPv4(NetworkInterfaceType.Wireless80211);
		/// </remarks>
		/// <returns>The local Ipv4.</returns>
		/// <param name="networkInterfaceType">Network interface type.</param>
		/// <see>
		///		<a href="http://stackoverflow.com/questions/6803073/get-local-ip-address">Get local ip address.</a>
		/// </see>
		/// <summary>
		/// Gets the local Ipv4.
		/// </summary>
		public static IPAddress RetrieveLocalIPv4(NetworkInterfaceType networkInterfaceType)
		{
			var networkInterfaces = NetworkInterface.GetAllNetworkInterfaces()
				.Where(i => i.NetworkInterfaceType == networkInterfaceType && i.OperationalStatus == OperationalStatus.Up);

			foreach (NetworkInterface networkInterface in networkInterfaces)
			{
				var adapterProperties = networkInterface.GetIPProperties();

				if (adapterProperties.GatewayAddresses.FirstOrDefault() != null)
				{
					foreach (UnicastIPAddressInformation ip in networkInterface.GetIPProperties().UnicastAddresses)
					{
						if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
						{
							return ip.Address;
						}
					}
				}
			}

			return null;
		}
        #endregion
    }
    #endregion
}
