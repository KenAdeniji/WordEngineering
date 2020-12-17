using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;

/*
	2018-08-02	Created.
*/
namespace InformationInTransit.ProcessCode
{ 
	public static partial class MakeMeKnow
	{
		public static void Main(string[] argv)
		{
		}
		
		public static DataSet Query
		(
			string 	bibleVersion,
			string	word
		)
		{
			string[] words = word.Split
			(
				BibleWordHelper.SplitSeparator,
				StringSplitOptions.RemoveEmptyEntries
			);
			int wordsLength = words.Length;
			int formatIndex = wordsLength - 1;
			string sqlStatement = null;
			DataSet dataSet = null;
			switch (wordsLength)
			{
				case 1:
				{
					sqlStatement = String.Format
					(
						SelectFormat[formatIndex],
						bibleVersion,
						words[0].Length
					);	
					break;
				}	
				case 2:
				{
					sqlStatement = String.Format
					(
						SelectFormat[formatIndex],
						bibleVersion,
						words[0].Length,
						words[1].Length
					);	
					break;
				}	
				case 3:
				{
					sqlStatement = String.Format
					(
						SelectFormat[formatIndex],
						bibleVersion,
						words[0].Length,
						words[1].Length,
						words[2].Length						
					);	
					break;
				}	
				default:
				{
					return dataSet;
					break;
				}	
			};
			dataSet = (DataSet) DataCommand.DatabaseCommand
			(
				sqlStatement,
				System.Data.CommandType.Text,
				DataCommand.ResultType.DataSet
			);
			return dataSet;
		}
		
		public static readonly string[] SelectFormat = new String[]
		{
			"SELECT bookId, chapterId, verseId, {0} AS verseText FROM Bible..Scripture WHERE BookID = {1} ORDER BY BookID, ChapterID, VerseID",
			"SELECT bookId, chapterId, verseId, {0} AS verseText FROM Bible..Scripture WHERE ChapterID = {1} AND VerseID = {2} ORDER BY BookID, ChapterID, VerseID",
			"SELECT bookId, chapterId, verseId, {0} AS verseText FROM Bible..Scripture WHERE BookID = {1} AND ChapterID = {2} AND VerseID = {3} ORDER BY BookID, ChapterID, VerseID",
		};
    }
}
