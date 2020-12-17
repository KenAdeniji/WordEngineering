using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

///<summary>
///	2015-02-12 Created.
///	csc TextHelper.cs
/// </summary>
namespace InformationInTransit.ProcessLogic
{
	public static partial class TextHelper
	{
		static void Main(string[] args)
		{
			string text = ReadFile("TextHelper.cs");
			string[] result = ListWords(text);
			foreach(string word in result)
			{
				System.Console.WriteLine(word);
			}
		}

		///<remarks>
		///	http://csharphelper.com/blog/2015/01/list-unique-words-in-a-text-file-in-c/
		/// </remarks>
		public static string[] ListWords(String txt)
		{
			// Use regular expressions to replace characters
			// that are not letters or numbers with spaces.
			Regex reg_exp = new Regex("[^a-zA-Z0-9]");
			txt = reg_exp.Replace(txt, " ");

			// Split the text into words.
			string[] words = txt.Split(
				new char[] { ' ' },
				StringSplitOptions.RemoveEmptyEntries);

			// Use LINQ to get the unique words.
			var word_query =
				(from string word in words
				 orderby word select word).Distinct();
			
			// Display the result.
			string[] result = word_query.ToArray();
			return result;
		}	

		public static string ReadFile(string filename)
		{
			// Get the file's text.
			string txt = File.ReadAllText(filename);
			return txt;
		}
	}
}
