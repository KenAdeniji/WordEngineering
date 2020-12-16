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
    #region OrganizationDb definition
    public static partial class OrganizationDb
    {
        #region Methods
        public static void DatabaseInsertUpdate(Organization organization)
        {
            List<SqlParameter> sqlParameterCollection = new List<SqlParameter>();

            SqlParameter organizationId = new SqlParameter("@organizationId", DbType.Int64);

            if (organization.OrganizationId != null)
            {
                organizationId.Value = organization.OrganizationId;
            }
            organizationId.Direction = ParameterDirection.InputOutput;
            organizationId.IsNullable = true;
            sqlParameterCollection.Add(organizationId);

            sqlParameterCollection.Add(new SqlParameter("@contactId", organization.ContactId));
            sqlParameterCollection.Add(new SqlParameter("@organizationName", organization.OrganizationName));
            sqlParameterCollection.Add(new SqlParameter("@title", organization.Title));

            Repository.DatabaseCommand
            (
                "OrganizationInsertUpdate",
                CommandType.StoredProcedure,
                Repository.ResultSet.NonQuery,
                sqlParameterCollection
            );
        }
        #endregion
    }
    #endregion
}