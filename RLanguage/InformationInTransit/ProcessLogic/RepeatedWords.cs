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
///	2016-06-18	Created. RepeatedWords.cs
///	2016-06-18	Revelation 4:8	And the four beasts had each of them six wings about him; and they were full of eyes within: and they rest not day and night, saying, Holy, holy, holy, LORD God Almighty, which was, and is, and is to come.
///	2016-03-13	"Context Connection = true;"
///	2016-03-13	CLR Scalar-Valued Functions https://msdn.microsoft.com/es-es/library/ms131043%28v=sql.90%29.aspx
///	2016-06-18	http://www.dotnetperls.com/dataset
///</summary>
namespace InformationInTransit.ProcessLogic
{
    public static partial class RepeatedWords
    {
		public static void Main(string[] argv)
		{
			DataSet otherData = OtherData(argv[0]);
			otherData.Tables[0].DumpDataTable();
		}	
		
		public static DataSet OtherData(string bibleVersion)
        {
			DataTable bible = (DataTable) DataCommand.DatabaseCommand
			(
				String.Format(BibleSQL, bibleVersion),
				System.Data.CommandType.Text,
				DataCommand.ResultType.DataTable
			);
			
			DataTable workTable = new DataTable("workTable");
			workTable.Columns.Add("Word");
			workTable.Columns.Add("ScriptureReference");
			workTable.Columns.Add("Occurrences");
			
			String[] words;
			string lastWord;
			int occurrences;
			
			foreach(DataRow dataRow in bible.Rows)
			{
				words = dataRow["VerseText"].ToString().Split(Delimiters, StringSplitOptions.RemoveEmptyEntries);
				
				occurrences = 0;
				lastWord = null;

				foreach(string word in words)
				{
					if (word == lastWord)
					{
						++occurrences;
					}
					else
					{
						if (occurrences > 0)
						{
							workTable.Rows.Add
							(
								lastWord,
								dataRow["ScriptureReference"],
								++occurrences
							);
						}			
						occurrences = 0;
						lastWord = word;
					}	
				}	
			}
			
			DataSet otherData = new DataSet("OtherData");
			otherData.Tables.Add(workTable);
			
			return otherData;
        }
		
		public static readonly string[] Books = {"Genesis","Exodus","Leviticus","Numbers","Deuteronomy","Joshua","Judges","Ruth","1 Samuel","2 Samuel","1 Kings","2 Kings","1 Chronicles","2 Chronicles","Ezra","Nehemiah","Esther","Job","Psalms","Proverbs","Ecclesiastes","Song of Solomon","Isaiah","Jeremiah","Lamentations","Ezekiel","Daniel","Hosea","Joel","Amos","Obadiah","Jonah","Micah","Nahum","Habakkuk","Zephaniah","Haggai","Zechariah","Malachi","Matthew","Mark","Luke","John","Acts","Romans","1 Corinthians","2 Corinthians","Galatians","Ephesians","Philippians","Colossians","1 Thessalonians","2 Thessalonians","1 Timothy","2 Timothy","Titus","Philemon","Hebrews","James","1 Peter","2 Peter","1 John","2 John","3 John","Jude","Revelation"};
		public static readonly char[] Delimiters = new char[] { ' ', ',', ';', '.' };
		public const string BibleSQL = "SELECT ScriptureReference, LOWER({0}) AS VerseText FROM Bible..Scripture_View ORDER BY VerseIDSequence ASC";
    }
}
