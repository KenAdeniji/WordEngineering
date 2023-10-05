using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Linq;

public partial class GoogleReverseGeocoding : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		string latitude = Request.QueryString["latitude"];
		if (String.IsNullOrEmpty(latitude)) { latitude = Latitude; }
		
		string longitude = Request.QueryString["longitude"];
		if (String.IsNullOrEmpty(longitude)) { longitude = Longitude; }
		
		RetrieveFormatedAddress(latitude, longitude);
	}
	
	public void RetrieveFormatedAddress(string lat, string lng)
	{
		string requestUri = string.Format(baseUri, lat, lng);
		using (WebClient wc = new WebClient())
		{
		  wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wc_DownloadStringCompleted);
		  wc.DownloadStringAsync(new Uri(requestUri));
		}
	}
	
	public void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
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
			Feedback.Text = res.Value;
		}
		else
		{
			Feedback.Text = "No Address Found";
		}
	}

	public const string baseUri = "http://maps.googleapis.com/maps/api/geocode/xml?latlng={0},{1}&sensor=false";
	public const string Latitude = "51.962146";
	public const string Longitude = "7.602304";
}
