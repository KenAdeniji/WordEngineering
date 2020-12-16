using System;
using System.Linq;

/*
	2019-01-02	Created.	http://manning-content.s3.amazonaws.com/download/1/857d550-856b-4ea8-9e91-843c1d956583/chapter%201%20sample.pdf
*/
namespace EnricoBuonanno.FunctionalProgrammingInCSharp.Chapter01
{
	public static class FunctionalApproachWhereAndOrderByDontAffectTheOriginalList
	{
		public static void Main(String[] argv)
		{
			Stub();
		}
	
		public static void Stub()
		{
			Func<int, bool> isOdd = x => x % 2 == 1;  
			int[] original = { 7, 6, 1 };  
			var sorted = original.OrderBy(x => x); 
			var filtered = original.Where(isOdd); 
		}
	}
}
	
	