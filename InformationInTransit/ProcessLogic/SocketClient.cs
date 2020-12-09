#region Using directives
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
#endregion

namespace InformationInTransit.ProcessLogic
{
    #region SocketClient definition
    public static partial class SocketClient
    {
        #region Methods
        public static void Main(string[] argv)
        {
            TcpClient tcpClient;
            NetworkStream networkStream;
            StreamReader streamReader;
            StreamWriter streamWriter;
            int port = 5555;
            try
            {
                tcpClient = new TcpClient("localhost", port);
                networkStream = tcpClient.GetStream();
                streamReader = new StreamReader(networkStream);
                streamWriter = new StreamWriter(networkStream);
                streamWriter.WriteLine("Message from the Client...");
                streamWriter.Flush();
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex);
            }
            Console.Read();
        }
        #endregion
    }
    #endregion
}
