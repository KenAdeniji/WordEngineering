/*
	2021-10-26T19:24:00 https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/
*/
using System;
using System.Collections.Generic;
using System.Linq;

namespace InformationInTransit.LanguageIntegratedQueryLINQ
{
	class LINQQueryExpressionsBibleBook
	{
		static void Main()
		{

			// Specify the data source.
			int[] pentateuchChapters = new int[] { 50, 40, 27, 36, 34 };

			// Define the query expression.
			IEnumerable<int> pentateuchChapterQuery =
				from pentateuchChapter in pentateuchChapters
				where pentateuchChapter > 35
				select pentateuchChapter;

			// Execute the query.
			foreach (int i in pentateuchChapterQuery)
			{
				Console.Write(i + " ");
			}
		}
	}
}
