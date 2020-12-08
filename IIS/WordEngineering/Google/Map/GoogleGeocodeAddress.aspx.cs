using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.XPath;

public partial class GoogleGeocodeAddress : System.Web.UI.Page
{
    public String Address
	{
		get { return address.Text; }
		set { address.Text = value; }
	}

    public String Latitude
	{
		get { return latitude.Text; }
		set { latitude.Text = value; }
	}

    public String Longitude
	{
		get { return longitude.Text; }
		set { longitude.Text = value; }
	}
	
	public void Submit_Click(object sender, EventArgs e)
    {
		string uri = String.Format(UriFormat, Address);
		XElement root = XElement.Load(uri);
		Latitude = root.XPathSelectElement("//result//geometry//location//lat").Value;
		Longitude = root.XPathSelectElement("//result//geometry//location//lng").Value;
    }
	
	public const string UriFormat = "http://maps.googleapis.com/maps/api/geocode/xml?sensor=false&address={0}";
}
