/*
	2023-06-25T12:42:00 wiley.com/en-us/Professional+C%23+7+and+NET+Core+2+0-p-9781119449263 	Professional C# 7 and .NET Core 2.0 Christian Nagel ISBN: 978-1-119-44926-3 March 2018 1440 Pages 			2023-06-22
	Page 89	
*/
using System;
using System.Collections;
using System.Collections.Generic;

namespace ChristianNagel
{
	public class Singleton
	{
		private static Singleton singletonInstance;
		private int _state = 0;
		private static int _sequentialCounter = 0;
		private Singleton
		(
			int state
		)
		{
			_state = state;
		}
		public static Singleton Instance
		{
			get
			{
				_sequentialCounter++;
				return
				(
					singletonInstance ??
					(
						singletonInstance =
						new Singleton(42)
					)
				);	
			}
		}	
		public static int SequentialCounter
		{
			get
			{
				return(_sequentialCounter);	
			}
			set
			{
				_sequentialCounter = value;
			}	
		}	
		public override String ToString()
		{
			return String.Format
			(
				"_sequentialCounter {0} _state {1}",
				_sequentialCounter,
				this._state
			);
		}	
		public static void Main
		(
			string[] args
		)
		{
			Stub(args);
		}		

		public static void Stub
		(
			string[] args
		)
		{
			int argsLength = args.Length;
			List<Singleton> singletons = new List<Singleton>();
			for 
			(
				int argsIndex = 0;
				argsIndex < argsLength;
				argsIndex++
			)
			{
				singletons.Add(Singleton.Instance);
				System.Console.WriteLine
				(
					"Singleton Instance[{0}] {1}",
					argsIndex,
					singletons[argsIndex]
				);
			}	
		}		
	}	
}	