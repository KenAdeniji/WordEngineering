/* Waiting for an Asynchronous Call with EndInvoke
The simplest way to execute a method asynchronously is to start it with BeginInvoke, do some work on 
the main thread, and then call EndInvoke. EndInvoke does not return until the asynchronous call
completes. This is a good technique to use with file or network operations, but because it blocks on 
EndInvoke, you should not use it from threads that service the user interface.
*/ 

using System;
using System.Threading;

public class AsynchronousCallWithEndInvoke 
{
    static void Main(string[] args) 
    {
        // The asynchronous method puts the thread id here.
        int threadId;

        // Create an instance of the test class.
        AsynchronousCallable ad = new AsynchronousCallable();

        // Create the delegate.
        AsynchronousDelegate dlgt = new AsynchronousDelegate(ad.TestMethod);
   
        // Initiate the asychronous call.
        IAsyncResult ar = dlgt.BeginInvoke(3000, 
            out threadId, null, null);

        Thread.Sleep(0);
        Console.WriteLine("Main thread {0} does some work.", Thread.CurrentThread.ManagedThreadId);

        // Call EndInvoke to Wait for the asynchronous call to complete,
        // and to retrieve the results.
        string ret = dlgt.EndInvoke(out threadId, ar);

        Console.WriteLine("The call executed on thread {0}, with return value \"{1}\".", threadId, ret);
    }
}
