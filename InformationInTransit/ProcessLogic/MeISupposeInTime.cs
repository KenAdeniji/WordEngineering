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
///	2016-07-13	Created. MeISupposeInTime.cs 6+5 Sepp Blatter.
///				Called Night (Genesis 1:5).
///				things saith (Revelation 22:20).
///</summary>
namespace InformationInTransit.ProcessLogic
{
    public static partial class MeISupposeInTime
    {
		public static void Main(string[] argv)
		{
			DataSet otherData = YouKnowTheSound(argv[0], Convert.ToInt32(argv[1]));
			otherData.Tables[0].DumpDataTable();
		}	
		
		public static DataSet YouKnowTheSound(string bibleVersion, int checker)
        {
			DataTable bible = (DataTable) DataCommand.DatabaseCommand
			(
				String.Format(BibleSQL, bibleVersion),
				System.Data.CommandType.Text,
				DataCommand.ResultType.DataTable
			);
			
			DataTable workTable = new DataTable("workTable");
			workTable.Columns.Add("Word");
			workTable.Columns.Add("ScriptureReference");
			
			string pointer = Convert.ToString(checker).Replace("0", "");
			int index = 0;
			bool seriesFound = false;
			String[] words;
			StringBuilder wordCombination = new StringBuilder();
			
			try
			{
				foreach(DataRow dataRow in bible.Rows)
				{
					words = dataRow["VerseText"].ToString().Split(Delimiters, StringSplitOptions.RemoveEmptyEntries);
					foreach(string word in words)
					{
						int pointerIndex = Convert.ToInt32(pointer.Substring(index, 1));
						if (pointerIndex == 0)
						{
							continue;
						}	
						if (word.Length != pointerIndex)
						{
							index = 0;	
							seriesFound = false;
							wordCombination = new StringBuilder();
							continue;
						}						
						if (wordCombination.Length > 0)
						{
							wordCombination.Append(" ");
						}		
						wordCombination.Append(word);
						++index;
						if 	(index >= pointer.Length)
						{	
							workTable.Rows.Add
							(
								wordCombination,
								dataRow["ScriptureReference"]
							);
							/*	
							System.Console.WriteLine
							(
								"word: {0} | word.Length: {1} | index: {2} | pointer[index]: {3} | pointer.Length: {4}",
								word,
								word.Length,
								index,
								pointer[index - 1],
								pointer.Length
							);
							*/
							index = 0;	
							seriesFound = false;
							wordCombination = new StringBuilder();
						}
 					}
				}
			}
			catch(Exception ex)
			{
				System.Console.WriteLine("Exception: {0}", ex.Message);
			}	
			DataSet otherData = new DataSet("OtherData");
			otherData.Tables.Add(workTable);
			
			return otherData;
        }
		
		public static readonly string[] Books = {"Genesis","Exodus","Leviticus","Numbers","Deuteronomy","Joshua","Judges","Ruth","1 Samuel","2 Samuel","1 Kings","2 Kings","1 Chronicles","2 Chronicles","Ezra","Nehemiah","Esther","Job","Psalms","Proverbs","Ecclesiastes","Song of Solomon","Isaiah","Jeremiah","Lamentations","Ezekiel","Daniel","Hosea","Joel","Amos","Obadiah","Jonah","Micah","Nahum","Habakkuk","Zephaniah","Haggai","Zechariah","Malachi","Matthew","Mark","Luke","John","Acts","Romans","1 Corinthians","2 Corinthians","Galatians","Ephesians","Philippians","Colossians","1 Thessalonians","2 Thessalonians","1 Timothy","2 Timothy","Titus","Philemon","Hebrews","James","1 Peter","2 Peter","1 John","2 John","3 John","Jude","Revelation"};
		public static readonly char[] Delimiters = new char[] { ' ', ',', ';', '.', '?', ':', '!', '(', ')' };
		public const string BibleSQL = "SELECT ScriptureReference, VerseText = {0} FROM Bible..Scripture_View ORDER BY VerseIDSequence";
		public const string BibleVersionDefault = "KingJamesVersion";
    }
}
