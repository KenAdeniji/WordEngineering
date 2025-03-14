﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Diagnostics.Contracts;
using System.Collections.ObjectModel;
using System.Xml;
using System.Xml.Serialization;

/*
	2021-04-17T21:48:00 Created.	https://grantwinney.com/how-to-compare-two-objects-testing-for-equality-in-c/
*/
namespace InformationInTransit.ProcessLogic
{
    public partial class BibleBook
    {
        public static void Main(string[] argv)
        {
			Stub();
			/*
            //BibleBook esther = new BibleBook()[17];
            //ObjectDumper.Write(esther);
            //BibleBook jeremiah = new BibleBook()["Jeremiah"];
            //ObjectDumper.Write(jeremiah);
            //BibleBook good = new BibleBook()["good"];
            //ObjectDumper.Write(good);
            BibleBook john = new BibleBook()["John"];
            string johnSerialized = john.ToXml();
            System.Console.WriteLine(johnSerialized);
			*/
            //string bibleBooksSerialized = BibleBooks.ToXml();
            //System.Console.WriteLine(bibleBooksSerialized);
        }

        public static void Stub()
        {
			foreach(BibleBook bibleBook in BibleBooks)
            {
                //System.Console.WriteLine(bibleBook);
                //ObjectDumper.Write(bibleBook);
            }
            ObjectDumper.Write(BibleBooks);
        }

        public int ID 
        {
            get; set;
        }

        [XmlAttribute(AttributeName = "Testament")]
		public string Testament
        {
            get
            {
                string testament = "Old";
                if (ID > OldTestamentBibleBooksCount)
                {
                    testament = "New";
                }
                return testament;
            }
			set
			{
				
			}
        }

        public string Title 
        {
            get; set;
        }

        /// <summary>Indexer.</summary>
        /// <code>
        ///     <example>
        ///         BibleBook esther = new BibleBook()[17];
        ///     </example>
        /// </code>
        public BibleBook this [int index]
        {
            get
            {
                //Contract.Requires<IndexOutOfRangeException>(index >= 1 && index <= BibleBooksCount);
                return BibleBooks[index - 1];
            }
        }

        /// <summary>Indexer.</summary>
        /// <code>
        ///     <example>
        ///         BibleBook jeremiah = new BibleBook()["Jeremiah"];
        ///     </example>
        /// </code>
        public BibleBook this[string title]
        {
            get
            {
                if (String.IsNullOrEmpty(title))
                {
                    throw new ArgumentOutOfRangeException("parameter must be the name of a bibleBook.");
                }
                //Contract.EndContractBlock();

                BibleBook bibleBook = BibleBooks.SingleOrDefault(element => element.Title == title);
                if (bibleBook == null) throw new ArgumentOutOfRangeException("parameter must be the name of a bibleBook.");
                return bibleBook;
            }
        }

		public override bool Equals(object obj)
		{
			var other = obj as BibleBook;
	 
			if (other == null)
				return false;
	 
			if (ID != other.ID || Title != other.Title)
				return false;
	 
			return true;
		}

		public static bool operator ==(BibleBook x, BibleBook y)
		{ 
			return x.Equals(y);
		}
	 
		public static bool operator !=(BibleBook x, BibleBook y)
		{
			return !(x == y);
		}

		public override int GetHashCode()
		{
			int hashTitle = Title == null ? 0 : Title.GetHashCode();
			int hashID = ID.GetHashCode();
	 
			return hashTitle ^ hashID;
		}
	
		[XmlArray("BibleBooks")]
		[XmlArrayItem("BibleBook")]
        public static readonly Collection<BibleBook> BibleBooks = new Collection<BibleBook>
        {
            new BibleBook{ ID = 1, Title = "Genesis" },
            new BibleBook{ ID = 2, Title = "Exodus" },
            new BibleBook{ ID = 3, Title = "Leviticus" },
            new BibleBook{ ID = 4, Title = "Numbers" },
            new BibleBook{ ID = 5, Title = "Deuteronomy" },
            new BibleBook{ ID = 6, Title = "Joshua" },
            new BibleBook{ ID = 7, Title = "Judges" },
            new BibleBook{ ID = 8, Title = "Ruth" },
            new BibleBook{ ID = 9, Title = "1 Samuel" },
            new BibleBook{ ID = 10, Title = "2 Samuel" },
            new BibleBook{ ID = 11, Title = "1 Kings" },
            new BibleBook{ ID = 12, Title = "2 Kings" },
            new BibleBook{ ID = 13, Title = "1 Chronicles" },
            new BibleBook{ ID = 14, Title = "2 Chronicles" },
            new BibleBook{ ID = 15, Title = "Ezra" },
            new BibleBook{ ID = 16, Title = "Nehemiah" },
            new BibleBook{ ID = 17, Title = "Esther" },
            new BibleBook{ ID = 18, Title = "Job" },
            new BibleBook{ ID = 19, Title = "Psalms" },
            new BibleBook{ ID = 20, Title = "Proverbs" },
            new BibleBook{ ID = 21, Title = "Ecclesiastes" },
            new BibleBook{ ID = 22, Title = "Song of Solomon" },
            new BibleBook{ ID = 23, Title = "Isaiah" },
            new BibleBook{ ID = 24, Title = "Jeremiah" },
            new BibleBook{ ID = 25, Title = "Lamentations" },
            new BibleBook{ ID = 26, Title = "Ezekiel" },
            new BibleBook{ ID = 27, Title = "Daniel" },
            new BibleBook{ ID = 28, Title = "Hosea" },
            new BibleBook{ ID = 29, Title = "Joel" },
            new BibleBook{ ID = 30, Title = "Amos" },
            new BibleBook{ ID = 31, Title = "Obadiah" },
            new BibleBook{ ID = 32, Title = "Jonah" },
            new BibleBook{ ID = 33, Title = "Micah" },
            new BibleBook{ ID = 34, Title = "Nahum" },
            new BibleBook{ ID = 35, Title = "Habakkuk" },
            new BibleBook{ ID = 36, Title = "Zephaniah" },
            new BibleBook{ ID = 37, Title = "Haggai" },
            new BibleBook{ ID = 38, Title = "Zechariah" },
            new BibleBook{ ID = 39, Title = "Malachi" },
            new BibleBook{ ID = 40, Title = "Matthew" },
            new BibleBook{ ID = 41, Title = "Mark" },
            new BibleBook{ ID = 42, Title = "Luke" },
            new BibleBook{ ID = 43, Title = "John" },
            new BibleBook{ ID = 44, Title = "Acts" },
            new BibleBook{ ID = 45, Title = "Romans" },
            new BibleBook{ ID = 46, Title = "1 Corinthians" },
            new BibleBook{ ID = 47, Title = "2 Corinthians" },
            new BibleBook{ ID = 48, Title = "Galatians" },
            new BibleBook{ ID = 49, Title = "Ephesians" },
            new BibleBook{ ID = 50, Title = "Philippians" },
            new BibleBook{ ID = 51, Title = "Colossians" },
            new BibleBook{ ID = 52, Title = "1 Thessalonians" },
            new BibleBook{ ID = 53, Title = "2 Thessalonians" },
            new BibleBook{ ID = 54, Title = "1 Timothy" },
            new BibleBook{ ID = 55, Title = "2 Timothy" },
            new BibleBook{ ID = 56, Title = "Titus" },
            new BibleBook{ ID = 57, Title = "Philemon" },
            new BibleBook{ ID = 58, Title = "Hebrews" },
            new BibleBook{ ID = 59, Title = "James" },
            new BibleBook{ ID = 60, Title = "1 Peter" },
            new BibleBook{ ID = 61, Title = "2 Peter" },
            new BibleBook{ ID = 62, Title = "1 John" },
            new BibleBook{ ID = 63, Title = "2 John" },
            new BibleBook{ ID = 64, Title = "3 John" },
            new BibleBook{ ID = 65, Title = "Jude" },
            new BibleBook{ ID = 66, Title = "Revelation" },
        };
                
        private const int BibleBooksCount = 66;
        private const int OldTestamentBibleBooksCount = 39;
    }
}
