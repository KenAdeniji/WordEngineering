using System;

namespace WordEngineering
{
 ///<summary>Utility DateTime Parse.</summary>
 public class UtilityDateTimeParse
 {
  ///<summary>DateTime Parse.</summary>
  public static DateTime DateTimeParse
  (
   string stringDateTime
  )
  {
   int dateTimeYear; 
   int dateTimeMonth; 
   int dateTimeDay; 
   int dateTimeHour; 
   int dateTimeMinute; 
   int dateTimeSecond; 
   
   int stringDateTimeLength = stringDateTime.Length;

   DateTime dateTime;   

   stringDateTime  =  stringDateTime.PadRight(14, '0');
   dateTimeYear    =  System.Convert.ToInt32( stringDateTime.Substring(  0, 4 ) ); //Year
   dateTimeMonth   =  System.Convert.ToInt32( stringDateTime.Substring(  4, 2 ) ); //Month
   dateTimeDay     =  System.Convert.ToInt32( stringDateTime.Substring(  6, 2 ) ); //Day
   dateTimeDay     =  System.Convert.ToInt32( stringDateTime.Substring(  6, 2 ) ); //Day
   dateTimeHour    =  System.Convert.ToInt32( stringDateTime.Substring(  8, 2 ) ); //Hour
   dateTimeMinute  =  System.Convert.ToInt32( stringDateTime.Substring( 10, 2 ) ); //Minute
   dateTimeSecond  =  System.Convert.ToInt32( stringDateTime.Substring( 12, 2 ) ); //Second
   dateTime        =  new DateTime( dateTimeYear, dateTimeMonth, dateTimeDay, dateTimeHour, dateTimeMinute, dateTimeSecond );
   return ( dateTime );
  }//public static DateTime DateTimeParse
 }//public class UtilityDateTimeParse
}//namespace WordEngineering  
