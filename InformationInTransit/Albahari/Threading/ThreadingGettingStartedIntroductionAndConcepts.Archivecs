using System;
using System.Threading;

/*
	2020-11-10	Created.	http://www.albahari.com/threading/#_Introduction
*/
class ThreadingGettingStartedIntroductionAndConcepts
{
	static void Main()
	{
		Thread t = new Thread(WriteGospel);      // Kick off a new thread
		t.Start();                               // running WriteGospel()
		// Simultaneously, do something on the main thread.
		String[] books = new String[] {"Genesis", "Exodus", "Leviticus", "Numbers", "Deuteronomy"};
		for
		(
			int index = 0, count = books.Length;
			index < count;
			index++
		)
		{
			System.Console.WriteLine("[{0}]: {1}", index, books[index]);
		}
	}

	static void WriteGospel()
	{
		String[] books = new String[] {"Matthew", "Mark", "Luke", "John"}; 
		for
		(
			int index = 0, count = books.Length;
			index < count;
			index++
		)
		{
			System.Console.WriteLine("[{0}]: {1}", index, books[index]);
		}
	}
}
