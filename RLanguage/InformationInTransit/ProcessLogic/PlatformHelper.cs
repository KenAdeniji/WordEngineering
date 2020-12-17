using System;


namespace InformationInTransit.ProcessLogic
{
	///<summary>2017-05-15	http://www.devx.com/tips/dot-net/c-sharp/testing-for-64-bit-or-32-bit-in-a-c-application-170321110044.html
	public static partial class PlatformHelper
	{
		public static void Main(string[] argv)
		{
			BitSize();
		}
		
		///<summary>2017-05-15	http://www.devx.com/tips/dot-net/c-sharp/testing-for-64-bit-or-32-bit-in-a-c-application-170321110044.html
		public static int BitSize()
		{
			int bitSize = 32;
			if (System.IntPtr.Size == 8) 
			{ 
				bitSize = 64;
			}
			System.Console.WriteLine
			(
				"Bit Size: {0}",
				bitSize
			);	
			return bitSize;
		}
	}
}
