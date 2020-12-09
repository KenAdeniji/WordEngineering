using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Net;
using System.Web;

namespace InformationInTransit.ProcessLogic
{
	public static partial class EsvApiHelper {
		public static void Main(string[] argv) {
            string query = "";
            if (argv.Length > 0)
            {
                query = argv[0];
            }
            string textualForm = PassageQuery(query);
            System.Console.WriteLine(textualForm);
		}
		
		///<remarks>
        /// 2015-06-14  http://www.esvapi.org/api#sample
        /// 2015-06-14  http://stackoverflow.com/questions/14731/urlencode-through-a-console-application
		///</remarks>
		public static string PassageQuery(string query) {
            string textualForm = "";
            StringBuilder sUrl = new StringBuilder();
            if (String.IsNullOrEmpty(query))
            {
                query = "Matthew 5";
            }
            //query = HttpContext.Current.Server.UrlEncode(query);
            query = System.Web.HttpUtility.UrlEncode(query);
            
            sUrl.Append("http://www.esvapi.org/v2/rest/passageQuery");
            sUrl.Append("?key=Test");
            sUrl.Append("&passage=" + query);
            sUrl.Append("&include-headings=true");
            
            WebRequest oReq = WebRequest.Create(sUrl.ToString());
            StreamReader sStream = new StreamReader(oReq.GetResponse().GetResponseStream());

            StringBuilder sOut = new StringBuilder();
            sOut.Append(sStream.ReadToEnd());
            sStream.Close();

            textualForm = sOut.ToString();
 
            //System.Web.HttpContext.Current.Response.Write(textualForm);
			return textualForm;
		}
	}
}
