using System;
using System.Globalization;

namespace WordEngineering
{
 ///<summary>UtilityCulture</summary>
 public class UtilityCulture
 {

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
   CultureInformation();
  }//public static void Stub()

  ///<summary>CultureInformation()</summary>
  public static void CultureInformation()
  {
   foreach( CultureInfo cultureInfo in CultureInfo.GetCultures(CultureTypes.AllCultures ) )
   {
    System.Console.WriteLine( cultureInfo.Name + " (" + cultureInfo.NativeName + ")" );
   }//foreach( CultureInfo ci in CultureInfo.GetCultures(CultureTypes.AllCultures ) )
  	
  }//public static void CultureInformation()
	
 }//public class UtilityCulture
 
}//namespace WordEngineering