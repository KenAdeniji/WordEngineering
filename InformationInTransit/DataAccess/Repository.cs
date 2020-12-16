#region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Web;
#endregion

namespace InformationInTransit.DataAccess
{
    #region Repository definition
    public class Repository
    {
        #region Enums
        public enum ResultSet
        {
            DataSet,
            DataTable,
            NonQuery,
            Reader,
            Scalar,
            XmlReader
        }
        #endregion

        #region Fields
        public static readonly string ConnectionStringDefault;
        public static readonly string ConnectionStringNameDefault;
        #endregion

        #region Methods
        public static object DatabaseCommand(string cmdText)
        {
            return DatabaseCommand
            (
                cmdText, //SQL statement
                null, //database connection string
                CommandType.Text,
                ResultSet.Reader,
                null //sqlParameter
            );
        }

        public static object DatabaseCommand
        (
            string cmdText,
            CommandType commandType,
            ResultSet resultSet
        )
        {
            return DatabaseCommand
            (
                cmdText, //SQL statement
                null, //database connection string
                commandType,
                resultSet,
                null //sqlParameter
            );
        }

        public static object DatabaseCommand
        (
            string cmdText,
            string connectionString,
            CommandType commandType,
            ResultSet resultSet
        )
        {
            return DatabaseCommand
            (
                cmdText, //SQL statement
                connectionString,
                commandType,
                resultSet,
                null //sqlParameterCollection
            );
        }

        public static object DatabaseCommand
        (
            string cmdText,
            CommandType commandType,
            ResultSet resultSet,
            List<SqlParameter> sqlParameterCollection
        )
        {
            return DatabaseCommand
            (
                cmdText, //SQL statement
                null, //database connection string
                commandType,
                resultSet,
                sqlParameterCollection
            );
        }

        public static object DatabaseCommand
        (
            string cmdText,
            List<SqlParameter> sqlParameterCollection
        )
        {
            return DatabaseCommand
            (
                cmdText, //SQL statement
                null, //database connection string
                CommandType.StoredProcedure,
                ResultSet.Reader,
                sqlParameterCollection
            );
        }

        public static object DatabaseCommand
        (
            string cmdText,
            string connectionString,
            CommandType commandType,
            ResultSet resultSet,
            List<SqlParameter> sqlParameterCollection
        )
        {
            DataSet dataSet;
            DataTable dataTable;
            Object returnValue = null;
            SqlCommand sqlCommand;
            SqlConnection sqlConnection = null;
            SqlDataAdapter sqlDataAdapter;

            if (String.IsNullOrEmpty(connectionString))
            {
                connectionString = ConnectionStringDefault;
            }
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                sqlCommand = new SqlCommand(cmdText, sqlConnection);
                sqlCommand.CommandTimeout = 300;
                sqlCommand.CommandType = commandType;
                if (sqlParameterCollection != null && sqlParameterCollection.Count > 0)
                {
                    sqlCommand.Parameters.AddRange((SqlParameter[])sqlParameterCollection.ToArray());
                }
                switch (resultSet)
                {
                    case ResultSet.DataSet:
                        sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                        dataSet = new DataSet();
                        sqlDataAdapter.Fill(dataSet);
                        returnValue = dataSet;
                        break;

                    case ResultSet.DataTable:
                        sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                        dataTable = new DataTable();
                        sqlDataAdapter.Fill(dataTable);
                        returnValue = dataTable;
                        break;

                    case ResultSet.NonQuery:
                        returnValue = sqlCommand.ExecuteNonQuery(); break;

                    case ResultSet.Reader:
                        returnValue = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection); break;

                    case ResultSet.Scalar:
                        returnValue = sqlCommand.ExecuteScalar(); break;

                    case ResultSet.XmlReader:
                        returnValue = sqlCommand.ExecuteXmlReader(); break;
                }
            }
			catch (HttpException ex)
            {
				EventLog.WriteEntry("Application", "HttpExceptionGood", EventLogEntryType.Error);
                string exceptionMessage = ex.Message;
				EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error);
				throw;
            }
			catch (Exception ex)
            {
				EventLog.WriteEntry("Application", "Exception Good", EventLogEntryType.Error);				
                string exceptionMessage = ex.Message;
				EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error);
				throw;
            }
            finally
            {
                if (resultSet != ResultSet.Reader)
                {
                    sqlConnection.Close();
                }
            }

            return (returnValue);
        }

        public static SqlParameter SqlParameterCreate(string name, SqlDbType sqlDbType)
        {
            return
            (
                SqlParameterCreate
                (
                    name,
                    sqlDbType,
                    ParameterDirection.Input,
                    true, //IsNullable default = false
                    -1, //size
                    null //value
                )
            );
        }

        public static SqlParameter SqlParameterCreate
        (
            string name,
            SqlDbType sqlDbType,
            object value
        )
        {
            return
            (
                SqlParameterCreate
                (
                    name,
                    sqlDbType,
                    ParameterDirection.Input,
                    true, //IsNullable default = false
                    -1, //size
                    value
                )
            );
        }

        public static SqlParameter SqlParameterCreate
        (
            string name,
            SqlDbType sqlDbType,
            ParameterDirection direction,
            bool isNullable,
            int size,
            object value
        )
        {
            SqlParameter sqlParameter = new SqlParameter();
            sqlParameter.SqlDbType = sqlDbType;
            sqlParameter.Direction = direction;
            sqlParameter.IsNullable = isNullable;
            sqlParameter.ParameterName = name;
            if (size > 1) { sqlParameter.Size = size; }
            sqlParameter.Value = value;
            return (sqlParameter);
        }

        static Repository()
        {
            ConnectionStringNameDefault = ConfigurationManager.AppSettings["connectionStringNameDefault"];
            ConnectionStringDefault = ConfigurationManager.ConnectionStrings[ConnectionStringNameDefault].ConnectionString;
        }
        #endregion
    }
    #endregion
}