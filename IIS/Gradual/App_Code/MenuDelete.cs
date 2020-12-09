#region Using directives
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
#endregion

#region MenuDeleteEventArgs definition
public class MenuDeleteEventArgs : EventArgs
{
}
#endregion

#region MenuDeleteEventHandler delegate declaration
public delegate void MenuDeleteEventHandler(object sender, MenuDeleteEventArgs e);
#endregion