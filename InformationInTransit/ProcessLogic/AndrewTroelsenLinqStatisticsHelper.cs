using System;

using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;	
using System.Xml;
using System.Xml.Serialization;

namespace InformationInTransit.ProcessLogic
{
	///<summary>
	///	2017-04-18	Created.	http://www.apress.com/us/book/9781484213339
	///</summary>
	public class AndrewTroelsenLinqStatisticsHelper
	{
		public static void Main(String[] argv)
		{
			WordStatistics(DefaultAddress, DefaultLimit, DefaultMinimumLength);
		}
		
		public static LongWord[] FindLongestWords(string[] words, int limit)
		{
			LongWord[] longWords = 	
			(
				from word in words
				orderby word.Length descending
				select new LongWord{ Word = word, Length = word.Length}
			).Take(limit).ToArray();
									;
			return longWords;
		}
		
		public static CommonWord[] FindMostCommonWords
		(
			string[] words,
			int limit,
			int minimumLength = DefaultMinimumLength
		)
		{
			CommonWord[] commonWords = 	
			(
				from word in words
				where word.Length >= minimumLength
				group word by word into grp
				orderby grp.Count() descending
				select new CommonWord{ Key = grp.Key, Frequency = grp.Count()}
			).Take(limit).ToArray();
									;
			return commonWords;
		}
		
		public static WordUsage WordStatistics
		(
			string content,
			int	limit,
			int minimumLength
		)
		{
			String[] words = content.Split(	SplitSeparator, StringSplitOptions.RemoveEmptyEntries );
			CommonWord[] mostCommonWords = FindMostCommonWords(words, limit, minimumLength);
			LongWord[] longWords = FindLongestWords(words, limit);

			WordUsage wordUsage = new WordUsage
			{
				CommonWords = mostCommonWords,
				LongWords = longWords
			};	
			
			return wordUsage;
		}
		
		public static readonly char[] SplitSeparator = new char[] { ' ', '\u000A', ',', '.', ';', ':', '-', '?', '/', '"', '(', ')', '[', ']', '<', '>', '/' };
		public const string DefaultAddress = @"http://www.gutenberg.org/files/98/98-8.txt";
		public const int DefaultLimit = 10;
		public const int DefaultMinimumLength = 6;
		
		public class CommonWord
		{
			public string Key { get; set; }
			public long Frequency { get; set; }
		}	
		
		public class LongWord
		{
			public string Word { get; set; }
			public long Length { get; set; }
		}	
		
		public class WordUsage
		{
			public CommonWord[] CommonWords { get; set; }
			public LongWord[] LongWords { get; set; }
		}	
	}
}
