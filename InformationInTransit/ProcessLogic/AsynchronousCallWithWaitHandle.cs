/*Waiting for an Asynchronous Call with WaitHandle

Waiting on a WaitHandle is a common thread synchronization technique. You can obtain a WaitHandle using the 
AsyncWaitHandle property of the IAsyncResult returned by BeginInvoke. The WaitHandle is signaled when the 
asynchronous call completes, and you can wait for it by calling its WaitOne.

If you use a WaitHandle, you can perform additional processing after the asynchronous call completes, but before you
retrieve the results by calling EndInvoke.
*/

using System;
using System.Threading;

public class AsynchronousCallWithWaitHandle
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
        IAsyncResult ar = dlgt.BeginInvoke(3000, out threadId, null, null);

        Thread.Sleep(0);
        Console.WriteLine("Main thread {0} does some work.", Thread.CurrentThread.ManagedThreadId);

        // Wait for the WaitHandle to become signaled.
        ar.AsyncWaitHandle.WaitOne();

        // Perform additional processing here.
        // Call EndInvoke to retrieve the results.
        string ret = dlgt.EndInvoke(out threadId, ar);

        Console.WriteLine("The call executed on thread {0}, with return value \"{1}\".", threadId, ret);
    }
}

