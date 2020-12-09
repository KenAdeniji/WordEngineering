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

#region MenuCancelEventArgs definition
public class MenuCancelEventArgs : EventArgs
{
}
#endregion

#region MenuCancelEventHandler delegate declaration
public delegate void MenuCancelEventHandler(object sender, MenuCancelEventArgs e);
#endregion