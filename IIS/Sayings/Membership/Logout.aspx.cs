#region Using directives
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
#endregion

#region Membership_Logout definition
public partial class Membership_Logout : System.Web.UI.Page
{
    #region Methods
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Abandon();
        FormsAuthentication.SignOut();
    }
    #endregion
}
#endregion