using System;
using System.Threading;

namespace WordEngineering
{
	public class ThreadSaferMemberAccess
	{
		private static int numericField = 1;
		
		/*
		Jeffrey Richter has come up with a relatively simple method to remedy this situation, which he details 
		quite clearly in the article "Safe Thread Synchronization" in the January 2003 issue of MSDN Magazine. His 
		solution is to create a private field within the class on which to synchronize. Only the object itself can
		acquire this private field; no outside object or type may acquire it. This solution is also now the 
		recommended practice in the MSDN documentation for the lock keyword.
		*/
	    private static object syncObj = new object( );

	    public static void Main(string[] argv)
		{
			IncrementNumericField();
			ModifyNumericField(5);
			int returnField = ReadNumericField();
			System.Console.WriteLine(returnField);
		}
		
		public static void IncrementNumericField()
		{
	        lock(syncObj)	{
				++numericField;
	        }
		}

	    public static void ModifyNumericField(int newValue)
	    {
	        lock(syncObj)	{
	        numericField = newValue;
			}
	    }

	    public static int ReadNumericField()
	    {
	        lock (syncObj)	{
				return (numericField);
	        }
	    }
	}
}	