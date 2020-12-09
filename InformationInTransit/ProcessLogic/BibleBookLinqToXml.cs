using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;

namespace InformationInTransit.ProcessLogic
{
	public class BibleBookLinqToXml
	{
        public static void Main(string[] argv)
        {
            OldTestament();
            BooksOfMoses();
        }

        public static void OldTestament()
        {
            var q = from bibleBook in BibleBooks.Descendants("BibleBook")
                where (string)bibleBook.Attribute("Testament") == "Old"
                    select (string)bibleBook.Element("Id") + " " +
                (string)bibleBook.Element("Title");
            ObjectDumper.Write(q);
        }

        public static void BooksOfMoses()
        {
            var q = from bibleBook in BibleBooks.Descendants("BibleBook")
                    where (int)bibleBook.Element("Id") <= 5
                    select (string)bibleBook.Element("Id") + " " +
                (string)bibleBook.Element("Title");
            ObjectDumper.Write(q);
        }

        /*
        public static void GospelOfChrist()
        {
            IEnumerable<BibleBook> q = (from bibleBook in BibleBooks.Descendants("BibleBook")
                    where (string)bibleBook.Element("Testament") == "New"
                    select bibleBook).Take(4);
            ObjectDumper.Write(q);
        }
        */

        static BibleBookLinqToXml()
        {
            BibleBooks = XDocument.Load(@"BibleBook.xml");
            FirstBooksInEachTestament = 
			new XElement("ArrayOfBibleBook",
                    new XElement("bibleBook", 
                        new XAttribute("testament", "Old"),
                        new XElement("id", 1),
                        new XElement("title", "Genesis")
                    ),
                    new XElement("bibleBook", 
                        new XAttribute("testament", "New"),
                        new XElement("id", 40),
                        new XElement("title", "Matthew")
                    )
                );

        }

        public static readonly XDocument BibleBooks;
        public static readonly XElement FirstBooksInEachTestament;
	}
}
