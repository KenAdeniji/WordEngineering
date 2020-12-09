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

#region UC_Contacts_ContactsList_SelectEventArgs definition
public class UC_Contacts_ContactsList_SelectEventArgs : EventArgs
{
    #region Fields
    private Int64 rowId;
    #endregion

    #region Constructors
    public UC_Contacts_ContactsList_SelectEventArgs(Int64 rowId)
    {
        this.rowId = rowId;
    }
    #endregion

    #region Properties
    public Int64 RowId
    {
        get { return rowId; }
    }
    #endregion
}
#endregion

#region UC_Contacts_ContactsList_SelectEventHandler delegate declaration
public delegate void UC_Contacts_ContactsList_SelectEventHandler(object sender, UC_Contacts_ContactsList_SelectEventArgs e);
#endregion