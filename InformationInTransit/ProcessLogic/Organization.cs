#region Using directives
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using InformationInTransit.DataAccess;
#endregion

namespace InformationInTransit.ProcessLogic
{
    #region Organization definition
    public partial class Organization
    {
        #region Fields
        private Int64? organizationId;
        private Int64 contactId;
        private string organizationName;
        private string title;
        #endregion

        #region Constructors
        public Organization
        (
            Int64? organizationId,
            Int64 contactId,
            string organizationName,
            string title
        )
        {
            this.organizationId = organizationId;
            this.contactId = contactId;
            this.organizationName = organizationName;
            this.title = title;
        }
        #endregion

        #region Properties
        public Int64? OrganizationId
        {
            get { return organizationId; }
            set { organizationId = value; }
        }

        public Int64 ContactId
        {
            get { return contactId; }
            set { contactId = value; }
        }

        public string OrganizationName
        {
            get { return organizationName; }
            set { organizationName = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        #endregion

        #region Methods
        public void DatabaseInsertUpdate()
        {
            OrganizationDb.DatabaseInsertUpdate(this);
        }
        #endregion
    }
    #endregion
}