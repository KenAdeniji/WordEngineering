using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Linq;

namespace InformationInTransit.ProcessLogic
{
	public static partial class ReverseGeocoding
	{
	  static string baseUri = "http://maps.googleapis.com/maps/api/geocode/xml?latlng={0},{1}&sensor=false";
	  static void Main(string[] args)
	  {
		RetrieveFormatedAddress("51.962146", "7.602304");
		Console.ReadLine();
	  }

	  public static void RetrieveFormatedAddress(string lat, string lng)
	  {
		string requestUri = string.Format(baseUri, lat, lng);
		using (WebClient wc = new WebClient())
		{
		  wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wc_DownloadStringCompleted);
		  wc.DownloadStringAsync(new Uri(requestUri));
		}
	  }

	  public static void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
	  {
		var xmlElm = XElement.Parse(e.Result);
		var status = (from elm in xmlElm.Descendants()
					  where elm.Name == "status"
					  select elm).FirstOrDefault();

		if (status.Value.ToLower() == "ok")
		{
		  var res = (from elm in xmlElm.Descendants()
					 where elm.Name == "formatted_address"
					 select elm).FirstOrDefault();
		  Console.WriteLine(res.Value);
		}

		else
		{
		  Console.WriteLine("No Address Found");
		}
	  }
	}
}
