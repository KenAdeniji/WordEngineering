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

public partial class HowToCalculateTheIncreasingPercentageOfSalesEachMonthPage : System.Web.UI.Page
{
	public static DataSet ProcessSql()
	{
		DataSet dataSet = null;
		dataSet = (DataSet)Repository.DatabaseCommand
		(
			"usp_Microsoft_HowToCalculateTheIncreasingPercentageOfSalesEachMonth",
			CommandType.StoredProcedure,
			Repository.ResultSet.DataSet
		);
		return dataSet;
	}

    protected void Page_Load(object sender, EventArgs e)
    {
		DataSet result = ProcessSql();
		
		sampleData.DataSource = result.Tables[SampleData];
		sampleData.DataBind();
		
		resultSet.DataSource = result.Tables[ResultSet];
		resultSet.DataBind();
	}
	
	public const int SampleData = 0;
	public const int ResultSet = 1;
}
