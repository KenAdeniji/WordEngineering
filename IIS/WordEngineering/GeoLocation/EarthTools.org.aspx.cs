using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using InformationInTransit.ProcessLogic;

public partial class WebServiceRequester_EarthTools : System.Web.UI.Page
{
    public int DateDay
    {
        get { return System.Convert.ToInt32(dateDay.Text); }
        set { dateDay.Text = value.ToString(); }
    }

    public bool DateDaylightSavingTimeDST
    {
        get { return dateDaylightSavingTimeDST.Checked; }
        set { dateDaylightSavingTimeDST.Checked = value; }
    }

    public int DateMonth
    {
        get { return System.Convert.ToInt32(dateMonth.Text); }
        set { dateMonth.Text = value.ToString(); }
    }

    public int DateTimezone
    {
        get { return System.Convert.ToInt32(dateTimezone.Text); }
        set { dateTimezone.Text = value.ToString(); }
    }
        
    public string ElevationHeightAboveSeaLevelOutput
	{
        get { return elevationHeightAboveSeaLevelOutput.Text; }
        set { elevationHeightAboveSeaLevelOutput.Text = value; }
	}

    public decimal Latitude
	{
		get { return Convert.ToDecimal(latitude.Text); }
		set { latitude.Text = value.ToString(); }
	}

	public decimal Longitude
	{
		get { return Convert.ToDecimal(longitude.Text); }
		set { longitude.Text = value.ToString(); }
	}

    public string SunriseAndSunsetTimesOutput
	{
        get { return sunriseAndSunsetTimesOutput.Text; }
        set { sunriseAndSunsetTimesOutput.Text = value; }
	}

    public string TimeZoneOutput
	{
        get { return timezoneOutput.Text; }
        set { timezoneOutput.Text = value; }
	}

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) {
            Latitude = 37.550999M;
            Longitude = -122.077797M;
            DateDay = DateTime.Today.Day;
            DateMonth = DateTime.Today.Month;
            DateTimezone = 99;
            DateDaylightSavingTimeDST = true;
        }
        Processing();
    }
	
	protected void QuerySubmit_Click(Object sender, EventArgs e)
	{
		Processing();
	}
	
	protected void Processing()
	{
        EarthToolsHelper.TimeZoneContainer timeZone = new
            EarthToolsHelper.TimeZoneContainer();
        timeZone.Request(Latitude,Longitude);
        TimeZoneOutput = timeZone.ToString();

        EarthToolsHelper.SunriseAndSunsetTimesContainer sunriseAndSunsetTimes = new
            EarthToolsHelper.SunriseAndSunsetTimesContainer();
        sunriseAndSunsetTimes.Request
		(
			Latitude,
			Longitude,
            DateDay,
            DateMonth,
            DateTimezone,
            DateDaylightSavingTimeDST == true ? 1 : 0
		);
        SunriseAndSunsetTimesOutput = sunriseAndSunsetTimes.ToString();

        EarthToolsHelper.ElevationHeightAboveSeaLevelContainer elevationHeightAboveSeaLevel = new
            EarthToolsHelper.ElevationHeightAboveSeaLevelContainer();
        elevationHeightAboveSeaLevel.Request
		(
			Latitude,
			Longitude
		);
        ElevationHeightAboveSeaLevelOutput = elevationHeightAboveSeaLevel.ToString();
	}
}
