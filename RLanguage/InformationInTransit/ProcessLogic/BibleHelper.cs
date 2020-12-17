using System;

using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

using Newtonsoft.Json;

using InformationInTransit.DataAccess;
using InformationInTransit.ProcessLogic;

/*
	2016-12-10	https://msdn.microsoft.com/en-us/library/dn921900.aspx
	2016-12-10	BibleHelper.cs 	Created.
	2016-12-11	http://stackoverflow.com/questions/24336597/why-cant-json-net-serialize-static-or-const-member-variables
*/
namespace InformationInTransit.ProcessLogic
{
    public partial class BibleHelper
    {
        public static void Main(string[] argv)
        {
			Serialize(JSONFileName);
        }

        public static void HelpingOneAnotherIsSeeingFurther(string path)
        {
            DataSet dataSet = Query();
			DataTable dataTable = dataSet.Tables[0];

			int bookID = -1;
			int bookIDPrevious = -1;
			string bookTitle = null;
			int chapterID = -1;
			int chapterIDPrevious = -1;
			int verseID = -1;
			string verseText = null;
			
			Bible bibleContainer = new Bible();
			Book bookContainer = new Book();
			Chapter chapterContainer = new Chapter();
			
			foreach(DataRow dataRow in dataTable.Rows)
			{
				bookID = (int) dataRow["bookId"];
				bookTitle = (string) dataRow["bookTitle"];
				chapterID = (int) dataRow["chapterId"];
				verseID = (int) dataRow["verseId"];
				verseText = (string) dataRow["verseText"];
				
				if (bookID > bookIDPrevious)
				{
					bookIDPrevious = bookID;
					bookContainer = new Book
					{
						ID = bookID,
						Title = bookTitle
					};

					bibleContainer.Books.Add(bookContainer);	
				}
				
				if (chapterID > chapterIDPrevious)
				{
					chapterIDPrevious = chapterID;
					chapterContainer = new Chapter
					{
						ID = chapterID
					};

					bookContainer.Chapters.Add(chapterContainer);	
				}
			}
			
			string json = JsonConvert.SerializeObject(bibleContainer, Newtonsoft.Json.Formatting.Indented);

			FileHelper.FileWrite(path, json);
        }

        public static DataSet Query()
        {
            DataSet dataSet = (DataSet) DataCommand.DatabaseCommand
            (
                "SELECT * FROM Bible..Scripture WHERE chapterID BETWEEN 1 AND 2 ORDER BY VerseIDSequence",
                CommandType.Text,
                DataCommand.ResultType.DataSet
            );
			return dataSet;
        }

        public static void Serialize(string path)
        {
            DataSet dataSet = Query();
			string json = JsonConvert.SerializeObject(dataSet, Newtonsoft.Json.Formatting.Indented);
			FileHelper.FileWrite(path, json);
        }
		
		public const string JSONFileName = "Bible.json";
		
		[JsonObject(MemberSerialization.OptIn)]
		public class Bible
		{
			[JsonProperty]
			public Collection<Book> Books = new Collection<Book>();
		}
		
		[JsonObject(MemberSerialization.OptIn)]
		public class Book
		{
			[JsonProperty]
			public int ID { get; set; }
			
			[JsonProperty]
			public string Title { get; set; }
			
			[JsonProperty]
			public Collection<Chapter> Chapters = new Collection<Chapter>();
		}

		[JsonObject(MemberSerialization.OptIn)]
		public class Chapter
		{
			[JsonProperty]
			public int ID { get; set; }
			
			[JsonProperty]
			public Collection<Verse> Verses = new Collection<Verse>();
		}

		[JsonObject(MemberSerialization.OptIn)]
		public class Verse
		{
			[JsonProperty]
			public int ID { get; set; }
			
			[JsonProperty]
			public Collection<String> VerseText = new Collection<String>();
		}	
    }
}
