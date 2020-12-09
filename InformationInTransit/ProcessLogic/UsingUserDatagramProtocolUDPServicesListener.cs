using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

/*
The UdpClient class communicates with network services using UDP. The properties and methods of the UdpClient class abstract the details of creating a Socket for requesting and receiving data using UDP.

User Datagram Protocol (UDP) is a simple protocol that makes a best effort to deliver data to a remote host. However, because the UDP protocol is a connectionless protocol, UDP datagrams sent to the remote endpoint are not guaranteed to arrive, nor are they guaranteed to arrive in the same sequence in which they are sent. Applications that use UDP must be prepared to handle missing, duplicate, and out-of-sequence datagrams.

To send a datagram using UDP, you must know the network address of the network device hosting the service you need and the UDP port number that the service uses to communicate. The Internet Assigned Numbers Authority (Iana) defines port numbers for common services (see www.iana.org/assignments/port-numbers). Services not on the Iana list can have port numbers in the range 1,024 to 65,535.

Special network addresses are used to support UDP broadcast messages on IP-based networks. The following discussion uses the IP version 4 address family used on the Internet as an example.

IP version 4 addresses use 32 bits to specify a network address. For class C addresses using a netmask of 255.255.255.0, these bits are separated into four octets. When expressed in decimal, the four octets form the familiar dotted-quad notation, such as 192.168.100.2. The first two octets (192.168 in this example) form the network number, the third octet (100) defines the subnet, and the final octet (2) is the host identifier.

Setting all the bits of an IP address to one, or 255.255.255.255, forms the limited broadcast address. Sending a UDP datagram to this address delivers the message to any host on the local network segment. Because routers never forward messages sent to this address, only hosts on the network segment receive the broadcast message.

Broadcasts can be directed to specific portions of a network by setting all bits of the host identifier. For example, to send a broadcast to all hosts on the network identified by IP addresses starting with 192.168.1, use the address 192.168.1.255.

The following code example uses a UdpClient to listen for UDP datagrams sent to the directed broadcast address 192.168.1.255 on port 11,000. The client receives a message string and writes the message to the console.
*/
///<remarks>
///https://msdn.microsoft.com/en-us/library/tst0kwb1%28v=vs.110%29.aspx
///</remarks>
namespace InformationInTransit.ProcessLogic
{
	public class UsingUserDatagramProtocolUDPServicesListener
	{
		private const int listenPort = 11000;

		private static void StartListener() 
		{
			bool done = false;

			UdpClient listener = new UdpClient(listenPort);
			IPEndPoint groupEP = new IPEndPoint(IPAddress.Any,listenPort);

			try 
			{
				while (!done) 
				{
					Console.WriteLine("Waiting for broadcast");
					byte[] bytes = listener.Receive( ref groupEP);

					Console.WriteLine("Received broadcast from {0} :\n {1}\n",
						groupEP.ToString(),
						Encoding.ASCII.GetString(bytes,0,bytes.Length));
				}

			} 
			catch (Exception e) 
			{
				Console.WriteLine(e.ToString());
			}
			finally
			{
				listener.Close();
			}
		}

		public static int Main() 
		{
			StartListener();

			return 0;
		}
	}
}
