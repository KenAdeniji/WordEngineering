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

using System.Text;
public partial class BiblicalCalendar : System.Web.UI.Page
{
    protected void Submit_Click(object sender, EventArgs e)
    {
        Boolean needSeparator = false;
        DateTime from;
        DateTime to;
        DateTime.TryParse(datedFrom.Text, out from);
        DateTime.TryParse(datedTo.Text, out to);
        TimeSpan dateDifference = to.Subtract(from);
        int years = (int) (dateDifference.Days / 360);
        int months = (int) ((dateDifference.Days % 360) / 30);
        int days = (int) ((dateDifference.Days % 360) % 30);

        StringBuilder sb = new StringBuilder();

        if (dateDifference.Days > 0)
        {
            sb.AppendFormat
            (
                "{0} day{1} (",
                dateDifference.Days,
                dateDifference.Days == 1 ? "" : "s"
            );
        }

        if (years > 0) 
        { 
            sb.AppendFormat
            (
                "{0} biblical year{1}", 
                years,
                years == 1 ? "" : "s"
            );
            needSeparator = true;
        }
        if (months > 0) 
        {
            if (needSeparator) { sb.Append(", "); needSeparator = false; };
            sb.AppendFormat
            (
                "{0} biblical month{1}",
                months,
                months == 1 ? "" : "s"
            );
            needSeparator = true;
        }
        if (days > 0)
        {
            if (needSeparator) { sb.Append(", "); needSeparator = false; };
            sb.AppendFormat
            (
                "{0} day{1}",
                days,
                days == 1 ? "" : "s"
            ); 
        }

        if (dateDifference.Days > 0)
        {
            sb.Append(')');
        }

        yearMonthDay.Text = sb.ToString();
    }
}
