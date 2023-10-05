using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using InformationInTransit.ProcessLogic;

namespace WordEngineering
{
    public partial class TwitterRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                screen_name.Text = "twitterapi";
            }
        }

        protected void QueryRequest_Click(object sender, EventArgs e)
        {
            resultSet.Text = TwitterHelper.Process(screen_name.Text);
        }
    }
}