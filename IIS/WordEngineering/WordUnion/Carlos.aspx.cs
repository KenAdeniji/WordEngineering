using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;

using InformationInTransit.DataAccess;
using InformationInTransit.UserInterface;

public partial class Carlos : System.Web.UI.Page
{
	protected String Question
	{
		get
		{
			return question.Text.Trim();
		}	
	}

	protected String AccordingTo
	{
		get
		{
			return accordingTo.SelectedValue;
		}	
	}

	protected void ExactGridView_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = (DataTable)ViewState["exactGridView"];
        if (dataTable != null)
        {
            exactGridView.DataSource = dataTable;
            exactGridView.Sort(e);
        }
    }

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			accordingTo.DataSource = AccordingTos;
			accordingTo.DataBind();
		}
	}
	
 	protected void Submit_Click(object sender, EventArgs e)
    {
		List<OdbcParameter> odbcParameterCollection = new List<OdbcParameter>();

		odbcParameterCollection.Add(new OdbcParameter("@question", Question));
		odbcParameterCollection.Add(new OdbcParameter("@accordingTo", @AccordingTo));
		
		DataTable dataTable = (DataTable) DataCommand.DatabaseCommand
		(
			"Bible..usp_Carlos '{0}', '{1}'",
			CommandType.StoredProcedure,
			DataCommand.ResultType.DataTable //,
			//odbcParameterCollection
		);
		
		ViewState["exactGridView"] = dataTable;
		exactGridView.DataSource = dataTable;
		exactGridView.DataBind();
    }
	
	public static readonly string[] AccordingTos = {
		"Length",
		"Soundex"
	};
}
