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
	2014-10-08 Created.
*/
public partial class BibleBook : System.Web.UI.Page
{
	public void Page_Load(object sender, EventArgs e)
	{
		DataTable dataTable = (DataTable) Repository.DatabaseCommand
		(
			"SELECT * FROM Bible..BibleBook ORDER BY BookId",
			CommandType.Text,
			Repository.ResultSet.DataTable
		);
		
		bibleBooks.DataSource = dataTable;
		bibleBooks.DataBind();
	}
}
