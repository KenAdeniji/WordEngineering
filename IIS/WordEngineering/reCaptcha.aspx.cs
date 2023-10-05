#region Using directives
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using InformationInTransit.ProcessLogic;
#endregion

#region Recaptcha definition
public partial class RecaptchaPage : System.Web.UI.Page
{
    #region Methods
	protected void Submit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
          feedBack.Text = "Captcha sucessfull!";
          feedBack.ForeColor = System.Drawing.Color.Green;
        }
        else
        {
          feedBack.Text = "Incorrect";
          feedBack.ForeColor = System.Drawing.Color.Red;
        }
    }
    #endregion
}
#endregion
