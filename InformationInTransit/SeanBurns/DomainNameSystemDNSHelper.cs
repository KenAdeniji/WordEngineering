using System;
using System.Net;

/*
	2021-11-23T18:23:00 https://books.google.com/books?id=WcyPDwAAQBAJ&printsec=frontcover&source=gbs_atb#v=onepage&q&f=false
	2021-11-23T18:23:00 DomainNameSystemDNSHelper Translate.Google.com
	2021-11-23T18:50:00 DomainNameSystemDNSHelper 127.0.0.1
		C:\Windows\System32\drivers\etc\hosts
		\etc\hosts
*/
namespace SeanBurns
{
	public class DomainNameSystemDNSHelper
	{
		public static void Main(string[] argv)
		{
			string hostName = argv.Length < 1 ? 
				HostNameDefault : argv[0];
			var domainEntry = Dns.GetHostEntry
			(
				hostName
			);
			System.Console.WriteLine(domainEntry.HostName);
			foreach(var ip in domainEntry.AddressList)
			{
				System.Console.WriteLine(ip);
			}
		}
		public const String HostNameDefault = "Google.com";
	}
}	