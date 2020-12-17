#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
#endregion

namespace InformationInTransit.ProcessLogic
{
    #region DnsHelper definition
    public static partial class DnsHelper
    {
        #region Methods
        public static void Main(string[] argv)
        {
			string hostName = RetrieveHostName();
            System.Console.WriteLine("Hostname: {0}", hostName);
			
			IPHostEntry ipHostEntry = IPHostEntry(hostName);
        }

		///<summary>
		///	2016-06-27	http://www.java2s.com/Tutorial/CSharp/0580__Network/DNSNameandItsIPHostEntry.htm
		///</summary>
		static public string RetrieveHostName()
		{
			return Dns.GetHostName();
		}
		
		///<summary>
		///	2016-06-28	http://www.java2s.com/Tutorial/CSharp/0580__Network/DNSNameandItsIPHostEntry.htm
		///</summary>
		static public IPHostEntry IPHostEntry(string hostName)
		{
			IPHostEntry ipHostEntry = Dns.GetHostEntry(hostName);
			foreach (IPAddress address in ipHostEntry.AddressList)
			{
			 Console.WriteLine("IP Address: {0}", address.ToString());
			}
			return ipHostEntry;	
		}	
        #endregion
    }
    #endregion
}
