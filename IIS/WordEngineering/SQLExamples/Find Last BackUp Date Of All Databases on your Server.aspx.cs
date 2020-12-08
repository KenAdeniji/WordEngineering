#region Using directives
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

using System.Data.SqlClient;

using InformationInTransit.DataAccess;
#endregion

#region SQLExamples_Find_Last_BackUp_Date_Of_All_Databases_on_your_Server definition
public partial class SQLExamples_Find_Last_BackUp_Date_Of_All_Databases_on_your_Server : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        IDataReader dataReader = (IDataReader)DataCommand.DatabaseCommand
        (
            "SELECT " +
            "T1.Name as DatabaseName, " +
            "COALESCE(Convert(varchar(12), MAX(T2.backup_finish_date), 101),'Not Yet Taken') as LastBackUpTaken, " +
            "COALESCE(Convert(varchar(12), MAX(T2.user_name), 101),'NA') as UserName " +
            "FROM sys.sysdatabases T1 LEFT OUTER JOIN msdb.dbo.backupset T2 " +
            "ON T2.database_name = T1.name " +
            "GROUP BY T1.Name " +
            "ORDER BY T1.Name",
            CommandType.Text,
            DataCommand.ResultType.DataReader
        );
        findLastBackUpDateOfAllDatabasesOnYourServer.DataSource = dataReader;
        findLastBackUpDateOfAllDatabasesOnYourServer.DataBind();
    }
}
#endregion