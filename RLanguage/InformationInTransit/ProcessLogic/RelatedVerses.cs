using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;

using InformationInTransit.DataAccess;

/*
2015-03-08 	RelatedVerses.cs created.
2015-03-17	dotnetperls.com/nested-list
*/
namespace InformationInTransit.ProcessLogic
{
    public class RelatedVersesArguments
    {
		[Argument(ArgumentType.AtMostOnce, HelpText="The ratio of words, that are equal.")]
		public decimal compareWords = 0.1M;
		
		[Argument(ArgumentType.AtMostOnce, HelpText="If frequency of occurrence is higher, ignore.")]
        public int OccurrenceLimit = 50;
    }

	public static partial class RelatedVerses
	{
		public static void Main(string[] argv)
		{
            RelatedVersesArguments parsedArgs = new RelatedVersesArguments();
            bool argumentsParser = Parser.ParseArgumentsWithUsage(argv, parsedArgs);

			if (argumentsParser == false)
			{
				return;
			}
			
			Parse(parsedArgs);
			
			return;
		}
		
		///<remarks>
		///	Search for words, that occur in both verses.
		///</remarks>
		public static decimal CompareWords(List<string> outerWords, List<string> innerWords)
		{
			bool found = false;
			int occurrence = 0;
			
			if (outerWords.Count == 0 || innerWords.Count == 0)
			{
				return 0;
			}

			int length = outerWords.Count > innerWords.Count ? outerWords.Count : innerWords.Count;
			foreach(String outerWord in outerWords)
			{
				found = innerWords.Contains(outerWord);
				if (found)
				{
					++occurrence;
				}	
			}
			return (decimal) occurrence / length;
		}
		
		///<remarks>
		///	Go through each verse in the Bible.
		///	If the ratio of the words is great, insert into the database.
		///</remarks>
		public static void Parse(RelatedVersesArguments parsedArgs)
		{
			string outerVerseText = null;
			List<List<String>> outerWords = new List<List<String>>();
			List<String> wordsParsed = null;
			
			DataTable dataTableBible = ReadBible();
			DataTable dataTableExact = ReadExact(parsedArgs);
			
			for(int outerIndex = 0, lastRow = dataTableBible.Rows.Count; outerIndex < lastRow; ++outerIndex)
			{
				outerVerseText = (string) dataTableBible.Rows[outerIndex]["verseText"];
				wordsParsed = ParseSentence(outerVerseText, dataTableExact);
				outerWords.Add(wordsParsed);
			}
			
			DataCommand.DatabaseCommand
			(
				"TRUNCATE TABLE Bible..RelatedVerses; DBCC CHECKIDENT('Bible..RelatedVerses', RESEED, 1);",
				CommandType.Text,
				DataCommand.ResultType.NonQuery
			);

			string outerScriptureReference = null;
			string innerScriptureReference = null;

			decimal compareWords = 0;
			StringBuilder alike = null;
			string relatedVersesInsertStatement = null;
			
			for(int outerIndex = 0, lastRow = dataTableBible.Rows.Count; outerIndex < lastRow; ++outerIndex)
			{
				outerScriptureReference = (string) dataTableBible.Rows[outerIndex]["scriptureReference"];
				
				alike = new StringBuilder();

				for(int innerIndex = 0; innerIndex < lastRow; ++innerIndex)
				{
					if (outerIndex == innerIndex)
					{
						continue;
					}	

					innerScriptureReference = (string) dataTableBible.Rows[innerIndex]["scriptureReference"];
					
					compareWords = CompareWords(outerWords[outerIndex], outerWords[innerIndex]);
					
					if (compareWords >= parsedArgs.compareWords)
					{
						if (alike.Length > 0)
						{
							alike.Append(", ");
						}
						alike.Append(innerScriptureReference);	
					}
				}

				if (alike.Length > 0)
				{
					relatedVersesInsertStatement = String.Format
					(
						RelatedVersesInsertStatementFormat,
						outerScriptureReference,
						alike.ToString()
					);
					
					DataCommand.DatabaseCommand
					(
						relatedVersesInsertStatement,
						CommandType.Text,
						DataCommand.ResultType.NonQuery
					);
				}
			}
		}	
		
		public static List<String> ParseSentence(string sentence, DataTable dataTableExact)
		{
			string adjust = null;
			string[] words = sentence.Split(SplitSeparator);
			DataRow foundRow = null;
			List<String> checkWord = new List<String>();
			foreach(string word in words)
			{
				adjust = word.Trim();
				if (adjust == String.Empty)
				{
					continue;
				}
				foundRow = dataTableExact.Rows.Find(adjust);
				if (foundRow == null)
				{
					continue;
				}
				checkWord.Add(adjust);
			}
			return checkWord;
		}
		
		public static DataTable ReadBible()
		{
			DataTable dataTable = (DataTable) DataCommand.DatabaseCommand
			(
				"SELECT * FROM Bible..Scripture ORDER BY bookId, chapterId, verseId",
				CommandType.Text,
				DataCommand.ResultType.DataTable
			);
			return dataTable;
		}

		public static DataTable ReadExact(RelatedVersesArguments parsedArgs)
		{
			string exactSelectStatement = String.Format
			(
				ExactSelectStatementFormat,
				parsedArgs.OccurrenceLimit
			);	
			DataTable dataTable = (DataTable) DataCommand.DatabaseCommand
			(
				exactSelectStatement,
				CommandType.Text,
				DataCommand.ResultType.DataTable
			);
			DataColumn[] primaryKey = new DataColumn[] {dataTable.Columns["BibleWord"]};
			dataTable.PrimaryKey = primaryKey;
			return dataTable;
		}
		
		public const string ExactSelectStatementFormat = "SELECT * FROM Bible..Exact WHERE Occurrence <= {0}";
		public const string RelatedVersesInsertStatementFormat = "INSERT INTO Bible..RelatedVerses(ScriptureReference, Alike) VALUES('{0}', '{1}');";
		public static readonly char[] SplitSeparator = new Char [] {' ', ',', '.', ':', ';', '(', ')', '?', '!'};
	}
}
