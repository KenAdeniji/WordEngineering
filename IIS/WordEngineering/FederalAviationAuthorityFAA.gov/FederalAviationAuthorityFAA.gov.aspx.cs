using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using InformationInTransit.ProcessLogic;

public partial class FederalAviationAuthorityFAA : System.Web.UI.Page
{
    public string IataCode
	{
        get { return iataCode.Text; }
        set { iataCode.Text = value; }
	}

    public string AirportStatusOutput
	{
        get { return airportStatusOutput.Text; }
        set { airportStatusOutput.Text = value; }
	}

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) {
            IataCode = "SFO";
        }
        Processing();
    }
	
	protected void QuerySubmit_Click(Object sender, EventArgs e)
	{
		Processing();
	}
	
	protected void Processing()
	{
		FederalAviationAuthorityFAAHelper.AirportStatusContainer airportStatus = new FederalAviationAuthorityFAAHelper.AirportStatusContainer();
		airportStatus.Request(IataCode);
		AirportStatusOutput = airportStatus.ToString();
	}
}
