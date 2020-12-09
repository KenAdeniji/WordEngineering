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

#region MenuEditEventArgs definition
public class MenuEditEventArgs : EventArgs
{
}
#endregion

#region MenuEditEventHandler delegate declaration
public delegate void MenuEditEventHandler(object sender, MenuEditEventArgs e);
#endregion