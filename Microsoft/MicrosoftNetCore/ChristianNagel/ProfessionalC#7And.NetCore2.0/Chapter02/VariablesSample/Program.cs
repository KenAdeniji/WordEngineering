// 	See https://aka.ms/new-console-template for more information
//	Console.WriteLine("Hello, World!");

/*
2023-06-22
wiley.com/en-us/Professional+C%23+7+and+NET+Core+2+0-p-9781119449263
Professional C# 7 and .NET Core 2.0 Christian Nagel ISBN: 978-1-119-44926-3 March 2018 1440 Pages
*/

using System;

namespace Wrox
{
	class Program
	{
		public static void Main(string[] argv)
		{
			var name = "John Doe";
			var age = 20;
			var isHuman = true;
			Type nameType = name.GetType();
			Type ageType = age.GetType();
			Type isHumanType = isHuman.GetType();
			Console.WriteLine($"Name value {name} type {nameType}");
			Console.WriteLine($"Age value {age} type {ageType}");
			Console.WriteLine($"IsHuman value {isHuman} type {isHumanType}");
		}	
	}
}
	