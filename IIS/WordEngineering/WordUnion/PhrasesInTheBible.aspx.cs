using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;

using InformationInTransit.DataAccess;
using InformationInTransit.UserInterface;

/*
2015-04-09 File created.
*/
public partial class PhrasesInTheBible : System.Web.UI.Page
{
	///<summary>
	///	GridView sort by column headings.
	///</summary>
	protected void GridViewPhrasesInTheBible_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = (DataTable)ViewState["gridViewPhrasesInTheBible"];
        if (dataTable != null)
        {
            gridViewPhrasesInTheBible.DataSource = dataTable;
            gridViewPhrasesInTheBible.Sort(e);
        }
	}

 	protected void Page_Load()
    {
		DataTable dataTable = (DataTable) Repository.DatabaseCommand
		(
			"SELECT * FROM WordEngineering..PhrasesInTheBible_view",
			CommandType.Text,
			Repository.ResultSet.DataTable
		);
		
		ViewState["gridViewPhrasesInTheBible"] = dataTable;
		gridViewPhrasesInTheBible.DataSource = dataTable;
		gridViewPhrasesInTheBible.DataBind();
    }
}

