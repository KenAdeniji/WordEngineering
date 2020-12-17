using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace InformationInTransit.ProcessLogic
{
    public static partial class WebHelper
    {
        public static string GetPageAsString(Uri address)
        {
            string result = "";

            // Create the web request  
            HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;

            // Get response  
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                // Get the response stream  
                StreamReader reader = new StreamReader(response.GetResponseStream());

                // Read the whole contents and return as a string  
                result = reader.ReadToEnd();
            }

            return result;
        }
		
        /*
			2017-04-05	Created.
		*/
		public static string GetPageAsString(String address)
        {
			return GetPageAsString( new Uri(address) );
        }
    }
}
