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

public partial class HisWord : System.Web.UI.Page
{
	protected Int32? ContactId
	{
		get
		{
			Int32 temp = -1;
			bool isNumber = Int32.TryParse( contactId.Text, out temp);
			if (isNumber)
			{
				return temp;
			}
			else
			{
				return null;
			}	
		}	
	}

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
	
	protected void HisWordGridView_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = (DataTable)ViewState["hisWordGridView"];
        if (dataTable != null)
        {
            hisWordGridView.DataSource = dataTable;
            hisWordGridView.Sort(e);
        }
	}

 	protected void Submit_Click(object sender, EventArgs e)
    {
		List<SqlParameter> sqlParameterCollection = new List<SqlParameter>();

		sqlParameterCollection.Add(new SqlParameter("@word", word.Text));
		sqlParameterCollection.Add(new SqlParameter("@commentary", commentary.Text));
		sqlParameterCollection.Add(new SqlParameter("@datedFrom", DatedFrom));
		sqlParameterCollection.Add(new SqlParameter("@datedUntil", DatedUntil));		
		sqlParameterCollection.Add(new SqlParameter("@contactId", ContactId));

		DataTable dataTable = (DataTable) Repository.DatabaseCommand
		(
			"usp_HisWordSelect",
			CommandType.StoredProcedure,
			Repository.ResultSet.DataTable,
			sqlParameterCollection
		);
		
		ViewState["hisWordGridView"] = dataTable;
		hisWordGridView.DataSource = dataTable;
		hisWordGridView.DataBind();
    }
}
