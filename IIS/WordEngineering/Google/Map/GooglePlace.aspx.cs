using System;
using System.Configuration;
using System.Collections;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

using InformationInTransit.ProcessLogic;

/// <see cref="https://maps.googleapis.com/maps/api/place/search/json?location=-33.8670522,151.1957362&radius=7500&types=library&sensor=false&key=AIzaSyA3s7tNLie9_XAyKwzl8sGypCllGrkEqu8"/>
/// <see cref="http://json2csharp.com"/>
public partial class GooglePlace : System.Web.UI.Page
{
    const String RequestFormat = @"https://maps.googleapis.com/maps/api/place/search/json?location={0},{1}&radius={2}&types={3}&sensor=false&key=AIzaSyD3jfeMZK1SWfRFDgMfxn_zrGRSjE7S8Vg";
    const String TellFormat = "Latitude: {0} Longitude: {1}<br/>Name: {2}<br/>Vicinity: {3}<hr/><br/>";
    
    protected void Page_Load(object sender, EventArgs e)
    {
		if (!Page.IsPostBack)
        {
            latitude.Text = @"-33.8670522";
            longitude.Text = @"151.1957362";
            radius.Text = @"7500";
            types.Text = @"library";
        }
    }

    protected void Query_Click(object sender, EventArgs e)
    {
        string requestUri = String.Format
                            (
                                RequestFormat,
                                latitude.Text,
                                longitude.Text,
                                radius.Text,
                                types.Text
                            );
        try
        {
			HttpWebRequest webRequest = WebRequest.Create(requestUri) as HttpWebRequest;
			
            webRequest.Timeout = 20000;
            webRequest.Method = "GET";

            webRequest.BeginGetResponse(new AsyncCallback(RequestCompleted), webRequest);

            DataTable dataTable = new DataTable();
            dataTable.ReadXml(requestUri);
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    private void RequestCompleted(IAsyncResult result)
    {
        var request = (HttpWebRequest)result.AsyncState;
        var response = (HttpWebResponse)request.EndGetResponse(result);
        StringBuilder sb = new StringBuilder();
        using (var stream = response.GetResponseStream())
        {
            var r = new StreamReader(stream);
            var resp = r.ReadToEnd();
            feedback.InnerText = resp;
            sb.Append(resp);
        }
        RootObject rootObject = (RootObject) SerializationHelper.FromJson<RootObject>(sb.ToString());
        List<Result> resultWork = (List<Result>) rootObject.results;

        StringBuilder tell = new StringBuilder();

        foreach (Result resultEach in resultWork)
        {
            tell.AppendFormat
            (
                TellFormat,
                resultEach.geometry.location.lat,
                resultEach.geometry.location.lng,
                resultEach.name,
                resultEach.vicinity
            );
        }
        feedback.InnerText = tell.ToString();
    }

    public class Location
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class Geometry
    {
        public Location location { get; set; }
    }

    public class Result
    {
        public Geometry geometry { get; set; }
        public string icon { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public double rating { get; set; }
        public string reference { get; set; }
        public List<string> types { get; set; }
        public string vicinity { get; set; }
    }

    public class RootObject
    {
        public List<string> html_attributions { get; set; }
        public List<Result> results { get; set; }
        public string status { get; set; }
    }
}
