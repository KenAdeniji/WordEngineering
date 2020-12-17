using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text;

namespace Lab_Assignment_5
{
    public partial class SitePersonalWebsite : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DateService.DateServiceClient date = new DateService.DateServiceClient();
            string today = date.Today();
            date.Close();

            nameWcfDate.InnerText = "Kehinde Adeniji " +
                                //new StringBuilder().Insert(0, "&nbsp;", 50).ToString() +
                                today;
        }
             
    }
}