using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Security;
using System.Text;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.UserInterface;

/*
	2014-12-27 Created. http://msdn.microsoft.com/en-us/library/8bh11f1k.aspx
*/
namespace WordEngineering
{
    /// <summary>GrowingWithSchoolArguments</summary>
    public partial class GrowingWithSchoolArguments
    {
        public bool date = false;
        public String sqlQuery = null;
        public String filenameJson = null;
    }

    /// <summary>GrowingWithSchool.</summary>
    public static partial class GrowingWithSchool
    {
        ///<summary>The entry point for the application.</summary>
        public static void Main
        (
			string[] argv
        )
        {
            GrowingWithSchoolArguments parsedArgs = new GrowingWithSchoolArguments();
			bool parseCommandLineArguments = CommandLine.Parser.ParseArgumentsWithUsage(argv, parsedArgs);
            if (parseCommandLineArguments == false) { return; }
            GrowingWithSchoolXml(parsedArgs);
        }
		
        /// <summary>GrowingWithSchoolXml</summary>
        public static string GrowingWithSchoolXml
        (
			GrowingWithSchoolArguments parsedArgs
        )
        {
    		DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
			(
				parsedArgs.sqlQuery,
				CommandType.Text,
				DataCommand.ResultType.DataSet
			);
			string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
			System.IO.File.WriteAllText(parsedArgs.filenameJson, json);
			return json;
        }
    }
}
