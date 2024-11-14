using System;

namespace WordEngineering
{
 ///<summary>UtilityDaytimePort13</summary>
 ///<remarks>
 /// Louisville.edu/~djchan01/cecs640/tcp.pdf Dar-jen Chang: CECS640 The Internet, TCP/IP Protocol, Socket and Client-Server Computing August 25, 2003
 ///</remarks> 
 public class UtilityDaytimePort13
 {
  ///<summary>Hostname</summary>
  public const string Hostname = "time.nist.gov";

  ///<summary>Port</summary>
  public const int Port = 13;

  ///<summary>The entry point for the application.</summary>
  ///<param name="argv">A list of command line arguments</param>
  public static void Main(string[] argv)
  {
   string hostname = Hostname;
   int port = Port;
   if ( argv.Length > 0 ) { hostname = argv[0]; }
   if ( argv.Length > 1 ) { Int32.TryParse(argv[1], out port); }
   System.Console.WriteLine( ScreenOne.SetupScreen( hostname, port, "Hello" ) );
   //System.Console.WriteLine( ScreenOne.Daytime() );
  }
 }
}