using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Xml;
using System.Xml.Serialization;

/*
	2021-04-18T21:48:00 Created.	https://grantwinney.com/how-to-compare-two-objects-testing-for-equality-in-c/
*/
namespace InformationInTransit.ProcessCode
{
    public partial class BibleBookCompareEquality
    {
        public static void Main(string[] argv)
        {
        }

        public static void Stub()
        {
        }

		public int ID {get; set;}
		public string Title {get; set;}

		public override bool Equals(object obj)
		{
			var other = obj as BibleBookCompareEquality;
	 
			if (other == null)
				return false;
	 
			if (ID != other.ID || Title != other.Title)
				return false;
	 
			return true;
		}
	
        public static readonly Collection<BibleBookCompareEquality> BibleBookCompareEqualities = new Collection<BibleBookCompareEquality>
        {
            new BibleBookCompareEquality{ ID = 1, Title = "Genesis" },
            new BibleBookCompareEquality{ ID = 2, Title = "Exodus" },
            new BibleBookCompareEquality{ ID = 3, Title = "Leviticus" },
            new BibleBookCompareEquality{ ID = 4, Title = "Numbers" },
            new BibleBookCompareEquality{ ID = 5, Title = "Deuteronomy" },
            new BibleBookCompareEquality{ ID = 6, Title = "Joshua" },
            new BibleBookCompareEquality{ ID = 7, Title = "Judges" },
            new BibleBookCompareEquality{ ID = 8, Title = "Ruth" },
            new BibleBookCompareEquality{ ID = 9, Title = "1 Samuel" },
            new BibleBookCompareEquality{ ID = 10, Title = "2 Samuel" },
            new BibleBookCompareEquality{ ID = 11, Title = "1 Kings" },
            new BibleBookCompareEquality{ ID = 12, Title = "2 Kings" },
            new BibleBookCompareEquality{ ID = 13, Title = "1 Chronicles" },
            new BibleBookCompareEquality{ ID = 14, Title = "2 Chronicles" },
            new BibleBookCompareEquality{ ID = 15, Title = "Ezra" },
            new BibleBookCompareEquality{ ID = 16, Title = "Nehemiah" },
            new BibleBookCompareEquality{ ID = 17, Title = "Esther" },
            new BibleBookCompareEquality{ ID = 18, Title = "Job" },
            new BibleBookCompareEquality{ ID = 19, Title = "Psalms" },
            new BibleBookCompareEquality{ ID = 20, Title = "Proverbs" },
            new BibleBookCompareEquality{ ID = 21, Title = "Ecclesiastes" },
            new BibleBookCompareEquality{ ID = 22, Title = "Song of Solomon" },
            new BibleBookCompareEquality{ ID = 23, Title = "Isaiah" },
            new BibleBookCompareEquality{ ID = 24, Title = "Jeremiah" },
            new BibleBookCompareEquality{ ID = 25, Title = "Lamentations" },
            new BibleBookCompareEquality{ ID = 26, Title = "Ezekiel" },
            new BibleBookCompareEquality{ ID = 27, Title = "Daniel" },
            new BibleBookCompareEquality{ ID = 28, Title = "Hosea" },
            new BibleBookCompareEquality{ ID = 29, Title = "Joel" },
            new BibleBookCompareEquality{ ID = 30, Title = "Amos" },
            new BibleBookCompareEquality{ ID = 31, Title = "Obadiah" },
            new BibleBookCompareEquality{ ID = 32, Title = "Jonah" },
            new BibleBookCompareEquality{ ID = 33, Title = "Micah" },
            new BibleBookCompareEquality{ ID = 34, Title = "Nahum" },
            new BibleBookCompareEquality{ ID = 35, Title = "Habakkuk" },
            new BibleBookCompareEquality{ ID = 36, Title = "Zephaniah" },
            new BibleBookCompareEquality{ ID = 37, Title = "Haggai" },
            new BibleBookCompareEquality{ ID = 38, Title = "Zechariah" },
            new BibleBookCompareEquality{ ID = 39, Title = "Malachi" },
            new BibleBookCompareEquality{ ID = 40, Title = "Matthew" },
            new BibleBookCompareEquality{ ID = 41, Title = "Mark" },
            new BibleBookCompareEquality{ ID = 42, Title = "Luke" },
            new BibleBookCompareEquality{ ID = 43, Title = "John" },
            new BibleBookCompareEquality{ ID = 44, Title = "Acts" },
            new BibleBookCompareEquality{ ID = 45, Title = "Romans" },
            new BibleBookCompareEquality{ ID = 46, Title = "1 Corinthians" },
            new BibleBookCompareEquality{ ID = 47, Title = "2 Corinthians" },
            new BibleBookCompareEquality{ ID = 48, Title = "Galatians" },
            new BibleBookCompareEquality{ ID = 49, Title = "Ephesians" },
            new BibleBookCompareEquality{ ID = 50, Title = "Philippians" },
            new BibleBookCompareEquality{ ID = 51, Title = "Colossians" },
            new BibleBookCompareEquality{ ID = 52, Title = "1 Thessalonians" },
            new BibleBookCompareEquality{ ID = 53, Title = "2 Thessalonians" },
            new BibleBookCompareEquality{ ID = 54, Title = "1 Timothy" },
            new BibleBookCompareEquality{ ID = 55, Title = "2 Timothy" },
            new BibleBookCompareEquality{ ID = 56, Title = "Titus" },
            new BibleBookCompareEquality{ ID = 57, Title = "Philemon" },
            new BibleBookCompareEquality{ ID = 58, Title = "Hebrews" },
            new BibleBookCompareEquality{ ID = 59, Title = "James" },
            new BibleBookCompareEquality{ ID = 60, Title = "1 Peter" },
            new BibleBookCompareEquality{ ID = 61, Title = "2 Peter" },
            new BibleBookCompareEquality{ ID = 62, Title = "1 John" },
            new BibleBookCompareEquality{ ID = 63, Title = "2 John" },
            new BibleBookCompareEquality{ ID = 64, Title = "3 John" },
            new BibleBookCompareEquality{ ID = 65, Title = "Jude" },
            new BibleBookCompareEquality{ ID = 66, Title = "Revelation" },
        };
    }
}
