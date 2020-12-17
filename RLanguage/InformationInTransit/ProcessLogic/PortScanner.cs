using System;
using System.Collections.Generic;
using System.Net.Sockets;

public partial class PortScanner
{
	public List<int> activePorts = new List<int>();
	public List<int> inactivePorts = new List<int>();
	
	public static void Main(string[] argv)
	{
		// Create a new PortScanner 
		PortScanner portScanner = new PortScanner(); 
		// Scan for open ports 
		portScanner.Scan("localhost", 5995, 5999); 
		// Write out the list of active/inactive ports 
		System.Console.WriteLine("Port Scanner Results:"); 
		System.Console.WriteLine(" Open Ports: "); 
		foreach (int Port in portScanner.activePorts) 
			System.Console.WriteLine(" " + Port.ToString()); 
		System.Console.WriteLine(" Closed Ports: "); 
		foreach (int Port in portScanner.inactivePorts) 
		System.Console.WriteLine(" " + Port.ToString()); 
	}
	
	public void Scan(string ip, int startPort, int endPort)
	{
		Socket socket = null;
		
		for (int port = startPort; port <= endPort; port++)
		{
			try
			{
				//Create a new socket and attempt to connect to the IP/Port
				socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				socket.Connect(ip, port);
				//Connection succeeded, add port to the list of active ports
				activePorts.Add(port);
			}
			catch (SocketException ex)
			{
				//Connection failed, add port to list of inactive ports
				inactivePorts.Add(port);
			}
			finally
			{
				//Gracefully close down the socket
				if (socket != null)
				{
					if (socket.Connected)
					{
						socket.Disconnect(false);
					}
					socket.Close();
				}
			}		
		}	
	}
}
