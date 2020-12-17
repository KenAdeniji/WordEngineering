using System;
using System.Net;
using System.Web;

/*
	2020-09-07 	Created.		https://docs.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlconnection.getschema?view=netframework-4.8
*/
namespace InformationInTransit.ProcessCode
{
	public static partial class EsvApi
	{
		public static void Main(string[] argv)
		{
			Query();
		}
		
		public static String Query()
		{
			var key = "e4cafb2e534d14a51bb0bce3723aee27c5ba7146";
			var strSearch = "John 1";
			var passage = HttpUtility.UrlEncode(strSearch);
			var options = "include-passage-references=true";
			var client = new WebClient();
			var query = string.Format
			(
				"http://www.esvapi.org/v2/rest/passageQuery?key={0}&passage={1}&options={2}",
				key,
				passage,
				options
			);
			var result = client.DownloadString(query);
			System.Console.WriteLine(result);
			return result;
		}		
    }
}
