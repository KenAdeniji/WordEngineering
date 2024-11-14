/*
 200303251559 Created.
 200303251702 UtilityEventLogRelease200303251702.cs
 200303251713 UtilityEventLogRelease200303251713.cs
*/

using System;
using System.ComponentModel;
using System.Configuration.Install;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Web;

namespace WordEngineering
{
 /// <summary>The Event Log Utility.</summary>
 /// <remarks>
 ///  PRB: "Requested Registry Access Is Not Allowed" Error Message When ASP.NET Application Tries to Write New EventSource in the EventLog  http://support.microsoft.com/default.aspx?scid=kb;en-us;329291
 ///</remarks>
 [RunInstaller(true)]
 public class UtilityEventLog
 {

  /// <summary>The entry point for the application.</summary>
  /// <param name="argv">A list of command line arguments</param>
  public static void Main
  (
   string[] argv
  )
  {
   string logName = "Application";
   string machineName = ".";
   if (argv.Length > 0) { logName = argv[0]; }
   if (argv.Length > 1) { machineName = argv[1]; }
   EventLog eventLog = new EventLog( logName, machineName );
   foreach(EventLogEntry eventLogEntry in eventLog.Entries )
   {
    System.Console.WriteLine(eventLogEntry.Message);
   }
  }//public static void Main

  /// <summary>Stub</summary>
  public static void Stub()
  {
   UtilityEventLog.WriteEntry
   (
    null,          //Log name
    null,          //Machine name
    null,          //Source
    null,          //Message
    EventLogEntryType.Information
   );
  }//public static void Stub()

  /// <summary>WriteEntry</summary>
  public static void WriteEntry
  (
   string  message
  )
  {
   WriteEntry
   (
    null, //logName
    null, //machineName
    null, //source
    message,
    EventLogEntryType.Error
   );  	
  }
  
  /// <summary>Write entry.</summary>
  /// <param name="logName">The event log name.</param>
  /// <param name="machineName">The name of the event log.</param>
  /// <param name="sourceName">The name of the event source.</param>  
  /// <param name="message">The message text.</param>
  /// <param name="eventLogEntryType">The event log entry type, for example, Error, FailureAudit, Information, SuccessAudit, Warning.</param>  
  public static void WriteEntry
  (
   string                  logName,
   string                  machineName,
   string                  sourceName,
   string                  message,
   EventLogEntryType       eventLogEntryType
  )
  {
   HttpContext              httpContext              =  HttpContext.Current;
   EventLog                 eventLog                 =  null;
   EventSourceCreationData  eventSourceCreationData  =  null;

   if ( string.IsNullOrEmpty( logName ) )
   {
    logName = "Application";
   }

   if ( string.IsNullOrEmpty( machineName ) )
   {
    machineName = Environment.MachineName;
   }

   if ( string.IsNullOrEmpty( sourceName ) )
   {
    /*
    sourceName  =  System.Reflection.Assembly.GetEntryAssembly().Location;  //BrianDela.com
    sourceName  =  System.Windows.Forms.Application.ExecutablePath;
    sourceName  =  System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToString(); 
    sourceName  =  System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
    */
    sourceName  =  System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase;
   }

   // Create the source, if it does not already exist.
   if ( !EventLog.SourceExists (sourceName, machineName ) )
   {
    if ( httpContext != null )
    {
     return;
    }
    //EventLog.CreateEventSource( source, logName, machineName );
    eventSourceCreationData  =  new EventSourceCreationData( sourceName, logName );
    eventSourceCreationData.MachineName = machineName;
    EventLog.CreateEventSource( eventSourceCreationData );
   }//if (!EventLog.SourceExists(source))
   
   // Write an entry to the event log.
   eventLog  =  new EventLog( logName, machineName, sourceName );
   eventLog.WriteEntry( message, eventLogEntryType );
  }//public static void WriteEntry
  
  /// <summary>Write the OleDb Error Collection.</summary>
  public static string WriteEntryOleDbErrorCollection
  (
   OleDbException  oleDbException
  ) 
  {
   string         exceptionMessage  =  null;
   StringBuilder  sb                =  null;
   
   sb  =  new StringBuilder();
  
   for (int exceptionErrorsCount = 1; exceptionErrorsCount <= oleDbException.Errors.Count; ++exceptionErrorsCount )
   {
    exceptionMessage = string.Format
    (
     "[{0}] Message: {1} | Native: {2} | Source: {3} | SQLState: {4}",
     exceptionErrorsCount,
     oleDbException.Errors[ exceptionErrorsCount ].Message,
     oleDbException.Errors[ exceptionErrorsCount ].NativeError,
     oleDbException.Errors[ exceptionErrorsCount ].Source,
     oleDbException.Errors[ exceptionErrorsCount ].SQLState     
    );
    sb.Append( exceptionMessage );
    sb.Append( Environment.NewLine );
   }//for (int exceptionErrorsCount = 1; exceptionErrorsCount <= oleDbException.Errors.Count; ++exceptionErrorsCount )
   WriteEntry( sb.ToString() );
   return( sb.ToString() );
  }//WriteEntryOleDbErrorCollection(OleDbException oleDbException, StringBuilder sb) 
 
  static UtilityEventLog()
  {

  }//static UtilityEventLog()

 }//public class UtilityEventLog
}//namespace WordEngineering