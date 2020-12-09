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

using Microsoft.SqlServer.Server;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;

namespace InformationInTransit.ProcessLogic
{
	/*
		2017-07-10	December ten, thirty one. Two numbers, after December.
	*/
	public static partial class DecemberTenThirtyOne
	{
		public static void Main(string[] argv)
		{
			DateTime dated = DateTime.Now;
			bool isDate = DateTime.TryParse(argv[0], out dated);
			if (isDate)
			{	
				DataSet resultSet = Query(dated);
			}	
		}

		public static DataSet Query
		(
			DateTime	dated,
			String		bibleVersion = "VerseText"
		)
		{
			DataSet dataSet = null;
			
			int bookID = (int) dated.Year / 100;
			int chapterID =	dated.Year % 100;
			int verseID = dated.Month;
			int wordID = dated.Day;
			
			System.Console.WriteLine
			(
				"Book ID: {0} Chapter ID: {1} Verse ID: {2} Word ID: {3}",
				bookID,
				chapterID,
				verseID,
				wordID
			);
			
			dataSet = (DataSet)DataCommand.DatabaseCommand
			(
				String.Format
				(
					BibleQueryBookChapterVerseFormat, 
					bibleVersion,
					bookID,
					chapterID,
					verseID
				),	
				CommandType.Text,
				DataCommand.ResultType.DataSet
			);
	
			if (dataSet.IsEmpty() == false)
			{	
				return dataSet;
			}
			
			dataSet = (DataSet)DataCommand.DatabaseCommand
			(
				String.Format
				(
					BibleQueryBookChapterFormat, 
					bibleVersion,
					bookID,
					chapterID
				),	
				CommandType.Text,
				DataCommand.ResultType.DataSet
			);
			
			if (dataSet.IsEmpty() == false)
			{	
				return dataSet;
			}
			
			dataSet = (DataSet)DataCommand.DatabaseCommand
			(
				String.Format
				(
					BibleQueryBookFormat, 
					bibleVersion,
					bookID
				),	
				CommandType.Text,
				DataCommand.ResultType.DataSet
			);
			
			return dataSet;
		}
		
		public static DataSet ProcessSqlStatement(StringBuilder sql)
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
	
		public const string BibleQueryBookChapterVerseFormat = "SELECT BookID, ChapterID, VerseID, VerseText = {0} FROM Bible..Scripture WHERE BookID = {1} AND ChapterID = {2} AND VerseID = {3} ORDER BY VerseIDSequence";
		public const string BibleQueryBookChapterFormat = "SELECT BookID, ChapterID, VerseID, VerseText = {0} FROM Bible..Scripture WHERE BookID = {1} AND ChapterID = {2} ORDER BY VerseIDSequence";
		public const string BibleQueryBookFormat = "SELECT BookID, ChapterID, VerseID, VerseText = {0} FROM Bible..Scripture WHERE BookID = {1} ORDER BY VerseIDSequence";		
	}
}
