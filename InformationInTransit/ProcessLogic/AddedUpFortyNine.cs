using System;

namespace ProcessLogic
{
	public static class AddedUpFortyNine
	{
		public static void Main(string[] argv)
		{
			for (int number = 1, sum = 0; number <= 49; ++number)
			{
				sum += number;
				System.Console.WriteLine
				(
					"Number: {0} | Sum: {1}",
					number,
					sum
				);
			}
		}
	}
}
