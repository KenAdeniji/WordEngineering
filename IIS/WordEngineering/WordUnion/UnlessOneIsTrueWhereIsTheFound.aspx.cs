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

using System.Text.RegularExpressions;

using InformationInTransit.ProcessLogic;

/*
	2017-04-23	Unless one is true; where is the found?
*/
public partial class UnlessOneIsTrueWhereIsTheFoundPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if (!Page.IsPostBack)
		{
			datedFrom.Text = "2007-04-21";
			duration.Text = "9 years, 9 months, 3 days";
			Query();
		}		
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
		Query();
    }
	
	protected void Query()
	{
		DateTime datetime;
        DateTime.TryParse(datedFrom.Text, out datetime);
		
		datedTo.Text = DateDifference.UnlessOneIsTrueWhereIsTheFound(datetime, duration.Text).ToString();
	}
	
	public static readonly string[] CalendarUnits = { "year", "month", "week", "day" };

	public static readonly char[] Separators = { ',', ';' };
}
