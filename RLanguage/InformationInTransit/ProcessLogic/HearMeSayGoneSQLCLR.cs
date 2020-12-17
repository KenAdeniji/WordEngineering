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
///	2016-03-13	Created.
///	Hear me say, gone.
///	Consider the alphabet sequence of each word, limited to maximum of four words, first word - book in the Bible; 
///		second word - chapter, third word - verse, fourth word - word in the verse.
///	Hear, 32. Book ID: Jonah.
///	Me, 18. There are only four chapters, in the book of Jonah. Return only the book.
///	2016-03-13	http://www.dotnetperls.com/split
///	2016-03-13	"Context Connection = true;"
///	2016-03-13	CLR Scalar-Valued Functions https://msdn.microsoft.com/es-es/library/ms131043%28v=sql.90%29.aspx
///</summary>
//namespace InformationInTransit.ProcessLogic
//{
    public static partial class HearMeSayGone
    {
		public static void Main(string[] argv)
		{
			foreach(string args in argv)
			{
				string algorithm = UpIsTheDefinitePushIHaveMade(args);
				System.Console.WriteLine(algorithm);
			}	
		}	
		
        [SqlFunction(DataAccess = DataAccessKind.Read)]
		public static string UpIsTheDefinitePushIHaveMade(string question)
        {
			string[] word = question.Split(Delimiters, StringSplitOptions.RemoveEmptyEntries);
			int wordLength = word.Length;

			if (wordLength > 4)
			{
				//System.Console.WriteLine("Word Length: {0}", wordLength);
				return null; 
			}
			int[] wordSequence = new int[wordLength];
			for (int wordIndex = 0; wordIndex < wordLength; ++wordIndex)
			{
				wordSequence[wordIndex] = AlphabetSequence.Id(word[wordIndex]);
			}
			int bookID = wordSequence[0];
			if (bookID > 66) //Books in the Bible.
			{
				//System.Console.WriteLine("Book: {0}", bookID);
				return null;
			} 

			string bookTitle = Books[bookID - 1]; 
			if (wordLength == 1) 
			{
				return bookTitle;
			} 

			int? chaptersInThisBook = 1;
			chaptersInThisBook = (int) DataCommand.DatabaseCommand
			(
				String.Format(ChapterQuery, bookID),
				System.Data.CommandType.Text,
				DataCommand.ResultType.Scalar
			);
		
			if (wordLength < 2 || wordSequence[1] > chaptersInThisBook )
			{
				return bookTitle;
			} 

			int chapterID = wordSequence[1]; 

			if (wordLength < 3) 
			{
				//System.Console.WriteLine("Book: {0} {1}", bookID, chapterID);
				return bookTitle + " " + chapterID.ToString();
			} 
			
			int? verseInThisBookChapter = 1;
			verseInThisBookChapter = (int) DataCommand.DatabaseCommand
			(
				String.Format(VerseQuery, bookID, chapterID),
				System.Data.CommandType.Text,
				DataCommand.ResultType.Scalar
			);
			
			if (wordLength < 2 || wordSequence[2] > verseInThisBookChapter )
			{
				return bookTitle + " " + chapterID.ToString();
			} 
			
			int verseID = wordSequence[2]; 	
			
			return String.Format
			(
				"{0} {1}:{2}",
				bookTitle,
				chapterID,
				verseID
			);
        }
		
		public static readonly string[] Books = {"Genesis","Exodus","Leviticus","Numbers","Deuteronomy","Joshua","Judges","Ruth","1 Samuel","2 Samuel","1 Kings","2 Kings","1 Chronicles","2 Chronicles","Ezra","Nehemiah","Esther","Job","Psalms","Proverbs","Ecclesiastes","Song of Solomon","Isaiah","Jeremiah","Lamentations","Ezekiel","Daniel","Hosea","Joel","Amos","Obadiah","Jonah","Micah","Nahum","Habakkuk","Zephaniah","Haggai","Zechariah","Malachi","Matthew","Mark","Luke","John","Acts","Romans","1 Corinthians","2 Corinthians","Galatians","Ephesians","Philippians","Colossians","1 Thessalonians","2 Thessalonians","1 Timothy","2 Timothy","Titus","Philemon","Hebrews","James","1 Peter","2 Peter","1 John","2 John","3 John","Jude","Revelation"};
		public static readonly char[] Delimiters = new char[] { ' ', ',', ';', '.' };
		public const string ChapterQuery = "SELECT MAX(ChapterID) FROM Bible..Scripture WHERE BookId = {0}";
		public const string VerseQuery = "SELECT MAX(VerseID) FROM Bible..Scripture WHERE BookID = {0} AND ChapterID = {1}";
    }
//}
