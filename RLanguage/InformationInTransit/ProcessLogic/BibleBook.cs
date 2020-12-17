using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Diagnostics.Contracts;
using System.Collections.ObjectModel;
using System.Xml;
using System.Xml.Serialization;

namespace InformationInTransit.ProcessLogic
{
    public partial class BibleBook
    {
        public static void Main(string[] argv)
        {
            /*
			Stub();
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

        public int Id 
        {
            get
            {
                //Contract.Requires<IndexOutOfRangeException>(Id >= 1 && Id <= BibleBooksCount);
                return id;
            }
            set
            {
                //Contract.Requires<IndexOutOfRangeException>(Id >= 1 && Id <= BibleBooksCount);
                id = value;
            }
        }

        [XmlAttribute(AttributeName = "Testament")]
		public string Testament
        {
            get
            {
                string testament = "Old";
                if (Id > OldTestamentBibleBooksCount)
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

		[XmlArray("BibleBooks")]
		[XmlArrayItem("BibleBook")]
        public static readonly Collection<BibleBook> BibleBooks = new Collection<BibleBook>
        {
            new BibleBook{ Id = 1, Title = "Genesis" },
            new BibleBook{ Id = 2, Title = "Exodus" },
            new BibleBook{ Id = 3, Title = "Leviticus" },
            new BibleBook{ Id = 4, Title = "Numbers" },
            new BibleBook{ Id = 5, Title = "Deuteronomy" },
            new BibleBook{ Id = 6, Title = "Joshua" },
            new BibleBook{ Id = 7, Title = "Judges" },
            new BibleBook{ Id = 8, Title = "Ruth" },
            new BibleBook{ Id = 9, Title = "1 Samuel" },
            new BibleBook{ Id = 10, Title = "2 Samuel" },
            new BibleBook{ Id = 11, Title = "1 Kings" },
            new BibleBook{ Id = 12, Title = "2 Kings" },
            new BibleBook{ Id = 13, Title = "1 Chronicles" },
            new BibleBook{ Id = 14, Title = "2 Chronicles" },
            new BibleBook{ Id = 15, Title = "Ezra" },
            new BibleBook{ Id = 16, Title = "Nehemiah" },
            new BibleBook{ Id = 17, Title = "Esther" },
            new BibleBook{ Id = 18, Title = "Job" },
            new BibleBook{ Id = 19, Title = "Psalms" },
            new BibleBook{ Id = 20, Title = "Proverbs" },
            new BibleBook{ Id = 21, Title = "Ecclesiastes" },
            new BibleBook{ Id = 22, Title = "Song of Solomon" },
            new BibleBook{ Id = 23, Title = "Isaiah" },
            new BibleBook{ Id = 24, Title = "Jeremiah" },
            new BibleBook{ Id = 25, Title = "Lamentations" },
            new BibleBook{ Id = 26, Title = "Ezekiel" },
            new BibleBook{ Id = 27, Title = "Daniel" },
            new BibleBook{ Id = 28, Title = "Hosea" },
            new BibleBook{ Id = 29, Title = "Joel" },
            new BibleBook{ Id = 30, Title = "Amos" },
            new BibleBook{ Id = 31, Title = "Obadiah" },
            new BibleBook{ Id = 32, Title = "Jonah" },
            new BibleBook{ Id = 33, Title = "Micah" },
            new BibleBook{ Id = 34, Title = "Nahum" },
            new BibleBook{ Id = 35, Title = "Habakkuk" },
            new BibleBook{ Id = 36, Title = "Zephaniah" },
            new BibleBook{ Id = 37, Title = "Haggai" },
            new BibleBook{ Id = 38, Title = "Zechariah" },
            new BibleBook{ Id = 39, Title = "Malachi" },
            new BibleBook{ Id = 40, Title = "Matthew" },
            new BibleBook{ Id = 41, Title = "Mark" },
            new BibleBook{ Id = 42, Title = "Luke" },
            new BibleBook{ Id = 43, Title = "John" },
            new BibleBook{ Id = 44, Title = "Acts" },
            new BibleBook{ Id = 45, Title = "Romans" },
            new BibleBook{ Id = 46, Title = "1 Corinthians" },
            new BibleBook{ Id = 47, Title = "2 Corinthians" },
            new BibleBook{ Id = 48, Title = "Galatians" },
            new BibleBook{ Id = 49, Title = "Ephesians" },
            new BibleBook{ Id = 50, Title = "Philippians" },
            new BibleBook{ Id = 51, Title = "Colossians" },
            new BibleBook{ Id = 52, Title = "1 Thessalonians" },
            new BibleBook{ Id = 53, Title = "2 Thessalonians" },
            new BibleBook{ Id = 54, Title = "1 Timothy" },
            new BibleBook{ Id = 55, Title = "2 Timothy" },
            new BibleBook{ Id = 56, Title = "Titus" },
            new BibleBook{ Id = 57, Title = "Philemon" },
            new BibleBook{ Id = 58, Title = "Hebrews" },
            new BibleBook{ Id = 59, Title = "James" },
            new BibleBook{ Id = 60, Title = "1 Peter" },
            new BibleBook{ Id = 61, Title = "2 Peter" },
            new BibleBook{ Id = 62, Title = "1 John" },
            new BibleBook{ Id = 63, Title = "2 John" },
            new BibleBook{ Id = 64, Title = "3 John" },
            new BibleBook{ Id = 65, Title = "Jude" },
            new BibleBook{ Id = 66, Title = "Revelation" },
        };
                
        private int id;

        private const int BibleBooksCount = 66;
        private const int OldTestamentBibleBooksCount = 39;
    }
}
