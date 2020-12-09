using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Globalization;
using Microsoft.SqlServer.Server;
using System.Text.RegularExpressions;

//using InformationInTransit.DataAccess;
//using InformationInTransit.ProcessLogic;

///<summary>
///	2016-05-20	AssociativeWords.cs	Created.
///	2016-05-20	All My talking, is one absolute truth; that I befall you, as I beneath you. The tree between 4765 Canvasback Common, Fremont CA 94555 and 4769.
///	2015-05-20	http://stackoverflow.com/questions/8935161/how-to-add-a-case-insensitive-option-to-array-indexof
///	2015-05-22	Before -1. After 1. AssociativeWords "All My talking, is one absolute truth; that I befall you, as I beneath you." "Absolute truth" -1 3
///	2015-05-24	Beside 0. AssociativeWords "All My talking, is one absolute truth; that I befall you, as I beneath you." "Absolute truth" -1 3
///</summary>
//namespace InformationInTransit.ProcessLogic
//{
    public static partial class AssociativeWords
    {
		public static void Main(string[] argv)
		{
			int logic = Convert.ToInt32(argv[2]);
			int wordsCount = Convert.ToInt32(argv[3]);
			string associativeWords = Association(argv[0], argv[1], logic, wordsCount);
			System.Console.WriteLine
			(
				"Sentence: {0} | Search word: {1} | Logic: {2} | Words Count: {3} | AssociativeWords: {4}",
				argv[0],
				argv[1],
				logic,
				wordsCount,
				associativeWords
			);
		}	
		
        public static String ConcatenateWordsBackward(String[] words, int count)
		{
			StringBuilder sb = new StringBuilder();

			for (int length = words.Length, index = length - count; index < length; ++index)
			{
				if (index > 0) 
				{
					sb.Append(' ');
				}		
				sb.Append(words[index]);
			}
			return sb.ToString();	
		}	

        public static String ConcatenateWordsForward(String[] words, int count)
		{
			StringBuilder sb = new StringBuilder();

			for (int index = 0; index < count; ++index)
			{
				if (index > 0) 
				{
					sb.Append(' ');
				}		
				sb.Append(words[index]);
			}
			return sb.ToString();	
		}	
		
		[SqlFunction(DataAccess = DataAccessKind.Read)]
		public static string Association
		(
			string 	sentence,
			string	searchWord,
			int		logic,
			int		wordsCount
		)
        {
			string 		associativeWords	=	"";
			string 		consider			=	null;
			string[] 	words 				= 	null;
			
			string pattern = @"\b" + searchWord + @"\b";
			
			Match match = Regex.Match
			(
				sentence,
				pattern,
				System.Text.RegularExpressions.RegexOptions.IgnoreCase 				
			);
			
			if (match.Index < 0)
			{
				return associativeWords;
			}
			
			switch (logic)
			{
				case -1:
					consider = sentence.Substring(0, match.Index);
					words = consider.Split(SplitSeparator, StringSplitOptions.RemoveEmptyEntries); 
					if (wordsCount < words.Length)
					{	
						associativeWords = ConcatenateWordsBackward(words, wordsCount);
					}	
					break;	
				case 0:	
					string 		associativeWordsLeft = "";
					string 		considerLeft = sentence.Substring(0, match.Index);
					string[] 	wordsLeft = considerLeft.Split(SplitSeparator, StringSplitOptions.RemoveEmptyEntries); 
					if (wordsCount < wordsLeft.Length)
					{	
						associativeWordsLeft = ConcatenateWordsBackward(wordsLeft, wordsCount);
					}	
					string 		associativeWordsRight = "";
					string 		considerRight = sentence.Substring(match.Index + searchWord.Length);
					string[]	wordsRight = considerRight.Split(SplitSeparator, StringSplitOptions.RemoveEmptyEntries); 
					if (wordsCount < wordsRight.Length)
					{	
						associativeWordsRight = ConcatenateWordsForward(wordsRight, wordsCount);
					}	
					associativeWords = associativeWordsLeft + " " + associativeWordsRight;
					break;
				case 1:
					consider = sentence.Substring(match.Index + searchWord.Length);
					words = consider.Split(SplitSeparator, StringSplitOptions.RemoveEmptyEntries); 
					if (wordsCount < words.Length)
					{	
						associativeWords = ConcatenateWordsForward(words, wordsCount);
					}	
					break;
			}
			
			return associativeWords;
        }
		
		public static readonly char[] SplitSeparator = new Char [] {' ', ',', '.', ':', ';', '(', ')', '?'};		
    }
//}
