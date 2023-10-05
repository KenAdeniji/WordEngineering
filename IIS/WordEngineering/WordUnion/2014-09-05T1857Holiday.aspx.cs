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
	2014-09-05 Created.
*/
public partial class Holiday : System.Web.UI.Page
{
	protected DateTime? DatedFrom
	{
		get
		{
			DateTime temp = new DateTime(1753, 1, 1);
			bool isDate = DateTime.TryParse( datedFrom.Text, out temp);
			if (isDate)
			{
				return temp;
			}
			else
			{
				return null;
			}	
		}	
	}

	protected DateTime? DatedUntil
	{
		get
		{
			DateTime temp = new DateTime(9999, 12, 31);
			bool isDate = DateTime.TryParse( datedFrom.Text, out temp);
			if (isDate)
			{
				return temp;
			}
			else
			{
				return null;
			}	
		}	
	}
	
	protected void HolidayGridView_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = (DataTable)ViewState["holidayGridView"];
        if (dataTable != null)
        {
            holidayGridView.DataSource = dataTable;
            holidayGridView.Sort(e);
        }
	}

 	protected void Submit_Click(object sender, EventArgs e)
    {
		List<SqlParameter> sqlParameterCollection = new List<SqlParameter>();

		sqlParameterCollection.Add(new SqlParameter("@datedFrom", DatedFrom));
		sqlParameterCollection.Add(new SqlParameter("@datedUntil", DatedUntil));
		sqlParameterCollection.Add(new SqlParameter("@day", day.Text));
		sqlParameterCollection.Add(new SqlParameter("@word", word.Text));

		DataTable dataTable = (DataTable) Repository.DatabaseCommand
		(
			"usp_HolidaySelect",
			CommandType.StoredProcedure,
			Repository.ResultSet.DataTable,
			sqlParameterCollection
		);
		
		ViewState["holidayGridView"] = dataTable;
		holidayGridView.DataSource = dataTable;
		holidayGridView.DataBind();
    }
}
