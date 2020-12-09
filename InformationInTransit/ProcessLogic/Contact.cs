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
    #region Contact definition
    public partial class Contact
    {
        #region Fields
        private Int64? contactId;
        private Guid userId;
        private string firstName;
        private string middleName;
        private string lastName;
        private string nickName;
        private DateTime? birthDay;
        private DateTime? anniversary;
        private string note;
        private string organizationName;
        #endregion

        #region Constructors
        public Contact
        (
            Int64? contactId,
            Guid userId,
            string firstName,
            string middleName,
            string lastName,
            string nickName,
            DateTime? birthDay,
            DateTime? anniversary,
            string note,
			string organizationName
        )
        {
            this.contactId = contactId;
            this.userId = userId;
            this.firstName = firstName;
            this.middleName = middleName;
            this.lastName = lastName;
            this.nickName = nickName;
            this.birthDay = birthDay;
            this.anniversary = anniversary;
            this.note = note;
			this.organizationName = organizationName;
        }
        #endregion

        #region Properties
        public Int64? ContactId
        {
            get { return contactId; }
            set { contactId = value; }
        }

        public Guid UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string MiddleName
        {
            get { return middleName; }
            set { middleName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string NickName
        {
            get { return nickName; }
            set { nickName = value; }
        }

        public DateTime? BirthDay
        {
            get { return birthDay; }
            set { birthDay = value; }
        }

        public DateTime? Anniversary
        {
            get { return anniversary; }
            set { anniversary = value; }
        }

        public string Note
        {
            get { return note; }
            set { note = value; }
        }

        public string OrganizationName
        {
            get { return organizationName; }
            set { organizationName = value; }
        }
        #endregion

        #region Methods
        public void DatabaseInsertUpdate()
        {
            ContactDb.DatabaseInsertUpdate(this);
        }

        public static void DatabaseDelete(Int64 contactId)
        {
            ContactDb.DatabaseDelete(contactId);
        }

        public static DataSet ContactsList(string loginName, string query)
        {
            DataSet dataSet = null;
            List<JesusInTheLamb> jesusInTheLambCollection = new List<JesusInTheLamb>();
            jesusInTheLambCollection.Add(new JesusInTheLamb("FullName"));
            jesusInTheLambCollection.Add(new JesusInTheLamb("NickName"));
            jesusInTheLambCollection.Add(new JesusInTheLamb("Note"));
            jesusInTheLambCollection.Add(new JesusInTheLamb("OrganizationName"));
            jesusInTheLambCollection.Add(new JesusInTheLamb("StreetAddressJoin"));
            jesusInTheLambCollection.Add(new JesusInTheLamb("PhoneNumberConcatenate"));
            
            string whereClause = JesusInTheLamb.Join(jesusInTheLambCollection, query);

            dataSet = ContactDb.ContactsList(loginName, whereClause);
            return dataSet;
        }

        public static string Fullname
        (
            object firstName,
            object middleName,
            object lastName
        )
        {
            StringBuilder sb = new StringBuilder();
            if (firstName != null) { sb.Append(firstName); sb.Append(" "); }
            if (middleName != null) { sb.Append(middleName); sb.Append(" "); }
            if (lastName != null) { sb.Append(lastName); sb.Append(" "); }
            return sb.ToString().Trim();
        }

        public static string NicknameOrFullname
        (
            object firstName,
            object middleName,
            object lastName,
            object nickName
        )
        {
            if (!String.IsNullOrEmpty(nickName.ToString()))
                return nickName.ToString();
            return Fullname(firstName, middleName, lastName);
        }
        #endregion
    }
    #endregion
}
