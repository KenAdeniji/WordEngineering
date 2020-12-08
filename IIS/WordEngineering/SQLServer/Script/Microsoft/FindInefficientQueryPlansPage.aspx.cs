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

public partial class FindInefficientQueryPlansPage : System.Web.UI.Page
{
	public static DataSet ProcessSql()
	{
		DataSet dataSet = null;
		dataSet = (DataSet)Repository.DatabaseCommand
		(
			"usp_Microsoft_PedroLopes_FindInefficientQueryPlans",
			CommandType.StoredProcedure,
			Repository.ResultSet.DataSet
		);
		return dataSet;
	}

    protected void Page_Load(object sender, EventArgs e)
    {
		DataSet result = ProcessSql();
		
		uptime_Information.DataSource = result.Tables[Uptime_Information];
		uptime_Information.DataBind();
		
		overallByTotalCPUTime.DataSource = result.Tables[OverallByTotalCPUTime];
		overallByTotalCPUTime.DataBind();

		overallByAverageCPUTimePerExec.DataSource = result.Tables[OverallByAverageCPUTimePerExec];
		overallByAverageCPUTimePerExec.DataBind();

		overallByTotalReadIOs.DataSource = result.Tables[OverallByTotalReadIOs];
		overallByTotalReadIOs.DataBind();

		overallByAverageReadIOsPerExec.DataSource = result.Tables[OverallByAverageReadIOsPerExec];
		overallByAverageReadIOsPerExec.DataBind();
		
		overallByTotalRecompiles.DataSource = result.Tables[OverallByTotalRecompiles];
		overallByTotalRecompiles.DataBind();
		
		overallByAverageRecompilesPerExec.DataSource = result.Tables[OverallByAverageRecompilesPerExec];
		overallByAverageRecompilesPerExec.DataBind();

		overallMostExecutions.DataSource = result.Tables[OverallMostExecutions];
		overallMostExecutions.DataBind();
	}
	
	public const int Uptime_Information = 0;
	public const int OverallByTotalCPUTime = 1;
	public const int OverallByAverageCPUTimePerExec = 2;
	public const int OverallByTotalReadIOs = 3;
	public const int OverallByAverageReadIOsPerExec = 4;
	public const int OverallByTotalRecompiles = 5;
	public const int OverallByAverageRecompilesPerExec = 6;
	public const int OverallMostExecutions = 7;
}
