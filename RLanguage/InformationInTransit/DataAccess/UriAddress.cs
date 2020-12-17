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
    #region UriAddressDb definition
    public static partial class UriAddressDb
    {
        #region Methods
        public static void DatabaseInsertUpdate(UriAddress uriAddress)
        {
            List<SqlParameter> sqlParameterCollection = new List<SqlParameter>();

            SqlParameter uriAddressId = new SqlParameter("@uriAddressId", DbType.Int64);

            if (uriAddress.UriAddressId != null)
            {
                uriAddressId.Value = uriAddress.UriAddressId;
            }
            uriAddressId.Direction = ParameterDirection.InputOutput;
            uriAddressId.IsNullable = true;
            sqlParameterCollection.Add(uriAddressId);

            sqlParameterCollection.Add(new SqlParameter("@contactId", uriAddress.ContactId));
            sqlParameterCollection.Add(new SqlParameter("@website", uriAddress.Website));

            Repository.DatabaseCommand
            (
                "UriAddressInsertUpdate",
                CommandType.StoredProcedure,
                Repository.ResultSet.NonQuery,
                sqlParameterCollection
            );
        }
        #endregion
    }
    #endregion
}