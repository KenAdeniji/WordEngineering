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
using System.Text;

/*
		2018-05-11	To carry someone.
		2018-05-13	Created. Javascript version. For a given time of the day, determine the time in between?		
		2018-05-16	Created. C# .NET version. For a given time of the day, determine the time in between?
*/
public partial class ToCarrySomeone : System.Web.UI.Page
{
    protected void Submit_Click(object sender, EventArgs e)
    {
		Compute();
	}

	public void Compute()
	{
		DateTime from;
        DateTime to;
		
        DateTime.TryParse(datedFrom.Text, out from);
		from = from.Date;
        DateTime.TryParse(datedTo.Text, out to);
		to = to.Date;
        TimeSpan dateDifference = to.Subtract(from);
		
		if (dateDifference.Days < 0)
		{
			daysTotal.Text = "";
			return; 
		}
		
		daysTotal.Text = dateDifference.Days.ToString();
		ParseTime();
    }
	
	public void ParseTime()
	{
		String timeUnit = timed.Text.Trim();
		feedback.Text = "Time all: " + timeUnit;
		int timesSeparator = timeUnit.IndexOf(":");
		if (timesSeparator < 0)
		{
			return;
		}
		string hours = timeUnit.Substring(0, timesSeparator);
		feedback.Text += " Hours: " + hours;
		int hour = Convert.ToInt32(hours);
		string minutes = timeUnit.Substring(timesSeparator + 1);
		feedback.Text += " Minute: " + minutes;
		if (minutes == "")
		{
			return;
		}
		int minute = Convert.ToInt32(minutes);
		int hourMinute = (hour * 60) + minute;
		feedback.Text += " Hour Minute: " + hourMinute.ToString();
		float ratio = hourMinute / (24 * 60);
		feedback.Text += " ratio: " + ratio.ToString();
		timedPercentage.Text = ratio.ToString();
    }
}
