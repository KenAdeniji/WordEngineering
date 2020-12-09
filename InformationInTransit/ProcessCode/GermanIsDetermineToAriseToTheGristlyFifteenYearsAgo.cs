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

using InformationInTransit.ProcessCode;

namespace InformationInTransit.ProcessLogic
{
	///<summary>
	///		2020-09-11	German is determine, to arise to the gristly, fifteen years ago.
	///		2020-09-11	BibleGroupSubstitute variable definition, and BibleGroupSubstituteReplace implementation.
	///		2020-09-12	Created.
	///</summary>
	public class GermanIsDetermineToAriseToTheGristlyFifteenYearsAgo
	{
		public static void Main(String[] argv)
		{
		}
		
		public static String Query
		(
			String 	scriptureReference,
			decimal	biblePercent
		)
		{
			scriptureReference = ScriptureReferenceHelper.BibleGroupSubstituteReplace(scriptureReference);
			
			String resultSet = "";
			
			String[] scriptureReferenceSubset = scriptureReference.Split
			(
				ScriptureReferenceHelper.PrePostSeparator
			);
			
			scriptureReferenceSubset[0] = scriptureReferenceSubset[0].Trim();
			
			int scriptureReferenceSubsetLength = scriptureReferenceSubset.Length;
			
			string bibleBookEnd = scriptureReferenceSubsetLength == 1
				? scriptureReferenceSubset[0] : scriptureReferenceSubset[1].Trim();
			
			resultSet = String.Format
			(
				"scriptureReferenceSubset[0]: {0} | bibleBookEnd: {1}",
				scriptureReferenceSubset[0],
				bibleBookEnd
			);

			//return resultSet;

			DataTable books = (DataTable) DataCommand.DatabaseCommand
			(
				String.Format
				(
					SQL_Book,
					scriptureReferenceSubset[0],
					bibleBookEnd
				),	
				System.Data.CommandType.Text,
				DataCommand.ResultType.DataTable
			);

			int lastRow = books.Rows.Count - 1;
			
			int	startingVerse = (int) books.Rows[0]["StartingVerse"];
			int endingVerse = (int) books.Rows[lastRow]["EndingVerse"];

			int	startingChapter = (int) books.Rows[0]["StartingChapter"];
			int endingChapter = (int) books.Rows[lastRow]["EndingChapter"];
			
			int verses = (int) Math.Round
			(
				(
					endingVerse - startingVerse
				)
				*
				biblePercent
			);

			int chapters = (int) Math.Round
			(
				(
					endingChapter - startingChapter
				)
				*
				biblePercent
			);

			int verseForward = startingVerse + verses;
			int verseBackward = endingVerse - verses;

			int chapterForward = startingChapter + chapters;
			int chapterBackward = endingChapter - chapters;

			String scriptureReferenceVerseForward = (String) DataCommand.DatabaseCommand
			(
				String.Format
				(
					SQLQueryVerse,
					verseForward
				),	
				System.Data.CommandType.Text,
				DataCommand.ResultType.Scalar
			);

			String scriptureReferenceVerseBackward = (String) DataCommand.DatabaseCommand
			(
				String.Format
				(
					SQLQueryVerse,
					verseBackward
				),	
				System.Data.CommandType.Text,
				DataCommand.ResultType.Scalar
			);

			String scriptureReferenceChapterForward = (String) DataCommand.DatabaseCommand
			(
				String.Format
				(
					SQLQueryChapter,
					chapterForward
				),	
				System.Data.CommandType.Text,
				DataCommand.ResultType.Scalar
			);

			String scriptureReferenceChapterBackward = (String) DataCommand.DatabaseCommand
			(
				String.Format
				(
					SQLQueryChapter,
					chapterBackward
				),	
				System.Data.CommandType.Text,
				DataCommand.ResultType.Scalar
			);


			resultSet = scriptureReferenceVerseForward + ", " + 
						scriptureReferenceChapterForward + ", " + 
						scriptureReferenceChapterBackward + ", " + 
						scriptureReferenceVerseBackward;

			return resultSet;
		}

		public const String SQL_Book =
			@"
				SELECT
					MIN(VerseIDSequence)	AS	StartingVerse,
					MIN(ChapterIDSequence)	AS	StartingChapter,
					MAX(ChapterIDSequence)	AS	EndingChapter,
					MAX(VerseIDSequence)	AS	EndingVerse
				FROM Bible..Scripture_View
				WHERE BookTitle = '{0}'
				UNION
				SELECT
					MIN(VerseIDSequence),
					MIN(ChapterIDSequence),
					MAX(ChapterIDSequence),
					MAX(VerseIDSequence)
				FROM Bible..Scripture_View
				WHERE BookTitle = '{1}'
				ORDER BY StartingVerse
			";
			
		public const String SQLQueryChapter = "SELECT BookTitle + ' ' + CONVERT(VARCHAR, ChapterID) AS ScriptureReference FROM Bible..Scripture_View WHERE ChapterIDSequence = {0}";
		public const String SQLQueryVerse = "SELECT ScriptureReference FROM Bible..Scripture_View WHERE VerseIDSequence = {0}";
	}		
} 	
