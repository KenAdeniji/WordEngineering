#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Collections.ObjectModel;
using System.Globalization;
#endregion

namespace InformationInTransit.ProcessLogic
{
    #region EventLogHelper definition
    public static partial class EventLogHelper
    {
        public static void Main(string[] argv)
        {
            BackupEventLog();
			MonitorEventLogChanges(null, null);
            System.Console.ReadLine();
        }

		public static void BackupEventLog(params object[] parameter)
		{
			String exportLogPath = null;
			String logName = null;
			
			if (parameter.Length < 1)
			{
				logName = LogName;
			}

			if (parameter.Length < 2)
			{
				exportLogPath = ExportLogPath;
			}
			try
			{
				EventLogSession els = new EventLogSession();
				els.ExportLogAndMessages
				(
					logName,			        //  Log Name to archive
					PathType.LogName,   		//  Type of Log
					"*",                        //  Query selecting all events
					exportLogPath,			    //  Exported Log Path(log created by this operation) 
					false,                      //  Stop the archive if the query is invalid
					CultureInfo.CurrentCulture	//  Culture to archive the events in
				);
				Console.WriteLine
				(
					ExportLogFormat,
					logName,
					exportLogPath
				);
			}
			catch (UnauthorizedAccessException e)
			{
				//  requires elevation of privilege
				Console.WriteLine("You do not have the correct permissions. " +
					"Try running with administrator privileges. " + e.ToString());
			}
			catch (EventLogNotFoundException e)
			{
				//  The target log may not exist
				Console.WriteLine(e.ToString());
			}
			catch (EventLogException e)
			{
				// The target file may already exist
				Console.WriteLine(e.ToString());
			}
		}
		
        public static void MonitorEventLogChanges
        (
                string logName, 
                string source
        )
        {
            if (String.IsNullOrEmpty(logName))
            {
                logName = "Security";
            }
            if (String.IsNullOrEmpty(source))
            {
                source = "Security";
            }
            EventLog eventLog = new EventLog
            (
                logName, 
                ".", //Machine name
                source
            );
            eventLog.EntryWritten += new EntryWrittenEventHandler(OnEntryWritten);
            eventLog.EnableRaisingEvents = true;
        }

        public static void OnEntryWritten(object source, EntryWrittenEventArgs e)
        {
            System.Console.WriteLine
            (
                e.Entry.Message
            );
        }

        public static System.Linq.IOrderedEnumerable<EventLogEntry> Query
        (
            string logName,
            string machineName
        )
        {
            EventLog eventLog = new EventLog(logName, machineName);
            System.Linq.IOrderedEnumerable<EventLogEntry> eventLogEntryEnumerable =
                from EventLogEntry eventLogEntry in eventLog.Entries
                where eventLogEntry.Source.Equals("MSSQLSERVER")
                orderby eventLogEntry.TimeGenerated descending
                select eventLogEntry;
            return eventLogEntryEnumerable;
        }
		
		public const string LogName = "Application";
		public const string ExportLogFormat = "Exported and Archived the {0} log to the {1} log file.";
		public const string ExportLogPath = @"Log.evtx";
    }
    #endregion
}

