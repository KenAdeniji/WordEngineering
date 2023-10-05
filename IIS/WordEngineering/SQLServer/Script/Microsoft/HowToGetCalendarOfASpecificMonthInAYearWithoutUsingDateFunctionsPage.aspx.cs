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
using System.Data.SqlClient;
using System.Text;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;

/*
	2014-08-25 Created http://gallery.technet.microsoft.com/scriptcenter/How-to-get-calendar-of-a-02255755
*/
public partial class HowToGetCalendarOfASpecificMonthInAYearWithoutUsingDateFunctionsPage : System.Web.UI.Page
{
	protected int Month
	{
		get
		{
			int monthNumeric = -1;
			bool validNumber = Int32.TryParse(month.Text, out monthNumeric);
			return monthNumeric;
		}
		set { month.Text = value.ToString(); }
	}

	protected int Year
	{
		get
		{
			int yearNumeric = -1;
			bool validNumber = Int32.TryParse(year.Text, out yearNumeric);
			return yearNumeric;
		}
		set { year.Text = value.ToString(); }
	}

    protected void Page_Load(object sender, EventArgs e)
    {
		if (!Page.IsPostBack)
		{
			string queryString = Request.QueryString["Year"];
			if (!String.IsNullOrEmpty(queryString))
			{
				queryString = System.Web.HttpUtility.HtmlDecode(queryString);
				Year = Convert.ToInt32(queryString);
			}
			else
			{
				Year = DateTime.Today.Year;
			}
			queryString = Request.QueryString["Month"];
			if (!String.IsNullOrEmpty(queryString))
			{
				queryString = System.Web.HttpUtility.HtmlDecode(queryString);
				Month = Convert.ToInt32(queryString);
			}
			else
			{
				Month = DateTime.Today.Month;
			}
			ProcessSql();
		}
	}

    protected void Query_Click(object sender, EventArgs e)
    {
		ProcessSql();
	}
	
	public void ProcessSql()
	{
		List<SqlParameter> sqlParameterCollection = new List<SqlParameter>();
		
		if (Year > -1)
		{
			sqlParameterCollection.Add(new SqlParameter("@year", Year));
		}

		if (Month > -1)
		{	
			sqlParameterCollection.Add(new SqlParameter("@month", Month));
		}	
		
		DataSet dataSet = null;
		dataSet = (DataSet)Repository.DatabaseCommand
		(
			"usp_Microsoft_MonthCalendarWithoutDateFunctions",
			CommandType.StoredProcedure,
			Repository.ResultSet.DataSet,
			sqlParameterCollection
		);

		resultSet.DataSource = dataSet.Tables[ResultSet];
		resultSet.DataBind();
	}
	public const int ResultSet = 0;
}
