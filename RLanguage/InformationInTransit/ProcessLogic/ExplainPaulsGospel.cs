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

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;

namespace InformationInTransit.ProcessLogic
{
	///<summary>
	/// 2015-03-20 ExplainPaulsGospel.cs Created.
	///</summary>
	public partial class ExplainPaulsGospel
	{
		public static void Main(string[] argv)
		{
			string table = Explain(argv[0]);
			System.Console.WriteLine(table.ToString());
		}
		
		public static StringBuilder BuildResult
		(
			String[] scriptureReferenceSubset,
			DataSet dataSet
		)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<table>");
			int subsetIndex = 0;
			foreach(DataTable dataTable in dataSet.Tables)
			{
				sb.Append
				(
					"<tr><th align=center colspan=2>" + 
					scriptureReferenceSubset[subsetIndex++] +
					"</th></tr>"
				);
				int existingBookId = -1;
				int existingChapterId = -1;
				foreach(DataRow dataRow in dataTable.Rows)
				{
					int bookId = (int) dataRow["bookId"];
					string bookTitle = ScriptureReference.BookName(bookId);
					int chapterId = (int) dataRow["chapterId"];
					int verseId = (int) dataRow["verseId"];
					string verseText = (string) dataRow["verseText"];
					
					if (bookId != existingBookId || chapterId != existingChapterId)
					{
						sb.Append
						(
							"<tr><th align=left colspan=2>" + 
							bookTitle + " " + chapterId.ToString() +
							"</th></tr>"
						);
						existingBookId = bookId;
						existingChapterId = chapterId;
					}
					
					sb.Append
					(
						"<tr><td>" + 
						String.Format("{0}:{1}", chapterId, verseId) +
						"</td><td>" + verseText + "</td></tr>"
					);
				}
			}
			sb.Append("</table>");
			return sb;
		}
		
		public static StringBuilder BuildSql(List<ScriptureReferenceSubset> scriptureReferenceSubsets)
		{
			StringBuilder sb = new StringBuilder();

			foreach(ScriptureReferenceSubset scriptureReferenceSubset in scriptureReferenceSubsets)
			{
				ScriptureReference pre = scriptureReferenceSubset.Pre;
				ScriptureReference post = scriptureReferenceSubset.Post;
				
				int 	verseIdSequence	= -1;
				string	sqlReferenceWhereClause = null;
				string	subQueryWhereClause = null;
				
				if (post == null)
				{
					if (pre.BookId > 0 && pre.Chapter == null && pre.Verse == null)
					{
						sqlReferenceWhereClause = "BookId = " + pre.BookId.ToString();
					}
					else if (pre.Verse == null)
					{
						sqlReferenceWhereClause = String.Format
						(
							"BookId = {0} AND ChapterId = {1}",
							pre.BookId,
							pre.Chapter
						);
					}
					else if (pre.Verse != null)
					{
						sqlReferenceWhereClause = String.Format
						(
							"BookId = {0} AND ChapterId = {1} AND VerseId = {2}",
							pre.BookId,
							pre.Chapter,
							pre.Verse
						);
					}
				}	
				else
				{
					if 
					(
						post.BookId >= pre.BookId && 
						pre.Chapter == null && pre.Verse == null &&
						post.Chapter == null && post.Verse == null
					)
					{
						sqlReferenceWhereClause = String.Format
						(
							"BookId BETWEEN {0} AND {1}",
							pre.BookId,
							post.BookId
						);
					}
					else
					{
						int verseIdSequenceFrom = -1;
						int verseIdSequenceUntil = -1;
						
						string subQueryWhereClauseFrom = String.Format
						(
							"BookId = {0} AND C",
							SubQueryWhereClauseFromFormat,
							pre.BookId,
							pre.Chapter,
							(pre.Verse == null) ? 1 : pre.Verse
						);
						
						subQueryWhereClauseFrom = 	" BookId = " + pre.BookId.ToString() + 
													" AND ChapterId = " + pre.Chapter.ToString() + 
													" AND VerseId = " + ((pre.Verse == null) ? "1" : pre.Verse.ToString());
						
						verseIdSequenceFrom = SelectVerseIdSequence(subQueryWhereClauseFrom);

						string subQueryWhereClauseUntil = null;
						
						if (post.Verse == null)
						{
							verseIdSequenceUntil = SelectVerseIdSequence(post.BookId, post.Chapter);
						}
						else
						{	
							subQueryWhereClauseUntil = 	" BookId = " + post.BookId.ToString() + 
														" AND ChapterId = " + post.Chapter.ToString() + 
														" AND VerseId = " + ((post.Verse == null) ? "1" : post.Verse.ToString());
							verseIdSequenceUntil = SelectVerseIdSequence(subQueryWhereClauseUntil);													
						}

						sqlReferenceWhereClause = String.Format
						(
							"verseIdSequence BETWEEN {0} AND {1}",
							verseIdSequenceFrom,
							verseIdSequenceUntil
						);
					}
				}
				sb.AppendFormat(BibleQueryFormat, sqlReferenceWhereClause);
			}
			return sb;
		}

		public static bool CheckForBookTitle(string currentReference, int bookTitleChapterSeparatorPosition)
		{
			int number = -1;
			if 
			(
				currentReference.Equals
				(
					ScriptureReference.Books[ScriptureReference.SongOfSolomonBookId],
					StringComparison.CurrentCultureIgnoreCase
				)
			)
			{
				return true;
			}	
			string leftOfSeparator = currentReference.Substring(0, bookTitleChapterSeparatorPosition).Trim();
			bool isBookTitle = Int32.TryParse(leftOfSeparator, out number);
			return isBookTitle;
		}
		
		public static StringBuilder Dump(List<ScriptureReferenceSubset> ScriptureReferenceSubsets)
		{
			StringBuilder sb = new StringBuilder();
			foreach(ScriptureReferenceSubset scriptureReferenceSubset in ScriptureReferenceSubsets)
			{
				sb.Append(scriptureReferenceSubset);
			}
			return sb;
		}
		
		public static String Explain(string question)
		{
			String[] scriptureReferenceSubset = question.Split(SubsetSeparator);
			List<ScriptureReferenceSubset> scriptureReferenceSubsets = Parse(scriptureReferenceSubset);
			Dump(scriptureReferenceSubsets);
			StringBuilder sql = BuildSql(scriptureReferenceSubsets);
			DataSet result = ProcessSql(sql);
			StringBuilder table = BuildResult(scriptureReferenceSubset, result);
			return table.ToString();
		}

		public static void ExplainBookTitle(string currentReference, ref ScriptureReference scriptureReference)
		{
			scriptureReference.BookTitle = currentReference;
			scriptureReference.Chapter = null;
			scriptureReference.Verse = null;
		}
		
		public static List<ScriptureReferenceSubset> Parse(string[] scriptureReferenceSubset)
		{
			List<ScriptureReferenceSubset> ScriptureReferenceSubsets = new List<ScriptureReferenceSubset>();
			
			ScriptureReference previousReference = null;
			for (int index = 0; index < scriptureReferenceSubset.Length; ++index)
			{
				String[] prePost = scriptureReferenceSubset[index].Split(PrePostSeparator);
				
				ScriptureReferenceSubset ScriptureReferenceSubset = new ScriptureReferenceSubset();
				for(int counter = 0; counter < prePost.Length; ++counter)
				{
					ScriptureReference scriptureReference = new ScriptureReference();
					string currentReference = prePost[counter].Trim();

					int number = 0; 
					bool numericFlag = int.TryParse(currentReference, out number);
					
					if (numericFlag)
					{
						scriptureReference = previousReference;
						if (previousReference.Verse == null)
						{
							scriptureReference.Chapter = number;
						}
						else
						{
							scriptureReference.Verse = number;
						}
						goto ClearDown;
					}
	  
					int chapterVerseSeparatorPosition = currentReference.LastIndexOf(ChapterVerseSeparator);
					if (chapterVerseSeparatorPosition > 0) //There must be a chapter and verse reference
					{
						scriptureReference.Verse = Convert.ToInt32
						(
							currentReference.Substring(chapterVerseSeparatorPosition + 1)
						);
						currentReference = currentReference.Substring(0, chapterVerseSeparatorPosition);
					}
					else
					{
						scriptureReference.Verse = null;
					}
					
					int bookTitleChapterSeparatorPosition = currentReference.LastIndexOf(BookTitleChapterSeparator);
					
					if (bookTitleChapterSeparatorPosition > -1)
					{
						bool isBookTitle = CheckForBookTitle(currentReference, bookTitleChapterSeparatorPosition);
						if (isBookTitle == true)
						{
							ExplainBookTitle(currentReference, ref scriptureReference);
							goto ClearDown;	
						}

						scriptureReference.Chapter = Convert.ToInt32
						(
							currentReference.Substring(bookTitleChapterSeparatorPosition + 1)
						);
						scriptureReference.BookTitle = currentReference.Substring(0, bookTitleChapterSeparatorPosition);
					}
					else
					{
						numericFlag = int.TryParse(currentReference, out number);
						if (numericFlag)
						{
							scriptureReference.Chapter = Convert.ToInt32(currentReference);
							scriptureReference.BookTitle = previousReference.BookTitle;
						}
						else
						{
							ExplainBookTitle(currentReference, ref scriptureReference);
						}	
					}
					
					ClearDown:
					
					if (counter == Pre)
					{
						ScriptureReferenceSubset.Pre = scriptureReference;
					}
					else
					{
						ScriptureReferenceSubset.Post = scriptureReference;
					}
					previousReference = new ScriptureReference(scriptureReference);
				}
				ScriptureReferenceSubsets.Add(ScriptureReferenceSubset);
			}
			
			return ScriptureReferenceSubsets;
		}

		public static int SelectVerseIdSequence(string subQueryWhereClause)
		{
			string sql = String.Format
			(
				"SELECT TOP 1 verseIdSequence FROM Bible..Scripture WHERE {0}",
				subQueryWhereClause
			);	

			int reference = (int) DataCommand.DatabaseCommand
							(
								sql,
								System.Data.CommandType.Text,
								DataCommand.ResultType.Scalar
							);
			return reference;
		}

		public static int SelectVerseIdSequence(int? bookId, int? chapterId)
		{
			string sql = String.Format
			(
				"SELECT MAX(verseIdSequence) FROM Bible..Scripture WHERE bookId = {0} AND chapterId = {1}",
				bookId,
				chapterId
			);	

			int reference = (int) DataCommand.DatabaseCommand
							(
								sql,
								System.Data.CommandType.Text,
								DataCommand.ResultType.Scalar
							);
			return reference;
		}

		public static DataSet ProcessSql(StringBuilder sql)
		{
			DataSet dataSet = null;
			dataSet = (DataSet)DataCommand.DatabaseCommand
			(
				sql.ToString(),
				CommandType.Text,
				DataCommand.ResultType.DataSet
			);
			return dataSet;
		}
		
		public static readonly char BookTitleChapterSeparator = ' ';
		public static readonly char ChapterVerseSeparator = ':';
		public static readonly char PrePostSeparator = '-';
		public static readonly char[] SubsetSeparator = {',', ';'};
		
		public const int Pre = 0;
		public const int Post = 1;
		
		public const string BibleQueryFormat = "SELECT bookId, chapterId, verseId, verseText=KingJamesVersion FROM Bible..Scripture WHERE {0} ORDER BY bookId, chapterId, verseId;";
		public const string SubQueryWhereClauseFromFormat = "BookId = {0} AND ChapterId = {1} AND VerseId = {2}";
		
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
			public static readonly int SongOfSolomonBookId = 21;
		}
		
		public class ScriptureReferenceSubset
		{
			public ScriptureReference Pre { get; set; }
			public ScriptureReference Post { get; set; }
			
			public override string ToString() 
			{
				return String.Format
				(
					"{0}{1}{2} ",
					Pre,
					Post == null ? "" : "-", 
					Post
				);	
			}
		}
	}
}
