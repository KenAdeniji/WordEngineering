#region Using directives
using System;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;
#endregion

namespace WordEngineering
{
    #region Contacts_ContactsList definition
    public partial class Contacts_ContactsList : System.Web.UI.Page
    {
        #region Methods
        protected void Page_Load(object sender, EventArgs e)
        {
            ContactsList1.Select += new UC_Contacts_ContactsList_SelectEventHandler(ContactDisplay1.Select);
            HeaderMenu1.MenuCancel += new MenuCancelEventHandler(MenuCancel_OnClick);
            HeaderMenu1.MenuDelete += new MenuDeleteEventHandler(MenuDelete_OnClick);
            HeaderMenu1.MenuEdit += new MenuEditEventHandler(MenuEdit_OnClick);
            HeaderMenu1.MenuNew += new MenuNewEventHandler(MenuNew_OnClick);
            HeaderMenu1.MenuSave += new MenuSaveEventHandler(MenuSave_OnClick);
        }

        private void ContactDelete(Int64? contactId)
        {
            if (contactId == null || string.IsNullOrEmpty(Page.User.Identity.Name))
			{	
                return;
			}	
            Contact.DatabaseDelete((Int64)contactId);
            DatabaseQuery();
        }

        public void MenuCancel_OnClick(object sender, EventArgs e)
        {
            ContactsList1.Visible = true;
            ContactDisplay1.Visible = true;
            ContactForm1.Visible = false;
            ContactDisplay1.Display();
        }

        public void MenuDelete_OnClick(object sender, EventArgs e)
        {
            ContactDelete(ContactDisplay1.ContactId);
        }

        public void MenuEdit_OnClick(object sender, EventArgs e)
        {
            ContactsList1.Visible = false;
            ContactDisplay1.Visible = false;
            ContactForm1.Visible = true;
            ContactForm1.Edit(ContactDisplay1.ContactId);
        }

        public void MenuNew_OnClick(object sender, EventArgs e)
        {
            ContactsList1.Visible = false;
            ContactDisplay1.Visible = false;
            ContactForm1.Visible = true;
            ContactForm1.New();
        }

        public void MenuSave_OnClick(object sender, EventArgs e)
        {
            ContactForm1.Save();
            ContactsList1.Visible = true;
            ContactDisplay1.Visible = true;
            ContactForm1.Visible = false;
            DatabaseQuery();
        }

        public void Search_OnClick(object sender, EventArgs e)
        {
            DatabaseQuery();
        }

        public void DatabaseQuery()
        {
            DataSet dataSet = null;
			/*
            if (User.Identity.IsAuthenticated)
            {
                dataSet = InformationInTransit.ProcessLogic.Contact.ContactsList
                (
                    User.Identity.Name,
                    Query.Text
                );
            }
			*/
			
			dataSet = InformationInTransit.ProcessLogic.Contact.ContactsList
            (
                "KenAdeniji@hotmail.com",
                Query.Text
            );
				
            if (dataSet != null)
            {
                DataColumn[] keys = new DataColumn[1];
                foreach (DataTable table in dataSet.Tables)
                {
                    keys[0] = table.Columns["ContactId"];
                    table.PrimaryKey = keys;
                }
            }
            ContactsList1.ContactSet = dataSet;
            ContactDisplay1.ContactSet = dataSet;
            ContactForm1.ContactSet = dataSet;
        }
        #endregion
    }
    #endregion
}