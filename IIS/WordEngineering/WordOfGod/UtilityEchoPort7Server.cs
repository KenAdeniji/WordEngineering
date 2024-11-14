using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace WordEngineering
{
 ///<summary>UtilityEchoPort7Server</summary>
 ///<remarks>
 /// MKP.com/Practical/CSharpSockets  
 ///  David B. Makofse david_makofse@Yahoo.com, Michael J. Donahoo Jeff_Donahoo@Baylor.edu, Kenneth L. Calvert Calvert@NetLab.UKY.edu: TCP/IP Sockets In C# Practical Guide for Programmers ISBN 0-12-466051-7
 ///</remarks> 
 public class UtilityEchoPort7Server
 {
  ///<summary>Buffer_Size</summary>
  public const int Buffer_Size = 1024;

  ///<summary>The entry point for the application.</summary>
  ///<param name="argv">Command-line parameters.</param>
  public static void Main(string[] argv)
  {
   int port = 7;
   string exceptionMessage;
   if ( argv.Length > 0 ) { Int32.TryParse(argv[0], out port); }
   EchoPort7Server(port, out exceptionMessage);
  }

  ///<summary>EchoPort7Server</summary>
  public static void EchoPort7Server
  (
   int port,
   out string exceptionMessage
  )
  {
   byte[] bufferRead = new byte[Buffer_Size];
   byte[] bufferWrite;
   int byteRead;
   string data;
   NetworkStream networkStream = null;
   TcpClient tcpClient = null;
   TcpListener tcpListener = null;
   exceptionMessage = null;
   try
   {
    tcpListener = new TcpListener( IPAddress.Any, port );
    tcpListener.Start();
    for (;;)
    {
     tcpClient = tcpListener.AcceptTcpClient();
     networkStream = tcpClient.GetStream();

     // Loop to receive all the data sent by the client.
     while( ( byteRead = networkStream.Read( bufferRead, 0, Buffer_Size ) ) !=0 ) 
     {   
      // Translate data bytes to a ASCII string.
      data = System.Text.Encoding.ASCII.GetString( bufferRead, 0, byteRead );
      
      // Process the data sent by the client.
      //data = data.ToUpper();

      bufferWrite = System.Text.Encoding.ASCII.GetBytes(data);

      // Send back a response.
      networkStream.Write(bufferWrite, 0, bufferWrite.Length);
     }

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
  }

 }
}