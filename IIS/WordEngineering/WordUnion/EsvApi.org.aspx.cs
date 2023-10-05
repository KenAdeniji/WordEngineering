using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;

using InformationInTransit.ProcessLogic;

/*
2015-06-14 File created.
*/
public partial class EsvApi : System.Web.UI.Page
{
	protected String Query
	{
		get
		{
			return query.Text;
		}	
	}

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            query.Text = "Matthew 5";
            Retrieve();
        }
    }

    protected void Submit_Click(object sender, EventArgs e)
    {
		Retrieve();
    }
	
 	protected void Retrieve()
    {
        String textualForm = EsvApiHelper.PassageQuery(Query);
        feedback.Text = textualForm;
    }
}
