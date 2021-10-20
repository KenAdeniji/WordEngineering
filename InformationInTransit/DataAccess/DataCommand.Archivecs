 #region Using directives
using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.SqlServer.Server;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.Web;
#endregion

/*
	2016-03-13	public const string ContextConnection = "Context Connection = true;";
	2016-03-13	ALTER DATABASE WordEngineering SET TRUSTWORTHY ON;
	2016-03-13	CLR Scalar-Valued Functions https://msdn.microsoft.com/es-es/library/ms131043%28v=Odbc.90%29.aspx
	2020-12-27	https://docs.microsoft.com/en-us/dotnet/api/system.exception.innerexception?view=net-5.0
				https://stackoverflow.com/questions/5428406/grant-execute-permission-for-a-user-on-all-stored-procedures-in-database
					USE [DB]
					GRANT EXEC TO [User_Name];
	2020-12-27	https://docs.microsoft.com/en-us/Odbc/relational-databases/clr-integration/clr-integration-enabling?view=Odbc-server-ver15
				EXEC sp_configure 'clr enabled', 1;  
				RECONFIGURE;  
				GO
	2020-12-27	alter database [WordEngineering] set trustworthy on;
	2021-04-24	providerName=MySql.Data.MySqlClient;
*/
/*

    alter database [WordEngineering]
        set trustworthy on;

*/

/*

alter database [master] set trustworthy on;
alter database [tempdb] set trustworthy on;
alter database [model] set trustworthy on;
alter database [msdb] set trustworthy on;
alter database [AdminDB] set trustworthy on;
alter database [lab] set trustworthy on;
alter database [WordEngineering] set trustworthy on;
alter database [URI] set trustworthy on;
alter database [IHaveDecidedToWorkOnAGradualImprovingSystem] set trustworthy on;
alter database [Bible] set trustworthy on;
alter database [bibleDB] set trustworthy on;
alter database [ASPNetDB] set trustworthy on;
alter database [BibleDictionary] set trustworthy on;
alter database [ElectronicCopy] set trustworthy on;
alter database [RatingRank] set trustworthy on;
alter database [kb] set trustworthy on;

*/
/*
select 
          tblSD.[name]

        , tblSD.[is_trustworthy_on]

        , [OdbcTrustworthy]
            = 'alter database '
                + quotename( tblSD.[name])
                + ' set trustworthy on;'


        , [OdbcTrustworthy]
            = 'exec ' 
                + quotename( tblSD.[name])
                + '..sp_changedbowner '
                + ' [sa]'


from   sys.databases tblSD

where  tblSD.database_id >4
*/

namespace InformationInTransit.DataAccess
{
    #region DataCommand definition
    public static partial class DataCommand
    {
        #region Methods
        public static void Main(string[] argv)
        {
			/*
			DatabaseCommandIDataReaderStub();
            DatabaseCommandDataSetStub();
            DatabaseCommandDataTableStub();
			*/
			//DatabaseCommand(OdbcInjection);

			DatabaseCommand
			(
				"SELECT Dated, Word FROM WordEngineering..HisWord_View WHERE AlphabetSequenceIndexScriptureReference LIKE '%Leviticus%' ORDER BY HisWordID DESC"
			);
        }

        public static void ConnectionString()
        {
            foreach (ConnectionStringSettings css in ConfigurationManager.ConnectionStrings)
            {
                /*
				System.Console.WriteLine
                (
                    "Name: {0} | Provider Name: {1} | ConnectionString: {2}",
                    css.Name,
                    css.ProviderName,
                    css.ConnectionString
                );
				*/
            }
        }

        public static object DatabaseCommand(string cmdText)
        {
            return DatabaseCommand
            (
                cmdText, //Odbc statement
                null, //database connection string
                CommandType.Text,
                ResultType.DataReader,
                null //OdbcParameter
            );
        }

        public static object DatabaseCommand
        (
            string cmdText,
            CommandType commandType,
            ResultType resultType
        )
        {
            return DatabaseCommand
            (
                cmdText, //Odbc statement
                null, //database connection string
                commandType,
                resultType,
                null //OdbcParameter
            );
        }

        public static object DatabaseCommand
        (
            string cmdText,
            string connectionString,
            CommandType commandType,
            ResultType resultType
        )
        {
            return DatabaseCommand
            (
                cmdText, //Odbc statement
                connectionString,
                commandType,
                resultType,
                null //OdbcParameterCollection
            );
        }

        public static object DatabaseCommand
        (
            string cmdText,
            CommandType commandType,
            ResultType resultType,
            Collection<OdbcParameter> OdbcParameterCollection
        )
        {
            return DatabaseCommand
            (
                cmdText, //Odbc statement
                null, //database connection string
                commandType,
                resultType,
                OdbcParameterCollection
            );
        }

        public static object DatabaseCommand
        (
            string cmdText,
            Collection<OdbcParameter> OdbcParameterCollection
        )
        {
            return DatabaseCommand
            (
                cmdText, //Odbc statement
                null, //database connection string
                CommandType.StoredProcedure,
                ResultType.DataReader,
                OdbcParameterCollection
            );
        }

        [SqlFunction(DataAccess = DataAccessKind.Read)]
		public static object DatabaseCommand
        (
            string cmdText,
            string connectionString,
            CommandType commandType,
            ResultType resultType,
            Collection<OdbcParameter> odbcParameterCollection
        )
        {
            DataSet dataSet;
            DataTable dataTable;
            Object returnValue = null;
            OdbcCommand OdbcCommand;
            OdbcConnection OdbcConnection = null;
            OdbcDataAdapter OdbcDataAdapter;

			//2018-02-16	http://net-informations.com/q/faq/remove.html
			string cmdLine = cmdText.Replace(" ", String.Empty);
			
			string strCommandTimeOut = "";
			

/*			
			if (cmdLine.IndexOf("';") > 0)
			{
				throw new Exception();
			}	
*/
			
			if (String.IsNullOrEmpty(connectionString))
            {
                //2016-03-13 connectionString = ConnectionStringDefault;
				connectionString = (SqlContext.IsAvailable) ? "context connection=true" : ConnectionStringDefault;
            }
            try
            {
                //EventLog.WriteEntry("Application", cmdText, EventLogEntryType.Information);
                OdbcConnection = new OdbcConnection(connectionString);
                OdbcConnection.Open();
                OdbcCommand = new OdbcCommand(cmdText, OdbcConnection);
                OdbcCommand.CommandType = commandType;
				OdbcCommand.CommandTimeout = OdbcConnection.ConnectionTimeout;
                if (CommandTimeout != null)
                {
                    OdbcCommand.CommandTimeout = (int)CommandTimeout;
                }
				
				// dadeniji 2018-08-26 12:02 PM
				OdbcCommand.CommandTimeout = 0;
				
				System.Console.WriteLine("OdbcCommand.commandTimeout: {0}", OdbcCommand.CommandTimeout);
				
				strCommandTimeOut = "OdbcCommand.commandTimeout is " + OdbcCommand.CommandTimeout;
				
                if (odbcParameterCollection != null && odbcParameterCollection.Count > 0)
                {
                    foreach (OdbcParameter odbcParameter in odbcParameterCollection)
                    {
                        OdbcCommand.Parameters.Add(odbcParameter);
                    }
                }
                switch (resultType)
                {
                    case ResultType.DataSet:
                        OdbcDataAdapter = new OdbcDataAdapter(OdbcCommand);
                        dataSet = new DataSet();
                        dataSet.Locale = CultureInfo.CurrentCulture;
                        OdbcDataAdapter.Fill(dataSet);
                        returnValue = dataSet;
                        break;

                    case ResultType.DataTable:
                        OdbcDataAdapter = new OdbcDataAdapter(OdbcCommand);
                        dataTable = new DataTable();
                        dataTable.Locale = CultureInfo.CurrentCulture;
                        OdbcDataAdapter.Fill(dataTable);
                        returnValue = dataTable;
                        break;

                    case ResultType.NonQuery:
                        returnValue = OdbcCommand.ExecuteNonQuery(); break;

                    case ResultType.DataReader:
                        returnValue = OdbcCommand.ExecuteReader(CommandBehavior.CloseConnection); break;

                    case ResultType.Scalar:
                        returnValue = OdbcCommand.ExecuteScalar(); break;

/*
                    case ResultType.XmlReader:
                        returnValue = OdbcCommand.ExecuteXmlReader(); break;
*/
                }
            }
			catch (OdbcException ex)
            {
				EventLog.WriteEntry("Application", connectionString, EventLogEntryType.Error);
				EventLog.WriteEntry("Application", strCommandTimeOut, EventLogEntryType.Error);
				EventLog.WriteEntry("Application", cmdText, EventLogEntryType.Error);
                EventLog.WriteEntry("Application", cmdLine, EventLogEntryType.Error);
				EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error);
				EventLog.WriteEntry
				(
					"Application",
					String.Format("Inner exception: {0}", ex.InnerException),
					EventLogEntryType.Error
				);
				throw;
            }
            catch (Exception ex)
            {
				EventLog.WriteEntry("Application", connectionString, EventLogEntryType.Error);
				EventLog.WriteEntry("Application", strCommandTimeOut, EventLogEntryType.Error);
				EventLog.WriteEntry("Application", cmdText, EventLogEntryType.Error);
				EventLog.WriteEntry("Application", cmdLine, EventLogEntryType.Error);
                EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error);
				EventLog.WriteEntry
				(
					"Application",
					String.Format("Inner exception: {0}", ex.InnerException),
					EventLogEntryType.Error
				);
                throw;
            }
            finally
            {
                if (resultType != ResultType.DataReader)
                {
                    OdbcConnection.Close();
                }
            }
            return (returnValue);
        }

        public static T DatabaseCommand<T>
        (
            string cmdText,
            string connectionString,
			CommandType commandType,
            Collection<OdbcParameter> OdbcParameterCollection
        )
        {
            DataSet dataSet;
            DataTable dataTable;
            Object returnValue = null;
            OdbcCommand OdbcCommand;
            OdbcConnection OdbcConnection = null;
            OdbcDataAdapter OdbcDataAdapter;

            Type typeOfT = typeof(T);
            string typeT = typeOfT.ToString();

            if (String.IsNullOrEmpty(connectionString))
            {
                connectionString = ConnectionStringDefault;
            }
            try
            {
                OdbcConnection = new OdbcConnection(connectionString);
                OdbcConnection.Open();
                OdbcCommand = new OdbcCommand(cmdText, OdbcConnection);
                OdbcCommand.CommandType = commandType;
                if (CommandTimeout != null)
                {
                    OdbcCommand.CommandTimeout = (int)CommandTimeout;
                }
                if (OdbcParameterCollection != null && OdbcParameterCollection.Count > 0)
                {
                    foreach (OdbcParameter OdbcParameter in OdbcParameterCollection)
                    {
                        OdbcCommand.Parameters.Add(OdbcParameter);
                    }
                }

                switch (typeT)
                {
                    case "System.Data.DataSet":
                        OdbcDataAdapter = new OdbcDataAdapter(OdbcCommand);
                        dataSet = new DataSet();
                        dataSet.Locale = CultureInfo.CurrentCulture;
                        OdbcDataAdapter.Fill(dataSet);
                        returnValue = dataSet;
                        break;

                    case "System.Data.DataTable":
                        OdbcDataAdapter = new OdbcDataAdapter(OdbcCommand);
                        dataTable = new DataTable();
                        dataTable.Locale = CultureInfo.CurrentCulture;
                        OdbcDataAdapter.Fill(dataTable);
                        returnValue = dataTable;
                        break;

                    case "System.Data.IDataReader":
                        returnValue = OdbcCommand.ExecuteReader(CommandBehavior.CloseConnection);
                        break;
                }
            }
			catch (OdbcException ex)
            {
                EventLog.WriteEntry("WordEngineering", ex.Message, EventLogEntryType.Error);
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("WordEngineering", ex.Message, EventLogEntryType.Error);
                throw;
            }
            finally
            {
                if (typeOfT != typeof(IDataReader))
                {
                    OdbcConnection.Close();
                }
            }
            return (T)returnValue;
        }

        public static OdbcConnection GainConnection()
        {
            return GainConnection(null);
        }

        public static OdbcConnection GainConnection(string connectionString)
        {
            OdbcConnection OdbcConnection = null;

            if (String.IsNullOrEmpty(connectionString))
            {
                connectionString = ConnectionStringDefault;
            }
            try
            {
                OdbcConnection = new OdbcConnection(connectionString);
                OdbcConnection.Open();
            }
            catch (OdbcException ex)
            {
                EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error);
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error);
                throw;
            }
            return OdbcConnection;
        }

        public static string ReadConnectionString(string connectionStringName)
        {
            string connectionString = null;
            if (!String.IsNullOrEmpty(connectionStringName))
            {
                connectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
            }
            else
            {
                connectionString = ConnectionStringMaster;
            }
            return connectionString;
        }

        static DataCommand()
        {
            string commandTimeout = ConfigurationManager.AppSettings["commandTimeout"];
            if (commandTimeout != null)
            {
                CommandTimeout = Convert.ToInt32(commandTimeout, CultureInfo.InvariantCulture);
            }
            ConnectionStringNameDefault = ConfigurationManager.AppSettings["connectionStringNameDefault"];
			/*
            if (!String.IsNullOrEmpty(ConnectionStringDefault))
            {
                ConnectionStringDefault = ConfigurationManager.ConnectionStrings[ConnectionStringNameDefault].ConnectionString;
            }
            else            
            {
                ConnectionStringDefault = ConnectionStringMaster;
            }
			*/
			ConnectionStringDefault = String.IsNullOrEmpty(ConnectionStringNameDefault)
									?	ConnectionStringMaster
									:	ConfigurationManager.ConnectionStrings[ConnectionStringNameDefault].ConnectionString
									;
			
			EventLog.WriteEntry
			(
				"Application",
				ConnectionStringDefault,
				EventLogEntryType.Error
			);
			
        }
        #endregion

        #region Enums
        public enum ResultType
        {
            DataSet,
            DataTable,
            NonQuery,
            DataReader,
            Scalar,
            XmlReader
        }
        #endregion

        #region Fields
        public static readonly int? CommandTimeout;
        public static readonly string ConnectionStringDefault;
        public const string ConnectionStringMaster = "Driver={SQL Server};Server=(local);Database=WordEngineering;Trusted_Connection=Yes;";
        public static readonly string ConnectionStringNameDefault;
		public const string ContextConnection = "Context Connection = true;";
		public const string OdbcInjection = "SELECT * FROM WordEngineering..HisWord WHERE Word = '" +
			"' ; DROP DATABASE junk";
        #endregion
    }
    #endregion
}
