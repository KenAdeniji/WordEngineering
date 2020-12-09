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
	2014-01-29 http://english.stackexchange.com/questions/132423/word-or-phrase-for-the-beginning-or-end-of-an-event-or-period-of-time 
	Terminus (plural termini, if you want to be stuffy) is the Latin word for either end of a 1-dimensional extent, and specifically of motion along that dimension. If one uses a Time Is Linear Motion metaphor theme, and considers the timeline of an event, one can talk about the beginning as the terminus a quo 'the terminus from which', and the ending as the terminus ad quem 'the terminus toward which'. These are all established words and phrases in English. –  John Lawler Oct 21 '13 at 17:04 
	2014-09-04 from = from.Date; to = to.Date;
	2016-12-08 Created. Where I have trained; where I have followed. To query, as sum.
	2016-12-08 http://stackoverflow.com/questions/3155266/datatype-datetime-value-initialization	
*/
public partial class WhereIHaveTrainedWhereIHaveFollowedToQueryAsSum : System.Web.UI.Page
{
	protected DateTime Sum
	{
		set { sum.Text = value.Date.ToString("yyyy-MM-dd"); }
	}
		
    protected void Submit_Click(object sender, EventArgs e)
    {
        DateTime from;
        DateTime to;
        DateTime.TryParse(datedFrom.Text, out from);
		from = from.Date;
        DateTime.TryParse(datedTo.Text, out to);
		to = to.Date;
		
		DateTime start = default(DateTime);

        TimeSpan datedFromDifference = from.Subtract(start);
        TimeSpan datedToDifference = to.Subtract(start);
		
		DateTime sum = start.AddDays(datedFromDifference.TotalDays + datedToDifference.TotalDays);
		
		Sum = sum;
		
	}
}
