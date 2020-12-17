using System;
using System.Threading;

public class MultiThreadedExceptionHandling
{
	static void Main()
	{
		try
		{
			Thread thread = new Thread(ThrowException);
			thread.Start();
			// ...
			// Wait for the unhandled exception to fire
			Thread.Sleep(10000);
			Console.WriteLine("Still running...");
		}
		finally
		{
			Console.WriteLine("Exiting...");
		}
		// Register a callback to receive notifications of any unhandled exception.
		AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
	}
	
	static void OnUnhandledException(object sender, UnhandledExceptionEventArgs eventArgs)
	{
		Console.WriteLine("ERROR:{0}", eventArgs.ExceptionObject);
	}

	public static void ThrowException()
	{
		throw new ApplicationException("Arbitrary exception");
	}
}
