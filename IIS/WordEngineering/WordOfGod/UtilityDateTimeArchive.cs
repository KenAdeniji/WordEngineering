using System;

namespace WordEngineering
{
 ///<summary>UtilityDateTime</summary>
 ///<remarks>Subject: How to set System Date in C# 8/9/2005 2:47 AM PST By: Willy Denoyette [MVP] In: microsoft.public.dotnet.languages.csharp</remarks>
 public class UtilityDateTime
 {
  /// <summary>GetSystemTime</summary>
  [System.Runtime.InteropServices.DllImport("kernel32", SetLastError = true)]
  public static extern bool GetSystemTime( out SYSTEMTIME  systemTime );
  
  /// <summary>SetSystemTime</summary>
  [System.Runtime.InteropServices.DllImport("kernel32", SetLastError = true)]
  public static extern bool SetSystemTime( ref SYSTEMTIME  systemTime );
  
  /// <summary>SYSTEMTIME</summary>
  public struct SYSTEMTIME 
  {
   internal short wYear;
   internal short wMonth;
   internal short wDayOfWeek;
   internal short wDay;
   internal short wHour;
   internal short wMinute;
   internal short wSecond;
   internal short wMilliseconds;
  }

  /// <summary>Main()</summary>
  public static void Main
  ( 
   string[] argv
  )
  {
   Stub();
  }//public static void Main

  /// <summary>Stub()</summary>
  public static void Stub()
  {

  }//public static void Stub()

  /// <summary>SetDateTime</summary>
  public static void SetDateTime()
  {
   SYSTEMTIME  systemTime;
   
   if ( GetSystemTime( out systemTime ) )
   {
    systemTime.wHour = 13; //Beware SYSTEMTIME is in UTC time format!!!!!
    if ( !SetSystemTime( ref systemTime ) )
    {
     System.Console.WriteLine
     ( 
      "SetSystemTime failed: {0}", 
      System.Runtime.InteropServices.Marshal.GetLastWin32Error() 
     );
    }//if ( !SetSystemTime( ref systemTime ) )
   }//if ( GetSystemTime( out systemTime ) )
   else
   {
    System.Console.WriteLine
    ( 
     "GetSystemTime failed: {0}", 
     System.Runtime.InteropServices.Marshal.GetLastWin32Error() 
    );
   }
  }//public static void SetDateTime()
  
  ///<summary>DateOfTheMonth()</summary>
  ///<remarks>Subject: How to get the last date of the month? 5/13/2005 6:26 PM PST By: William Stacey [MVP] In: microsoft.public.dotnet.languages.csharp</remarks>
  public static void DateOfTheMonth
  (
   ref DateTime  dateTime,
   out DateTime  dateTimeFirstDayOfThisMonth,
   out DateTime  dateTimeFirstDayOfNextMonth,
   out DateTime  dateTimeLastDayOfThisMonth
  )
  {
   dateTimeFirstDayOfThisMonth  =  dateTime.Subtract( TimeSpan.FromDays( dateTime.Day - 1 ) );
   dateTimeFirstDayOfNextMonth  =  dateTimeFirstDayOfThisMonth.AddMonths(1);
   dateTimeLastDayOfThisMonth   =  dateTimeFirstDayOfNextMonth.Subtract( TimeSpan.FromDays(1) );
   System.Console.WriteLine
   (
    "DateTime: {0} | First Day of the Month: {1} | First Day of the Next Month: {2} | Last Day of the Month: {3}",
    dateTime,
    dateTimeFirstDayOfThisMonth,
    dateTimeFirstDayOfNextMonth,
    dateTimeLastDayOfThisMonth
   ); 
  }//public static void DateOfTheMonth()
  
  ///<summary>LastDayOfMonth()</summary>
  public static DateTime LastDayOfMonth( DateTime presentDayOfTheMonth )
  {
   DateTime firstDayOfTheMonth  =  new DateTime( presentDayOfTheMonth.Year, presentDayOfTheMonth.Month, 1);
   DateTime lastDayOfTheMonth   =  firstDayOfTheMonth.AddMonths(1).AddDays(-1);
   return   ( lastDayOfTheMonth );
  }

  ///<summary>LastDayOfTheMonth()</summary>
  public static DateTime LastDayOfTheMonth( DateTime presentDayOfTheMonth )
  {
   int  month  =  presentDayOfTheMonth.Month;
   int  year   =  presentDayOfTheMonth.Year;
   
   DateTime lastDayOfTheMonth   =  new DateTime( year, month, DateTime.DaysInMonth( year, month ) );
   return   ( lastDayOfTheMonth );
  }
   	
 }//public class UtilityDateTime
}//namespace WordEngineering