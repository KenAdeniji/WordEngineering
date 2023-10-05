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

using System.Runtime.InteropServices;

/*
	2014-01-29 http://english.stackexchange.com/questions/132423/word-or-phrase-for-the-beginning-or-end-of-an-event-or-period-of-time 
	Terminus (plural termini, if you want to be stuffy) is the Latin word for either end of a 1-dimensional extent, and specifically of motion along that dimension. If one uses a Time Is Linear Motion metaphor theme, and considers the timeline of an event, one can talk about the beginning as the terminus a quo 'the terminus from which', and the ending as the terminus ad quem 'the terminus toward which'. These are all established words and phrases in English. –  John Lawler Oct 21 '13 at 17:04 
	2014-09-04 from = from.Date; to = to.Date;
*/
public partial class DateHandler : System.Web.UI.Page
{
	[DllImport
	(
		@"E:\WordEngineering\C++\PeopleAreNative\PeopleAreNative.dll",
		CallingConvention=CallingConvention.Cdecl
	)]
    public static extern int call_DateTimeHandler_dateDifference
	(
		int	fromYear,
		int	fromMonth,
		int	fromDay,	
		int	toYear,
		int	toMonth,
		int	toDay
	);
	
    protected void Submit_Click(object sender, EventArgs e)
    {
		DateTime from;
        DateTime to;
        DateTime.TryParse(datedFrom.Text, out from);
		from = from.Date;
        DateTime.TryParse(datedTo.Text, out to);
		to = to.Date;

		int days = call_DateTimeHandler_dateDifference
		(
			from.Year,
			from.Month,
			from.Day,
			to.Year,
			to.Month,
			to.Day
		);
		
		StringBuilder sb = new StringBuilder();
		
		sb.AppendFormat
		(
			"{0} ({1}) ({2})",
			Days(days),
			BiblicalCalendar(days),
			YearMonthWeekDay(from, to)
		);
		
		yearMonthWeekDay.Text = sb.ToString();
    }
	
	StringBuilder Days(int days)
	{
        StringBuilder sb = new StringBuilder();

		if (days > 0)
        {
            sb.AppendFormat
            (
                "{0} day{1}",
                days,
                days == 1 ? "" : "s"
            );
        }
		return sb;
	}

	StringBuilder BiblicalCalendar(int days)
	{
        int years = (int) (days / 360);
        int months = (int) ((days % 360) / 30);
        int day = (int) ((days % 360) % 30);

        StringBuilder sb = new StringBuilder();

		if (years > 0)
		{
            sb.AppendFormat
            (
                "{0} biblical year{1}", 
                years,
                years == 1 ? "" : "s"
            );
		}

		if (months > 0)
		{
            sb.AppendFormat
            (
                "{0}{1} biblical month{2}", 
				sb.Length == 0 ? "" : ", ",
                months,
                months == 1 ? "" : "s"
            );
		}

		if (day > 0)
		{
            sb.AppendFormat
            (
                "{0}{1} day{2}", 
				sb.Length == 0 ? "" : ", ",
                day,
                day == 1 ? "" : "s"
            );
		}
		
		return sb;
	}
	
	StringBuilder YearMonthWeekDay(DateTime dateFrom, DateTime dateTo)
	{
		DateTime 			dateCurrent = dateFrom;
		int					days = 0;
		int					weeks = 0;
		int					months = 0;
		int					years = 0;
		
		int					weekDays = 0;
		
		List<DaysInYears>	daysInYears = new List<DaysInYears>();
		
		while ( dateCurrent < dateTo )
		{
			int daysOffset = 365;
			if (DateTime.IsLeapYear(dateCurrent.Year))
			{
				daysOffset = 366;
			}
			if ( dateCurrent.AddDays( daysOffset ) > dateTo )
			{
				break;
			}
			dateCurrent = dateCurrent.AddDays( daysOffset );
			++years;
		}
		
		while ( dateCurrent < dateTo )
		{
			int currentMonth = dateCurrent.Month;
			int daysOffset = DaysInMonth[currentMonth - 1];
			if (DateTime.IsLeapYear(dateCurrent.Year) && currentMonth == 2)
			{
				daysOffset = 29;
			}
			if ( dateCurrent.AddDays( daysOffset ) > dateTo )
			{
				break;
			}
			dateCurrent = dateCurrent.AddDays( daysOffset );
			++months;
		}

		weekDays = (dateTo.Subtract(dateCurrent)).Days;
	
		weeks = (int) (weekDays / 7);

		days = weekDays % 7;
		
		StringBuilder sb = new StringBuilder();
		
		daysInYears.Add( new DaysInYears{ Metric = "year", Value = years } );
		daysInYears.Add( new DaysInYears{ Metric = "month", Value = months } );
		daysInYears.Add( new DaysInYears{ Metric = "week", Value = weeks } );
		daysInYears.Add( new DaysInYears{ Metric = "day", Value = days } );
		
		for (int index = 0, count = daysInYears.Count; index < count; ++index)
		{
            if (daysInYears[index].Value == 0) { continue; }
			sb.AppendFormat
            (
                "{0}{1} {2}{3}", 
				sb.Length == 0 ? "" : ", ",
				daysInYears[index].Value,
                daysInYears[index].Metric,
                daysInYears[index].Value == 1 ? "" : "s"
            );			
		}
		
		return sb;
	}
	//											  1	  2	  3	  4	  5	  6	  7,  8,  9  10, 11, 12	
	public static readonly int[] DaysInMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
	
	public class DaysInYears
	{
		public string 	Metric 	{ get; set; }
		public int 		Value	{ get; set; }
	}
}
