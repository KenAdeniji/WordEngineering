/*
	2023-06-26T19:46:00 wiley.com/en-us/Professional+C%23+7+and+NET+Core+2+0-p-9781119449263 	Professional C# 7 and .NET Core 2.0 Christian Nagel ISBN: 978-1-119-44926-3 March 2018 1440 Pages 			2023-06-22
*/
using System;

namespace ChristianNagel
{
	public static partial class StringExtension
	{
		public static void Main(String[] args)
		{
		}
		
		public static int WordCount
		(
			this String s
		)
		{
			return s.Split().Length;
		}	
	}	
}	