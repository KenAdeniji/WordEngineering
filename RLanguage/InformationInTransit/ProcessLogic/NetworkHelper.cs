using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.IO;
using System.Management;
using System.Net;
using System.Net.Cache;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace InformationInTransit.ProcessLogic
{
    /// <summary>
    /// netstat -anb
    /// </summary>
    public static partial class NetworkHelper
    {
        [STAThread]
        public static void Main(string[] argv)
        {
            System.Console.WriteLine("IsNetworkAvailable: {0}", IsNetworkAvailable());
            System.Console.WriteLine("IPAddress.Loopback: {0}", Loopback);
            System.Console.WriteLine("IPAddress.Broadcast: {0}", Broadcast);
            System.Console.WriteLine("IPAddress.Any: {0}", Any);
            System.Console.WriteLine("IPAddress.None: {0}", None);

            System.Console.WriteLine("IPEndPoint: {0}", LoopbackPort80);

            System.Console.WriteLine("HostName: {0}", HostName);

            string fullyQualifiedDomainName = RetrieveFullyQualifiedDomainName();
            System.Console.WriteLine("FullyQualifiedDomainName: {0}", fullyQualifiedDomainName);

			System.Console.WriteLine(IPAddressInternetDynDns());
			
			List<string> macAddresses = MACAddresses(false);
			foreach(string macAddress in macAddresses)
			{
				System.Console.WriteLine(macAddress);
			}
        }
        
        /// <summary>
        /// Telnet localhost 7
        /// </summary>
        public static void EchoClientWithoutMessageEncoding()
        {
            using (TcpClient tcpClient = new TcpClient("localhost", PortEcho))
            {
                NetworkStream networkStream = tcpClient.GetStream();
                StreamWriter streamWriter = new StreamWriter(networkStream);
                StreamReader streamReader = new StreamReader(networkStream);

                streamWriter.WriteLine("Echo request.");
                streamWriter.Flush();
                System.Console.WriteLine(streamReader.ReadLine());
            }
        }

        public static void EchoClientWithUTF8Encoding()
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(new IPEndPoint(IPAddress.Loopback, PortEcho));

            UTF8Encoding utf8Encoding = new UTF8Encoding();
            socket.Send(utf8Encoding.GetBytes("Echo request."));
            Byte[] buffer = new Byte[1024];
            socket.Receive(buffer);
            System.Console.WriteLine(utf8Encoding.GetString(buffer));
        }

        /// <summary>
        /// http://codekeep.net/snippets/59d020e8-6667-4e90-b866-a3857072b941.aspx
        /// 2014-04-04 Kevin Shuma
        /// </summary>
        /// <returns></returns>
        public static string RetrieveFullyQualifiedDomainName()
        {
            var domainName = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName;
            var hostName = Dns.GetHostName();
            string fullyQualifiedDomainName = null;

            bool contains = hostName.Contains(domainName);

            /*
            System.Console.WriteLine
            (
                "Host name: {0} | Domain name: {1} | Contains: {2}",
                hostName,
                domainName,
                contains
            );
            */

            if (contains == false)
            {
                fullyQualifiedDomainName = string.Format("{0}.{1}", hostName, domainName);
            }
            else
            {
                fullyQualifiedDomainName = hostName;
            }
            return fullyQualifiedDomainName;
        }

		///<remarks>
		///http://extensionmethod.net/csharp/net/convert-internet-dot-address-to-network-address
		///</remarks>
		///<example>
		///IPAddress ipAddress = IPAddress.Parse(HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]);
		///double ipNumber = ipAddress.inet_aton();
		///</example>
		public static double inet_aton(this IPAddress IPaddress)
		{
			int i;
			double num = 0;
			if (IPaddress.ToString() == "")
			{
				return 0;
			}
			string[] arrDec = IPaddress.ToString().Split('.');
			for (i = arrDec.Length - 1; i >= 0; i--)
			{
				num += ((int.Parse(arrDec[i]) % 256) * Math.Pow(256, (3 - i)));
			}
			return num;
		}

		///<remarks>
		///http://support.microsoft.com/kb/305703
		///</remarks>
		public static void InternetBrowser()
		{
			string webAddress = "http://www.microsoft.com";
			//string ftpAddress = "ftp://ftp.microsoft.com";
			//string htmlFileName = "C:\\Program Files\\Microsoft Visual Studio\\INSTALL.HTM";
			System.Diagnostics.Process.Start(webAddress);
		}

		///<remarks>
		///http://msdn.microsoft.com/en-us/library/aa287519%28v=vs.71%29.aspx
		///</remarks>
		public static void InternetExplorer()
		{
			System.Diagnostics.Process.Start("IExplore.exe", "www.microsoft.com");
		}

		///<remarks>
		///overclock.net/t/1333198/how-to-get-internet-ip-address-c
		///</remarks>
		public static string IPAddressInternet()
		{
			 WebClient client = new WebClient();
			 return client.DownloadString("http://icanhazip.com/");
		}
		
		private static string IPAddressInternetDynDns()
		{
			// check IP using DynDNS's service
			WebRequest request = WebRequest.Create("http://checkip.dyndns.org");
			WebResponse response = request.GetResponse();
			StreamReader stream = new StreamReader(response.GetResponseStream());
		 
			// IMPORTANT: set Proxy to null, to drastically INCREASE the speed of request
			// request.Proxy = null;
		 
			// read complete response
			string ipAddress = stream.ReadToEnd();
		 
			// replace everything and keep only IP
			return ipAddress.
				Replace("<html><head><title>Current IP Check</title></head><body>Current IP Address: ", string.Empty).
				Replace("</body></html>", string.Empty);
		}

		///<remarks>
		///http://matijabozicevic.com/blog/wpf-winforms-development/csharp-get-computer-ip-address-lan-and-internet
		///</remarks>
		private static string IPAddressLocalAreaNetworkLAN()
		{
			string ipAddressLAN = null;
			string strHostName = System.Net.Dns.GetHostName();

			IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);
			 
			foreach (IPAddress ipAddress in ipEntry.AddressList)
			{
				if (ipAddress.AddressFamily.ToString() == "InterNetwork")
				{
					ipAddressLAN = ipAddress.ToString();
					break;
				}
			}
		 
			return ipAddressLAN;
		}
		
		/*
			//returns false
			string s = "192.168.1.256";
			bool b = s.IsValidIPv4Address();
			//returns true
			string s = "192.168.1.254";
			bool b = s.IsValidIPv4Address();
		*/
        public static bool IsValidIPv4Address(this string s)
		{
			return Regex.IsMatch(s,
				@"\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b");
		}
		
		public static bool IsNetworkAvailable()
        {
            bool isNetworkAvailable = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
            return isNetworkAvailable;
        }

		///<example>
		///	List<string> macAddresses = MACAddresses(false);
		///	foreach(string macAddress in macAddresses)
		///	{
		///		System.Console.WriteLine(macAddress);
		///	}
		///</example>
		///<remarks>
		/// dotnetspider.com/resources/4889-Get-MAC-address-your-system.aspx
		///</remarks>
		public static List<string> MACAddresses(bool? status)
		{
			string macAddress = null;
			List<string> macAddresses = new List<string>();
			
			ManagementClass managementClass = new ManagementClass("Win32_NetworkAdapterConfiguration");
			ManagementObjectCollection managementClassCollection = managementClass.GetInstances();

			bool? flag = null;
			
			foreach (ManagementObject managementObject in managementClassCollection)
			{
				macAddress = (string) managementObject["MacAddress"];
				flag = (bool?) managementObject["IPEnabled"];
				
				if (status == null)
				{
					macAddresses.Add( macAddress );
				}
				else if (status == flag)
				{
					macAddresses.Add( macAddress );
				}
			}
			
			return macAddresses;
		}

		///<remarks>
		///http://stackoverflow.com/questions/6435099/c-how-to-get-datetime-from-the-internet
		///</remarks>
        public static DateTime NationalInstituteOfStandardsAndTechnologyNISTInternetTimeService()
		{
			var client = new TcpClient("64.90.182.55", 13);
			string response = null;
			string utcDateTimeString = null;
			DateTime localDateTime = DateTime.Now;
			
			using (var streamReader = new StreamReader(client.GetStream()))
			{
				response = streamReader.ReadToEnd();
				utcDateTimeString = response.Substring(7, 17);
				localDateTime = DateTime.ParseExact
				(
					utcDateTimeString,
					"yy-MM-dd hh:mm:ss",
					CultureInfo.InvariantCulture,
					DateTimeStyles.AssumeUniversal
				);
			}
			return localDateTime;
		}

		///<remarks>
		///http://stackoverflow.com/questions/6435099/c-how-to-get-datetime-from-the-internet
		///For environments where port 13 is blocked, time from NIST can be web scraped as below.
		///</remarks>
		public static DateTime NationalInstituteOfStandardsAndTechnologyNISTInternetTimeServiceRetrieve()
		{
			DateTime dateTime = DateTime.MinValue;

			HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://nist.time.gov/timezone.cgi?UTC/s/0");
			request.Method = "GET";
			request.Accept = "text/html, application/xhtml+xml, */*";
			request.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)";
			request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore); //No caching
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			if (response.StatusCode == HttpStatusCode.OK)
			{
				StreamReader stream = new StreamReader(response.GetResponseStream());
				string html = stream.ReadToEnd().ToUpper();
				string time = Regex.Match(html, @">\d+:\d+:\d+<").Value; //HH:mm:ss format
				string date = Regex.Match(html, @">\w+,\s\w+\s\d+,\s\d+<").Value; //dddd, MMMM dd, yyyy
				dateTime = DateTime.Parse((date + " " + time).Replace(">", "").Replace("<", ""));
			}
			return dateTime;
		}
		
		public static void SendDataUsingSocket()
        {
            IPAddress host = Loopback;
            IPEndPoint hostEndPoint = new IPEndPoint(host, PortEcho);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                socket.Connect(hostEndPoint);
                socket.Send(Encoding.ASCII.GetBytes("Socket send."));
            }
            catch (SocketException ex)
            {
                System.Console.WriteLine("SocketException: {0}", ex.Message);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception: {0}", ex.Message);
            }
            finally
            {
                socket.Close();
            }
        }

        public static void ReceiveDataFromServer()
        {
            IPAddress host = Loopback;
            IPEndPoint hostEndPoint = new IPEndPoint(host, PortQuoteOfTheDay);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                socket.Connect(hostEndPoint);
                byte[] data = new byte[1024];
                int receivedDataLength = socket.Receive(data);
                string stringData = Encoding.ASCII.GetString(data, 0, receivedDataLength);
                Console.WriteLine(stringData);
            }
            catch (SocketException ex)
            {
                System.Console.WriteLine("SocketException: {0}", ex.Message);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception: {0}", ex.Message);
            }
            finally
            {
                socket.Close();
            }
        }

        public static void SendDataToTheServer()
        {
            IPAddress host = Loopback;
            IPEndPoint hostEndPoint = new IPEndPoint(host, PortEcho);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                socket.Connect(hostEndPoint);

                System.Console.WriteLine("Type 'exit' to exit.");

                while (true)
                {
                    string input = Console.ReadLine();
                    if (input == "exit")
                    {
                        break;
                    }
                    socket.Send(Encoding.ASCII.GetBytes(input));
                    byte[] data = new byte[1024];
                    int receivedDataLength = socket.Receive(data);
                    string stringData = Encoding.ASCII.GetString(data, 0, receivedDataLength);
                    Console.WriteLine(stringData);
                }
            }
            catch (SocketException ex)
            {
                System.Console.WriteLine("SocketException: {0}", ex.Message);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception: {0}", ex.Message);
            }
            finally
            {
                socket.Close();
            }
        }

        public static void SendDataToTheClient()
        {
            Socket socket = null;
            Socket client = null;

            try
            {
                IPEndPoint ip = new IPEndPoint(IPAddress.Any, 9999);
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                socket.Bind(ip);
                socket.Listen(10);
                System.Console.WriteLine("Waiting for a client...");
                client = socket.Accept();
                IPEndPoint clientep = (IPEndPoint)client.RemoteEndPoint;
                System.Console.WriteLine("Connected with {0} at port {1}", clientep.Address, clientep.Port);

                string welcome = "Welcome";
                byte[] data = new byte[1024];
                data = Encoding.ASCII.GetBytes(welcome);
                client.Send(data, data.Length, SocketFlags.None);

                System.Console.WriteLine("Disconnected from {0}", clientep.Address);
            }
            catch (SocketException ex)
            {
                System.Console.WriteLine("SocketException: {0}", ex.Message);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception: {0}", ex.Message);
            }
            finally
            {
                client.Close();
                socket.Close();
            }
        }

		//**************************************
		// Name: Send mail with SmtpClient using Gmail SMTP Server
		// Description:Connects to smtp.gmail.com, authenticate a valid gmail user account using SSL and sends an email.
		// Regular SSL port 465 won´t work. You´ll have to use an alternate port, 587.
		// By: Bernardo Bicalho
		//
		// Inputs:valid gmail user account
		// valid gmail user password
		//
		// This code is copyrighted and has limited warranties.Please see http://www.Planet-Source-Code.com/vb/scripts/ShowCode.asp?txtCodeId=4733&lngWId=10//for details.
		// http://joelbennett.wordpress.com/2007/09/24/sending-text-messages-via-sms-to-a-mobile-phone-from-a-c-windows-application-via-gmail/
		public static void ShortMessageServiceSms()
		{
			MailMessage MailObj = new MailMessage();
			MailObj.To.Add("GmailAccount@gmail.com");
			//MailObj.From = "GmailAccount@gmail.com"; //Not in use.
			//MailObj.Cc = "cc@cc.com";
			
			MailObj.IsBodyHtml = true;
	
			MailObj.Priority = MailPriority.Normal ;
			//string sAttach = @"c:\yourpic.jpg";
			//MailObj.Attachments.Add(new Attachment(sAttach));
			MailObj.Subject = "Subject";
			MailObj.Body = "<table><tr><td>Test</td></tr></table>";

			SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587); //use this PORT!
			smtpClient.EnableSsl = true;
			smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
			smtpClient.Credentials = new NetworkCredential("", "");

			try
			{
				smtpClient.Send(MailObj);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		///<remarks>
		///http://stackoverflow.com/questions/2471209/how-to-read-a-file-from-internet
		///</remarks>
        public static string UriRead(String uri)
		{
			WebClient client = new WebClient();
			Stream stream = client.OpenRead(uri);
			StreamReader reader = new StreamReader(stream);
			String content = reader.ReadToEnd();
			return content;
		}
		
		///<remarks>
		///http://www.c-sharpcorner.com/UploadFile/jghosh/WhoIsWeb12052005042946AM/WhoIsWeb.aspx
		///</remarks>
		public static string WhoIs()
		{
			TcpClient tcpc = new TcpClient();
			tcpc.Connect("whois.networksolutions.com", PortWhoIs);
			String strDomain = "microsoft.com\r\n";
			Byte[] arrDomain = Encoding.ASCII.GetBytes(strDomain.ToCharArray());
			Stream s = tcpc.GetStream();
			s.Write(arrDomain, 0, strDomain.Length);
			StreamReader sr = new StreamReader(tcpc.GetStream(), Encoding.ASCII);
			while (-1 != sr.Peek())
			{
				System.Console.WriteLine(sr.ReadLine() + "<br>");
			}
			tcpc.Close();
			return "whois";
		}
		
        static NetworkHelper()
        {
            Loopback = IPAddress.Loopback;
            Broadcast = IPAddress.Broadcast;
            Any = IPAddress.Any;
            None = IPAddress.None;

            LoopbackPort80 = new IPEndPoint(Loopback, 80);
            HostName = Dns.GetHostName();

            IPAddress[] localIPAddresses = Dns.GetHostAddresses(Dns.GetHostName());
        }

        //public static readonly IPAddress ipAddress;

        /// <summary>
        /// Provides the IP loopback address. This field is read-only.
        /// The Loopback field is equivalent to 127.0.0.1 in dotted-quad notation.
        /// </summary>
        public static readonly IPAddress Loopback;

        /// <summary>
        /// Provides the IP broadcast address. This field is read-only.
        /// The Broadcast field is equivalent to 255.255.255.255 in dotted-quad notation.
        /// </summary>
        public static readonly IPAddress Broadcast;

        /// <summary>
        /// Provides an IP address that indicates that the server must listen for client activity on all network interfaces. This field is read-only.
        /// The Socket.Bind method uses the Any field to indicate that a Socket instance must listen for client activity on all network interfaces.
        /// The Any field is equivalent to 0.0.0.0 in dotted-quad notation.
        /// </summary>
        public static readonly IPAddress Any;

        /// <summary>
        /// Provides an IP address that indicates that no network interface should be used. This field is read-only.
        /// The Socket.Bind method uses the None field to indicate that a Socket must not listen for client activity. The None field is equivalent to 255.255.255.255 in dotted-quad notation.
        /// </summary>
        public static readonly IPAddress None;

        public static readonly IPEndPoint LoopbackPort80;

        public static readonly string HostName;

        const int PortEcho = 7;
        const int PortQuoteOfTheDay = 17;
		const int PortWhoIs = 43;
    }
}
