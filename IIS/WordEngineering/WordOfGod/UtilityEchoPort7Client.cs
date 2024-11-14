using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace WordEngineering
{
 ///<summary>UtilityEchoPort7Client</summary>
 ///<remarks>
 /// MKP.com/Practical/CSharpSockets  
 ///  David B. Makofse david_makofse@Yahoo.com, Michael J. Donahoo Jeff_Donahoo@Baylor.edu, Kenneth L. Calvert Calvert@NetLab.UKY.edu: TCP/IP Sockets In C# Practical Guide for Programmers ISBN 0-12-466051-7
 ///</remarks> 
 public class UtilityEchoPort7Client
 {
  ///<summary>Buffer_Size</summary>
  public const int Buffer_Size = 1024;

  ///<summary>The entry point for the application.</summary>
  ///<param name="argv">Command-line parameters.</param>
  public static void Main(string[] argv)
  {
   string server = "localhost";
   int port = 7;
   string exceptionMessage;
   string request = "Hello World";
   StringBuilder response;

   if ( argv.Length > 0 ) { server = argv[0]; }
   if ( argv.Length > 1 ) { Int32.TryParse(argv[1], out port); }
   if ( argv.Length > 2 ) { request = argv[2]; }
   EchoPort7Client
   (
    server,
    port,
    request,
    out response,
    out exceptionMessage
   );
  }

  ///<summary>EchoPort7Client</summary>
  public static void EchoPort7Client
  (
   string server,
   int port,
   string request,
   out StringBuilder response,
   out string exceptionMessage
  )
  {
   response = new StringBuilder();
   exceptionMessage = null;
   byte[] bufferRead = new byte[Buffer_Size];
   byte[] bufferWrite = Encoding.ASCII.GetBytes(request);
   int byteRead;
   TcpClient tcpClient = null;
   NetworkStream networkStream = null;
   try
   {
    tcpClient = new TcpClient(server, port);
    networkStream = tcpClient.GetStream();
    networkStream.Write(bufferWrite, 0, bufferWrite.Length);
    for (;;)
    {
     byteRead = networkStream.Read(bufferRead, 0, Buffer_Size);
     response.Append( Encoding.ASCII.GetString( bufferRead, 0, byteRead ) );
     if ( byteRead < Buffer_Size ) { break; }
    }
   }
   catch( Exception ex)
   {
    exceptionMessage = ex.Message;
   }
   finally
   {
    if ( networkStream != null ) { networkStream.Close(); };
    if ( tcpClient != null ) { tcpClient.Close(); };
   }
   if ( exceptionMessage != null ) { System.Console.WriteLine( exceptionMessage ); }
   System.Console.WriteLine( response );
  }

 }
}