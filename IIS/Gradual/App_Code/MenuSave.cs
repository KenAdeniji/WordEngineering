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

#region MenuSaveEventArgs definition
public class MenuSaveEventArgs : EventArgs
{
}
#endregion

#region MenuSaveEventHandler delegate declaration
public delegate void MenuSaveEventHandler(object sender, MenuSaveEventArgs e);
#endregion