#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using InformationInTransit.DataAccess;
#endregion

namespace InformationInTransit.ProcessLogic
{
    #region StreetAddress definition
    public partial class StreetAddress
    {
        #region Constructors
        public StreetAddress
        (
            Int64? streetAddressId,
            Int64 contactId,
            int informationTypeId,
            string address,
            string suburb,
            string state,
            string postCode,
            string country
        )
        {
            this.streetAddressId = streetAddressId;
            this.contactId = contactId;
            this.informationTypeId = informationTypeId;
            this.address = address;
            this.suburb = suburb;
            this.state = state;
            this.postCode = postCode;
            this.country = country;
        }
        #endregion

        #region Fields
        Int64? streetAddressId;
        Int64 contactId;
        int informationTypeId;
        string address;
        string suburb;
        string state;
        string postCode;
        string country;
        #endregion

        #region Properties
        public Int64? StreetAddressId
        {
            get { return streetAddressId; }
            set { streetAddressId = value; }
        }

        public Int64 ContactId
        {
            get { return contactId; }
            set { contactId = value; }
        }

        public int InformationTypeId
        {
            get { return informationTypeId; }
            set { informationTypeId = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string Suburb
        {
            get { return suburb; }
            set { suburb = value; }
        }

        public string State
        {
            get { return state; }
            set { state = value; }
        }

        public string PostCode
        {
            get { return postCode; }
            set { postCode = value; }
        }

        public string Country
        {
            get { return country; }
            set { country = value; }
        }
        #endregion

        #region Methods
        public void DatabaseInsertUpdate()
        {
            StreetAddressDb.DatabaseInsertUpdate(this);
        }
        #endregion
    }
    #endregion
}