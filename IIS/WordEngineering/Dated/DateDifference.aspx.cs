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
using System.Data.Linq;	
using System.Text;

using InformationInTransit.ProcessCode;

/*
	2014-01-29 	http://english.stackexchange.com/questions/132423/word-or-phrase-for-the-beginning-or-end-of-an-event-or-period-of-time 
	Terminus (plural termini, if you want to be stuffy) is the Latin word for either end of a 1-dimensional extent, and specifically of motion along that dimension. If one uses a Time Is Linear Motion metaphor theme, and considers the timeline of an event, one can talk about the beginning as the terminus a quo 'the terminus from which', and the ending as the terminus ad quem 'the terminus toward which'. These are all established words and phrases in English. –  John Lawler Oct 21 '13 at 17:04 
	2014-09-04 	from = from.Date; to = to.Date;
	2015-12-09 Gregorian Calendar. DateDifference.cs YearMonthWeekDay.
	2018-10-25	Instead of incrementing counter, DateDifference extract DatePart.
	2018-10-25	http://www.pressthered.com/datediff_equivalent_in_c_-_3_options/
	2018-10-25	From 2008-06-29 Until 2018-10-25.
				3770 days (10 biblical years, 5 biblical months, 20 days) (10 years, 3 months, 3 weeks, 4 days) (10 years, 4 months, -4 days)
				
*/
public partial class DateDifference : System.Web.UI.Page
{
    protected void Submit_Click(object sender, EventArgs e)
    {
        DateTime from;
        DateTime to;
        DateTime.TryParse(datedFrom.Text, out from);
		from = from.Date;
        DateTime.TryParse(datedTo.Text, out to);
		to = to.Date;
        TimeSpan dateDifference = to.Subtract(from);
		
		if (dateDifference.Days < 0) { yearMonthWeekDay.Text = ""; return; }
		
		StringBuilder sb = new StringBuilder();
		
		sb.AppendFormat
		(
			"{0} ({1}) ({2})",
			InformationInTransit.ProcessCode.DateDifferenceHelper.Days(dateDifference),
			InformationInTransit.ProcessCode.DateDifferenceHelper.BiblicalCalendar(dateDifference),
			InformationInTransit.ProcessCode.DateDifferenceHelper.YearMonthWeekDay(from, to)
			//,InformationInTransit.ProcessCode.DateDifferenceHelper.GregorianCalendar(from, to)
		);
		
		yearMonthWeekDay.Text = sb.ToString();
    }
}
