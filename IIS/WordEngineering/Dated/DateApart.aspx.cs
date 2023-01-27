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

public partial class DateApart : System.Web.UI.Page
{
	protected DateTime Dated
	{
		get
		{
			DateTime date = DateTime.Today;
			bool isDateTime = DateTime.TryParse(dated.Text, out date);
			return date;
		}
	}

	protected int Day
	{
		get
		{
			int day = 0;
			bool isInteger = Int32.TryParse(days.Text, out day);
			return day;
		}
	}
	
	protected String FeedBack
	{
		set
		{
			feedBack.Text = value;
		}
	}

	protected int Month
	{
		get
		{
			int month = 0;
			bool isInteger = Int32.TryParse(months.Text, out month);
			return month;
		}
	}
	
	protected int Year
	{
		get
		{
			int year = 0;
			bool isInteger = Int32.TryParse(years.Text, out year);
			return year;
		}
	}
	
    public DateTime BiblicalCalendar()
	{
		DateTime date = Dated.AddDays
		(
			(Year * 360) +
			(Month * 30) +
			Day
		);
		return date;
	}

    public DateTime JulianCalendar()
	{
		DateTime date = Dated.AddYears(Year);
		date = date.AddMonths(Month);
		date = date.AddDays(Day);
		return date;
	}
	
	protected void Submit_Click(object sender, EventArgs e)
    {
		FeedBack = String.Format
		(
			FeedBackFormat,
			BiblicalCalendar(),
			JulianCalendar()
		);
    }
	
	public const string FeedBackFormat = "Biblical calendar: {0:s}<br/>Gregorian calendar: {1:s}";
}
