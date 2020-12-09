using System;

namespace InformationInTransit.ProcessLogic
{
	/*
		2017-04-21	Created.	apress.com/us/book/9781484213339
	*/
	public static partial class GenericPointStructure
	{
		public static void Main(string[] argv)
		{
			Stub();
		}

		public static void Stub()
		{
			Point<double> point = new Point<double>{ X = 5.4, Y = 3.3 };
			System.Console.WriteLine(point);
			point.Reset();
			System.Console.WriteLine(point);
		}	
		
		public struct Point<T>
		{
			public T X {get; set;}
			public T Y {get; set;}
			
			public void Reset()
			{
				X = default(T);
				Y = default(T);
			}
			
			public override String ToString()
			{
				return String.Format
				(
					"[{0}, {1}]",
					X, Y
				);
			}	
		}	
	}
}
