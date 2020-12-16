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

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;
#endregion

namespace WordEngineering
{
    #region Contact_ContactList definition
    public partial class Contact_ContactList : System.Web.UI.Page
    {
        #region Methods
        public void Search_OnClick(object sender, EventArgs e)
        {
			DatabaseQuery();
        }

        public void DatabaseQuery()
        {

            if (!User.Identity.IsAuthenticated) return;
			String loginName = User.Identity.Name;
			DataSet dataSet = null;
            List<JesusInTheLamb> jesusInTheLambCollection = new List<JesusInTheLamb>();
            jesusInTheLambCollection.Add(new JesusInTheLamb("FirstName"));
            jesusInTheLambCollection.Add(new JesusInTheLamb("LastName"));
            jesusInTheLambCollection.Add(new JesusInTheLamb("OtherName"));
            jesusInTheLambCollection.Add(new JesusInTheLamb("NickName"));
            jesusInTheLambCollection.Add(new JesusInTheLamb("Note"));
            jesusInTheLambCollection.Add(new JesusInTheLamb("OrganizationName"));
            
            string query = Query.Text.Trim();
			string whereClause = JesusInTheLamb.Join(jesusInTheLambCollection, query);

            dataSet = ContactDb.ContactsList(loginName, whereClause);
			
			if (dataSet != null)
            {
                DataColumn[] keys = new DataColumn[1];
                foreach (DataTable table in dataSet.Tables)
                {
                    keys[0] = table.Columns["contactId"];
                    table.PrimaryKey = keys;
                }
            }
			
			gridViewContact.DataSource = dataSet;
			gridViewContact.DataBind();

			string cmdText = "SELECT * FROM Contact";
			dataSet = (DataSet)Repository.DatabaseCommand
			(
				cmdText,
				CommandType.Text,
				Repository.ResultSet.DataSet
			);

			formViewContact.DataSource = dataSet;
			formViewContact.DataBind();
		}
		
		protected void gridViewContact_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (gridViewContact.SelectedIndex >= 0)
			{
				RefreshContact();
			}	
		}
		
		void RefreshContact()
		{
			long selectedIndex = gridViewContact.SelectedIndex;
			long contactId = (long) gridViewContact.SelectedDataKey.Value;
			String cmdText = String.Format(ContactSqlSelectFormat, contactId);
			DataSet dataSet = null;
			feedback.Text = contactId.ToString();	
			feedback.Text = "Good.";
			//cmdText = "SELECT * FROM Contact WHERE ContactId = 1";
			dataSet = (DataSet)Repository.DatabaseCommand
			(
				cmdText,
				CommandType.Text,
				Repository.ResultSet.DataSet
			);
		
			formViewContact.DataSource = dataSet;
			formViewContact.DataBind();
			
			//feedback.Text = cmdText;
		}
        #endregion
		
        #region Constants
		public const string ContactSqlSelectFormat = "SELECT * FROM Contact WHERE ContactId = {0}";
		#endregion
    }
    #endregion
}
