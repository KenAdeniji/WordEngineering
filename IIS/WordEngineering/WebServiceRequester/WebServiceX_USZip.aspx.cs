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

using net.webservicex.www;

/// <summary>
/// http://www.webservicex.net/uszip.asmx?wsdl
/// </summary>
public partial class WebServiceRequester_WebServiceX_USZip : System.Web.UI.Page
{
	public static string[] Operations = new string[]
						{
							"Area Code",
							"City",
							"State",
							"Zip"	
						};

    protected void Page_Load(object sender, EventArgs e)
    {
	    if (!Page.IsPostBack)
	    {
		    operation.DataSource = Operations;
		    operation.DataBind();
	    }
    }
	
    protected void SubmitQuery_Click(object sender, EventArgs e)
    {
        USZip usZip = new USZip();
	/*
        gridView.DataSource = usZip.GetInfoByAreaCode("510");
        gridView.DataBind();
	*/
	    XmlNode xmlNodeOriginal = null;
	    switch(operation.SelectedItem.Text)
	    {
		    case "Area Code": 
			    xmlNodeOriginal = usZip.GetInfoByAreaCode(entry.Text);
			    break;

		    case "City":
			    xmlNodeOriginal = usZip.GetInfoByCity(entry.Text);
			    break;

		    case "State": 
			    xmlNodeOriginal = usZip.GetInfoByState(entry.Text);
			    break;

		    case "Zip":
			    xmlNodeOriginal = usZip.GetInfoByZIP(entry.Text);
			    break;
	    }

	    XmlDocument xmlDocument = new XmlDocument();
	    XmlNode newDocument = xmlDocument.ImportNode(xmlNodeOriginal, true);
        xmlDocument.AppendChild(newDocument);
	    XmlNode documentElement = xmlDocument.DocumentElement;

	    XmlNodeList xmlNodeList = documentElement.SelectNodes("Table/CITY");
	    List<string> cities = new List<string>();
	    foreach(XmlNode xmlNode in xmlNodeList)
	    {
		    cities.Add(xmlNode.InnerText);
	    }

	    xmlNodeList = documentElement.SelectNodes("Table/STATE");
	    List<string> states = new List<string>();
	    foreach(XmlNode xmlNode in xmlNodeList)
	    {
		    states.Add(xmlNode.InnerText);
	    }

	    xmlNodeList = documentElement.SelectNodes("Table/ZIP");
	    List<int> zip = new List<int>();
	    foreach(XmlNode xmlNode in xmlNodeList)
	    {
		    zip.Add(Convert.ToInt32(xmlNode.InnerText));
	    }

	    xmlNodeList = documentElement.SelectNodes("Table/AREA_CODE");
	    List<int> areaCode = new List<int>();
	    foreach(XmlNode xmlNode in xmlNodeList)
	    {
		    areaCode.Add(Convert.ToInt32(xmlNode.InnerText));
	    }

	    xmlNodeList = documentElement.SelectNodes("Table/TIME_ZONE");
	    List<string> timeZones = new List<string>();
	    foreach(XmlNode xmlNode in xmlNodeList)
	    {
		    timeZones.Add(xmlNode.InnerText);
	    }

	    List<ResultSet> resultSetList = new List<ResultSet>();
	    for (int index = 0; index < cities.Count; ++index)
	    {
		    resultSetList.Add
		    ( 
			    new ResultSet
			    { 		
				    City = cities[index],
				    State = states[index],
				    Zip = zip[index],
				    AreaCode = areaCode[index],
				    TimeZone = timeZones[index]
			    }
		    );		
	    }
        gridView.DataSource = resultSetList;
        gridView.DataBind();
    }
}

partial class ResultSet
{
	public string City { get; set; }
	public string State { get; set; }
	public int Zip { get; set; }
	public int AreaCode { get; set; }
	public string TimeZone { get; set; }
}



