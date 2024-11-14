using System;
using System.Text;
using System.Xml;

namespace WordEngineering
{
 /// <summary>UtilityDateTimeXml.</summary>
 public class UtilityDateTimeXml
 {

  /// <summary>The command-line argument for the start datetime.</summary>
  public const int CommandLineArgumentDateTimeStart = 0;

  /// <summary>The command-line argument for the end datetime.</summary>
  public const int CommandLineArgumentDateTimeEnd = 1;

  ///<summary>The entry point for the application.</summary>
  ///<param name="argv">
  /// The first argument is the start datetime in the XML DateTime Format (xs:dateTime), for example, 2003-03-28T19:49:00.0000000-08:00.
  /// The second argument is the start datetime in the XML DateTime Format (xs:dateTime), for example, 2003-04-17T10:24:00.0000000-08:00.
  ///</param>
  public static void Main
  (
   string[] argv
  )
  {
   int       commandLineArgumentTotal = argv.Length;
   string    exceptionMessage         = null;
   string    stringEnd                = null;
   string    stringStart              = null;
   TimeSpan  timeSpanStartEnd                 = new TimeSpan();
   
   if ( commandLineArgumentTotal > CommandLineArgumentDateTimeStart )
   {
    stringStart = argv[CommandLineArgumentDateTimeStart];
   }//if ( commandLineArgumentTotal > CommandLineArgumentDateTimeStart )
   
   if ( commandLineArgumentTotal > CommandLineArgumentDateTimeEnd )
   {
    stringEnd = argv[CommandLineArgumentDateTimeEnd];
   }//if ( commandLineArgumentTotal > CommandLineArgumentDateTimeStart )
       
   TimeSpan( stringStart, stringEnd, ref timeSpanStartEnd, ref exceptionMessage );
   
   if ( exceptionMessage == null )
   {
    System.Console.WriteLine
    (
     "Days: {0} | Hours: {1} | Minutes: {2}", 
     timeSpanStartEnd.TotalDays, 
     timeSpanStartEnd.TotalHours, 
     timeSpanStartEnd.TotalMinutes
    );
   } 
  }//public static void Main

  ///<summary>The Timespan.</summary>
  ///<param name="stringStart">The start datetime in the XML DateTime Format (xs:dateTime), for example, 2003-03-28T19:49:00.0000000-08:00.</param>
  ///<param name="stringEnd">The end datetime in the XML DateTime Format (xs:dateTime), for example, 2003-03-28T19:49:00.0000000-08:00.</param>
  ///<param name="timeSpanStartEnd">The timespan.</param>
  ///<param name="exceptionMessage">The exception message.</param>
  public static void TimeSpan
  (
       string   stringStart,
       string   stringEnd,
   ref TimeSpan timeSpanStartEnd,
   ref string   exceptionMessage
  )
  {

   DateTime      dateTimeStart  = System.DateTime.Now;
   DateTime      dateTimeEnd    = System.DateTime.Now;
   StringBuilder stringBuilder  = null;

   try
   {
    dateTimeStart = XmlConvert.ToDateTime( stringStart );
    dateTimeEnd = XmlConvert.ToDateTime( stringEnd );    
   }
   catch( XmlException xmlException ) 
   {
    System.Console.WriteLine
    (
     "Exception Message: {0} | Object Line: {1} | Position: {2)", 
     xmlException.Message,
     xmlException.LineNumber, 
     xmlException.LinePosition 
    );
    stringBuilder = new StringBuilder("Exception Message: ");
    stringBuilder.Append( xmlException.Message );
    stringBuilder.Append( " | Object Line: " );
    stringBuilder.Append( xmlException.LineNumber );
    stringBuilder.Append( " | Position: " ); 
    stringBuilder.Append( xmlException.LinePosition );
    exceptionMessage = stringBuilder.ToString();
   }
   catch ( Exception exception )
   { 
    exceptionMessage = exception.Message;
    System.Console.WriteLine("Exception: {0}", exception.Message);
   }	
   
   TimeSpan 
   ( 
        dateTimeStart, 
        dateTimeEnd, 
    ref timeSpanStartEnd,
    ref exceptionMessage 
   );
   
  }//public static void TimeSpan 

  ///<summary>The Timespan.</summary>
  ///<param name="dateTimeStart">The start datetime.</param>
  ///<param name="dateTimeEnd">The end datetime.</param>
  ///<param name="timeSpanStartEnd">The timespan.</param>
  ///<param name="exceptionMessage">The exception message.</param>  
  public static void TimeSpan
  (
        DateTime dateTimeStart,
        DateTime dateTimeEnd,
    ref TimeSpan timeSpanStartEnd,
    ref string   exceptionMessage 
  )
  {
   try
   {
    timeSpanStartEnd = dateTimeEnd - dateTimeStart;
   }
   catch ( Exception exception )
   { 
    exceptionMessage = exception.Message;
    System.Console.WriteLine("Exception: {0}", exception.Message);
   }	
  }//public static void TimeSpan
  
 }//public class UtilityDateTimeXml
}//WordEngineering