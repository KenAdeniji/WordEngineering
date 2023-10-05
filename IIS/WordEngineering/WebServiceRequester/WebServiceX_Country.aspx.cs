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
using System.Xml;

//using net.webservicex.www;

/// <summary>
/// http://www.webservicex.net/country.asmx?WSDL
/// </summary>
public partial class WebServiceRequester_WebServiceX_Country : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /*
        var service = new net.webservicex.www.country();
        var xml = service.GetCountries();
        var countries = XDocument.Parse(xml).Descendants("Name").Select(arg => arg.Value).ToList();
        gridView.DataSource = countries;
        gridView.DataBind();
        */

        DataSet dataSet = new DataSet();

        try
        {
            dataSet.ReadXml(Server.HtmlEncode("http://www.webservicex.net/country.asmx/GetCountries"));
            //gridView.DataSource = dataSet;
            gridView.DataBind();
        } 
        catch (Exception ex)
        {
            return;
        }
    }
}

