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
    // Server class 
	public class RemotingRichardWienerSingleHostSaveNamesServer : MarshalByRefObject 
	{
		public static void Main() 
		{
			// Create and register the channel 
			HttpChannel channel = new HttpChannel(12345);
			ChannelServices.RegisterChannel(channel);   
			Console.WriteLine("Starting RemotingRichardWienerSingleHostSaveNamesServer"); 
			// Register the SaveNamesServer for remoting 
			RemotingConfiguration.RegisterWellKnownServiceType
			( 
				typeof(RemotingRichardWienerSingleHostSaveNamesServer),
				"RemotingRichardWienerSingleHostSaveNamesServer", 
				WellKnownObjectMode.Singleton
			);
			Console.WriteLine("Press return to exit SingleHostSaveNamesServer."); 
			Console.ReadLine();
		} 
	}	
}
