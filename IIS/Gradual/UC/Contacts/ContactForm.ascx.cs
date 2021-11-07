#region Using directives
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Globalization;

using InformationInTransit.ProcessLogic;
using InformationInTransit.UserInterface;
#endregion

/*
	2021-11-02T16:38:00 ... 2021-11-02T18:45:00 https://docs.microsoft.com/en-us/dotnet/api/system.web.httputility.htmlencode?view=net-5.0
*/
namespace WordEngineering
{
    #region UC_Contacts_ContactForm definition
    public partial class UC_Contacts_ContactForm : System.Web.UI.UserControl
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
                    contactId = System.Convert.ToInt64(obj);
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
                ViewState.Add("ContactSet", value);
            }
        }

        public HeaderMenuInitiate Initiate
        {
            get
            {
                return (HeaderMenuInitiate)Convert.ToInt32(ViewState["Initiate"]);
            }
            set
            {
                ViewState["Initiate"] = value;
            }
        }
        #endregion

        #region Methods
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PreferredEmail.DataSource = InformationInTransit.ProcessLogic.PreferredEmail.DatabaseQuery();
                PreferredEmail.DataTextField = "Description";
                PreferredEmail.DataValueField = "PreferredEmailId";
                PreferredEmail.DataBind();
                
                BirthdayMonth.DataSource = DateTimeCollection.MonthNameCollection;
                BirthdayMonth.DataBind();

                BirthdayDay.DataSource = DateTimeCollection.DayCollection;
                BirthdayDay.DataBind();

                BirthdayYear.DataSource = DateTimeCollection.YearCollection;
                BirthdayYear.DataBind();
            }
        }

        public void Edit(Int64? contactId)
        {
            Initiate = HeaderMenuInitiate.Edit;
            ContactId = contactId;
            ControlHelper.Reset(this);
			
			StringWriter myWriter = new StringWriter();
			
            DataRow contact = GetRow(ContactSet, (int)ContactsListResultSet.Contact, contactId);
            if (contact == null)
			{
                return;
			}	
            FirstName.Text = contact["FirstName"].ToString();
            LastName.Text = contact["LastName"].ToString();
            NickName.Text = contact["NickName"].ToString();
            
/*
			String note = contact["Note"].ToString();
			HttpUtility.HtmlDecode(note, myWriter);
			string myDecodedString = myWriter.ToString();			
			Note.Text = myDecodedString;
*/			
			Note.Text = contact["Note"].ToString();
			
            DateTime? birthday = null;
            if (contact["Birthday"] != DBNull.Value)
            {
                birthday = Convert.ToDateTime(contact["Birthday"]);
                BirthdayMonth.SelectedIndex = birthday.Value.Month;
                BirthdayDay.SelectedIndex = birthday.Value.Day;
                BirthdayYear.SelectedValue = birthday.Value.Year.ToString();
            }
            DataRow emailAddress = GetRow(ContactSet, (int)ContactsListResultSet.EmailAddress, contactId);
            if (emailAddress != null)
            {
                PersonalEmail.Text = emailAddress["PersonalEmail"].ToString();
                WorkEmail.Text = emailAddress["WorkEmail"].ToString();
                OtherEmail.Text = emailAddress["OtherEmail"].ToString();

                if (emailAddress["PreferredEmailId"] != DBNull.Value)
                {
                    int preferredEmailId = 1;
                    Int32.TryParse(emailAddress["PreferredEmailId"].ToString(), out preferredEmailId);
                    PreferredEmail.SelectedValue = preferredEmailId.ToString();
                }
            }
            DataRow phoneNumber = GetRow(ContactSet, (int)ContactsListResultSet.PhoneNumber, contactId);
            if (phoneNumber != null)
            {
                HomePhone.Text = phoneNumber["HomePhone"].ToString();
                MobilePhone.Text = phoneNumber["MobilePhone"].ToString();
                WorkPhone.Text = phoneNumber["WorkPhone"].ToString();
                Pager.Text = phoneNumber["Pager"].ToString();
                Fax.Text = phoneNumber["Fax"].ToString();
                OtherPhone.Text = phoneNumber["OtherPhone"].ToString();
            }
            Company.Text = contact["OrganizationName"].ToString();
            DataRow personalStreetAddress = GetRow(ContactSet, (int)ContactsListResultSet.PersonalStreetAddress, contactId);
            if (personalStreetAddress != null)
            {
                HomeAddress.Text = personalStreetAddress["Address"].ToString();
                PersonalCity.Text = personalStreetAddress["Suburb"].ToString();
                PersonalStateProvince.Text = personalStreetAddress["State"].ToString();
                PersonalZipPostalCode.Text = personalStreetAddress["PostCode"].ToString();
                PersonalCountry.Text = personalStreetAddress["Country"].ToString();
            }
            DataRow businessStreetAddress = GetRow(ContactSet, (int)ContactsListResultSet.BusinessStreetAddress, contactId);
            if (businessStreetAddress != null)
            {
                WorkAddress.Text = businessStreetAddress["Address"].ToString();
                BusinessCity.Text = businessStreetAddress["Suburb"].ToString();
                BusinessStateProvince.Text = businessStreetAddress["State"].ToString();
                BusinessZipPostalCode.Text = businessStreetAddress["PostCode"].ToString();
                BusinessCountry.Text = businessStreetAddress["Country"].ToString();
            }
            DataRow uriAddress = GetRow(ContactSet, (int)ContactsListResultSet.UriAddress, contactId);
            if (uriAddress != null)
            {
                Website.Text = uriAddress["Website"].ToString();
            }
        }

        public DataRow GetRow(DataSet dataSet, int tableId, Int64? primaryId) 
        {
            if (dataSet == null || dataSet.Tables.Count < tableId - 1)
            {
                return null;
            }
            DataTable table = dataSet.Tables[tableId];
            string expression;
            expression = String.Format("{0} = {1}", table.PrimaryKey[0].ColumnName, primaryId);
            DataRow[] foundRows;
            DataRow foundRow = null;
            if (table.Rows.Count == 0)
			{	
               return null;
			}   
            // Use the Select method to find all rows matching the filter.
            foundRows = table.Select(expression);
            if (foundRows.Length > 0)
            {
                foundRow = foundRows[0];
            }
            return foundRow;
        }

        public void New()
        {
            Initiate = HeaderMenuInitiate.New;
            ContactId = null;
            ControlHelper.Reset(this);
        }

        public void Save()
        {
            Int64? contactId = null;

            if (Initiate == HeaderMenuInitiate.Edit)
            {
                contactId = ContactId;
                if (contactId == null)
				{	
                    return;
				}	
            }
            Contact contact = new Contact
            (
                contactId,
                UserNameId.QueryUserId("KenAdeniji@hotmail.com"), //UserNameId.QueryUserId(Page.User.Identity.Name),
                FirstName.Text,
                null, //Middle name
                LastName.Text,
                NickName.Text,
                DateTimeCollection.Parse(BirthdayYear.SelectedValue, BirthdayMonth.SelectedIndex, BirthdayDay.SelectedIndex),
                null, //Anniversary
                Note.Text, //HttpUtility.HtmlEncode(Note.Text)
				Company.Text
            );

            contact.DatabaseInsertUpdate();

            if (contact.ContactId != null)
            {
                Int64 contactIdNotNull = (Int64)contact.ContactId;
                SaveEmailAddress(contactIdNotNull);
                SavePhoneNumber(contactIdNotNull);
                //SaveOrganization(contactIdNotNull);
                SavePersonalStreetAddress(contactIdNotNull);
                SaveBusinessStreetAddress(contactIdNotNull);
                SaveUriAddress(contactIdNotNull);
            }
        }

        public void SaveBusinessStreetAddress(Int64 contactId)
        {
            if
            (
                Initiate == HeaderMenuInitiate.New &&
                string.IsNullOrEmpty(WorkAddress.Text) &&
                string.IsNullOrEmpty(BusinessCity.Text) &&
                string.IsNullOrEmpty(BusinessStateProvince.Text) &&
                string.IsNullOrEmpty(BusinessZipPostalCode.Text) &&
                string.IsNullOrEmpty(BusinessCountry.Text)
            )
			{
                return;
			}	
            StreetAddress streetAddress = new StreetAddress
            (
                null, //StreetAddressId
                contactId,
                (int)InformationTypeId.Business,
                WorkAddress.Text,
                BusinessCity.Text,
                BusinessStateProvince.Text,
                BusinessZipPostalCode.Text,
                BusinessCountry.Text
            );
            streetAddress.DatabaseInsertUpdate();
        }

        public void SaveEmailAddress(Int64 contactId)
        {
            if
            (
                Initiate == HeaderMenuInitiate.New &&
                string.IsNullOrEmpty(PersonalEmail.Text) &&
                string.IsNullOrEmpty(WorkEmail.Text) &&
                string.IsNullOrEmpty(OtherEmail.Text)
            )
                return;
            EmailAddress emailAddress = new EmailAddress
            (
                null, //EmailAddressId
                contactId,
                PersonalEmail.Text,
                WorkEmail.Text,
                OtherEmail.Text,
                Convert.ToInt32(PreferredEmail.SelectedValue)
            );
            emailAddress.DatabaseInsertUpdate();
        }

        public void SaveOrganization(Int64 contactId)
        {
            if
            (
                Initiate == HeaderMenuInitiate.New &&
                string.IsNullOrEmpty(Company.Text) 
            )
                return;
            Organization organization = new Organization
            (
                null, //OrganizationId
                contactId,
                Company.Text,
                null //Title
            );
            organization.DatabaseInsertUpdate();
        }

        public void SavePersonalStreetAddress(Int64 contactId)
        {
            if
            (
                Initiate == HeaderMenuInitiate.New &&
                string.IsNullOrEmpty(HomeAddress.Text) &&
                string.IsNullOrEmpty(PersonalCity.Text) &&
                string.IsNullOrEmpty(PersonalStateProvince.Text) &&
                string.IsNullOrEmpty(PersonalZipPostalCode.Text) &&
                string.IsNullOrEmpty(PersonalCountry.Text)
            )
                return;
            StreetAddress streetAddress = new StreetAddress
            (
                null, //StreetAddressId
                contactId,
                (int)InformationTypeId.Personal,
                HomeAddress.Text,
                PersonalCity.Text,
                PersonalStateProvince.Text,
                PersonalZipPostalCode.Text,
                PersonalCountry.Text
            );
            streetAddress.DatabaseInsertUpdate();
        }

        public void SavePhoneNumber(Int64 contactId)
        {
            if
            (
                Initiate == HeaderMenuInitiate.New &&
                string.IsNullOrEmpty(HomePhone.Text) &&
                string.IsNullOrEmpty(MobilePhone.Text) &&
                string.IsNullOrEmpty(WorkPhone.Text) &&
                string.IsNullOrEmpty(Pager.Text) &&
                string.IsNullOrEmpty(Fax.Text) &&
                string.IsNullOrEmpty(OtherPhone.Text)
            )
                return;
            PhoneNumber phoneNumber = new PhoneNumber
            (
                null, //PhoneNumberId
                contactId,
                HomePhone.Text,
                MobilePhone.Text,
                WorkPhone.Text,
                Pager.Text,
                Fax.Text,
                OtherPhone.Text
            );
            phoneNumber.DatabaseInsertUpdate();
        }

        public void SaveUriAddress(Int64 contactId)
        {
            if
            (
                Initiate == HeaderMenuInitiate.New &&
                string.IsNullOrEmpty(Website.Text)
            )
                return;
            UriAddress uriAddress = new UriAddress
            (
                null, //UriAddressId
                contactId,
                Website.Text
            );
            uriAddress.DatabaseInsertUpdate();
        }
        #endregion
    }
    #endregion
}
