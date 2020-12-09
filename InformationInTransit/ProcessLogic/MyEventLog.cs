using System;
using System.Diagnostics;
using System.Threading;

class MyEventLog
{
    public static void Main()
    {
        EventLog myNewLog = new EventLog("Security", ".", "Security");

        myNewLog.EntryWritten += new EntryWrittenEventHandler(MyOnEntryWritten);
        myNewLog.EnableRaisingEvents = true;
        //myNewLog.WriteEntry("Test message", EventLogEntryType.Information);
	System.Console.ReadLine();
    }

    public static void MyOnEntryWritten(object source, EntryWrittenEventArgs e)
    {
        Console.WriteLine("In event handler");
    }
}


