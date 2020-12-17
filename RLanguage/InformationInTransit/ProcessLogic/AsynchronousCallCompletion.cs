/*Polling for Asynchronous Call Completion

You can use the IsCompleted property of the IAsyncResult returned by BeginInvoke to discover when the asynchronous call
completes. You might do this when making the asynchronous call from a thread that services the user interface. Polling
for completion allows the user interface thread to continue processing user input.
*/

using System;
using System.Threading;

public class AsynchronousCallCompletion
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

        // Poll while simulating work.
        while(ar.IsCompleted == false) {
            Thread.Sleep(10);
        }

        // Call EndInvoke to retrieve the results.
        string ret = dlgt.EndInvoke(out threadId, ar);

        Console.WriteLine("The call executed on thread {0}, with return value \"{1}\".", threadId, ret);
    }
}
