using System;
using System.Collections.Generic;
using System.Linq;

public static partial class ProgrammingWithAnonymousTypesInCSharp
{
	public static void Main(string[] argv)
	{
		AForeachStatementWhoseIterandIsDerivedFromALINQQuery();
		ACoupleOfSimpleLINQQueriesToPlayWithDemonstratingFutureTopicsSuchAsSortingAndProjections();
	}

	public static IEnumerable<int> AForeachStatementWhoseIterandIsDerivedFromALINQQuery()
	{
		IEnumerable<int> fibonacciDivisibleBy3 = from f in Fibonacci where f%3==0 select f;
		foreach (var fibo in fibonacciDivisibleBy3)
		{
			System.Console.WriteLine(fibo);
		}
		return fibonacciDivisibleBy3;
	}

	public static IEnumerable<int> ACoupleOfSimpleLINQQueriesToPlayWithDemonstratingFutureTopicsSuchAsSortingAndProjections()
	{
		IEnumerable<int> fibonacciDescending = from f in Fibonacci
							orderby f descending
							select f;
		foreach(var fibo in fibonacciDescending)
		{
			System.Console.WriteLine(fibo);
		}
		return fibonacciDescending;
	}

	public static readonly int[] Fibonacci = new int[]{ 1, 1, 2, 3, 5, 8, 13, 21, 33, 54, 87 };
}