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
	2015-06-10	Created.	ToMostExtentOfTalent.aspx.cs
	2015-09-14	Created.	NotOnlyMeIWillBeAsSome.cs
	2015-09-19	Created. 	NotOnlyMeIWillBeAsSome.html
*/
public partial class ToMostExtentOfTalent : System.Web.UI.Page
{
	protected void ToMostExtentOfTalentGridView_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = (DataTable)ViewState["toMostExtentOfTalentGridView"];
        if (dataTable != null)
        {
            toMostExtentOfTalentGridView.DataSource = dataTable;
            toMostExtentOfTalentGridView.Sort(e);
        }
    }

 	protected void Submit_Click(object sender, EventArgs e)
    {
		List<SqlParameter> sqlParameterCollection = new List<SqlParameter>();

		sqlParameterCollection.Add(new SqlParameter("@bibleWord", word.Text.Trim()));
		sqlParameterCollection.Add(new SqlParameter("@scriptureReference", scriptureReference.Text.Trim()));
		
		DataTable dataTable = (DataTable) Repository.DatabaseCommand
		(
			"Bible..usp_ToMostExtentOfTalentSelect",
			CommandType.StoredProcedure,
			Repository.ResultSet.DataTable,
			sqlParameterCollection
		);
		
		ViewState["toMostExtentOfTalentGridView"] = dataTable;
		toMostExtentOfTalentGridView.DataSource = dataTable;
		toMostExtentOfTalentGridView.DataBind();
    }
}
