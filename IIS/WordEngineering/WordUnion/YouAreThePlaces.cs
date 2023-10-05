using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Security;
using System.Text;

using InformationInTransit.DataAccess;
using InformationInTransit.UserInterface;

/*
	2015-01-05 Created. http://www.codeproject.com/Articles/30705/C-CSV-Import-Export
	2015-01-05			http://msdn.microsoft.com/en-us/library/system.data.datatablereader.getschematable%28v=vs.110%29.aspx
*/
namespace WordEngineering
{
    /// <summary>YouAreThePlacesArguments</summary>
    public partial class YouAreThePlacesArguments
    {
        public String sqlQuery = null;
        public String filenameCommaSeparatedValuesCSV = null;
		public String separator = ",";
		public bool headerRow = true;
    }

    /// <summary>YouAreThePlaces.</summary>
    public static partial class YouAreThePlaces
    {
        ///<summary>The entry point for the application.</summary>
        public static void Main
        (
			string[] argv
        )
        {
            YouAreThePlacesArguments parsedArgs = new YouAreThePlacesArguments();
			bool parseCommandLineArguments = CommandLine.Parser.ParseArgumentsWithUsage(argv, parsedArgs);
            if (parseCommandLineArguments == false) { return; }
            YouAreThePlacesXml(parsedArgs);
        }
		
		///<summary>GenerateContent</summary>
		public static void GenerateContent
		(
			SqlDataReader dataReader,
			YouAreThePlacesArguments parsedArgs
		)
		{
			DataTable schemaTable = dataReader.GetSchemaTable();
			StringBuilder sb = null;
			try
			{
				using (StreamWriter sw = new StreamWriter(parsedArgs.filenameCommaSeparatedValuesCSV))
				{
					sb = new StringBuilder();

					if ( parsedArgs.headerRow )
					{
						for (int rowIndex = 0; rowIndex < schemaTable.Rows.Count; rowIndex++)
						{
							sb.Append( schemaTable.Rows[rowIndex]["ColumnName"] );	
							if (rowIndex < schemaTable.Rows.Count - 1)
							{
								sb.Append(parsedArgs.separator);
							}
						}
						sw.WriteLine(sb);
					}
					
					while (dataReader.Read())
					{
						sb = new StringBuilder();
						for (int columnIndex = 0; columnIndex < dataReader.FieldCount; columnIndex++)
						{
							sb.Append( dataReader[columnIndex] );
							if (columnIndex < dataReader.FieldCount - 1)
							{
								sb.Append(parsedArgs.separator);
							}
						}
						sw.WriteLine(sb);
					}
				}
			}	
			catch(Exception ex)
			{
				System.Console.WriteLine(ex.Message);
			}
		}
		
        /// <summary>YouAreThePlacesXml</summary>
        public static void YouAreThePlacesXml
        (
			YouAreThePlacesArguments parsedArgs
        )
        {
    		SqlDataReader dataReader = (SqlDataReader) DataCommand.DatabaseCommand
			(
				parsedArgs.sqlQuery,
				CommandType.Text,
				DataCommand.ResultType.DataReader
			);
			GenerateContent(dataReader, parsedArgs);
        }
    }
}
