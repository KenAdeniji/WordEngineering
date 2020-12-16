using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Collections;

/*
	2020-04-19T10:00:00	jot.fm/issues/issue_2004_01/column8.pdf
*/
namespace RichardWiener
{
	public class RemotingRichardWienerSingleHostClient 
	{
		//   Constructor   
		public RemotingRichardWienerSingleHostClient(String newName)
		{ 
			// Create and register the remoting channel
			HttpChannel channel = new HttpChannel();  
			ChannelServices.RegisterChannel(channel);
            // Initialize the remoting system
			InitializeRemoteServer();
            this.AddName(new RemotingRichardWienerNameHolder(),   newName);
		}
		private void InitializeRemoteServer() 
		{ 
			RemotingConfiguration.RegisterWellKnownClientType
			(
				typeof(RemotingRichardWienerNameHolder),
				"http://localhost:12345/RemotingRichardWienerNameHolder" 
			);
		}
		private void AddName(RemotingRichardWienerNameHolder server, String newName) 
		{
			server.AddName(newName);
			ArrayList   names   =   server.GetNames();
			foreach (String name in names) 
			{
				Console.WriteLine(name);  
			} 
			Console.WriteLine();
		}		
		public static void Main(String [] args)
		{
			Console.WriteLine("Adding " + args[0] + " to name list.");
			new RemotingRichardWienerSingleHostClient(args[0]);
		}
	}
}
