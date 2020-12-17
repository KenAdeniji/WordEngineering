using System;
using System.Threading;

namespace WordEngineering
{
	public class ThreadStaticField
	{
		[ThreadStaticAttribute()] /*Create a new variable, uninitialized, for each subsequent thread. Indicates that the value of a static field is unique for each thread.*/
	    public static string Bar = "Initialized string";
		
		public static void Main(string[] argv)
		{
			TestStaticField();
		}
		
		public static void DisplayStaticFieldValue()
	    {
	        string msg =
	            string.Format("{0} contains static field value of: {1}",
	                Thread.CurrentThread.GetHashCode(),
	                ThreadStaticField.Bar);
	        System.Console.WriteLine(msg);
	    }
		
		public static void TestStaticField()
		{
			ThreadStaticField.DisplayStaticFieldValue( );

			Thread newStaticFieldThread =
				new Thread(ThreadStaticField.DisplayStaticFieldValue);

			newStaticFieldThread.Start( );

			ThreadStaticField.DisplayStaticFieldValue( );
		}
	}
}	