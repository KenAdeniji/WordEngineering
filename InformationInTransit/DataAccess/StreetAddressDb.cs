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
    #region StreetAddressDb definition
    public static partial class StreetAddressDb
    {
        #region Methods
        public static void DatabaseInsertUpdate(StreetAddress streetAddress)
        {
            List<SqlParameter> sqlParameterCollection = new List<SqlParameter>();

            SqlParameter streetAddressId = new SqlParameter("@streetAddressId", DbType.Int64);

            if (streetAddress.StreetAddressId != null)
            {
                streetAddressId.Value = streetAddress.StreetAddressId;
            }
            streetAddressId.Direction = ParameterDirection.InputOutput;
            streetAddressId.IsNullable = true;
            sqlParameterCollection.Add(streetAddressId);

            sqlParameterCollection.Add(new SqlParameter("@contactId", streetAddress.ContactId));
            sqlParameterCollection.Add(new SqlParameter("@informationTypeId", streetAddress.InformationTypeId));
            sqlParameterCollection.Add(new SqlParameter("@address", streetAddress.Address));
            sqlParameterCollection.Add(new SqlParameter("@suburb", streetAddress.Suburb));
            sqlParameterCollection.Add(new SqlParameter("@state", streetAddress.State));
            sqlParameterCollection.Add(new SqlParameter("@postCode", streetAddress.PostCode));
            sqlParameterCollection.Add(new SqlParameter("@country", streetAddress.Country));

            Repository.DatabaseCommand
            (
                "StreetAddressInsertUpdate",
                CommandType.StoredProcedure,
                Repository.ResultSet.NonQuery,
                sqlParameterCollection
            );
        }
        #endregion
    }
    #endregion
}