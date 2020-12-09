#region Using directives
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
#endregion

namespace InformationInTransit.ProcessLogic
{
    #region SocketServer definition
    public static partial class SocketServer
    {
        #region Methods            
        public static void Main(string[] argv)
        {
            StreamWriter streamWriter;
            StreamReader streamReader;
            NetworkStream networkStream;
            Int32 port = 5555;
            IPAddress localAddress = IPAddress.Parse("127.0.0.1");
            TcpListener tcpListener = new TcpListener(localAddress, port);
            tcpListener.Start();
            Console.WriteLine("The Server has started on port 5555");
            Socket serverSocket = tcpListener.AcceptSocket();
            try
            {
                if (serverSocket.Connected)
                {
                    while (true)
                    {
                        Console.WriteLine("Client connected");
                        networkStream = new NetworkStream(serverSocket);
                        streamWriter = new StreamWriter(networkStream);
                        streamReader = new StreamReader(networkStream);
                        Console.WriteLine(streamReader.ReadLine());
                    }
                }
                if (serverSocket.Connected)
                {
                    serverSocket.Close();
                }
                System.Console.Read();
            }
            catch (SocketException ex)
            {
                System.Console.WriteLine(ex);
            }
        }
        #endregion
    }
    #endregion
}
