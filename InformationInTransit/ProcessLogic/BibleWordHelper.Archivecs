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
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;

namespace InformationInTransit.ProcessLogic
{
	/*
		2013-03-23 BibleWord.aspx.cs BibleWordPage created. HtmlBible.com example.
		2013-05-23T18:00:00 Support for phrase added.
			Here I am (Genesis 22).
			Here am I (1 Samuel 3).
			I Am here (Acts 9:10).
		2013-07-11T15:49:00 ScriptureReference concatenate visible
		2014-08-02 	ParsebibleBookGroup(). bibleBookGroup All, Old, New.
		2015-10-04	http://stackoverflow.com/questions/5444300/search-for-whole-word-match-with-sql-server-like-pattern
		2015-10-04 	WholeWordsWildCardSearchQueryFormat.
		2015-10-04 	Verse(s) count.
		2015-10-04	http://www.textfixer.com/tutorials/css-table-alternating-rows.php
		2015-10-07	BibleWord.cs created.
		2015-10-07	BibleWord.html created.
		2015-10-07	I Am the LORD.
		2015-11-09	Changed the variable, named; andOrPhrase to logic; creating room for future expansion.
		2015-11-15	GetAPage();
		2015-11-16	http://stackoverflow.com/questions/2886480/concatenate-all-list-content-in-on-string-in-c-sharp
		2016-03-14	string[] words = sentence.Split(SplitSeparator, StringSplitOptions.RemoveEmptyEntries); //http://www.dotnetperls.com/split
		2016-04-25	Bible versions. King James Version (KingJamesVersion), American Standard Bible, Young's Literal Translation
		2016-05-15	OccurrenceOfTheMotion.
		2017-05-12	brenocon@cs.umass.edu
		2018-04-24 	http://quondam.csi.edu/ip/adc/faculty/bbennett/ps011exp.htm
		2020-12-29	https://stackoverflow.com/questions/23292776/counting-the-occurrences-of-every-duplicate-words-in-a-string-using-dictionary-i/23292870
					static string[] SplitWords(string s)
					{
						 return Regex.Split(s, @"\W+");
					}
		2021-01-21	Apocalyptic Books			
	*/
	public static partial class BibleWordHelper
	{
		public static void Main(string[] argv)
		{
			DataSet resultSet = null;
			if (argv.Length > 0)
			{
                resultSet = GetAPage(argv[0], "KingJamesVersion");
			}		
		}

		public static DataSet CheckForCombination
		(
			List<String>	keywords,
			String			logic,
			String			bibleVersion
		)
		{
			DataSet dataSet = null;
			StringBuilder sqlWhereClause = new StringBuilder(" WHERE ");

			if (keywords.Count == 0)
			{
				return dataSet;
			}

			for(int wordIndex = 0; wordIndex < keywords.Count; ++wordIndex)
			{
				if (wordIndex > 0)
				{
					sqlWhereClause.Append(" " + logic + " ");
				}
				
				sqlWhereClause.AppendFormat
				(
					WholeWordsWildCardSearchQueryFormat,
					keywords[wordIndex],
					bibleVersion
				);
			}
			String sqlStatement = String.Format
            (
			    BibleQueryFormat,
				bibleVersion,
                sqlWhereClause
            );
            dataSet = ProcessSqlStatement(sqlStatement, bibleVersion);
			dataSet.Tables[0].DumpDataTable();
			return dataSet;
		}
		
		public static DataSet CheckForPhrase
		(
			String	question,
			String	bibleVersion
		)
		{
			DataSet dataSet = null;
			StringBuilder sqlWhereClause = new StringBuilder(" WHERE ");

			question = question.Trim();
			
			if (question.Length == 0)
			{
				return dataSet;
			}
			
			sqlWhereClause.AppendFormat
			(
				WholeWordsWildCardSearchQueryFormat,
				question,
				bibleVersion
			);
			
			String sqlStatement = String.Format(BibleQueryFormat, bibleVersion, sqlWhereClause);
            dataSet = ProcessSqlStatement(sqlStatement, bibleVersion);
			dataSet.Tables[0].DumpDataTable();
			return dataSet;
		}

		public static DataSet GetAPage
		(
			String	question,
			String	bibleVersion
		)
		{
			DataSet dataSet = null;
			DataTable dataTable = null;
			
			question = question.Replace("'", "''");

            dataSet = CheckForPhrase(question, bibleVersion);
			
			if (dataSet.IsEmpty() == false)
			{
				return dataSet;
			}
			
			string[] keywords = Split(question);
			
			var distinctWords = new List<string>(keywords.Distinct());
			List<string> existWords = new List<string>();

			foreach(string word in distinctWords)
			{
				string wholeWordsFindSqlStatement = String.Format
				(
					WholeWordsWildCardSearchQueryFormat,
					word,
					bibleVersion
				);	
				string bibleWordFindSqlStatement = String.Format
				(
					BibleWordFindFormat,
					" WHERE " + wholeWordsFindSqlStatement
				);
				Object result = DataCommand.DatabaseCommand
				(
					bibleWordFindSqlStatement,
					System.Data.CommandType.Text,
					DataCommand.ResultType.Scalar
				);
				int verseIdSequence = -1;
				if (result != null && result != DBNull.Value)
				{
					verseIdSequence = (int) result;
					existWords.Add(word);
				}		
				System.Console.WriteLine
				(
					"word: {0} | verseIdSequence: {1}",
					word,
					verseIdSequence
				);
			}	

			string wordCombination = string.Join(" ", existWords.ToArray());
            dataSet = CheckForPhrase(wordCombination, bibleVersion);
			if (dataSet.IsEmpty() == false)
			{
				return dataSet;
			}
			dataSet = CheckForCombination(existWords, "and", bibleVersion);
			return dataSet;
		}

		public static DataSet OccurrenceOfTheMotion
		(
			String	logic,
			String	bibleBookGroup,
			String	question,
			bool	wholeWords,
			String	bibleVersion
		)
		{
			DataSet dataSetVerses = Query
			(
				logic,
				bibleBookGroup,
				question,
				wholeWords,
				bibleVersion
			);
			
			StringBuilder verseIdSequences = new StringBuilder();
			
			foreach(DataTable dataTableVerses in dataSetVerses.Tables)
			{
				foreach(DataRow dataRowVerses in dataTableVerses.Rows)
				{
					if (verseIdSequences.Length > 0)
					{
						verseIdSequences.Append(", ");
					}
					verseIdSequences.Append( dataRowVerses["verseIdSequence"] );
				}	
			}

			DataSet dataSetHisWord_viewFormat = (DataSet)DataCommand.DatabaseCommand
			(
				String.Format(HisWord_viewFormat, verseIdSequences),
				CommandType.Text,
				DataCommand.ResultType.DataSet
			);
			return dataSetHisWord_viewFormat;
		}
		
		public static DataSet Query
		(
			String	logic,
			String	bibleBookGroup,
			String	question,
			bool	wholeWords,
			String	bibleVersion
		)
		{
			DataSet resultSet = null;
			StringBuilder sqlWhereClause = new StringBuilder();
			String[] keywords = null;

            StringBuilder sqlbibleBookGroup = ParseBibleBookGroup(bibleBookGroup);		
			StringBuilder sqlWord = PrepareSqlStatement
            (
                logic,
                question,
				wholeWords,
                out keywords,
				bibleVersion
            );
			if (sqlWord.Length == 0)
			{
				return resultSet;
			}
			else
			{
				sqlWhereClause.AppendFormat
				(
					WhereQueryFormat,
					sqlbibleBookGroup,
					sqlbibleBookGroup.Length == 0 ? "" : " AND ",
					"(" + sqlWord + ")"
				);
			}
			
			String sqlStatement = String.Format
            (
			    BibleQueryFormat,
				bibleVersion,
                sqlWhereClause
            );
            resultSet = ProcessSqlStatement(sqlStatement, bibleVersion);
			return resultSet;
		}
		
		public static StringBuilder BuildResult
		(
			DataSet dataSet
		)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<table id='resultSet' border='1'>");
			int subsetIndex = 0;
			foreach(DataTable dataTable in dataSet.Tables)
			{
				foreach(DataRow dataRow in dataTable.Rows)
				{
					int bookId = (int) dataRow["bookId"];
					string bookTitle = ScriptureReference.BookName(bookId);
					int chapterId = (int) dataRow["chapterId"];
					int verseId = (int) dataRow["verseId"];
					string verseText = (string) dataRow["verseText"];
					
					sb.Append
					(
						"<tr><td>" + 
						String.Format("{0} {1}:{2}", bookTitle, chapterId, verseId) +
						"</td><td>" + verseText + "</td></tr>"
					);
				}
			}
			sb.Append("</table>");
			return sb;
		}

		public static StringBuilder ParseBibleBookGroup(string bibleBookGroup)
		{
			StringBuilder sqlStatement = new StringBuilder();
			
			string[] bookGroups = bibleBookGroup.Split(',');
			
			int indexOfAll = Array.IndexOf(bookGroups, "all");
			int indexOfOld = Array.IndexOf(bookGroups, "old");
			int indexOfNew = Array.IndexOf(bookGroups, "new");
			
			if (indexOfAll >= 0)
			{
				return(sqlStatement);
			}

			if (indexOfOld >= 0 && indexOfNew == -1)
			{
				sqlStatement.AppendFormat(" ( Testament = '{0}' ) ", "Old");
				return(sqlStatement);
			}
			else if (indexOfOld == -1 && indexOfNew >= 0)
			{
				sqlStatement.AppendFormat(" ( Testament = '{0}' ) ", "New");
				return(sqlStatement);
			}
			else if (indexOfOld >= 0 && indexOfNew >= 0)
			{
				return(sqlStatement);
			}
			
			foreach(string bookGroup in bookGroups)
			{
				if (bookGroup == "pentateuch")
				{
					if (indexOfOld == -1)
					{
						if (sqlStatement.Length > 0)
						{
							sqlStatement.Append(" OR ");
						}
						sqlStatement.AppendFormat(" ( BookID BETWEEN 1 AND 5 ) ");
					}	
				}

				if (bookGroup == "poetry")
				{
					if (indexOfOld == -1)
					{
						if (sqlStatement.Length > 0)
						{
							sqlStatement.Append(" OR ");
						}
						sqlStatement.AppendFormat(" ( BookID BETWEEN 18 AND 22 ) ");
					}	
				}

				if (bookGroup == "major prophets")
				{
					if (indexOfOld == -1)
					{
						if (sqlStatement.Length > 0)
						{
							sqlStatement.Append(" OR ");
						}
						sqlStatement.AppendFormat(" ( BookID BETWEEN 23 AND 27 ) ");
					}	
				}

				if (bookGroup == "minor prophets")
				{
					if (indexOfOld == -1)
					{
						if (sqlStatement.Length > 0)
						{
							sqlStatement.Append(" OR ");
						}
						sqlStatement.AppendFormat(" ( BookID BETWEEN 28 AND 39 ) ");
					}	
				}

				if (bookGroup == "gospel")
				{
					if (indexOfNew == -1)
					{
						if (sqlStatement.Length > 0)
						{
							sqlStatement.Append(" OR ");
						}
						sqlStatement.AppendFormat(" ( BookID BETWEEN 40 AND 43 ) ");
					}	
				}
				
				if (bookGroup == "pauline epistles")
				{
					if (indexOfNew == -1)
					{
						if (sqlStatement.Length > 0)
						{
							sqlStatement.Append(" OR ");
						}
						sqlStatement.AppendFormat(" ( BookID BETWEEN 45 AND 57 ) ");
					}	
				}

				if (bookGroup == "general epistles")
				{
					if (indexOfNew == -1)
					{
						if (sqlStatement.Length > 0)
						{
							sqlStatement.Append(" OR ");
						}
						sqlStatement.AppendFormat(" ( BookID BETWEEN 59 AND 65 ) ");
					}	
				}
				
				if (bookGroup == "apocalyptic books")
				{
					if (sqlStatement.Length > 0)
					{
						sqlStatement.Append(" OR ");
					}
					sqlStatement.AppendFormat(" (BookID = 27 OR BookID = 66 ) ");
				}
			}
			
			return sqlStatement;
		}
		
		public static StringBuilder PrepareSqlStatement
        (
            string logic,
            string question,
			bool wholeWords,
            out string[] keywords,
			string bibleVersion
        )
		{
			if (logic == "phrase")
			{
				keywords = new String[] { question };
			}
			else
			{
				keywords = Split(question);
			}	
			
			string queryFormat = wholeWords ? WholeWordsWildCardSearchQueryFormat : PartialWordsQueryFormat;
			StringBuilder sqlStatement = new StringBuilder();
			StringBuilder sqlWhereClause = new StringBuilder();
			
			for(int index = 0, count = keywords.Length; index < count; ++index)
			{
				keywords[index] = keywords[index].Trim();
				if (index > 0)
				{
					sqlWhereClause.Append(' ' + logic + ' ');
				}
				sqlWhereClause.AppendFormat(queryFormat, keywords[index], bibleVersion);
			}
			return sqlWhereClause;
		}

		public static StringBuilder PrepareSqlStatement
        (
            string logic,
            string bibleWord,
			bool wholeWords,
            out string[] keywords,
			string[] bibleVersions
        )
		{
			string queryFormat = wholeWords ? WholeWordsWildCardSearchQueryFormat : PartialWordsQueryFormat;
			StringBuilder sqlWhereClause = new StringBuilder();
			StringBuilder sb = new StringBuilder();
			
			keywords = new String[] { bibleWord };
			
			foreach (String bibleVersion in bibleVersions)
			{
				if (sqlWhereClause.Length > 0)
				{
					sqlWhereClause.Append(" AND ");
				}	
				sb = PrepareSqlStatement
				(
					logic,
					bibleWord,
					wholeWords,
					out keywords,
					bibleVersion
				);	
				sqlWhereClause.Append( sb.ToString() );
			}	
			return sqlWhereClause;
		}

		public static DataSet ProcessSqlStatement
		(
			String sqlStatement,
			string bibleVersion
		)
		{
			string sqlStatementTrim = sqlStatement;

			if (String.Compare(bibleVersion, ScriptureReferenceHelper.BibleVersionDefault, true) != 0)
			{
                sqlStatement = Regex.Replace
				(
                    sqlStatement,
					"verseText",
					bibleVersion + " AS verseText ",
					RegexOptions.IgnoreCase
				);
				
				int indexOfWhereClause = sqlStatement.IndexOf("FROM Bible.." + ScriptureReferenceHelper.BibleVersionDefault + " WHERE");
				string whereClauseWithASVerseText = sqlStatement.Substring(indexOfWhereClause);
				string whereClauseWithoutASVerseText = Regex.Replace
				(
                    whereClauseWithASVerseText,
					"AS verseText",
					"",
					RegexOptions.IgnoreCase
				);
				sqlStatementTrim = sqlStatement.Substring(0, indexOfWhereClause) + 
											whereClauseWithoutASVerseText;
			}	
			
			DataSet dataSet = null;
			dataSet = (DataSet)DataCommand.DatabaseCommand
			(
				sqlStatementTrim,
				CommandType.Text,
				DataCommand.ResultType.DataSet
			);
			return dataSet;
		}

		public static string[] Split
        (
			string sentence
        )
		{
			string[] words = sentence.Split(SplitSeparator, StringSplitOptions.RemoveEmptyEntries);
			return words;
		}
		
		static BibleWordHelper()
		{
			PartsOfSpeechArray = Split(PartsOfSpeech);	
		}	
		
		public class ScriptureReference
		{
			public ScriptureReference()
			{
			}

            public ScriptureReference(ScriptureReference scriptureReference)
			{
				this.BookTitle = scriptureReference.BookTitle;
				this.Chapter = scriptureReference.Chapter;
				this.Verse = scriptureReference.Verse;
			}
			
			public int?	 BookId
			{
				get
				{
					int? bookId = null;
					if ( !String.IsNullOrEmpty(BookTitle) )
					{
						bookId = Array.FindIndex(Books, p => p.Equals(BookTitle, StringComparison.CurrentCultureIgnoreCase));
						if (bookId > -1) {++bookId;} //Arrays are zero-based.
					}	
					return bookId;
				}
			}

			public static string BookName(int bookId)
			{
				string bookName = null;
				if ( bookId > 0 && bookId < MaxBookId )
				{
					bookName = Books[bookId - 1];
				}	
				return bookName;
			}

			public string 	BookTitle { get; set; }
			public int?		Chapter	{ get; set; }
			public int?		Verse { get; set; }
			
			public override string ToString() 
			{
				return String.Format
				(
					"{0} {1}{2}{3}",
					BookTitle,
					Chapter,
					Chapter != null && Verse != null ? ":" : "", 
					Verse
				);	
			}
			
			public static readonly string[] Books = {"Genesis","Exodus","Leviticus","Numbers","Deuteronomy","Joshua","Judges","Ruth","1 Samuel","2 Samuel","1 Kings","2 Kings","1 Chronicles","2 Chronicles","Ezra","Nehemiah","Esther","Job","Psalms","Proverbs","Ecclesiastes","Song of Solomon","Isaiah","Jeremiah","Lamentations","Ezekiel","Daniel","Hosea","Joel","Amos","Obadiah","Jonah","Micah","Nahum","Habakkuk","Zephaniah","Haggai","Zechariah","Malachi","Matthew","Mark","Luke","John","Acts","Romans","1 Corinthians","2 Corinthians","Galatians","Ephesians","Philippians","Colossians","1 Thessalonians","2 Thessalonians","1 Timothy","2 Timothy","Titus","Philemon","Hebrews","James","1 Peter","2 Peter","1 John","2 John","3 John","Jude","Revelation"};
			public static readonly int MaxBookId = Books.Count() + 1;
		}

		public static readonly char[] SplitSeparator = new Char [] {' ', ',', '.', ':', ';', '(', ')', '?', '!'};
		
		public const string BibleQueryFormat = "SELECT bookId, chapterId, verseId, verseText = {0}, verseIdSequence FROM Bible..Scripture_View {1} ORDER BY bookId, chapterId, verseId;";
		public const string	BibleWordFindFormat = "SELECT TOP 1 verseIdSequence FROM Bible..Scripture_View {0}";
		public const string HisWord_viewFormat = "SELECT Word, HisWordID, Dated, Commentary, " + 
			" EnglishTranslation, AlphabetSequenceIndex, AlphabetSequenceIndexScriptureReference " +
			" FROM WordEngineering..HisWord_view WHERE AlphabetSequenceIndex IN ({0}) " + 
			" ORDER BY AlphabetSequenceIndex, HisWordID";
		public const string WhereQueryFormat = " WHERE {0} {1} {2} ";
		public const string WholeWordsWildCardSearchQueryFormat = "  ( {1}  LIKE  '%[^a-z]{0}[^a-z]%' ) ";
		public const string PartialWordsQueryFormat = "   ( {1} LIKE '%{0}%' ) ";
		//2018-04-24 https://quondam.csi.edu/ip/adc/faculty/bbennett/ps011exp.htm
		public const string PartsOfSpeech = 
			"can, could, will, would, shall, should, may, might, must, " + //Verbs
			"have, has, had, do, does, did,be, am, is, are, was, were, been, being, " +
			"a, an, the, " + //Adjectives
			"I, he, we, she, they, me, him, us, her, them, it, this, that, who, which, what, " + //Pronouns
			"my, mine, his, her, hers, our, ours, their, theirs, your, yours, its, whose, " +
			"at, to, with, from, for, of, on, in, into, onto,between, under, over, against, around, " + //Prepositions
			"for, and, nor, but, or, yet, so, " + //Conjunctions
			"because, when, while, as, since, although, whenever, " +
			"not, very, often, here, almost, always, never, there, too, " + //Adverbs
			"Oh, Ouch, yes, no, false, true"; //Interjections
		public static readonly string[] PartsOfSpeechArray;
	}
}
