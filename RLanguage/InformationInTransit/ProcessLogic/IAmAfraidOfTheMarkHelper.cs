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
using InformationInTransit.ProcessLogic;

namespace InformationInTransit.ProcessLogic
{
	/*
		2017-12-16	Created.
		2017-12-16	To test; My own.
	*/	
	public static class IAmAfraidOfTheMarkHelper
	{
		public static String Query
		(
			string word,
			string scriptureReference
		)
		{
			String[] scriptureReferenceSubset = null;
			DataSet result = null;
			
			int id = AlphabetSequence.Id(word);
			
			ScriptureReferenceHelper.Process
			(
					scriptureReference,
				ref	scriptureReferenceSubset,
				ref result,
					ScriptureReferenceHelper.BibleQueryFormat,
					"KingJamesVersion"
			);
			
			DataTable customMerge = DataSetHelper.CustomMerge(result);
			
			/*
			var nthRecord = customMerge.Skip( id ).FirstOrDefault();
			var scriptureReferenceVerseForward = customMerge[nthRecord]["ScriptureReference"];
			*/
			
			//int index = customMerge.Rows.IndexOf(id);
			
			var row = customMerge.Rows[id];
			//var	column = row["scriptureReference"];
			
			int bookID = (int) row["bookId"];
			int chapterID = (int) row["chapterId"];
			int verseID = (int) row["verseId"];
			
			//var	column = row["verseText"];
			
			//var scriptureReferenceVerseForward = customMerge[id]["scriptureReference"];
			
			/*
			var scriptureReferenceVerseForward = ScriptureReferenceHelper.BookChapterVerseJoin
			(
				bookID,
				chapterID,
				verseID
			);
			*/
			
/*
			ScriptureReference scriptureReferenceVerseForward = 
				new ScriptureReferenceHelper.ScriptureReference
				(
					"Hebrews", //ScriptureReferenceHelper.ScriptureReference.Books[bookID - 1],
					chapterID,
					verseID
				);
*/
//			ScriptureReference scriptureReferenceVerseForward = new ScriptureReferenceHelper.ScriptureReference();
/*			
			(
					"Hebrews", //ScriptureReferenceHelper.ScriptureReference.Books[bookID - 1],
					chapterID,
					verseID
				);
*/				
//			return scriptureReferenceVerseForward.ToString();

			//string scriptureReferenceVerseForward = "Hebrews";
			
			string scriptureReferenceVerseForward = Books[bookID - 1] +
				" " + chapterID.ToString() + ":" + verseID.ToString();
			
			return scriptureReferenceVerseForward;
			
		}
		
		public static readonly string[] Books = {"Genesis","Exodus","Leviticus","Numbers","Deuteronomy","Joshua","Judges","Ruth","1 Samuel","2 Samuel","1 Kings","2 Kings","1 Chronicles","2 Chronicles","Ezra","Nehemiah","Esther","Job","Psalms","Proverbs","Ecclesiastes","Song of Solomon","Isaiah","Jeremiah","Lamentations","Ezekiel","Daniel","Hosea","Joel","Amos","Obadiah","Jonah","Micah","Nahum","Habakkuk","Zephaniah","Haggai","Zechariah","Malachi","Matthew","Mark","Luke","John","Acts","Romans","1 Corinthians","2 Corinthians","Galatians","Ephesians","Philippians","Colossians","1 Thessalonians","2 Thessalonians","1 Timothy","2 Timothy","Titus","Philemon","Hebrews","James","1 Peter","2 Peter","1 John","2 John","3 John","Jude","Revelation"};
	}	
}
