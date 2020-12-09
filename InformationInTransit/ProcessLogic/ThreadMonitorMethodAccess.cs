using System;
using System.Threading;

public static class ThreadMonitorMethodAccess
{
    private static int numericField = 1;
    private static object syncObj = new object( );

    public static object SyncRoot
    {
        get { return syncObj; }
    }

    public static void IncrementNumericField( )
    {
        if (Monitor.TryEnter(syncObj, 250))
        {
            try
            {
                ++numericField;
            }
            finally
            {
                Monitor.Exit(syncObj);
            }

            }
    }

    public static void ModifyNumericField(int newValue)
    {
        if (Monitor.TryEnter(syncObj, 250))
        {
            try
            {
                numericField = newValue;
            }
            finally
            {
                Monitor.Exit(syncObj);
            }
        }
    }

    public static int ReadNumericField( )
    {
        if (Monitor.TryEnter(syncObj, 250))
        {
            try
            {
                return (numericField);
            }
            finally
            {
                Monitor.Exit(syncObj);
            }
        }

        return (-1);
    }
	
	public static void Main(string[] argv)
	{
		int num = 0;
		if(Monitor.TryEnter(ThreadMonitorMethodAccess.SyncRoot,250))
		{
			ThreadMonitorMethodAccess.ModifyNumericField(10);
			num = ThreadMonitorMethodAccess.ReadNumericField( );
			Monitor.Exit(ThreadMonitorMethodAccess.SyncRoot);
		}
		Console.WriteLine(num);
	}
}
