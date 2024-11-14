/*
20040730 212nd day create.
*/
using System;
using System.Web;

namespace WordEngineering
{
 /// <summary>UtilityDebug.</summary>
 public class UtilityDebug
 {

  ///<summary>The entry point for the application.</summary>
  ///<param name="argv">Command-line arguments.</param>
  public static void Main
  (
   string[] argv
  )
  {
    
  }//public static void Main()

  ///<summary>Write.</summary>
  public static void Write
  (
   object debugMessage
  ) 
  {
   HttpContext  httpContext = HttpContext.Current;
   
   #if (DEBUG)
    if ( debugMessage != null )
    {
     if ( httpContext == null )
     {
      System.Console.WriteLine( debugMessage );
     }//if ( httpContext == null )
     else
     {
      httpContext.Response.Write( debugMessage );
     }//else 
    }//if ( debugMessage != null ) 
   #endif
  }//public static void Write()

 }//public class UtilityDebug.
}//namespace WordEngineering. 
