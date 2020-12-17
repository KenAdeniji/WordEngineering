#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Globalization;
using System.Xml;

using InformationInTransit.DataAccess;
#endregion

namespace InformationInTransit.ProcessLogic
{
    #region AdventureWorksPersonContact definition
    public partial class AdventureWorksPersonContact
    {
        #region Methods
        public static Collection<AdventureWorksPersonContact> Select()
        {
            SqlXml additionalContactInfo;
            int columnIndexAdditionalContactInfo;
            Int64 contactID;
            string emailAddress;
            int emailPromotion;
            string firstName;
            string lastName;
            string middleName;
            DateTime modifiedDate;
            bool nameStyle;
            string phone;
            string suffix;

            string title;

            AdventureWorksPersonContact adventureWorksPersonContact = null;
            Collection<AdventureWorksPersonContact> adventureWorksPersonContacts = new Collection<AdventureWorksPersonContact>();

            SqlDataReader dataReader = (SqlDataReader)AdventureWorksPersonContactDb.Select();
            columnIndexAdditionalContactInfo = dataReader.GetOrdinal("AdditionalContactInfo");
            while (dataReader.Read())
            {
                additionalContactInfo = dataReader.GetSqlXml(columnIndexAdditionalContactInfo);
                emailAddress = (String)dataReader["EmailAddress"];
                contactID = System.Convert.ToInt64(dataReader["ContactId"], CultureInfo.InvariantCulture);
                emailAddress = (String)dataReader["EmailAddress"];
                emailPromotion = (int)dataReader["EmailPromotion"];
                firstName = (String) dataReader["FirstName"];
                lastName = (String) dataReader["LastName"];
                middleName = null;
                if (dataReader["MiddleName"] != DBNull.Value)
                {
                    middleName = (String)dataReader["MiddleName"];
                }
                modifiedDate = (DateTime)dataReader["ModifiedDate"];
                nameStyle = (bool)dataReader["NameStyle"];
                phone = (String)dataReader["Phone"];
                suffix = null;
                if (dataReader["Suffix"] != DBNull.Value)
                {
                    suffix = (string)dataReader["Suffix"];
                }
                title = null;
                if (dataReader["Title"] != DBNull.Value)
                {
                    title = (string)dataReader["Title"];
                }

                //Object initialization
                adventureWorksPersonContact = new AdventureWorksPersonContact
                {
                    AdditionalContactInfo = additionalContactInfo,
                    ContactID = contactID,
                    EmailAddress = emailAddress,
                    EmailPromotion = emailPromotion,
                    FirstName = firstName,
                    LastName = lastName,
                    MiddleName = middleName,
                    ModifiedDate = modifiedDate,
                    NameStyle = nameStyle,
                    Phone = phone,
                    Suffix = suffix,
                    Title = title
                };

                adventureWorksPersonContacts.Add(adventureWorksPersonContact);
            }

            return adventureWorksPersonContacts;
        }
        #endregion

        #region Automatic Properties
        public SqlXml AdditionalContactInfo { get; set; }
        public Int64 ContactID { get; set; }
        public string EmailAddress { get; set; }
        public int EmailPromotion { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool NameStyle { get; set; }
        public string Phone { get; set; }
        public string Suffix { get; set; }
        public string Title { get; set; }
        #endregion
    }
    #endregion
}
