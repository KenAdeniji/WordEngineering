#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;
#endregion

namespace InformationInTransit.DataAccess
{
    #region UserNameIdDb definition
    public static partial class UserNameIdDb
    {
        #region Fields
        public static readonly string ConnectionString;
        public const string SqlSelectUserIdTemplate = "SELECT TOP 1 UserId FROM aspnet_Users (NOLOCK) WHERE UserName = '{0}'";
        public static readonly Guid UserIdDefault;
        #endregion

        #region Methods
        public static Guid QueryUserId(string userName)
        {
            string selectCommand = String.Format(SqlSelectUserIdTemplate, userName);
            Guid userId = UserIdDefault;
            IDataReader dataReader = null;
            try
            {
                userId = (Guid)Repository.DatabaseCommand
                (
                    selectCommand,
                    ConnectionString,
                    System.Data.CommandType.Text,
                    Repository.ResultSet.Scalar
                );
            }
            catch (Exception ex)
            {
                string exceptionMessage = ex.Message;
            }
            finally
            {
                if (dataReader != null) 
                    dataReader.Close();
            }
            return userId;
        }

        static UserNameIdDb()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
            UserIdDefault = new Guid();
        }
        #endregion
    }
    #endregion
}