using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using InformationInTransit.ProcessLogic;

public partial class WebServiceRequester_HostIpInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HostIpLocationInfo hostIpLocationInfo = HostIpInfoHelper.GetLocationInfo();
        latitude.Text = hostIpLocationInfo.Latitude.ToString();
        longitude.Text = hostIpLocationInfo.Longitude.ToString();
        countryName.Text = hostIpLocationInfo.CountryName.ToString();
        countryCode.Text = hostIpLocationInfo.CountryCode.ToString();
        suburb.Text = hostIpLocationInfo.Name.ToString();
    }
}

