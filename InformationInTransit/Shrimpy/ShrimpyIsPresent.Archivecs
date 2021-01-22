using System;
using System.Collections.Generic;

/*
	2021-01-20T07:00:00 ... 2021-01-20T08:30:00 https://www.interviewzen.com/question/5bDFhhY
*/
namespace InformationInTransit.Shrimpy
{
	public class ShrimpyIsPresent
	{
		public static void Main
		(
			string[] argv
		)
		{
			int[] simulation = new int[] { 0, 1, 6, 2, 7, 3, 8, 4, 9, 10};
			System.Console.WriteLine(isPresent(simulation, 11));
			System.Console.WriteLine(isPresent(simulation, -1));
			System.Console.WriteLine(isPresent(simulation, 5));
			System.Console.WriteLine(isPresent(simulation, 7));
		}		
			
		public static int isPresent
		(
			int[] root,
			int val
		)
		{
			//Design by Contract (DbC) C# version support dependency
			if (root.Length > 10)
			{
				new Exception();
			}
			if (val < 1 || val > ((root.Length / 2) * root.Length))
			{
				new Exception();
			}
			
			LinkedList<int> singlyLinked = new LinkedList<int>(root);
			
			return singlyLinked.Contains(val) ? 1 : 0;
		}	
	}
}
