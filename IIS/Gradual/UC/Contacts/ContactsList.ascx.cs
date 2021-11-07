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

using System.ComponentModel;
using System.Data.SqlClient;
using System.Text;

using InformationInTransit.UserInterface;

namespace WordEngineering
{
    public partial class UC_Contacts_ContactsList : System.Web.UI.UserControl
    {
        public DataSet ContactSet
        {
            set
            {
                GridViewContact.DataSource = value;
                GridViewContact.DataBind();
                ViewState["GridViewContact"] = value;
                if (value != null)
				{	
                    GridViewContact.SelectedIndex = 0;
				}	
            }
        }

        protected void GridView_PageIndexChanged(Object sender, EventArgs e)
        {
            GridView gridViewSender = (GridView)sender;
            GridViewContact.SelectedIndex = 0;
            Int64 contactId = Convert.ToInt64(gridViewSender.DataKeys[0].Value);
            UC_Contacts_ContactsList_SelectEventArgs selectEventArgs = new UC_Contacts_ContactsList_SelectEventArgs(contactId);
            OnSelect(selectEventArgs);
        }

        protected void GridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView gridView = (GridView)sender;
            gridView.DataSource = ViewState["GridViewContact"];
            gridView.PageIndexChange(e);
        }

        public void ItemTemplateNicknameOrFullname_Click(object sender, EventArgs e)
        {
            LinkButton itemTemplateFullName = (LinkButton)sender;
            GridViewRow gridViewRow = (GridViewRow)itemTemplateFullName.NamingContainer;
            GridViewContact.SelectedIndex = gridViewRow.RowIndex;
            Int64 rowId = Convert.ToInt64(GridViewContact.DataKeys[gridViewRow.RowIndex].Value);

            UC_Contacts_ContactsList_SelectEventArgs selectEventArgs = new UC_Contacts_ContactsList_SelectEventArgs(rowId);
            OnSelect(selectEventArgs);
        }

        // The event member that is of type UC_Contacts_ContactsList_SelectEventHandler.
        public event UC_Contacts_ContactsList_SelectEventHandler Select;

        // The protected OnSelect method raises the event by invoking 
        // the delegates. The sender is always this, the current instance 
        // of the class.
        protected virtual void OnSelect(UC_Contacts_ContactsList_SelectEventArgs e)
        {
            UC_Contacts_ContactsList_SelectEventHandler handler = Select;
            if (handler != null)
            {
                // Invokes the delegates. 
                handler(this, e);
            }
        }
    }
}