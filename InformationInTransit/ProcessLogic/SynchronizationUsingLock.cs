using System;
using System.Threading;

class SynchronizationUsingLock
{
	readonly static object _Sync = new object();
	const int _Total = int.MaxValue;
	static long _Count = 0;
	public static void Main()
	{
		Thread thread = new Thread(Decrement);
		thread.Start();

		// Increment
		for (int i = 0; i < _Total; i++)
		{
			lock (_Sync)
			{
				_Count++;
			}
		}	
		thread.Join();
		Console.WriteLine("Count = {0}", _Count);
	}
	static void Decrement()
	{
		for (int i = 0; i < _Total; i++)
		{
			lock (_Sync)
			{
				_Count--;
			}
		}
	}
}

/*
By locking the section of code accessing _Count (using either lock, or
Monitor with try catch block), you are making the Main() and Decrement() methods threadsafe,
meaning they can be safely called from multiple threads simultaneously.
Synchronization does not come without a cost. First, synchronization
has an impact on performance. Listing 18.9, for example, takes an order-ofmagnitude
longer to execute than Listing 18.7 does, which demonstrates
lock’s relatively slow execution compared to the execution of incrementing
and decrementing the count.
Even when lock is insignificant in comparison with the work it synchronizes,
programmers should avoid indiscriminately adding synchronization,
thus avoiding the complexities of deadlocks and unnecessary
constraints on multiprocessor computers. The general best practice for
object design is to synchronize static state and to leave out synchronization
*/
