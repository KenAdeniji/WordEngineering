#region Using directives
using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;
#endregion

namespace InformationInTransit.ProcessLogic
{
    #region SQLCLRHelper definition
    public static partial class SQLCLRHelper
    {
        public static void SelectAddressType()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Context Connection=true";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = @"SELECT AddressTypeID, [Name] FROM AdventureWorks.Person.AddressType Order by AddressTypeID";

            conn.Open();

            SqlDataReader rdr = cmd.ExecuteReader();
            SqlContext.Pipe.Send(rdr);

            rdr.Close();
            conn.Close();
        }
    }
    #endregion
}
