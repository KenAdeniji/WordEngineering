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
using System.Text;

using InformationInTransit.ProcessLogic;
#endregion

namespace WordEngineering
{
    #region UC_Contacts_ContactDisplay definition
    public partial class UC_Contacts_ContactDisplay : System.Web.UI.UserControl
    {
        #region Properties
        public Int64? ContactId
        {
            get
            {
                Int64? contactId = null;
                object obj = ViewState["ContactId"];
                if (obj != null)
                {
                    contactId = Convert.ToInt64(obj);
                }
                return contactId;
            }
            set
            {
                ViewState["ContactId"] = value;
            }
        }

        public DataSet ContactSet
        {
            get
            {
                object obj = ViewState["ContactSet"];
                DataSet contactSet = null;
                if (obj != null)
                {
                    contactSet = (DataSet)obj;
                }
                return contactSet;
            }
            set
            {
                ViewState["ContactSet"] = value;
                Display(null);
            }
        }
        #endregion

        #region Methods
        void CreateTableRow(DataRow row, string description, string columnName)
        {
            CreateTableRow(row, description, columnName, null);
        }

        void CreateTableRow(DataRow row, string description, string columnName, string format)
        {
            if (row == null) { return; }
            string columnValue = row[columnName].ToString();
            if (String.IsNullOrEmpty(columnValue)) { return; }
            TableRow tableRow = new TableRow();
            TableCell tableCell = new TableCell();
            tableCell.Controls.Add(new LiteralControl(description));
            tableCell.HorizontalAlign = HorizontalAlign.Right;
            tableRow.Cells.Add(tableCell);
            tableCell = new TableCell();
            string rightHandSide = null;
            if (format == null)
            {
                rightHandSide = columnValue;
            }
            else
            {
                rightHandSide = String.Format(format, row[columnName]);
            }
            tableCell.Controls.Add(new LiteralControl(rightHandSide));
            tableRow.Cells.Add(tableCell);
            ContactTable.Rows.Add(tableRow);
        }

        public void Display()
        {
            Display(ContactId);
        }

        public void Display(Int64? rowId)
        {
            DataRow contactRow = GetRow(ContactsListResultSet.Contact, rowId);
            if (contactRow == null) { ContactId = null; return; }
            bool suppressFullname = false;

            if (rowId == null)
			{	
                rowId = System.Convert.ToInt64(contactRow["ContactId"]);
			}
            ContactId = rowId;

            if (String.Compare(contactRow["NicknameOrFullname"].ToString(), contactRow["Fullname"].ToString()) == 0)
                suppressFullname = true;

            CreateTableRow(contactRow, null, "NicknameOrFullname");
            if (suppressFullname != true) CreateTableRow(contactRow, "Name", "FullName", "<b>{0}<b>");

            DataRow emailRow = GetRow(ContactsListResultSet.EmailAddress, rowId);
            CreateTableRow(emailRow, "Personal e-mail", "PersonalEmail", "<a href=\"mailto:{0}\">{0}</a>");

            DataRow phoneRow = GetRow(ContactsListResultSet.PhoneNumber, rowId);
            CreateTableRow(phoneRow, "Home phone", "HomePhone");
            CreateTableRow(phoneRow, "Mobile phone", "MobilePhone");

            DataRow personalStreetAddressRow = GetRow(ContactsListResultSet.PersonalStreetAddress, rowId);
            CreateTableRow(personalStreetAddressRow, "Home address", "StreetAddressConcatenate");

            CreateTableRow(contactRow, "Company", "OrganizationName");
            CreateTableRow(emailRow, "Work e-mail", "WorkEmail", "<a href=\"mailto:{0}\">{0}</a>");
            CreateTableRow(phoneRow, "Work phone", "WorkPhone");
            CreateTableRow(phoneRow, "Pager", "Pager");
            CreateTableRow(phoneRow, "Fax", "Fax");

            DataRow businessStreetAddressRow = GetRow(ContactsListResultSet.BusinessStreetAddress, rowId);
            CreateTableRow(businessStreetAddressRow, "Work address", "StreetAddressConcatenate");

            CreateTableRow(emailRow, "Other e-mail", "OtherEmail", "<a href=\"mailto:{0}\">{0}</a>");
            CreateTableRow(phoneRow, "Other phone", "OtherPhone");

            DataRow uriRow = GetRow(ContactsListResultSet.UriAddress, rowId);
            if (uriRow != null)
            {
                object uriRowWebsite = uriRow["Website"];
                uriRow["Website"] = "<a href=" +
                    ProtocolHelper.PrefixProtocol(uriRow["Website"].ToString()) +
                    " target=\"_blank\">" +
                    uriRow["Website"] +
                    "</a>";
                CreateTableRow(uriRow, "Website", "Website");
                uriRow["Website"] = uriRowWebsite;
            }

            CreateTableRow(contactRow, "Birthday", "Birthday", "{0:d}");
            CreateTableRow(contactRow, "Notes", "Note");
        }

        /// <summary>
        /// Retrieve a row based on the row Id.
        /// If the row Id is null, retrieve the top row.
        /// </summary>
        public DataRow GetRow(ContactsListResultSet tableEnum, Int64? rowId)
        {
            int tableId = (int)tableEnum;
            if (ContactSet == null || ContactSet.Tables.Count < tableId - 1)
            {
                return null;
            }
            DataTable table = ContactSet.Tables[tableId];
            string expression;
            expression = String.Format("ContactId = {0}", rowId);
            DataRow[] foundRows;
            DataRow foundRow = null;
            if (table.Rows.Count == 0) return null;
            if (rowId == null)
            {
                foundRow = table.Rows[0];
            }
            else
            {
                // Use the Select method to find all rows matching the filter.
                foundRows = table.Select(expression);
                if (foundRows.Length > 0)
                {
                    foundRow = foundRows[0];
                }
            }
            return foundRow;
        }

        public void Select(object sender, UC_Contacts_ContactsList_SelectEventArgs e)
        {
            Display(e.RowId);
        }
        #endregion
    }
    #endregion
}