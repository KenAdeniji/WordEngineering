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
    #region ContactDb definition
    public static partial class ContactDb
    {
        #region Methods
        public static void DatabaseDelete(Int64 contactId)
        {
            List<SqlParameter> sqlParameterCollection = new List<SqlParameter>();

            sqlParameterCollection.Add(new SqlParameter("@contactId", contactId));

            Repository.DatabaseCommand
            (
                "ContactDelete",
                CommandType.StoredProcedure,
                Repository.ResultSet.NonQuery,
                sqlParameterCollection
            );
        }

        public static void DatabaseInsertUpdate(Contact contact)
        {
            List<SqlParameter> sqlParameterCollection = new List<SqlParameter>();

            if (contact.UserId != UserNameIdDb.UserIdDefault)
                sqlParameterCollection.Add(new SqlParameter("@userId", contact.UserId));

            SqlParameter contactId = new SqlParameter("@contactId", SqlDbType.BigInt);
            if (contact.ContactId == null)
                contactId.Value = DBNull.Value;
            else
                contactId.Value = contact.ContactId;
            contactId.Direction = ParameterDirection.InputOutput;
            contactId.IsNullable = true;
            sqlParameterCollection.Add(contactId);

            sqlParameterCollection.Add(new SqlParameter("@firstName", contact.FirstName));
            sqlParameterCollection.Add(new SqlParameter("@middleName", contact.MiddleName));
            sqlParameterCollection.Add(new SqlParameter("@lastName", contact.LastName));
            sqlParameterCollection.Add(new SqlParameter("@nickName", contact.NickName));
            sqlParameterCollection.Add(new SqlParameter("@birthDay", contact.BirthDay));
            sqlParameterCollection.Add(new SqlParameter("@anniversary", contact.Anniversary));
            sqlParameterCollection.Add(new SqlParameter("@note", contact.Note));
			sqlParameterCollection.Add(new SqlParameter("@organizationName", contact.OrganizationName));

            Repository.DatabaseCommand
            (
                "ContactInsertUpdate",
                CommandType.StoredProcedure,
                Repository.ResultSet.NonQuery,
                sqlParameterCollection
            );

            if (contactId.Value != DBNull.Value)
                contact.ContactId = Convert.ToInt64(contactId.Value);
        }

        public static DataSet ContactsList(string loginName, string whereClause)
        {
            DataSet dataSet = null;
            List<SqlParameter> sqlParameterCollection = new List<SqlParameter>();

            if (!String.IsNullOrEmpty(loginName))
            {
                sqlParameterCollection.Add(new SqlParameter("@loginName", loginName));
            }
            if (!String.IsNullOrEmpty(whereClause))
            {
                sqlParameterCollection.Add(new SqlParameter("@whereClause", whereClause));
            }
            dataSet = (DataSet)Repository.DatabaseCommand
            (
                "IHaveDecidedToWorkOnAGradualImprovingSystem..ContactsList",
                null,
                CommandType.StoredProcedure,
                Repository.ResultSet.DataSet,
                sqlParameterCollection
            );
            return dataSet;
        }
        #endregion
    }
    #endregion
}