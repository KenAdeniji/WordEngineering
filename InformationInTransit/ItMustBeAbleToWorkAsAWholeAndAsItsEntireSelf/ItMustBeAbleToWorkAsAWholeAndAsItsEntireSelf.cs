using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;

using Newtonsoft.Json;

/*
	2024-07-30T21:50:00	Created.
*/
    public class ItMustBeAbleToWorkAsAWholeAndAsItsEntireSelfArguments
    {
		[Argument(ArgumentType.AtMostOnce, HelpText="If there is no connection string, use default.")]
        public String DatabaseConnectionString = "";

		[Argument(ArgumentType.AtMostOnce, HelpText="If there is no JSON, ignore.")]
        public String JSON = "";

		[Argument(ArgumentType.AtMostOnce, HelpText="If there is no query, ignore.")]
        public String SQL = "";
    }
	
	public partial class ItMustBeAbleToWorkAsAWholeAndAsItsEntireSelf
	{
		public static void Main(string[] argv)
		{
            ItMustBeAbleToWorkAsAWholeAndAsItsEntireSelfArguments parsedArgs = new ItMustBeAbleToWorkAsAWholeAndAsItsEntireSelfArguments();
            bool argumentsParser = Parser.ParseArgumentsWithUsage(argv, parsedArgs);

			if (argumentsParser == false)
			{
				return;
			}
			
			Query(parsedArgs);
			
			return;
		}
		
        public static DataSet DatabaseCommand
        (
            string cmdText,
            string connectionString
        )
        {
            DataSet dataSet;
            SqlCommand sqlCommand;
            SqlConnection sqlConnection = null;
            SqlDataAdapter sqlDataAdapter;

            if (String.IsNullOrEmpty(connectionString))
            {
                connectionString = DatabaseConnectionString;
            }
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                sqlCommand = new SqlCommand(cmdText, sqlConnection);
                sqlCommand.CommandTimeout = 300;

				sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				dataSet = new DataSet();
				sqlDataAdapter.Fill(dataSet);
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
                sqlConnection.Close();
            }

            return (dataSet);
        }
		
		public static void Query(ItMustBeAbleToWorkAsAWholeAndAsItsEntireSelfArguments parsedArgs)
		{
			DataSet dataSet = DatabaseCommand
			(
				parsedArgs.SQL,
				parsedArgs.DatabaseConnectionString
			);	
			
			if ( !String.IsNullOrEmpty(parsedArgs.JSON))
			{
				string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
				File.WriteAllText(parsedArgs.JSON, json);
			}
		}	
		
		public const String DatabaseConnectionString = "Server=(local);Database=master;Trusted_Connection=Yes;";
	}

