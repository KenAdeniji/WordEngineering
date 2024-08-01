using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;

using Newtonsoft.Json;

/*
	2024-07-30T21:50:00...2024-07-30T23:34:00	Created. JSON file export.
	2024-07-31T15:18:00...2024-07-31T15:25:00	Coding.
	2024-07-31T15:47:00...2024-07-31T15:49:00	Documentation.
		2024-07-31T15:47:00						Each method, now only does one thing. 
												Upgraded and added XML file export.
		2024-07-31T15:49:00						Offer only one functionality.
*/
    public class ItMustBeAbleToWorkAsAWholeAndAsItsEntireSelfArguments
    {
		[Argument(ArgumentType.AtMostOnce, HelpText="If there is no connection string, use default.")]
        public String DatabaseConnectionString = "";

		[Argument(ArgumentType.AtMostOnce, HelpText="If there is no JSON, ignore.")]
        public String JSON = "";

		[Argument(ArgumentType.AtMostOnce, HelpText="If there is no query, ignore.")]
        public String SQL = "";

		[Argument(ArgumentType.AtMostOnce, HelpText="If there is no XML, ignore.")]
        public String XML = "";
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
			
			DataSet dataSet = DatabaseQuery
			(
				parsedArgs.SQL,
				parsedArgs.DatabaseConnectionString
			);	

			FileWrite
			( 
				dataSet,
				parsedArgs
			);
		}
		
        public static DataSet DatabaseQuery
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
		
		public static void FileWrite
		(
			DataSet dataSet,
			ItMustBeAbleToWorkAsAWholeAndAsItsEntireSelfArguments parsedArgs
		)
		{
			if ( !String.IsNullOrEmpty( parsedArgs.JSON ) )
			{
				string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
				File.WriteAllText(parsedArgs.JSON, json);
			}

			if ( !String.IsNullOrEmpty( parsedArgs.XML ) )
			{
				dataSet.WriteXml(parsedArgs.XML);
			}
		}	
		
		public const String DatabaseConnectionString = "Server=(local);Database=master;Trusted_Connection=Yes;";
	}

