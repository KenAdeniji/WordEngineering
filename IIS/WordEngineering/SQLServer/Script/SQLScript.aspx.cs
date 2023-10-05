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
2014-08-23 File created. 2014-08-21 DatabaseBestPractices.com. DropDownList value and text.
*/
public partial class SQLScript : System.Web.UI.Page
{
	protected String DropDownListSource
	{
		get
		{
			return dropDownListSource.SelectedItem.Value;
		}	
	}
	
	protected void GridViewSource_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = (DataTable)ViewState["gridViewSource"];
        if (dataTable != null)
        {
            gridViewSource.DataSource = dataTable;
            gridViewSource.Sort(e);
        }
	}

	protected void Page_Load(object sender, EventArgs e)
    {
		if ( !Page.IsPostBack )
		{
			dropDownListSource.DataSource = SourceList;
			dropDownListSource.DataTextField="Text";
			dropDownListSource.DataValueField="Value"; 			
			dropDownListSource.DataBind();
		}
	}
	
 	protected void Submit_Click(object sender, EventArgs e)
    {
		DataTable dataTable = (DataTable) Repository.DatabaseCommand
		(
			DropDownListSource,
			CommandType.StoredProcedure,
			Repository.ResultSet.DataTable
		);
		
		ViewState["gridViewSource"] = dataTable;
		gridViewSource.DataSource = dataTable;
		gridViewSource.DataBind();
    }
	
	public static readonly Script[] SourceList = { 
		new Script { Value = "usp_databasebestpractices_com_FindTotalAndFreeDiskSpace", Text = "Total and Free, Disk Space" },
		new Script { Value = "usp_databasebestpractices_com_SQLQueryConsumingHighCPU", Text = "SQL query consuming high CPU" },
		new Script { Value = "usp_NumberOfConnections", Text = "Number of Connections" },
	};

	public class Script
	{
		public string Value { get; set; }
		public string Text { get; set; }
	}	
}
