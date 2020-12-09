#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using InformationInTransit.DataAccess;
#endregion

namespace InformationInTransit.ProcessLogic
{
    #region PhoneNumber definition
    public partial class PhoneNumber
    {
        #region Constructors
        public PhoneNumber
        (
            Int64? phoneNumberId,
            Int64 contactId,
            string homePhone,
	        string mobilePhone,
	        string workPhone,
            string pager,
            string fax,
            string otherPhone
        )
        {
            this.phoneNumberId = phoneNumberId;
            this.contactId = contactId;
            this.homePhone = homePhone;
	        this.mobilePhone = mobilePhone;
	        this.workPhone = workPhone;
            this.pager = pager;
            this.fax = fax;
            this.otherPhone = otherPhone;
        }
        #endregion

        #region Fields
        Int64? phoneNumberId;
        Int64 contactId;
        string homePhone;
	    string mobilePhone;
	    string workPhone;
        string pager;
        string fax;
        string otherPhone;
        #endregion

        #region Properties
        public Int64? PhoneNumberId
        {
            get { return phoneNumberId; }
            set { phoneNumberId = value; }
        }

        public Int64 ContactId
        {
            get { return contactId; }
            set { contactId = value; }
        }

        public string HomePhone
        {
            get { return homePhone; }
            set { homePhone = value; }
        }

        public string MobilePhone
        {
            get { return mobilePhone; }
            set { mobilePhone = value; }
        }

        public string WorkPhone
        {
            get { return workPhone; }
            set { workPhone = value; }
        }

        public string Pager
        {
            get { return pager; }
            set { pager = value; }
        }

        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }

        public string OtherPhone
        {
            get { return otherPhone; }
            set { otherPhone = value; }
        }
        #endregion

        #region Methods
        public void DatabaseInsertUpdate()
        {
            PhoneNumberDb.DatabaseInsertUpdate(this);
        }
        #endregion
    }
    #endregion
}
