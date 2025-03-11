using 	System;
using 	System.Collections;
using 	System.Collections.Generic;
using 	System.Collections.ObjectModel;
using 	System.Data;
using 	System.Data.SqlClient;
using 	System.Text;
using	System.Text.RegularExpressions;	
using	System.Linq;

using 	InformationInTransit.DataAccess;

/*
	2025-03-09T20:29:00	Created.	
	2025-03-09T20:17:00...2025-03-09T20:22:00	http://stackoverflow.com/questions/6111298/best-way-to-specify-whitespace-in-a-string-split-operation
	2025-03-10T15:54:53...2025-03-10T17:32:00	JSON
*/
namespace InformationInTransit.ProcessCode
{
	public static partial class AsideWithChristianityHelper
	{
		public static void Main(string[] argv)
		{
			//Query(38, 60, 155, "KingJamesVersion");
			Query(284, 98, 120, "KingJamesVersion");
		}
	
		public static String Query
		(
			int		bookID,
			int		chapterID,
			int		verseID,
			String	bibleVersion
		)
		{
			String jsonFormat = String.Format
			(
				JsonFormatBothDirections,
				QueryScriptureReferenceForward(bookID, chapterID, verseID, bibleVersion),
				QueryScriptureReferenceBackward(bookID, chapterID, verseID, bibleVersion)
			);
			System.Console.WriteLine(jsonFormat);
			return jsonFormat;
		}
		
		public static String QueryScriptureReferenceForward
		(
			int		bookID,
			int		chapterID,
			int		verseID,
			String	bibleVersion
		)
		{
			String 		scriptureReferenceForward 			= 	"";
			String 		verseIDSequenceForwardStatement 	= 	"";
			int 		chapterIDSequenceForward			=	-1;
			int 		verseIDSequenceForward				=	-1;
			String		wordForward							=	"";
			String 		verseText							=	"";
			String[]	words								=	null;
			int			wordsCounter						=	0;
			int			wordsLength							=	-1;
		
			String		jsonFormat							=	"";
		
			chapterIDSequenceForward = (int) DataCommand.DatabaseCommand
			(
				String.Format
				(
					SQLStatementChapterIDForwardFormat,
					bookID
				),	
				CommandType.Text,
				DataCommand.ResultType.Scalar
			);
			System.Console.WriteLine
			(
				"chapterIDSequenceForward: {0}",
				chapterIDSequenceForward
			);	
			verseIDSequenceForwardStatement	= String.Format
			(
				SQLStatementVerseIDForwardFormat,
				chapterIDSequenceForward,
				chapterID
			);	
			System.Console.WriteLine
			(
				"verseIDSequenceForwardStatement: {0}",
				verseIDSequenceForwardStatement
			);	
			verseIDSequenceForward = (int) DataCommand.DatabaseCommand
			(
				verseIDSequenceForwardStatement,
				CommandType.Text,
				DataCommand.ResultType.Scalar
			);
			System.Console.WriteLine
			(
				"verseIDSequenceForward: {0}",
				verseIDSequenceForward
			);	
			for
			(
				wordsCounter = 0;
				wordsCounter < verseID;
			)
			{
				verseText = (String) DataCommand.DatabaseCommand
				(
					String.Format
					(
						SQLStatementVerseTextForwardFormat,
						verseIDSequenceForward,
						bibleVersion
					),	
					CommandType.Text,
					DataCommand.ResultType.Scalar
				);
				words = Regex.Split(verseText, @"\s+").Where(s => s != String.Empty).ToArray<string>();
				wordsLength = words.Length;
				System.Console.WriteLine
				(
					"verseIDSequenceForward: {0}",
					verseIDSequenceForward
				);	
				if (wordsCounter + wordsLength < verseID)
				{
					wordsCounter += wordsLength;
					++verseIDSequenceForward;
					continue;
				}		
				wordForward = words[verseID - wordsCounter];
				scriptureReferenceForward = (String) DataCommand.DatabaseCommand
				(
					String.Format
					(
						SQLStatementScriptureReferenceForwardFormat,
						verseIDSequenceForward
					),	
					CommandType.Text,
					DataCommand.ResultType.Scalar
				);
				System.Console.WriteLine
				(
					"verseIDSequenceForward: {0} | scriptureReferenceForward: {1} | verseText: {2} | wordForward: {3}",
					verseIDSequenceForward,
					scriptureReferenceForward,
					verseText,
					wordForward
				);	
				jsonFormat = String.Format
				(
					JsonFormatUniDirection,
					verseIDSequenceForward,
					scriptureReferenceForward,
					verseText,
					wordForward
				);	
				System.Console.WriteLine(jsonFormat);	
				break;
			}		
			return jsonFormat;
		}

		public static String QueryScriptureReferenceBackward
		(
			int		bookID,
			int		chapterID,
			int		verseID,
			String	bibleVersion
		)
		{
			String 		scriptureReferenceBackward 			= 	"";
			String 		verseIDSequenceBackwardStatement 	= 	"";
			int 		chapterIDSequenceBackward			=	-1;
			int 		verseIDSequenceBackward				=	-1;
			String		wordBackward							=	"";
			String 		verseText							=	"";
			String[]	words								=	null;
			int			wordsCounter						=	0;
			int			wordsLength							=	-1;
		
			String		jsonFormat							=	"";
		
			chapterIDSequenceBackward = (int) DataCommand.DatabaseCommand
			(
				String.Format
				(
					SQLStatementChapterIDBackwardFormat,
					bookID
				),	
				CommandType.Text,
				DataCommand.ResultType.Scalar
			);
			System.Console.WriteLine
			(
				"chapterIDSequenceBackward: {0}",
				chapterIDSequenceBackward
			);	
			verseIDSequenceBackwardStatement	= String.Format
			(
				SQLStatementVerseIDBackwardFormat,
				chapterIDSequenceBackward,
				chapterID
			);	
			System.Console.WriteLine
			(
				"verseIDSequenceBackwardStatement: {0}",
				verseIDSequenceBackwardStatement
			);	
			verseIDSequenceBackward = (int) DataCommand.DatabaseCommand
			(
				verseIDSequenceBackwardStatement,
				CommandType.Text,
				DataCommand.ResultType.Scalar
			);
			System.Console.WriteLine
			(
				"verseIDSequenceBackward: {0}",
				verseIDSequenceBackward
			);	
			for
			(
				wordsCounter = 0;
				wordsCounter < verseID;
			)
			{
				verseText = (String) DataCommand.DatabaseCommand
				(
					String.Format
					(
						SQLStatementVerseTextBackwardFormat,
						verseIDSequenceBackward,
						bibleVersion
					),	
					CommandType.Text,
					DataCommand.ResultType.Scalar
				);
				words = Regex.Split(verseText, @"\s+").Where(s => s != String.Empty).ToArray<string>();
				wordsLength = words.Length;
				System.Console.WriteLine
				(
					"verseIDSequenceBackward: {0}",
					verseIDSequenceBackward
				);	
				if (wordsCounter + wordsLength < verseID)
				{
					wordsCounter += wordsLength;
					--verseIDSequenceBackward;
					continue;
				}		
				wordBackward = words[verseID - wordsCounter];
				scriptureReferenceBackward = (String) DataCommand.DatabaseCommand
				(
					String.Format
					(
						SQLStatementScriptureReferenceBackwardFormat,
						verseIDSequenceBackward
					),	
					CommandType.Text,
					DataCommand.ResultType.Scalar
				);
				System.Console.WriteLine
				(
					"verseIDSequenceBackward: {0} | scriptureReferenceBackward: {1} | verseText: {2} | wordBackward: {3}",
					verseIDSequenceBackward,
					scriptureReferenceBackward,
					verseText,
					wordBackward
				);	
				jsonFormat = String.Format
				(
					JsonFormatUniDirection,
					verseIDSequenceBackward,
					scriptureReferenceBackward,
					verseText,
					wordBackward
				);	
				System.Console.WriteLine(jsonFormat);	
				break;
			}		
			return jsonFormat;
		}
		
		public const string SQLStatementChapterIDForwardFormat = "SELECT TOP 1 ChapterIDSequence FROM Bible..Scripture_View WHERE BookID = {0} % 66 ORDER BY VerseIDSequence";
		public const string SQLStatementVerseIDForwardFormat = "SELECT TOP 1 VerseIDSequence FROM Bible..Scripture_View WHERE ChapterIDSequence = (SELECT distinct TOP 1 ChapterIDSequence WHERE ChapterIDSequence = {0} - 1 + {1})";
		public const string SQLStatementVerseTextForwardFormat = "SELECT TOP 1 {1} VerseText FROM Bible..Scripture_View WHERE VerseIDSequence = {0} ORDER BY VerseIDSequence";
		public const string SQLStatementScriptureReferenceForwardFormat = "SELECT TOP 1 ScriptureReference FROM Bible..Scripture_View WHERE VerseIDSequence = {0} ORDER BY VerseIDSequence";

		public const string SQLStatementChapterIDBackwardFormat = "SELECT TOP 1 ChapterIDSequence FROM Bible..Scripture_View WHERE BookID = 66 - {0} % 66 ORDER BY VerseIDSequence";
		public const string SQLStatementVerseIDBackwardFormat = "SELECT TOP 1 VerseIDSequence FROM Bible..Scripture_View WHERE ChapterIDSequence = (SELECT distinct TOP 1 ChapterIDSequence WHERE ChapterIDSequence = {0} + 1 - {1})";
		public const string SQLStatementVerseTextBackwardFormat = "SELECT TOP 1 {1} VerseText FROM Bible..Scripture_View WHERE VerseIDSequence = {0} ORDER BY VerseIDSequence";
		public const string SQLStatementScriptureReferenceBackwardFormat = "SELECT TOP 1 ScriptureReference FROM Bible..Scripture_View WHERE VerseIDSequence = {0} ORDER BY VerseIDSequence";

		public const string	JsonFormatUniDirection = "{{\"verseIDSequence\": {0}, \"scriptureReference\": \"{1}\", \"verseText\": \"{2}\", \"verseWord\": \"{3}\"}}";
		public const string	JsonFormatBothDirections = "[{0}, {1}]";
    }
}
