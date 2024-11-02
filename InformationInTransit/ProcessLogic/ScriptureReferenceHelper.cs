using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.DataSetExtensions;
using System.Data.Linq;
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

using InformationInTransit.ProcessCode;

namespace InformationInTransit.ProcessLogic
{
	///<summary>
	///	2015-07-17 Created.
	///	2015-10-14
	///		if (question == "")
	///		{
	///			sql.AppendFormat(BibleQueryFormat, "1 = 1");
	///		}
	///		else
	///		{		
	///			sql = BuildSql(scriptureReferenceSubsets);
	///		}	
	///		
	///	2015-11-07	Support         public const string BibleCommentaryQueryFormat = "SELECT KingJamesVersion.bookId, KingJamesVersion.chapterId, KingJamesVersion.verseId, KingJamesVersion.verseText, BibleCommentary_View.* FROM Bible..Scripture_View JOIN BibleDictionary..BibleCommentary_View ON KingJamesVersion.BookID = BibleCommentary_View.BibleBookID AND KingJamesVersion.ChapterID = BibleCommentary_View.BibleChapterID AND KingJamesVersion.VerseID = BibleCommentary_View.BibleVerseID WHERE {0} ORDER BY bookId, chapterId, verseId;";
	///	public static void Process
	///	(
	///		string question,
	///		ref String[] scriptureReferenceSubset,
	///		ref DataSet result,
	///		string queryFormat
	///	)
	///	2015-11-10	http://stackoverflow.com/questions/2706500/how-do-i-generate-a-random-int-number-in-c
	///	2015-11-10	qotd http://stackoverflow.com/questions/7599732/caching-in-a-console-application
	///	2015-11-11	qotd Each day.
	///	2016-04-24	Bible versions. King James Version (KingJamesVersion), American Standard Bible, Young's Literal Translation
	///	2017-02-26	http://stackoverflow.com/questions/1412008/join-datatable-with-listsomeobject
	///	2017-02-27	https://msdn.microsoft.com/en-us/library/bb396189(v=vs.110).aspx
	///	2017-02-27	http://stackoverflow.com/questions/444798/case-insensitive-containsstring
	///	2017-02-27	http://stackoverflow.com/questions/2017533/best-way-to-check-if-column-returns-a-null-value-from-database-to-net-applicat
	///	2017-04-07	Replace Convert.ToInt32 with Int32.TryParse();	
	///	2017-04-20	BibleDistinctQuery() Mo fe ma lole; mo niyawo le. MoFeMaLoleMoNiyawoLe.html
	///				Danny, got out of Wienerschnitzel, exit westward.
	///	2017-07-09	FullPosition().
	///				https://stackoverflow.com/questions/2971055/left-of-a-character-in-a-string-in-c-sharp
	///	2018-09-28	For sacred text query. The title of a sub-text.
	///	2020-09-11	BibleGroupSubstitute variable definition, and BibleGroupSubstituteReplace implementation.
	///	2022-01-15	BibleSequenceQueryFormat added.
	/// 2022-11-26	IKeepOnFindingWhereIAmThatIMayChooseWhereIBelong added.
	///</summary>
	public class ScriptureReferenceHelper
	{
		public static void Main(String[] argv)
		{
			String[] scriptureReferenceSubset = null;
			DataSet result = new DataSet();
			
			//string sacredText = PrintTable(argv[0], ref scriptureReferenceSubset, ref result);
			//System.Console.WriteLine(sacredText);
			
/*
			StringBuilder fullPosition = new StringBuilder();
			
			FullPosition
			(
					argv[0],
				ref scriptureReferenceSubset,
				ref result,
				ref fullPosition
			);
*/			

	string QueryFormat = 
	@"
		SELECT 
			STRING_AGG({1}, ';') -- WITHIN GROUP (ORDER BY VerseIDSequence)
			FROM Bible..Scripture
			WHERE {0} 
			GROUP BY {2}
	";

	string bibleGroup = "VerseID";
	String bibleVersion = "KingJamesVersion";

			String scriptureReference = "John 1:7, Genesis 22:1";

			String dynamicSql = String.Format
			(
				QueryFormat,
				"{0}", 
				bibleVersion, 
				bibleGroup
			);

			//return dynamicSql;
			

			ScriptureReferenceHelper.Process
			(
				scriptureReference,
				ref scriptureReferenceSubset,
				ref result,
				dynamicSql,
				bibleVersion
			);
		}
		
		public static DataTable Approach
		(
			string 			scriptureReference,
			ref String[] 	scriptureReferenceSubset,
			ref DataSet 	result,
			string			bibleWord,
			string			firstScriptureReference,
			string			lastScriptureReference,
			int				fromOccurrence,
			int				untilOccurrence,
			int				exactIDFrom,
			int				exactIDUntil,
			int				alphabetSequenceIndexFrom,
			int				alphabetSequenceIndexUntil
		)
		{
			//CultureInfo cultureInfo = CultureInfo.CurrentCulture;
			CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
		
			Process
            (
                scriptureReference,
                ref scriptureReferenceSubset,
                ref result,
                ScriptureReferenceHelper.BibleQueryFormat,
                "KingJamesVersion"
            );

			var exactUniques = DataTableHelper.DataTableColumnSplitStringCollection
			(
				result.Tables[0],
				"VerseText"
			);

			DataTable dataTableExact = (DataTable) DataCommand.DatabaseCommand
			(
				"SELECT * FROM Bible..Exact_View",
				CommandType.Text,
				DataCommand.ResultType.DataTable
			);

			DataTable dataResult = dataTableExact.AsEnumerable()
				.Where
				( 
					dt => 	exactUniques.Contains((string)dt["BibleWord"]) &&
							cultureInfo.CompareInfo.IndexOf
							(
								(string)dt["BibleWord"],
								bibleWord,
								CompareOptions.IgnoreCase
							) >= 0 &&
							cultureInfo.CompareInfo.IndexOf
							(
								(string)dt["FirstOccurrenceScriptureReference"],
								firstScriptureReference,
								CompareOptions.IgnoreCase
							) >= 0 &&
							cultureInfo.CompareInfo.IndexOf
							(
								DBNull.Value.Equals(dt["LastOccurrenceScriptureReference"]) ? (string)dt["FirstOccurrenceScriptureReference"] : (string)dt["LastOccurrenceScriptureReference"],
								lastScriptureReference,
								CompareOptions.IgnoreCase
							) >= 0 &&
							(int)dt["FrequencyOfOccurrence"] >= fromOccurrence &&
							(int)dt["FrequencyOfOccurrence"] <= untilOccurrence &&
							(int)dt["ExactID"] >= exactIDFrom &&
							(int)dt["ExactID"] <= exactIDUntil &&
							(int)dt["AlphabetSequenceIndex"] >= alphabetSequenceIndexFrom &&
							(int)dt["AlphabetSequenceIndex"] <= alphabetSequenceIndexUntil
				)
			  .CopyToDataTable();
					  
			return dataResult;		  
		}

		public static void BibleDistinctQuery
		(
			string 			scriptureReference,
			ref String[] 	scriptureReferenceSubset,
			ref DataSet 	result
		)
		{
			//CultureInfo cultureInfo = CultureInfo.CurrentCulture;
			CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
		
			Process
            (
                scriptureReference,
                ref scriptureReferenceSubset,
                ref result,
                ScriptureReferenceHelper.BibleDistinctQueryFormat,
                "KingJamesVersion"
            );
		}

		public static String BibleGroupSubstituteReplace
		(
			string 	scriptureReference
		)
		{
			for 
			(
				int groupIndex = 0, groupCount = BibleGroupSubstitute.Length;
				groupIndex < groupCount;
				++groupIndex
			)
			{
				scriptureReference = Regex.Replace
				(
					scriptureReference,
					BibleGroupSubstitute[groupIndex][0],
					BibleGroupSubstitute[groupIndex][1],
					RegexOptions.IgnoreCase
				);
			}
			return scriptureReference;
		}
		
		public static DataTable BillInDate
		(
			string 			scriptureReference,
			ref String[] 	scriptureReferenceSubset,
			ref DataSet 	result,
			//string			commentary,
			string			umlType,
			string			umlSource,
			string			umlTarget
		)
		{
			//CultureInfo cultureInfo = CultureInfo.CurrentCulture;
			CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
		
			Process
            (
                scriptureReference,
                ref scriptureReferenceSubset,
                ref result,
                ScriptureReferenceHelper.BillInDateQueryFormat,
                "KingJamesVersion"
            );

			DataTable dataTable = DataSetHelper.CustomMerge(result);
			
			var dataResult = dataTable.AsEnumerable()
				.Where
				( 
					dt => 	/*
							cultureInfo.CompareInfo.IndexOf
							(
								(string)dt["commentary"],
								commentary,
								CompareOptions.IgnoreCase
							) >= 0 &&
							*/
							cultureInfo.CompareInfo.IndexOf
							(
								(string)dt["UmlType"],
								umlType,
								CompareOptions.IgnoreCase
							) >= 0 &&
							cultureInfo.CompareInfo.IndexOf
							(
								(string)dt["UmlSource"],
								umlSource,
								CompareOptions.IgnoreCase
							) >= 0 &&
							cultureInfo.CompareInfo.IndexOf
							(
								(string)dt["UmlTarget"],
								umlTarget,
								CompareOptions.IgnoreCase
							) >= 0
				)
			  .CopyToDataTable();
					  
			return dataResult;		  
		}
		
		public static StringBuilder BuildResult
		(
			String[] scriptureReferenceSubset,
			DataSet dataSet
		)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("<table id=\"sacredText\">");
			int subsetIndex = 0;
			foreach(DataTable dataTable in dataSet.Tables)
			{
				System.Console.WriteLine
				(
					"{0}, {1}",
					subsetIndex,
					scriptureReferenceSubset[subsetIndex]
				);
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
		
		public static StringBuilder BuildSql
		(
			List<ScriptureReferenceSubset> scriptureReferenceSubsets,
			String	queryFormat
		)
		{
			StringBuilder sb = new StringBuilder();

			foreach(ScriptureReferenceSubset scriptureReferenceSubset in scriptureReferenceSubsets)
			{
				ScriptureReference pre = scriptureReferenceSubset.Pre;
				ScriptureReference post = scriptureReferenceSubset.Post;
				
				int 	verseIDSequence	= -1;
				string	sqlReferenceWhereClause = null;
				string	subQueryWhereClause = null;
				
				if (post == null)
				{
					if (pre.BookID > 0 && pre.Chapter == null && pre.Verse == null)
					{
						sqlReferenceWhereClause = "BookID = " + pre.BookID.ToString();
					}
					else if (pre.Verse == null)
					{
						sqlReferenceWhereClause = String.Format
						(
							"BookID = {0} AND ChapterID = {1}",
							pre.BookID,
							pre.Chapter
						);
					}
					else if (pre.Verse != null)
					{
						sqlReferenceWhereClause = String.Format
						(
							"BookID = {0} AND ChapterID = {1} AND VerseID = {2}",
							pre.BookID,
							pre.Chapter,
							pre.Verse
						);
					}
				}	
				else
				{
					if 
					(
						post.BookID >= pre.BookID && 
						pre.Chapter == null && pre.Verse == null &&
						post.Chapter == null && post.Verse == null
					)
					{
						sqlReferenceWhereClause = String.Format
						(
							"BookID BETWEEN {0} AND {1}",
							pre.BookID,
							post.BookID
						);
					}
					else
					{
						int verseIDSequenceFrom = -1;
						int verseIDSequenceUntil = -1;
						
						string subQueryWhereClauseFrom = String.Format
						(
							"BookID = {0} AND ChapterID = {1}",
							SubQueryWhereClauseFromFormat,
							pre.BookID,
							pre.Chapter,
							(pre.Verse == null) ? 1 : pre.Verse
						);
						
						subQueryWhereClauseFrom = 	" BookID = " + pre.BookID.ToString() + 
													" AND ChapterID = " + pre.Chapter.ToString() + 
													" AND VerseID = " + ((pre.Verse == null) ? "1" : pre.Verse.ToString());
						
						verseIDSequenceFrom = SelectVerseIDSequence(subQueryWhereClauseFrom);

						string subQueryWhereClauseUntil = null;
						
						if (post.Verse == null)
						{
							verseIDSequenceUntil = SelectVerseIDSequence(post.BookID, post.Chapter);
						}
						else
						{	
							subQueryWhereClauseUntil = 	" BookID = " + post.BookID.ToString() + 
														" AND ChapterID = " + post.Chapter.ToString() + 
														" AND VerseID = " + ((post.Verse == null) ? "1" : post.Verse.ToString());
							verseIDSequenceUntil = SelectVerseIDSequence(subQueryWhereClauseUntil);													
						}

						sqlReferenceWhereClause = String.Format
						(
							"verseIDSequence BETWEEN {0} AND {1}",
							verseIDSequenceFrom,
							verseIDSequenceUntil
						);
					}
				}
				sb.AppendFormat(queryFormat, sqlReferenceWhereClause);
			}
			return sb;
		}

		public static void BuildSql
		(
				List<ScriptureReferenceSubset> 	scriptureReferenceSubsets,
			ref	List<String>					sqlWhereClauses
		)
		{
			sqlWhereClauses = new List<String>();
			foreach(ScriptureReferenceSubset scriptureReferenceSubset in scriptureReferenceSubsets)
			{
				ScriptureReference pre = scriptureReferenceSubset.Pre;
				ScriptureReference post = scriptureReferenceSubset.Post;
				
				int 	verseIDSequence	= -1;
				string	sqlReferenceWhereClause = null;
				string	subQueryWhereClause = null;
				
				if (post == null)
				{
					if (pre.BookID > 0 && pre.Chapter == null && pre.Verse == null)
					{
						sqlReferenceWhereClause = "BookID = " + pre.BookID.ToString();
					}
					else if (pre.Verse == null)
					{
						sqlReferenceWhereClause = String.Format
						(
							"BookID = {0} AND ChapterID = {1}",
							pre.BookID,
							pre.Chapter
						);
					}
					else if (pre.Verse != null)
					{
						sqlReferenceWhereClause = String.Format
						(
							"BookID = {0} AND ChapterID = {1} AND VerseID = {2}",
							pre.BookID,
							pre.Chapter,
							pre.Verse
						);
					}
				}	
				else
				{
					if 
					(
						post.BookID >= pre.BookID && 
						pre.Chapter == null && pre.Verse == null &&
						post.Chapter == null && post.Verse == null
					)
					{
						sqlReferenceWhereClause = String.Format
						(
							"BookID BETWEEN {0} AND {1}",
							pre.BookID,
							post.BookID
						);
					}
					else
					{
						int verseIDSequenceFrom = -1;
						int verseIDSequenceUntil = -1;
						
						string subQueryWhereClauseFrom = String.Format
						(
							"BookID = {0} AND ChapterID = {1}",
							SubQueryWhereClauseFromFormat,
							pre.BookID,
							pre.Chapter,
							(pre.Verse == null) ? 1 : pre.Verse
						);
						
						subQueryWhereClauseFrom = 	" BookID = " + pre.BookID.ToString() + 
													" AND ChapterID = " + pre.Chapter.ToString() + 
													" AND VerseID = " + ((pre.Verse == null) ? "1" : pre.Verse.ToString());
						
						verseIDSequenceFrom = SelectVerseIDSequence(subQueryWhereClauseFrom);

						string subQueryWhereClauseUntil = null;
						
						if (post.Verse == null)
						{
							verseIDSequenceUntil = SelectVerseIDSequence(post.BookID, post.Chapter);
						}
						else
						{	
							subQueryWhereClauseUntil = 	" BookID = " + post.BookID.ToString() + 
														" AND ChapterID = " + post.Chapter.ToString() + 
														" AND VerseID = " + ((post.Verse == null) ? "1" : post.Verse.ToString());
							verseIDSequenceUntil = SelectVerseIDSequence(subQueryWhereClauseUntil);													
						}

						sqlReferenceWhereClause = String.Format
						(
							"verseIDSequence BETWEEN {0} AND {1}",
							verseIDSequenceFrom,
							verseIDSequenceUntil
						);
					}
				}
				sqlWhereClauses.Add(sqlReferenceWhereClause);
			}
		}

		public static bool CheckForBookTitle(string currentReference, int bookTitleChapterSeparatorPosition)
		{
			int number = -1;
			if 
			(
				currentReference.Equals
				(
					ScriptureReference.Books[ScriptureReference.SongOfSolomonBookID],
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

		public static StringBuilder Dump(List<ScriptureReferenceSubset> scriptureReferenceSubsets)
		{
			StringBuilder sb = new StringBuilder();
			foreach(ScriptureReferenceSubset scriptureReferenceSubset in scriptureReferenceSubsets)
			{
				sb.Append(scriptureReferenceSubset);
			}
			return sb;
		}
		

		public static void ExtractBookTitle(string currentReference, ref ScriptureReference scriptureReference)
		{
			scriptureReference.BookTitle = currentReference;
			scriptureReference.Chapter = null;
			scriptureReference.Verse = null;
		}
		
		public static List<ScriptureReferenceSubset> Parse
		(
				string		question,
			ref string[] 	scriptureReferenceSubset
		)
		{
			List<ScriptureReferenceSubset> scriptureReferenceSubsets = new List<ScriptureReferenceSubset>();
			
			scriptureReferenceSubset = question.Split
			(
				SubsetSeparator,
				StringSplitOptions.RemoveEmptyEntries 
			);
			
			if (scriptureReferenceSubset.Length == 0)
			{
				return scriptureReferenceSubsets;
			}
			
			scriptureReferenceSubsets = Parse
			(
				scriptureReferenceSubset	
			);
			
			return scriptureReferenceSubsets;
		}
		
		public static void FullPosition
		(
			string 				scriptureReference,
			ref String[] 		scriptureReferenceSubset,
			ref DataSet 		result,
			ref StringBuilder	fullPosition
		)
		{
			//CultureInfo cultureInfo = CultureInfo.CurrentCulture;
			CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
		
			System.Console.WriteLine("Full position");
		
			Process
            (
                scriptureReference,
                ref scriptureReferenceSubset,
                ref result,
                ScriptureReferenceHelper.FullPositionQueryFormat,
                "KingJamesVersion"
            );
			
			DataRow dataRowTop;

			fullPosition = new StringBuilder();
			
			foreach(DataTable dataTable in result.Tables)
			{
				int verseIDNext = -1;
				int verseIDPrecede = -1;
				int verseIDSequence = -1;
				
				int chapterIDNext = -1;
				int chapterIDPrecede = -1;
				int chapterIDSequence = -1;
				
				String verseNext = null;
				String versePrecede = null;
				
				String chapterNext = null;
				String chapterPrecede = null;
				
				String chapterPrecedeChapterOnly = null;
				String chapterNextChapterOnly = null;	
				
				if (dataTable.Rows.Count > 0)
				{
					dataRowTop = dataTable.Rows[0];
					verseIDSequence = (int) dataRowTop["VerseIDSequence"];
					if (verseIDSequence > 1)
					{
						verseIDPrecede = verseIDSequence - 1;
						versePrecede = FullPositionQuery("VerseIDSequence", verseIDPrecede);
						FullPositionAppend(ref fullPosition, versePrecede);
					}
					if (verseIDSequence < VerseCount)
					{
						verseIDNext = verseIDSequence + 1;
						verseNext = FullPositionQuery("VerseIDSequence", verseIDNext);
						FullPositionAppend(ref fullPosition, verseNext);
					}
					chapterIDSequence = (int) dataRowTop["ChapterIDSequence"];
					if (chapterIDSequence > 1)
					{
						chapterIDPrecede = chapterIDSequence - 1;
						chapterPrecede = FullPositionQuery("ChapterIDSequence", chapterIDPrecede);
						chapterPrecedeChapterOnly = chapterPrecede.Substring(0, chapterPrecede.IndexOf(":"));
						FullPositionAppend(ref fullPosition, chapterPrecedeChapterOnly);
					}
					if (chapterIDSequence > 1)
					{
						chapterIDNext = chapterIDSequence + 1;
						chapterNext = FullPositionQuery("ChapterIDSequence", chapterIDNext);
						chapterNextChapterOnly = chapterNext.Substring(0, chapterNext.IndexOf(":"));
						FullPositionAppend(ref fullPosition, chapterNextChapterOnly);
					}
				}	
			}
			System.Console.WriteLine(fullPosition);
		}

		public static void FullPositionAppend
		(
			ref StringBuilder fullPosition,
				String scriptureReference
		)
		{
			if (fullPosition.Length > 0)
			{
				fullPosition.Append(", ");
			}
			fullPosition.Append(scriptureReference);
		}
		
		public static string FullPositionQuery
		(
			string columnName,
			int columnValue
		)
		{
			return (string) DataCommand.DatabaseCommand
			(
				String.Format
				(
					FullPositionQueryFormatScriptureReferenceScalarSelect,
					columnName,
					columnValue
				),
				CommandType.Text,
				DataCommand.ResultType.Scalar
			);
		}

		public static string IKeepOnFindingWhereIAmThatIMayChooseWhereIBelongQuery
		(
			string columnName,
			int columnValue,
			string bibleVersion
		)
		{
			return (string) DataCommand.DatabaseCommand
			(
				String.Format
				(
					IKeepOnFindingWhereIAmThatIMayChooseWhereIBelongScalarSelect,
					columnName,
					columnValue,
					bibleVersion
				),
				CommandType.Text,
				DataCommand.ResultType.Scalar
			);
		}
		
		public static List<ScriptureReferenceSubset> Parse(string[] scriptureReferenceSubset)
		{
			bool tryParseFlag = false;
			
			int chapter = -1;
			int	verse = -1;
			
			ScriptureReference previousReference = null;
			
			List<ScriptureReferenceSubset> scriptureReferenceSubsets = new List<ScriptureReferenceSubset>();
			
			try
			{
				for (int index = 0; index < scriptureReferenceSubset.Length; ++index)
				{
					String[] prePost = scriptureReferenceSubset[index].Split
					(
						PrePostSeparator//,
						//StringSplitOptions.RemoveEmptyEntries
					);
					
					if (prePost.Length == 0)
					{
						return scriptureReferenceSubsets;
					}		
					
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
							tryParseFlag = Int32.TryParse
							(
								currentReference.Substring(chapterVerseSeparatorPosition + 1),
								out verse
							);
							if (tryParseFlag == false)
							{
								return scriptureReferenceSubsets;
							}	
							scriptureReference.Verse = verse;
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
								ExtractBookTitle(currentReference, ref scriptureReference);
								goto ClearDown;	
							}

							tryParseFlag = Int32.TryParse
							(
								currentReference.Substring(bookTitleChapterSeparatorPosition + 1),
								out chapter
							);
							
							if (tryParseFlag == false)
							{
								return scriptureReferenceSubsets;
							}	
							
							scriptureReference.Chapter = chapter;
							
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
								ExtractBookTitle(currentReference, ref scriptureReference);
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
					scriptureReferenceSubsets.Add(ScriptureReferenceSubset);
				}
			}
			catch(Exception ex)
			{
				System.Console.WriteLine
				(
					"Exception: {0}",
					ex.Message
				);
			}	
			return scriptureReferenceSubsets;
		}

		public static int SelectVerseIDSequence(string subQueryWhereClause)
		{
			string sql = String.Format
			(
				"SELECT TOP 1 VerseIDSequence FROM Bible..Scripture_View WHERE {0}",
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

		public static int SelectVerseIDSequence(int? bookID, int? chapterID)
		{
			string sql = String.Format
			(
				"SELECT MAX(VerseIDSequence) FROM Bible..Scripture_View WHERE BookID = {0} AND ChapterID = {1}",
				bookID,
				chapterID
			);	

			int reference = (int) DataCommand.DatabaseCommand
							(
								sql,
								System.Data.CommandType.Text,
								DataCommand.ResultType.Scalar
							);
			return reference;
		}

		/*
			2020-10-08	Story out of line. Scripture Reference continue. Combine verses. Find gaps in the VerseSequenceID column. Search column must be variable, and type. Can you look at scripture reference, and which one to combine?
			2020-10-19	Works.	
		*/
		public static StringBuilder StoryOutOfLine
		(
			DataSet dataSet
		)		
		{		
			int bookID;
			string bookTitle;
			int chapterID;
			int verseID;
			int verseIDSequence;
			
			StringBuilder sb = new StringBuilder();
			foreach(DataTable dataTable in dataSet.Tables)
			{
				verseIDSequence = -1;
				int verseIDSequenceRetain = -1;
				DataRow dataRowRetain = null;
				DataRow dataRowCurrent = null;
				int occurrences = 0;
				
				foreach(DataRow dataRow in dataTable.Rows)
				{
					bookID = (int) dataRow["bookId"];
					//string bookTitle = ScriptureReference.BookName(bookID);
					chapterID = (int) dataRow["chapterId"];
					verseID = (int) dataRow["verseId"];
					verseIDSequence = (int) dataRow["verseIdSequence"];
					if (sb.Length == 0)
					{
						sb.AppendFormat
						(
							"{0} {1}:{2}",
							ScriptureReference.BookName(bookID),
							chapterID,
							verseID
						);
						verseIDSequenceRetain = verseIDSequence;
						dataRowRetain = dataRow;
						dataRowCurrent = dataRow;
						continue;
					}
					if (verseIDSequence - verseIDSequenceRetain > occurrences)
					{
						if (occurrences > 1)
						{	
							sb.AppendFormat
							(
								"-{0} {1}:{2} ",
								ScriptureReference.BookName((int)dataRowCurrent["bookId"]),
								(int) dataRowCurrent["chapterId"],
								(int) dataRowCurrent["verseId"]

							);
						}
						sb.Append(", ");
						sb.AppendFormat
						(
							" {0} {1}:{2}",
							ScriptureReference.BookName((int)dataRow["bookId"]),
							(int) dataRow["chapterId"],
							(int) dataRow["verseId"]

						);
						dataRowRetain = dataRow;
						verseIDSequenceRetain = verseIDSequence;
						occurrences = 0;
					}
					dataRowCurrent = dataRow;
					++occurrences;
				}
			}
			return(sb);
		}

		public static String PrintTable(string question, ref String[] scriptureReferenceSubset, ref DataSet result)
		{
			Process
            (
                question,
                ref scriptureReferenceSubset,
                ref result,
                ScriptureReferenceHelper.BibleQueryFormat,
                "KingJamesVersion"
            );
			StringBuilder table = BuildResult(scriptureReferenceSubset, result);
			string sacredText = table.ToString();
			return sacredText;
		}

/*
		2018-03-20
				queryFormat = StringHelper.ReplaceFirst
				(
					queryFormat,
					"verseText",
					" VerseText = " + bibleVersion
				);

		2018-03-20
				queryFormat = Regex.Replace
				(
					queryFormat,
					"verseText",
					//2018-03-19 bibleVersion + " AS verseText ",
					" VerseText = bibleVersion ",
					RegexOptions.IgnoreCase
				);
*/
		public static void Process
		(
			string question,
			ref String[] scriptureReferenceSubset,
			ref DataSet result,
			string queryFormat,
			string bibleVersion
		)
		{
			question = BibleGroupSubstituteReplace(question);
			
			queryFormat = Regex.Replace
			(
				queryFormat,
				"verseText",
				" verseText = " + bibleVersion + " ",
				RegexOptions.IgnoreCase
			);

			string sacredText = SacredTextHelper.Query(question);
			if (!string.IsNullOrEmpty(sacredText))
			{
				question = sacredText;
			}	

			scriptureReferenceSubset = question.Split(SubsetSeparator);
			
			List<ScriptureReferenceSubset> scriptureReferenceSubsets = Parse(scriptureReferenceSubset);
			Dump(scriptureReferenceSubsets);
			StringBuilder sql = new StringBuilder();
			question = question.ToLower();
			if (question == "")
			{
				sql.AppendFormat(queryFormat, "1 = 1");
			}
			else if (question == QuoteOfTheDayQuestion)
			{
				DateTime dateTimeNow = DateTime.Now;
				if (dateTimeNow.Date > QuoteOfTheDayQuestionDateTime.Date)
				{	
					QuoteOfTheDayVerseIDSequence = GetRandomNumber(1, VerseCount + 1);
					QuoteOfTheDayQuestionDateTime = dateTimeNow;
				}	
				sql.AppendFormat(queryFormat, "VerseIDSequence = " + QuoteOfTheDayVerseIDSequence.ToString());
			}
			else if (question == RandomQuestion)
			{
				int randomNumber = GetRandomNumber(1, VerseCount + 1);
				sql.AppendFormat(queryFormat, "VerseIDSequence = " + randomNumber.ToString());
			}
			else
			{
				sql = BuildSql(scriptureReferenceSubsets, queryFormat);
			}	
			result = ProcessSql(sql);
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
			System.Console.WriteLine(sql);
			return dataSet;
		}

		public static DataSet WhatChildrenOurGroom
		(
			string 			scriptureReference,
			ref String[] 	scriptureReferenceSubset,
			ref DataSet 	result,
			string			bibleVersion,
			bool			combinedResult
		)
		{
			//CultureInfo cultureInfo = CultureInfo.CurrentCulture;
			CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
		
			Process
            (
                scriptureReference,
                ref scriptureReferenceSubset,
                ref result,
                ScriptureReferenceHelper.ExactQueryFormat,
                bibleVersion
            );

			StringBuilder sbSplitResultSQL = new StringBuilder();
			
			StringBuilder sbJoinResultWord = new StringBuilder();

			StringCollection stringCollection;
			
			String exactLiteral;

			String exactLiteralQuote;

			foreach(DataTable tableResult in result.Tables)
			{
				stringCollection = DataTableHelper.DataTableColumnSplitStringCollection
				(
					tableResult,
					"verseText"
				);	
				
				exactLiteral = string.Join(", ", stringCollection.Cast<string>());
				
				exactLiteral = exactLiteral.Replace("'", "''");
				
				exactLiteralQuote = string.Join(",", exactLiteral.Split(',').Select(x => string.Format("'{0}'", x)));

				if ( !combinedResult )
				{
					sbSplitResultSQL.AppendFormat
					(
						"SELECT * FROM Bible..Exact_View WHERE BibleWord IN ({0});",
						exactLiteralQuote
					);	
				}	
				else
				{
					if ( sbJoinResultWord.Length > 0 )
					{
						sbJoinResultWord.Append(", ");
					}	
					sbJoinResultWord.Append
					(
						exactLiteralQuote
					);
				}
			}	
			
			String sqlStatement = combinedResult == false ? 
				sbSplitResultSQL.ToString() :
				String.Format
				(
					"SELECT * FROM Bible..Exact_View WHERE BibleWord IN ({0});",
					sbJoinResultWord
				);
			
			DataSet exactWords = (DataSet) DataCommand.DatabaseCommand
			(
				sqlStatement,
				CommandType.Text,
				DataCommand.ResultType.DataSet
			);
			
			return exactWords;
		}
		
		static ScriptureReferenceHelper()
		{
			QuoteOfTheDayVerseIDSequence = GetRandomNumber(1, VerseCount + 1);
		}	
		
		public static readonly char BookTitleChapterSeparator = ' ';
		public static readonly char ChapterVerseSeparator = ':';
		public static readonly char PrePostSeparator = '-';
		public static readonly char[] SubsetSeparator = {',', ';'};
		
		public const int Pre = 0;
		public const int Post = 1;
		
		public const int ChapterCount = 1189;
		public const int VerseCount = 31102;
		public const int VerseCountOldTestament = 23145;

		public const string BibleDistinctQueryFormat = 
			@"
			SELECT
				COUNT(DISTINCT BookID) AS BookIDCount,
				COUNT(DISTINCT ChapterIDSequence) AS ChapterIDSequenceCount,
				COUNT(DISTINCT VerseIDSequence) AS VerseIDSequenceCount
			FROM
				Bible..Scripture
			WHERE {0};	
			";	

		public const string BibleQueryFormat = "SELECT bookID, chapterID, verseID, verseText FROM Bible..Scripture_View WHERE {0} ORDER BY bookID, chapterID, verseID;";
        public const string BibleCommentaryQueryFormat = 
			@"SELECT 
				Scripture.bookID,
				Scripture.chapterID,
				Scripture.verseID,
				Scripture.verseText,
				BibleCommentary_View.*
			FROM 
				Bible..Scripture_View JOIN BibleDictionary..BibleCommentary
			ON 	KingJamesVersion.BookID = BibleCommentary_View.BibleBookID
			AND KingJamesVersion.ChapterID = BibleCommentary_View.BibleChapterID 
			AND KingJamesVersion.VerseID = BibleCommentary_View.BibleVerseID 
			WHERE
				{0} 
			ORDER BY bookID, chapterID, verseID;
		";
		public const string BibleSequenceQueryFormat = "SELECT ScriptureReference, ChapterIDSequence, VerseIDSequence, ChapterIDSequencePercent, VerseIDSequencePercent FROM Bible..Scripture_View WHERE {0} ORDER BY bookID, ChapterID, VerseID;";
		public const string BillInDateQueryFormat = "SELECT * FROM WordEngineering..BillInDate WHERE {0} ORDER BY BookID, ChapterID, VerseID, BillInDateID;";
		public const string ExactQueryFormat = "SELECT ScriptureReference, VerseText FROM Bible..Scripture_View WHERE {0} ORDER BY bookID, chapterID, verseID;";
		public const string FullPositionQueryFormat = "SELECT BookID, ChapterID, VerseID, VerseText, VerseIDSequence, ChapterIDSequence FROM Bible..Scripture_View WHERE {0} ORDER BY BookID, ChapterID, VerseID;";
		public const string FullPositionQueryFormatScriptureReferenceScalarSelect = "SELECT TOP 1 ScriptureReference FROM Bible..Scripture_View WHERE {0} = {1}";
		public const string IKeepOnFindingWhereIAmThatIMayChooseWhereIBelongScalarSelect = "SELECT TOP 1 {2} AS VerseText FROM Bible..Scripture_View WHERE {0} = {1}";

		public const string BibleVersionDefault = "KingJamesVersion";
		
		public const string	QuoteOfTheDayQuestion = "qotd";
		public static DateTime QuoteOfTheDayQuestionDateTime = DateTime.MinValue;
		public static int QuoteOfTheDayVerseIDSequence = -1;
		
		public const string RandomQuestion = "random";
		
		private static readonly Random getrandom = new Random();
		
		private static readonly object syncLock = new object();
		public static int GetRandomNumber(int min, int max)
		{
			lock(syncLock) { // synchronize
				return getrandom.Next(min, max);
			}
		}
		
		public const string SubQueryWhereClauseFromFormat = "BookID = {0} AND ChapterID = {1} AND VerseID = {2}";

		public static readonly String[][] BibleGroupSubstitute =
		{ 
			new String[] { "All", "Genesis - Revelation" },		
			new String[] { "Gospels", "Matthew - John" },
			new String[] { "Major Prophets", "Isaiah - Daniel" },
			new String[] { "Minor Prophets", "Joel - Malachi" },
			new String[] { "New Testament", "Matthew - Revelation" },
			new String[] { "Old Testament", "Genesis - Malachi" },
			new String[] { "Pentateuch", "Genesis - Deuteronomy" },
			new String[] { "Synoptic Gospels", "Matthew - Luke" }, //2022-12-27T17:55:00
		};	
	
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

            public ScriptureReference
			(
				string	bookTitle,
				int	chapterID,
				int	verseID
			)
			{
				this.BookTitle = bookTitle;
				this.Chapter = chapterID;
				this.Verse = verseID;
			}
			
			public int?	 BookID
			{
				get
				{
					int? bookID = null;
					if ( !String.IsNullOrEmpty(BookTitle) )
					{
						bookID = Array.FindIndex(Books, p => p.Equals(BookTitle, StringComparison.CurrentCultureIgnoreCase));
						if (bookID > -1) {++bookID;} //Arrays are zero-based.
					}	
					return bookID;
				}
			}

			public static string BookName(int bookID)
			{
				string bookName = null;
				if ( bookID > 0 && bookID < MaxBookID )
				{
					bookName = Books[bookID - 1];
				}	
				return bookName;
			}

			public static string Syntax
			(
				int bookID,
				int chapterID,
				int verseID
			)
			{
				string formatted = Books[bookID - 1] + " " + chapterID.ToString() + ":" + verseID.ToString();
				return formatted;
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
			public static readonly int MaxBookID = Books.Count() + 1;
			public static readonly int SongOfSolomonBookID = 21;
		}

        public class ScriptureReferenceSubset
		{
			public ScriptureReference Pre { get; set; }
			public ScriptureReference Post { get; set; }
			
			public String StringRepresentation 
			{
				get
				{
					return this.ToString();
				}	
			}
			
			public override string ToString() 
			{
				return String.Format
				(
					"{0}{1}{2} ",
					Pre,
					Post == null ? "" : "-", 
					Post
				).Trim();	
			}
		}
	}
}
