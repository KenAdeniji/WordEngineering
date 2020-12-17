using System;
using System.Runtime.InteropServices;

namespace InformationInTransit.ProcessLogic
{
    public static partial class InternetHelper
    {
		[DllImport("wininet.dll")]
		private extern static bool InternetGetConnectedState(out int conn, int val);
		
        public static void Main(string[] argv)
        {
			bool internetConnection = RetrieveInternetConnectedState();
			System.Console.WriteLine
			(
				"Internet Connection: {0}",
				internetConnection
			);	
        }
		
		public static bool RetrieveInternetConnectedState()
		{
			int lpdwFlags;
			bool internetConnection = InternetGetConnectedState(out lpdwFlags, 0);
			return internetConnection;
		}
		
	}
}
