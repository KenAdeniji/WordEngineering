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

#region MenuNewEventArgs definition
public class MenuNewEventArgs : EventArgs
{
}
#endregion

#region MenuNewEventHandler delegate declaration
public delegate void MenuNewEventHandler(object sender, MenuNewEventArgs e);
#endregion