using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace InformationInTransit.ProcessLogic
{
	///<remarks>
	/// 2015-09-01	http://www.codeproject.com/Articles/105805/Web-Server-Information-using-NET
	///</remarks>
    public static partial class WebClientHelper
    {
		public static void Main(String[] argv)
		{
			foreach(String argc in argv)
			{
				System.Console.WriteLine(Inspect(argc));
			}	
		}		

		public static string Inspect(String address)
        {
			WebClient wc = new WebClient();
			// This line adds a user agent string to header of Web Client.
			// user agent is optional but some websites/servers use this string
			// to verify whether you are a bot or browser. We use this to act our tool 
			// like a browser.
			// More info about user agent here - http://en.wikipedia.org/wiki/User_agent

			wc.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)"); 

			// Below line reads information from the server of specified website.
			// OpenRead() method returns the contents of the file, but since we do not need
			// it for our tool, I am not reading it to a variable.
			wc.OpenRead(address); 

			StringBuilder sb = new StringBuilder();
			
			// wc.ResponseHeaders contents all the header responses from server.
			// I am adding those information to a StringBuilder variable with some formatting.
			// wc.ResponseHeaders.Count returns number of keys/values available. 
			// Count varies from website to website
			for (int i = 0; i < wc.ResponseHeaders.Count; i++)
			{
				 sb.Append((i + 1).ToString() + ". [" + wc.ResponseHeaders.AllKeys[i] + "] => " 
				 + wc.ResponseHeaders[i] + Environment.NewLine + Environment.NewLine);
			}

            return sb.ToString();
        }
    }
}
