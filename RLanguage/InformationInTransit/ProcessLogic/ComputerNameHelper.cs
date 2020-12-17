using System;
using System.Collections.ObjectModel;

namespace InformationInTransit.ProcessLogic
{
	public static partial class ComputerNameHelper
	{
		public static void Main(string[] argv)
		{
			ComputerNamesStub();
		}
		
		public static void ComputerNamesStub()
		{
			System.Console.WriteLine
			(
				"Environment.MachineName: {0} | System.Net.Dns.GetHost(): {1} | System.Environment.GetEnvironmentVariable(\"COMPUTERNAME\"): {2}",
				ComputerNames[0],
				ComputerNames[1],
				ComputerNames[2]
			);
		}
		
		/// <summary>
		/// 2014-02-17
		/// ginktage.com/2014/01/different-ways-to-get-the-computer-name-in-c
		/// </summary> 
		public static readonly Collection<String> ComputerNames = new Collection<String>
		{
			Environment.MachineName,
			System.Net.Dns.GetHostName(),
			System.Environment.GetEnvironmentVariable("COMPUTERNAME")
		};
	}	
}
