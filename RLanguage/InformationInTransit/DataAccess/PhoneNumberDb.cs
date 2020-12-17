#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using InformationInTransit.ProcessLogic;
#endregion

namespace InformationInTransit.DataAccess
{
    #region PhoneNumberDb definition
    public static partial class PhoneNumberDb
    {
        #region Methods
        public static void DatabaseInsertUpdate(PhoneNumber phoneNumber)
        {
            List<SqlParameter> sqlParameterCollection = new List<SqlParameter>();

            SqlParameter phoneNumberId = new SqlParameter("@phoneNumberId", DbType.Int64);

            if (phoneNumber.PhoneNumberId != null)
            {
                phoneNumberId.Value = phoneNumber.PhoneNumberId;
            }
            phoneNumberId.Direction = ParameterDirection.InputOutput;
            phoneNumberId.IsNullable = true;
            sqlParameterCollection.Add(phoneNumberId);

            sqlParameterCollection.Add(new SqlParameter("@contactId", phoneNumber.ContactId));
            sqlParameterCollection.Add(new SqlParameter("@homePhone", phoneNumber.HomePhone));
            sqlParameterCollection.Add(new SqlParameter("@mobilePhone", phoneNumber.MobilePhone));
            sqlParameterCollection.Add(new SqlParameter("@workPhone", phoneNumber.WorkPhone));
            sqlParameterCollection.Add(new SqlParameter("@pager", phoneNumber.Pager));
            sqlParameterCollection.Add(new SqlParameter("@fax", phoneNumber.Fax));
            sqlParameterCollection.Add(new SqlParameter("@otherPhone", phoneNumber.OtherPhone));

            Repository.DatabaseCommand
            (
                "PhoneNumberInsertUpdate",
                CommandType.StoredProcedure,
                Repository.ResultSet.NonQuery,
                sqlParameterCollection
            );
        }
        #endregion
    }
    #endregion
}