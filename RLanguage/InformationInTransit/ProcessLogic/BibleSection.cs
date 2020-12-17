using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;

using System.Globalization;
using System.Threading;

using InformationInTransit.DataAccess;

namespace InformationInTransit.ProcessLogic
{
	/*
		2018-01-12	Created.	Psalms 168. Poetic.	Psalms 126, Job 8:8
		2018-01-13T03:00:00 Inconsistency with sequence order of the Bible and Tanakh.
		2018-01-13	https://en.wikipedia.org/wiki/Chapters_and_verses_of_the_Bible
	*/
	public class BibleSection
	{
		public static void Main(string[] argv)
		{
			ScriptureReference("Poetry", 168);
		}
		
		public static string[] DictionaryKeys()
		{
			string[] keys = Section.Keys.ToArray();
			return keys;
		}
		
        public static string ScriptureReference
		(
			string sectionKey,
			int alphabetSequenceIndex
		)
        {
			var sectionValues = Section.FirstOrDefault(x => x.Key == sectionKey).Value;
			string sectionJoin = string.Join(",", sectionValues.ToArray());

			StringBuilder sb = new StringBuilder();
			
			int arrayIndex = -1;
			
			int	presetValueChapter;
			int	presetValueVerse;
			
			foreach(string sectionValue in sectionValues)
			{
				arrayIndex = Array.IndexOf
				(
					ScriptureReferenceHelper.ScriptureReference.Books,
					sectionValue
				);
				if (sb.Length > 0)
				{
					sb.Append(", ");
				}	
				sb.Append(arrayIndex + 1);
			}
			
			DataTable chapterTable = (DataTable) DataCommand.DatabaseCommand
			(
				String.Format
				(
					ChapterQueryFormat,
					sb
				),	
                System.Data.CommandType.Text,
                DataCommand.ResultType.DataTable
            );
			
			int chapterTableCount = (int) DataCommand.DatabaseCommand
			(
				String.Format
				(
					ChapterQueryCountFormat,
					sb
				),	
                System.Data.CommandType.Text,
                DataCommand.ResultType.Scalar
            );
			
			int verseTableCount = (int) DataCommand.DatabaseCommand
			(
				String.Format
				(
					VerseQueryCountFormat,
					sb
				),	
                System.Data.CommandType.Text,
                DataCommand.ResultType.Scalar
            );
			
			presetValueChapter = alphabetSequenceIndex % chapterTableCount;

			int	bookID = -1;
			int	chapterID = -1;
			
			string	chapterForward = "";
			
			foreach (DataRow row in chapterTable.Rows)
            {
				bookID = (int) row["BookID"];
				int	chapterCount = (int) row["ChapterCount"];
				
				if ((presetValueChapter - chapterCount) > 0)
				{
					presetValueChapter -= chapterCount;
				}
				else
				{
					chapterForward = ScriptureReferenceHelper.ScriptureReference.Books
					[
						bookID - 1
					] + " " + presetValueChapter.ToString();
					break;
				}		
            }

			string	chapterBackward = "";
			presetValueChapter = alphabetSequenceIndex % chapterTableCount;
			
			for
			(
				int rowIndex = chapterTable.Rows.Count - 1;
				rowIndex >= 0;
				--rowIndex
			)	
            {
				DataRow row = chapterTable.Rows[rowIndex];
				bookID = (int) row["BookID"];
				int	chapterCount = (int) row["ChapterCount"];
				
				if ((presetValueChapter - chapterCount) > 0)
				{
					presetValueChapter -= chapterCount;
				}
				else
				{
					chapterBackward = ScriptureReferenceHelper.ScriptureReference.Books
					[
						bookID - 1
					] + " " + (chapterCount - presetValueChapter).ToString();
					break;
				}		
            }
			
			DataTable verseTable = (DataTable) DataCommand.DatabaseCommand
			(
				String.Format
				(
					VerseQueryFormat,
					sb
				),	
                System.Data.CommandType.Text,
                DataCommand.ResultType.DataTable
            );

			string	verseForward = "";
			
			presetValueVerse = alphabetSequenceIndex % verseTableCount;
			
			foreach (DataRow row in verseTable.Rows)
            {
				int	verseCount = (int) row["VerseCount"];
				
				if ((presetValueVerse - verseCount) > 0)
				{
					presetValueVerse -= verseCount;
				}
				else
				{
					bookID = (int) row["BookID"];
					chapterID = (int) row["ChapterID"];
					verseForward = ScriptureReferenceHelper.ScriptureReference.Books
					[
						bookID - 1
					] + " " + chapterID.ToString() + ":" + presetValueVerse.ToString();
					break;
				}		
            }
			
			string	verseBackward = "";
			presetValueVerse = alphabetSequenceIndex % verseTableCount;
			
			for
			(
				int rowIndex = verseTable.Rows.Count - 1;
				rowIndex >= 0;
				--rowIndex
			)	
            {
				DataRow row = verseTable.Rows[rowIndex];
				bookID = (int) row["BookID"];
				chapterID = (int) row["ChapterID"];
				int	verseCount = (int) row["VerseCount"];
				
				if ((presetValueVerse - verseCount) > 0)
				{
					presetValueVerse -= verseCount;
				}
				else
				{
					verseBackward = ScriptureReferenceHelper.ScriptureReference.Books
					[
						bookID - 1
					] + " " + chapterID.ToString() + ":" + ((verseCount - presetValueVerse).ToString());
					
					break;
				}		
            }
			
			StringBuilder	scriptureReference = ParamsHelper.Append
			(
				chapterForward,
				verseForward,
				chapterBackward,
				verseBackward
			);
			
			System.Console.WriteLine(scriptureReference);
			
			return scriptureReference.ToString();
        }
		
		//2018-01-12	https://stackoverflow.com/questions/14472245/initialize-dictionarystring-liststring
		public static readonly Dictionary<string, List<string>> Section = new Dictionary<string, List<string>>()
		{
		/*	
			{"Torah", new List<string> { "Genesis", "Exodus", "Leviticus", "Numbers", "Deuteronomy" } },
			{"Nevi'im", new List<string> { "Joshua", "Judges", "1 Samuel", "2 Samuel", "1 Kings", "2 Kings", "Isaiah", "Jeremiah", "Ezekiel", "Hosea", "Joel", "Amos", "Obadiah", "Jonah", "Micah", "Nahum", "Habakkuk", "Zephaniah", "Haggai", "Zechariah", "Malachi"} },
			{"Ketuvim", new List<string> { "Psalms", "Proverbs", "Job", "Song of Solomon", "Ruth", "Lamentations", "Ecclesiastes", "Esther", "Daniel", "Ezra", "Nehemiah", "1 Chronicles", "2 Chronicles" } },
		*/
			{"Pentateuch", new List<string> {"Genesis", "Exodus", "Leviticus", "Numbers", "Deuteronomy" } },
			{"Historical", new List<string> {"Joshua", "Judges", "Ruth", "1 Samuel", "2 Samuel", "1 Kings", "2 Kings", "1 Chronicles", "2 Chronicles", "Ezra", "Nehemiah", "Esther"}},
			{"Poetry", new List<string> {"Job", "Psalms", "Proverbs", "Ecclesiastes", "Song of Solomon" } },
			{"Major Prophets", new List<string> {"Isaiah", "Jeremiah", "Lamentations", "Ezekiel", "Daniel" } },
			{"Minor Prophets", new List<string> {"Hosea", "Joel", "Amos", "Obadiah", "Jonah", "Micah", "Nahum", "Habakkuk", "Zephaniah", "Haggai", "Zechariah", "Malachi"}},
			{"Gospels", new List<string> {"Matthew", "Mark", "Luke", "John" } },
			{"History", new List<string> {"Acts" } },
			{"Pauline Epistles", new List<string> {"Romans", "1 Corinthians", "2 Corinthians", "Galatians", "Ephesians", "Philippians", "Colossians", "1 Thessalonians", "2 Thessalonians", "1 Timothy", "2 Timothy", "Titus", "Philemon" } },
			{"General Epistles", new List<string> {"Hebrews", "James", "1 Peter", "2 Peter", "1 John", "2 John", "3 John", "Jude" }},
			{"Apocalyptic Writings", new List<string> {"Revelation"}}
		};
		
		public const string ChapterQueryFormat = "SELECT BookID, COUNT(DISTINCT ChapterID) AS ChapterCount FROM Bible..Scripture_View WHERE BookID IN ({0}) GROUP BY BookID";
		public const string ChapterQueryCountFormat = "SELECT COUNT(ChapterID) AS ChapterCount FROM Bible..Scripture_View WHERE BookID IN ({0})";		
		public const string VerseQueryFormat = "SELECT BookID, ChapterID, COUNT(VerseID) AS VerseCount FROM Bible..Scripture_View WHERE BookID IN ({0}) GROUP BY BookID, ChapterID ORDER BY BookID, ChapterID";
		public const string VerseQueryCountFormat = "SELECT COUNT(VerseID) AS VerseCount FROM Bible..Scripture_View WHERE BookID IN ({0})";		
		
		public const string ScriptureReferenceFormat = "{0}, {1}, {2}, {3}";
	}
}
