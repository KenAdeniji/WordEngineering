/*
Executing a Callback Method When an Asynchronous Call Completes

If the thread that initiates the asynchronous call does not need to process the results, you can execute a callback 
method when the call completes. The callback method is executed on a ThreadPool thread.

To use a callback method, you must pass BeginInvoke an AsyncCallback delegate representing the method. You can also 
pass an object containing information to be used by the callback method. For example, you might pass the delegate 
that was used to initiate the call, so the callback method can call EndInvoke.
*/

using System;
using System.Threading;

public class AsynchronousCallCompletesExecuteACallbackMethod
{
    // Asynchronous method puts the thread id here.
    private static int threadId;

    static void Main(string[] args) {
        // Create an instance of the test class.
        AsynchronousCallable ad = new AsynchronousCallable();

        // Create the delegate.
        AsynchronousDelegate dlgt = new AsynchronousDelegate(ad.TestMethod);

        // Initiate the asychronous call.  Include an AsyncCallback
        // delegate representing the callback method, and the data
        // needed to call EndInvoke.
        IAsyncResult ar = dlgt.BeginInvoke(3000,
            out threadId, 
            new AsyncCallback(CallbackMethod),
            dlgt );

        Console.WriteLine("Press Enter to close application.");
        Console.ReadLine();
    }
    
    // Callback method must have the same signature as the
    // AsyncCallback delegate.
    static void CallbackMethod(IAsyncResult ar) {
        // Retrieve the delegate.
        AsynchronousDelegate dlgt = (AsynchronousDelegate)ar.AsyncState;

        // Call EndInvoke to retrieve the results.
        string ret = dlgt.EndInvoke(out threadId, ar);

        Console.WriteLine("The call executed on thread {0}, with return value \"{1}\".", threadId, ret);
    }
}
