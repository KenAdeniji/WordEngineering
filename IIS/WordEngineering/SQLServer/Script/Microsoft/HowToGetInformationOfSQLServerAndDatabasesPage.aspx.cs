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

public partial class HowToGetInformationOfSQLServerAndDatabasesPage : System.Web.UI.Page
{
	public static DataSet ProcessSql()
	{
		DataSet dataSet = null;
		dataSet = (DataSet)Repository.DatabaseCommand
		(
			"usp_Microsoft_HowToGetInformationOfSQLServerAndDatabases",
			CommandType.StoredProcedure,
			Repository.ResultSet.DataSet
		);
		return dataSet;
	}

    protected void Page_Load(object sender, EventArgs e)
    {
		DataSet result = ProcessSql();
		
		versionOfSQLServer.DataSource = result.Tables[VersionOfSQLServer];
		versionOfSQLServer.DataBind();
		
		cpu.DataSource = result.Tables[CPU];
		cpu.DataBind();
		
		userDatabasesPath.DataSource = result.Tables[UserDatabasesPath];
		userDatabasesPath.DataBind();
		
		logFilesOfDatabases.DataSource = result.Tables[LogFilesOfDatabases];
		logFilesOfDatabases.DataBind();
	}
	
	public const int VersionOfSQLServer = 0;
	public const int CPU = 1;
	public const int UserDatabasesPath = 2;
	public const int LogFilesOfDatabases = 3;
}
