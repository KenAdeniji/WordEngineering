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
using System.Data.SqlTypes;
using System.Text;

using System.Text.RegularExpressions;

//2017-03-03	Remove namespace for assembly
/*
"C:\WINDOWS\Microsoft.NET\Framework\v3.5\csc.exe" ThisIsMySpreadOut.cs
"C:\WINDOWS\Microsoft.NET\Framework\v3.5\csc.exe" /target:library ThisIsMySpreadOut.cs 

DROP Function  udf_BookTitle
GO

DROP Function  udf_ScriptureReference
GO

DROP assembly ThisIsMySpreadOut
GO

CREATE ASSEMBLY ThisIsMySpreadOut from 'E:\WordEngineering\InformationInTransit\ProcessLogic\ThisIsMySpreadOut.dll' WITH PERMISSION_SET = SAFE
GO

CREATE FUNCTION udf_BookTitle(@bookID int)
RETURNS NVARCHAR(MAX)
AS EXTERNAL NAME ThisIsMySpreadOut.[ThisIsMySpreadOut].BookTitle
GO

SELECT dbo.udf_BookTitle(40)
GO

CREATE FUNCTION udf_ScriptureReference(@bookID int, @chapterID int, @verseID int)
RETURNS NVARCHAR(MAX)
AS EXTERNAL NAME ThisIsMySpreadOut.[ThisIsMySpreadOut].ScriptureReference
GO

SELECT dbo.udf_ScriptureReference(40, 17, 6)
GO
*/
/*
	2017-03-03	ThisIsMySpreadOut.cs Created.
		SELECT 
			  '"' + bookTitle + '",'
		FROM 
			[Bible].[dbo].[BibleBook]
		ORDER BY
			BookID	
*/

//namespace InformationInTransit.ProcessLogic 
//{
	public static partial class ThisIsMySpreadOut
	{
		public static void Main(string[] argv)
		{
			System.Console.WriteLine(BookTitle(5));
			System.Console.WriteLine(BookTitle(-1));
			System.Console.WriteLine(BookTitle(67));
			System.Console.WriteLine(ScriptureReference(15, 12, 7));
			System.Console.WriteLine(ScriptureReference(67, 15, 17));
		}
		
		[SqlFunction(IsDeterministic = true)]
		public static SqlString BookTitle(int bookID)
		{
			return (bookID >= 1 && bookID <= 66) ? BookTitles[bookID - 1] : null;
		}

		[SqlFunction(IsDeterministic = true)]
		public static SqlString ScriptureReference(int bookID, int chapterID, int verseID)
		{
			return String.Format
			(
				ScriptureReferenceFormat, 
				BookTitle(bookID),
				chapterID,
				verseID
			);	
		}
		
		public static readonly string[] BookTitles = { 
			"Genesis",
			"Exodus",
			"Leviticus",
			"Numbers",
			"Deuteronomy",
			"Joshua",
			"Judges",
			"Ruth",
			"1 Samuel",
			"2 Samuel",
			"1 Kings",
			"2 Kings",
			"1 Chronicles",
			"2 Chronicles",
			"Ezra",
			"Nehemiah",
			"Esther",
			"Job",
			"Psalms",
			"Proverbs",
			"Ecclesiastes",
			"Song of Solomon",
			"Isaiah",
			"Jeremiah",
			"Lamentations",
			"Ezekiel",
			"Daniel",
			"Hosea",
			"Joel",
			"Amos",
			"Obadiah",
			"Jonah",
			"Micah",
			"Nahum",
			"Habakkuk",
			"Zephaniah",
			"Haggai",
			"Zechariah",
			"Malachi",
			"Matthew",
			"Mark",
			"Luke",
			"John",
			"Acts",
			"Romans",
			"1 Corinthians",
			"2 Corinthians",
			"Galatians",
			"Ephesians",
			"Philippians",
			"Colossians",
			"1 Thessalonians",
			"2 Thessalonians",
			"1 Timothy",
			"2 Timothy",
			"Titus",
			"Philemon",
			"Hebrews",
			"James",
			"1 Peter",
			"2 Peter",
			"1 John",
			"2 John",
			"3 John",
			"Jude",
			"Revelation"
		};	

		public const string ScriptureReferenceFormat = "{0} {1}:{2}";
	}
//}
