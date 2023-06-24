// 	See https://aka.ms/new-console-template for more information
//	Console.WriteLine("Hello, World!");

/*
2023-06-24T07:48:00
wiley.com/en-us/Professional+C%23+7+and+NET+Core+2+0-p-9781119449263
Professional C# 7 and .NET Core 2.0 Christian Nagel ISBN: 978-1-119-44926-3 March 2018 1440 Pages
*/

using System;

namespace Wrox
{
	class Program
	{
		public const int LoopLimit = 10;
		public static void Main(string[] argv)
		{
			//This loop iterates through the rows
			for(int outerLoop = 0; outerLoop < LoopLimit; outerLoop++)
			{	
				//This loop iterates through the columns
				for(int innerLoop = 0; innerLoop < LoopLimit; innerLoop++)
				{	
					Console.Write($" {(outerLoop * LoopLimit) + innerLoop}");
				}
				Console.WriteLine();
			}	
		}	
	}
}
	