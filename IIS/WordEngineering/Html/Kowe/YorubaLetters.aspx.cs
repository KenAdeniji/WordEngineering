using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class YorubaLetters : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
		Response.Write(HttpUtility.HtmlEncode('\u00C0')); //192
		//1EB8;0300  
		Response.Write(HttpUtility.HtmlEncode("\u21B8"));
    }
}
