using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace InformationInTransit.ProcessLogic
{
	public static partial class WhoIsHelper {
		public static void Main(string[] argv) {
			foreach (String argc in argv)
			{
				string whoIs = WhoIs("whois.markmonitor.com", -1, argc);
				System.Console.WriteLine
				(
					"Address: {0} WhoIs: {1}",
					argc,
					whoIs
				);
			}
		}
		
		///<remarks>
		/// 2015-06-13  http://stackoverflow.com/questions/36817/who-provides-a-whois-api
		///</remarks>
		public static string WhoIs(string server, int port, string address) {
			string response = null;
			if (String.IsNullOrEmpty(server))
				server = "whois.internic.net";
			if (port < 1)
				port = 43;
			using (var client = new TcpClient(server, port)) {
				using (var ns = client.GetStream()) {
					using (var buffer = new BufferedStream(ns)) {
						var sw = new StreamWriter(buffer);
						sw.WriteLine(address);
						sw.Flush();
						var sr = new StreamReader(buffer);
						response = sr.ReadToEnd();
					}
					ns.Close();
					ns.Dispose();
				}
				client.Close();
			}
			return response;
		}
	}
}
