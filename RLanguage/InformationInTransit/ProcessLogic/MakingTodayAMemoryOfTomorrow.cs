using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.SqlServer.Server;
using System.Collections;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;

///<summary>
///	2016-09-26	Created. Making today, a memory, of tomorrow. MakingTodayAMemoryOfTomorrow.cs
///				Personal computer  (PC), find the words that start with P, and the next word starts with C.
///				https://en.wikipedia.org/wiki/Microsoft
///</summary>
namespace InformationInTransit.ProcessLogic
{
    public static partial class MakingTodayAMemoryOfTomorrow
    {
		public static void Main(string[] argv)
		{
			DataSet dataSet = Query(argv[0], argv[1]);
			dataSet.Tables[0].DumpDataTable();
		}	
		
		public static DataSet Query(string firstLetters, string bibleVersion)
        {
            firstLetters = firstLetters.ToLower();
			
			DataTable bible = (DataTable) DataCommand.DatabaseCommand
			(
				String.Format(BibleSQL, bibleVersion),
				System.Data.CommandType.Text,
				DataCommand.ResultType.DataTable
			);
			
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add("Phrase");
			dataTable.Columns.Add("ScriptureReference");
			 
			String[] words;
			StringBuilder wordsCombined = new StringBuilder();;
			
			int firstLettersLength = firstLetters.Length;
			
			foreach(DataRow dataRow in bible.Rows)
			{
				words = dataRow["VerseText"].ToString().Split(Delimiters, StringSplitOptions.RemoveEmptyEntries);
				
				int wordSet = 0;

				for
				(
					int wordIndex = 0, wordCount = words.Length, wordPlus = wordIndex; 
					wordIndex < wordCount - firstLettersLength;
					++wordIndex, wordPlus = wordIndex
				)
				{
					for
					(
						int firstLettersIndex = 0;
						firstLettersIndex < firstLettersLength;
						++firstLettersIndex, ++wordPlus
					)
					{
						/*
						System.Console.WriteLine
						(
							"{0} {1} {2} {3} {4}",
							dataRow["ScriptureReference"],
							dataRow["VerseText"],
							firstLetters[firstLettersIndex],
							words[wordPlus][0],
							wordSet
						);
						*/
						if (firstLetters[firstLettersIndex] != words[wordPlus][0])
						{
							wordSet = 0;
							break;
						}
						
						++wordSet;
					}
	
					if (wordSet >= firstLettersLength)
					{
						wordsCombined = new StringBuilder();
						for (int wordStart = wordPlus - firstLettersLength; wordStart < wordPlus; ++wordStart)
						{
							if (wordsCombined.Length != 0)
							{	
								wordsCombined.Append(" ");
							}	
							wordsCombined.Append(words[wordStart]);
						}		
						dataTable.Rows.Add
						(
							wordsCombined,
							dataRow["ScriptureReference"]
						);
						wordSet = 0;
					}
				}	
			}
			
			DataSet dataSet = new DataSet("DataSet");
			dataSet.Tables.Add(dataTable);
			
			return dataSet;
        }
		
		public static readonly string[] Books = {"Genesis","Exodus","Leviticus","Numbers","Deuteronomy","Joshua","Judges","Ruth","1 Samuel","2 Samuel","1 Kings","2 Kings","1 Chronicles","2 Chronicles","Ezra","Nehemiah","Esther","Job","Psalms","Proverbs","Ecclesiastes","Song of Solomon","Isaiah","Jeremiah","Lamentations","Ezekiel","Daniel","Hosea","Joel","Amos","Obadiah","Jonah","Micah","Nahum","Habakkuk","Zephaniah","Haggai","Zechariah","Malachi","Matthew","Mark","Luke","John","Acts","Romans","1 Corinthians","2 Corinthians","Galatians","Ephesians","Philippians","Colossians","1 Thessalonians","2 Thessalonians","1 Timothy","2 Timothy","Titus","Philemon","Hebrews","James","1 Peter","2 Peter","1 John","2 John","3 John","Jude","Revelation"};
		public static readonly char[] Delimiters = new char[] { ' ', ',', ';', '.' };
		public const string BibleSQL = "SELECT ScriptureReference, LOWER({0}) AS VerseText FROM Bible..Scripture_View ORDER BY VerseIDSequence ASC";
		public const string BibleVersionDefault = "KingJamesVersion";
    }
}
