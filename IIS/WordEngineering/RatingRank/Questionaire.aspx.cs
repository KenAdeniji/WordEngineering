using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;

public partial class Questionaire : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		if (Page.IsPostBack == false)
		{
			string sql = "SELECT TOP 1 * FROM RatingRank..Organization ORDER BY NewID()";
			SqlDataReader dataReader = (SqlDataReader) DataCommand.DatabaseCommand(sql);
		}
    }

    protected string Uri
    {
        get
        {
            return uri.Text.Trim();
        }
		set
		{
			uri.Text = value;
		}
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
    }
}
