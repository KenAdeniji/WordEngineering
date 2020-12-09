using System;

namespace WordEngineering
{
	delegate int Transformer (int x);
	
	public class DelegateSimple
	{
		public static void Main(string[] argv)
		{
			Transformer t = Square;          // create delegate instance
			int result = t(3);               // invoke delegate
			Console.WriteLine(result);
		}
		static int Square (int x) { return x * x; }	
	}
}
