using System;
using Microsoft.Win32;

namespace WordEngineering
{
 ///<summary>UtilityDNS.</summary>
 ///<remarks>UtilityDNS.</remarks>
 public class UtilityDNS
 {
  
  ///<summary>The entry point for the application.</summary>
  ///<param name="argv">A list of command line arguments</param>
  public static void Main
  (
    String[] argv
  )
  {
   DNSServerList();
  }//public static void Main()

  ///<summary>DNSServerList.</summary>
  public static void DNSServerList()
  {
   UtilityRegistry.DNSServerList();
  }//public static void DNSServerList()
  
 }//public class UtilityDNS
}//namespace WordEngineering