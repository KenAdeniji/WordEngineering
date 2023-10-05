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
2015-03-09 File created.
*/
public partial class RelatedVerses : System.Web.UI.Page
{
	protected String Alike
	{
		get
		{
			return alike.Text;
		}	
	}

	protected String ScriptureReference
	{
		get
		{
			return scriptureReference.Text;
		}	
	}
	
	protected void GridViewRelatedVerses_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = (DataTable)ViewState["gridViewRelatedVerses"];
        if (dataTable != null)
        {
            gridViewRelatedVerses.DataSource = dataTable;
            gridViewRelatedVerses.Sort(e);
        }
	}

 	protected void Submit_Click(object sender, EventArgs e)
    {
		List<SqlParameter> sqlParameterCollection = new List<SqlParameter>();

		sqlParameterCollection.Add(new SqlParameter("@scriptureReference", ScriptureReference));
		sqlParameterCollection.Add(new SqlParameter("@alike", Alike));

		DataTable dataTable = (DataTable) Repository.DatabaseCommand
		(
			"Bible..usp_RelatedVersesSelect",
			CommandType.StoredProcedure,
			Repository.ResultSet.DataTable,
			sqlParameterCollection
		);
		
		ViewState["gridViewRelatedVerses"] = dataTable;
		gridViewRelatedVerses.DataSource = dataTable;
		gridViewRelatedVerses.DataBind();
    }
}



