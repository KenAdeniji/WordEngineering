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
namespace WordEngineering
{
	/*
		2016-05-28	Created.	DateCompute.aspx.cs
	*/
	public partial class DateCompute : System.Web.UI.Page
	{
		protected void Submit_Click(object sender, EventArgs e)
		{
			DateTime from;
			DateTime to;
			
			Int32	yearsPart;
			Int32	monthsPart;
			Int32	weeksPart;
			Int32	daysPart;
			
			DateTime.TryParse(datedFrom.Text, out from);
			Int32.TryParse(years.Text, out yearsPart);
			Int32.TryParse(months.Text, out monthsPart);
			Int32.TryParse(weeks.Text, out weeksPart);
			Int32.TryParse(days.Text, out daysPart);
			
			DateTime	compute = from;
			compute = compute.AddYears(yearsPart);
			compute = compute.AddMonths(monthsPart);
			compute = compute.AddDays(weeksPart * 7);
			compute = compute.AddDays(daysPart);
				 
			datedTo.Text = compute.ToString("s");
		}
	}
}
