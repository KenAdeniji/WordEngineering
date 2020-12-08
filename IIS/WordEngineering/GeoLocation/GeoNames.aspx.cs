#region Using directives
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using System.Collections.Generic;
using System.Globalization;
using System.Text;
#endregion

#region WebServiceRequester_GeoNames
/// <summary>
/// 2014-04-23 Integrated username query string.
/// 2014-04-23 Request.IsLocal for web service address display.
/// </summary>
public partial class WebServiceRequester_GeoNames : System.Web.UI.Page
{
    #region Properties
    protected string Country
    {
        get { return country.Text.Trim(); }
    }

    protected string East
    {
        get { return east.Text.Trim(); }
    }

    protected string GeonameId
    {
        get { return geonameId.Text.Trim(); }
    }

    protected string Latitude
    {
        get { return latitude.Text.Trim(); }
    }

    protected string Longitude
    {
        get { return longitude.Text.Trim(); }
    }

    protected string MaximumRows
    {
        get { return maximumRows.Text.Trim(); }
    }

    protected string Name
    {
        get { return name.Text.Trim(); }
    }

    protected string North
    {
        get { return north.Text.Trim(); }
    }

    protected string Q
    {
        get { return q.Text.Trim(); }
    }

    protected string South
    {
        get { return south.Text.Trim(); }
    }

    protected string StartRow
    {
        get { return startRow.Text.Trim(); }
    }

    protected string WebServiceUri
    {
        get { return webServiceUri.Text.Trim(); }
        set 
        { 
            webServiceUri.NavigateUrl = value.Trim();
            webServiceUri.Text = value.Trim(); 
        }
    }

    protected string West
    {
        get { return west.Text.Trim(); }
    }
    #endregion

    #region Methods
    protected override void OnLoad(EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            webService.DataSource = WebServices;
            webService.DataBind();
            webService.SelectedValue = "search";
        }
    }

    protected string QueryKeyValue(string key, string value)
    {
        string queryKeyValue = "";
        if (!String.IsNullOrEmpty(value))
        {
            queryKeyValue = key + "=" + value + "&";
        }
        return queryKeyValue;
    }

    protected string QueryKeyValue(string key, string value, char[] separators)
    {
        StringBuilder sb = new StringBuilder();
        string[] values = value.Split(separators);
        foreach (string valueCurrent in values)
        {
            sb.Append(QueryKeyValue(key, valueCurrent));
        }
        return sb.ToString();
    }

    protected void QuerySubmit_Click(Object sender, EventArgs e)
    {
        string requestUri = GeonamesWebServiceUri + webService.SelectedValue + "?";
		string geoNamesUserName = ConfigurationManager.AppSettings["GeoNamesUserName"];
		requestUri += "username=" + geoNamesUserName + "&";
        switch (webService.SelectedValue)
        {
            case "children":
            case "hierarchy":
            case "neighbours":
            case "siblings":
                requestUri += QueryKeyValue("geonameId", GeonameId);
                break;

            case "cities":
            case "wikipediaBoundingBox":
                requestUri += 
                    QueryKeyValue("east", East) +
                    QueryKeyValue("north", North) +
                    QueryKeyValue("south", South) +
                    QueryKeyValue("west", West);
                break;

            case "countryCode":
            case "countrySubdivision":
            case "findNearby":
            case "findNearbyPlaceName":
            case "findNearbyWikipedia":
            case "srtm3":
            case "timezone":
                requestUri += 
                    QueryKeyValue("lat", Latitude) +
                    QueryKeyValue("lng", Longitude);
                break;
         
            case "search":
            case "wikipediaSearch":
                requestUri += QueryKeyValue("q", Q) +
                        QueryKeyValue("name", Name) +
                        QueryKeyValue("maxRows", MaximumRows) +
                        QueryKeyValue("startRow", StartRow) +
                        QueryKeyValue("country", Country, Separators)
                        ;
                break;
        }

        switch (webService.SelectedValue)
        {
            case "countryCode":
                requestUri += QueryKeyValue("type", "xml");
                break;
        }

        if (requestUri.EndsWith("&", true, CultureInfo.InvariantCulture))
        {
            requestUri = requestUri.Substring(0, requestUri.Length - 1);
        }

        if (Request.IsLocal)
		{
			WebServiceUri = requestUri;
		}	

        DataSet dataSet = new DataSet();

        try
        {
            dataSet.ReadXml(Server.HtmlEncode(requestUri));
            gridViewGeoNames.DataSource = dataSet.Tables[dataSet.Tables.Count - 1];
            gridViewGeoNames.DataBind();
        } 
        catch (Exception ex)
        {
            return;
        }
    }

    static WebServiceRequester_GeoNames()
    {
        WebServices = new Dictionary<string, string>();
        WebServices.Add("children", "Children");
        WebServices.Add("cities", "Cities");
        WebServices.Add("countryCode", "CountryCode");
        WebServices.Add("countryInfo", "CountryInfo");
        WebServices.Add("countrySubdivision", "Country Subdivision");
        //WebServices.Add("srtm3", "Elevation - SRTM3");
        WebServices.Add("findNearbyPlaceName", "Find nearby populated place");
        WebServices.Add("findNearby", "Find nearby toponym");
        WebServices.Add("findNearbyWikipedia", "Find nearby Wikipedia Entries");
        WebServices.Add("hierarchy", "Hierarchy");
        WebServices.Add("neighbours", "Neighbours");
        WebServices.Add("search", "Search");
        WebServices.Add("siblings", "Siblings");
        WebServices.Add("timezone", "Timezone");
        WebServices.Add("wikipediaBoundingBox", "Wikipedia Articles in Bounding Box");
        WebServices.Add("wikipediaSearch", "Wikipedia Fulltext Search");
    }        
    #endregion

    #region Statics
    private static char[] Separators = new char[] { ';', ',' };
    private const string GeonamesWebServiceUri = @"http://ws.geonames.org/";
    private static readonly Dictionary<string, string> WebServices;
    #endregion
}
#endregion