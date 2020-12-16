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

using UserInterface;
#endregion

#region Membership_Login definition
public partial class Membership_Login : System.Web.UI.Page
{
    #region Methods
    protected void DefaultControl()
    {
        if (!Page.IsPostBack)
        {
            TextBox userName = (TextBox)Login1.FindControl("UserName");
            if (userName != null)
            {
                Page.Form.DefaultFocus = userName.ClientID;
            }
        }
    }

    protected override void OnLoad(EventArgs e)
    {
        HtmlLinkHelper.AddStyleSheet(@"Standard\StyleSheet.css");
        DefaultControl();
        base.OnLoad(e);
    }
    #endregion
}
#endregion