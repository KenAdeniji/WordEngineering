using System;
using System.Linq;

namespace InformationInTransit.ProcessLogic
{
	public static partial class HelloLinq
	{
		public static void Main(string[] argv)
		{
			ShortWords();
			WordGroupOrderBy();
		}
		
		public static void ShortWords()
		{
			var shortWords =
				from word in Words
				where word.Length <= 5
				select word;
				
			foreach (var word in shortWords)
				Console.WriteLine(word);
		}
		
		public static void WordGroupOrderBy()
		{
			var groups =
				from word in Words
				orderby word ascending
				group word by word.Length into lengthGroups
				orderby lengthGroups.Key descending
				select new {Length=lengthGroups.Key, Words=lengthGroups};

			foreach (var group in groups)
			{
				Console.WriteLine("Words of length " + group.Length);
				foreach (string word in group.Words)
				Console.WriteLine(" " + word);
			}
		}
		
		public static readonly string[] Words = { "hello", "wonderful", "linq", "beautiful", "world" };
	}
}
