#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using InformationInTransit.DataAccess;
#endregion

namespace InformationInTransit.ProcessLogic
{
    #region UriAddress definition
    public partial class UriAddress
    {
        #region Constructors
        public UriAddress
        (
            Int64? uriAddressId,
            Int64 contactId,
            string website
        )
        {
            this.uriAddressId = uriAddressId;
            this.contactId = contactId;
            this.website = website;
        }
        #endregion

        #region Fields
        Int64? uriAddressId;
        Int64 contactId;
        string website;
        #endregion

        #region Properties
        public Int64? UriAddressId
        {
            get { return uriAddressId; }
            set { uriAddressId = value; }
        }

        public Int64 ContactId
        {
            get { return contactId; }
            set { contactId = value; }
        }

        public string Website
        {
            get { return website; }
            set { website = value; }
        }
        #endregion

        #region Methods
        public void DatabaseInsertUpdate()
        {
            UriAddressDb.DatabaseInsertUpdate(this);
        }
        #endregion
    }
    #endregion
}