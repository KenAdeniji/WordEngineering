using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;

namespace InformationInTransit.ProcessLogic
{
	/*
		2015-10-16	Differencing from my need. (Psalms 35:10, Isaiah 10:2). Supporting the Word of God. BibleWord, exact.
		2015-10-16	DifferencingFromMyNeed.cs
		2015-10-17	As at the first.
		2015-10-17	public static void BuildSQL(string sentence)
					Word: Differencing | Count: 0
					Word: From | Count: 3113
					Word: My | Count: 3376
					Word: Need | Count: 126
		2015-10-17	Eric Lippert, Microsoft. http://stackoverflow.com/questions/2401532/generate-word-combination-array-in-c-sharp
		2015-10-18	http://stackoverflow.com/questions/19368834/remove-duplicate-words-from-string-in-c-sharp
		2015-10-18	http://stackoverflow.com/questions/6973972/remove-duplicate-in-a-string	
	*/
	public static partial class DifferencingFromMyNeed
	{
		public static void Main(string[] argv)
		{
			string defaultArgument = argv.Length == 0 ? DefaultArgument : argv[0];
			//BuildSQL(defaultArgument);
			string[] array = new string[]{"big", "bad", "dog"};
			WordPermutationEricLippert(defaultArgument);
		}
		
		public static void BuildSQL(string sentence)
		{
			bool found = true;
			string adjust = null;
			
			string[] words = null;
			words = sentence.Split(SplitSeparator);
			
			SameWordComparer compareWord = new SameWordComparer();
			Dictionary<string, int> uniqueWords = new Dictionary<string, int>(compareWord);
			
			for 
			(
				int outerIndex = 0, outerLength = words.Length; 
				outerIndex < outerLength;
				++outerIndex
			)
			{
				words[outerIndex] = words[outerIndex].Trim();

				if (words[outerIndex].Length == 0)
				{
					continue;
				}
				
				words[outerIndex] = char.ToUpper(words[outerIndex][0]) + words[outerIndex].Substring(1);
				
				string selectStatement = String.Format
				(
					SQLOneWordFormat,
					words[outerIndex]
				);
				
				int versesCount = (int) DataCommand.DatabaseCommand
                               (
                                    selectStatement,
                                    System.Data.CommandType.Text,
                                    DataCommand.ResultType.Scalar
                                );
				
				System.Console.WriteLine
				(
					"Word: {0} | Count: {1}",
					words[outerIndex],
					versesCount
				);
				
				for 
				(
					int innerIndex = 0, innerLength = words.Length; 
					innerIndex < innerLength;
					++innerIndex
				)
				{
					words[innerIndex] = words[innerIndex].Trim();

					if (words[innerIndex].Length == 0)
					{
						continue;
					}
					
					words[innerIndex] = char.ToUpper(words[innerIndex][0]) + words[innerIndex].Substring(1);
				}	
			}		
		}
		
		static String RemoveDuplicates(this String x)
		{
			return String.Join(" ", x.Split(' ').Distinct(StringComparer.CurrentCultureIgnoreCase));
		}
	
		public static int WordOccurrence(string wordsCombination)
		{
			wordsCombination = wordsCombination.RemoveDuplicates();
			string whereClausePrefix = " WHERE ";
			string[] words = wordsCombination.Split(' ');
			StringBuilder sbWhereClause = new StringBuilder();
			
			foreach(string word in words)
			{
				sbWhereClause.Append(whereClausePrefix);
				sbWhereClause.AppendFormat
				(
					WholeWordsWildCardSearchQueryFormat,
					word
				);
				whereClausePrefix = " AND ";
			}
			String selectStatement = String.Format
			(
				SQLQueryFormatAppendClause,
				sbWhereClause.ToString()
			);
			int versesCount = (int) DataCommand.DatabaseCommand
						   (
								selectStatement,
								System.Data.CommandType.Text,
								DataCommand.ResultType.Scalar
							);
			return versesCount;
		}
		
		/*
			http://
			string[] array = new string[]{"big", "bad", "dog"};
		*/	
		public static Dictionary<string, int> WordPermutationEricLippert(string[] array)
		{
			bool found = false;
			int wordOccurrence = -1;
			SameWordComparer compareWord = new SameWordComparer();
			Dictionary<string, int> uniqueWords = new Dictionary<string, int>(compareWord);

			for(ulong mask = 0; mask < (1ul << array.Length); mask++)
			{
				string permutation = "";
				for(int i = 0; i < array.Length;  i++)
				{
					if((mask & (1ul << (array.Length - 1 - i))) != 0)
					{
						permutation += array[i] + " ";
					}
				}
				permutation = permutation.Trim();
				if (permutation.Length == 0) continue;
				found = uniqueWords.TryGetValue(permutation, out wordOccurrence);
				if (!found)
				{
					wordOccurrence = WordOccurrence(permutation);
					uniqueWords.Add(permutation, wordOccurrence);
				}	
			}
			
			return uniqueWords;
		}
		
		public static Dictionary<string, int> WordPermutationEricLippert(string sentence)
		{
			string[] words = null;
			words = sentence.Split(SplitSeparator);
			return WordPermutationEricLippert(words);
		}
		
		public const string DefaultArgument = "Differencing from my need.";
		public static readonly char[] SplitSeparator = new Char [] {' ', ',', '.', ':', ';', '(', ')', '?', '!'};
		public const string SQLOneWordFormat = 
			"SELECT COUNT(*) AS verseCount FROM Bible..Scripture WHERE VerseText LIKE '%{0}%'";	
		public const string SQLQueryFormatAppendClause = 
			"SELECT COUNT(*) AS verseCount FROM Bible..Scripture {0}";	
		public const string WholeWordsWildCardSearchQueryFormat = "  ( verseText  LIKE  '%[^a-z]{0}[^a-z]%' ) ";	
		
		class SameWordComparer : EqualityComparer<string>
		{
			public override bool Equals(string s1, string s2)
			{
				return s1.Equals(s2, StringComparison.CurrentCultureIgnoreCase);
			}

			public override int GetHashCode(string s)
			{
				return base.GetHashCode();
			}
		}
	}
}
