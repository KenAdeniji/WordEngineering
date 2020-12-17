using System;
using System.Linq;

/*
	2019-01-02	Created.	http://manning-content.s3.amazonaws.com/download/1/857d550-856b-4ea8-9e91-843c1d956583/chapter%201%20sample.pdf
*/
namespace EnricoBuonanno.FunctionalProgrammingInCSharp.Chapter01
{
	public static class Range20Plus30MultiplesOf4SortedDescendingOrder
	{
		public static void Main(String[] argv)
		{
			Stub();
		}
	
		public static void Stub()
		{
			var original = Enumerable.Range(20, 30);
			var resultSet = original.Where(x => ( (x % 4) == 0) )
									.OrderByDescending(x => x)
							;		
			ObjectDumper.Write(resultSet);
		}
	}
}
	
	