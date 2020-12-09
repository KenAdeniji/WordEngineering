using System;
using System.Threading; 

public class AsynchronousCallable {
    // The method to be executed asynchronously.
    //
    public string TestMethod(int callDuration, out int threadId) {
        Console.WriteLine("Test method begins.");
        Thread.Sleep(callDuration);
        threadId = Thread.CurrentThread.ManagedThreadId;
        return "MyCallTime was " + callDuration.ToString();
    }
}

// The delegate must have the same signature as the method
// you want to call asynchronously.
public delegate string AsynchronousDelegate(int callDuration, out int threadId);

