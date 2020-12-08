using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;

/// <summary> 
/// http://www.aspsnippets.com/Articles/Pass-multiple-records-rows-to-a-Stored-Procedure-in-SQL-Server-using-C-and-VBNet.aspx
/// </summary> 
public partial class AspSnippets_MudassarAhmedKhan_PassMultipleRecordsToStoredProcedure : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			DataSet ds = new DataSet();
			ds.ReadXml(Server.MapPath("~/ASP.NET/AspSnippets.com_MudassarAhmedKhan/Pass multiple records to Stored Procedure.xml"));
			GridView1.DataSource = ds.Tables[0];
			GridView1.DataBind();
		}
	}
	

	protected void Bulk_Insert(object sender, EventArgs e)
	{
		DataTable dt = new DataTable();
		dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Id", typeof(int)),
						new DataColumn("Name", typeof(string)),
						new DataColumn("Country",typeof(string)) });
		foreach (GridViewRow row in GridView1.Rows)
		{
			if ((row.FindControl("CheckBox1") as CheckBox).Checked)
			{
				int id = int.Parse(row.Cells[1].Text);
				string name = row.Cells[2].Text;
				string country = row.Cells[3].Text;
				dt.Rows.Add(id, name, country);
			}
		}
		if (dt.Rows.Count > 0)
		{
			string consString = ConfigurationManager.ConnectionStrings["WordEngineering"].ConnectionString;
			using (SqlConnection con = new SqlConnection(consString))
			{
				using (SqlCommand cmd = new SqlCommand("usp_AspSnippetsMudassarAhmedKhan_InsertCustomer"))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.Connection = con;
					cmd.Parameters.AddWithValue("@tblCustomer", dt);
					con.Open();
					cmd.ExecuteNonQuery();
					con.Close();
				}
			}
		}
	}
}
	

