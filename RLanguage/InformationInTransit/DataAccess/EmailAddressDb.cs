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
    #region EmailAddressDb definition
    public static partial class EmailAddressDb
    {
        #region Methods
        public static void DatabaseInsertUpdate(EmailAddress emailAddress)
        {
            List<SqlParameter> sqlParameterCollection = new List<SqlParameter>();

            SqlParameter emailAddressId = new SqlParameter("@emailAddressId", DbType.Int64);

            if (emailAddress.EmailAddressId != null)
            {
                emailAddressId.Value = emailAddress.EmailAddressId;
            }
            emailAddressId.Direction = ParameterDirection.InputOutput;
            emailAddressId.IsNullable = true;
            sqlParameterCollection.Add(emailAddressId);

            sqlParameterCollection.Add(new SqlParameter("@contactId", emailAddress.ContactId));
            sqlParameterCollection.Add(new SqlParameter("@personalEmail", emailAddress.PersonalEmail));
            sqlParameterCollection.Add(new SqlParameter("@workEmail", emailAddress.WorkEmail));
            sqlParameterCollection.Add(new SqlParameter("@otherEmail", emailAddress.OtherEmail));
            sqlParameterCollection.Add(new SqlParameter("@preferredEmailId", emailAddress.PreferredEmailId));

            Repository.DatabaseCommand
            (
                "EmailAddressInsertUpdate",
                CommandType.StoredProcedure,
                Repository.ResultSet.NonQuery,
                sqlParameterCollection
            );
        }
        #endregion
    }
    #endregion
}