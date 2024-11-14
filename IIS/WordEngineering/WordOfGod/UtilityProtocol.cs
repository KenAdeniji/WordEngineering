using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Management;
using System.Security;
using System.Net;
using System.Net.Mail; //2.0
using System.Net.Mime;
using System.Net.Sockets;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Mail; //1.0
using System.Web.Caching;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Xsl;

namespace WordEngineering
{

 ///<summary>UtilityProtocol</summary>
 ///<remarks>
 ///	2019-08-08T15:00:00 @ precede .
 ///	PATH = %SystemRoot%\system32;%SystemRoot%;%SystemRoot%\System32\Wbem;%SYSTEMROOT%\System32\WindowsPowerShell\v1.0\;%SYSTEMROOT%\System32\OpenSSH\;C:\Program Files (x86)\ATI Technologies\ATI.ACE\Core-Static;D:\Program Files (x86)\Microsoft SQL Server\160\Tools\Binn\;D:\Program Files\Microsoft SQL Server\160\Tools\Binn\;D:\Program Files\Microsoft SQL Server\Client SDK\ODBC\170\Tools\Binn\;D:\Program Files\Microsoft SQL Server\160\DTS\Binn\;D:\Program Files (x86)\Microsoft SQL Server\160\DTS\Binn\;C:\Windows\Microsoft.NET\Framework64\v4.0.30319;C:\Windows\Microsoft.NET\Framework64\v3.5;C:\Windows\Microsoft.NET\Framework64\v2.0.50727;C:\Program Files\dotnet\;
 ///	regsvr32 UtilityProtocol.dll
 ///</remarks>
 public class UtilityProtocol
 {

  /// <summary>Constructor.</summary>
  public UtilityProtocol()
  {

  }
  
  ///<summary>The entry point for the application.</summary>
  ///<param name="argv">A list of command line arguments</param>
  public static void Main
  (
   String[] argv
  )
  {
		System.Console.WriteLine(PrefixProtocol(argv[0]));
  }

  ///<summary>PrefixProtocol</summary>
  public static string PrefixProtocol
  (
   string URI
  ) 
  {
   if ( URI.IndexOf('@') > -1 && URI.IndexOf('@') < URI.IndexOf('.') )
   {
    return("mailto:" + URI);
   }
   else if ( URI.IndexOf(':') < 0 )
   {
    return("http://" + URI);
   }
   else 
   {
    return(URI);
   }
  }
  
  static UtilityProtocol()
  {
  }
  
 }
 
}