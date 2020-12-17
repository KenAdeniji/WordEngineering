using System;

namespace InformationInTransit.ProcessLogic
{
	/*
		2017-04-21	Created.	apress.com/us/book/9781484213339
	*/
	public static partial class MyGenericMethods
	{
		public static void Main(string[] argv)
		{
			Stub();
		}

		public static void DisplayBaseClass<T>()
		{
			System.Console.WriteLine
			(
				"Base class of {0} is: {1}",
				typeof(T), typeof(T).BaseType
			);
		}
		
		public static void Stub()
		{
			string first = "First";
			string second = "Second";
			System.Console.WriteLine
			(
				"Before swap. First: {0} | Second: {1}",
				first, second
			);	
			Swap<string>(ref first, ref second);
			System.Console.WriteLine
			(
				"After swap. First: {0} | Second: {1}",
				first, second
			);
			DisplayBaseClass<int>();	
		}	
		
		public static void Swap<T>(ref T a, ref T b)
		{
			T temp;
			temp = a;
			a = b;
			b = temp;
		}	
	}
}
