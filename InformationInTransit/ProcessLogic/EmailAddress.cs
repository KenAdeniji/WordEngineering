#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using InformationInTransit.DataAccess;
#endregion

namespace InformationInTransit.ProcessLogic
{
    #region EmailAddress definition
    public partial class EmailAddress
    {
        #region Constructors
        public EmailAddress
        (
            Int64? emailAddressId,
            Int64 contactId,
            string personalEmail,
	        string workEmail,
	        string otherEmail,
            int preferredEmailId
        )
        {
            this.emailAddressId = emailAddressId;
            this.contactId = contactId;
            this.personalEmail = personalEmail;
	        this.workEmail = workEmail;
	        this.otherEmail = otherEmail;
            this.preferredEmailId = preferredEmailId;
        }
        #endregion
        #region Fields
        Int64? emailAddressId;
        Int64 contactId;
        string personalEmail;
	    string workEmail;
	    string otherEmail;
        int preferredEmailId;
        #endregion

        #region Properties
        public Int64? EmailAddressId
        {
            get { return emailAddressId; }
            set { emailAddressId = value; }
        }

        public Int64 ContactId
        {
            get { return contactId; }
            set { contactId = value; }
        }

        public string PersonalEmail
        {
            get { return personalEmail; }
            set { personalEmail = value; }
        }

        public string WorkEmail
        {
            get { return workEmail; }
            set { workEmail = value; }
        }

        public string OtherEmail
        {
            get { return otherEmail; }
            set { otherEmail = value; }
        }

        public int PreferredEmailId
        {
            get { return preferredEmailId; }
            set { preferredEmailId = value; }
        }
        #endregion

        #region Methods
        public void DatabaseInsertUpdate()
        {
            EmailAddressDb.DatabaseInsertUpdate(this);
        }
        #endregion
    }
    #endregion
}
