using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Xml;
using System.Xml.Serialization;

namespace InformationInTransit.ProcessLogic
{
	/*
		2017-04-19	https://msdn.microsoft.com/en-us/library/bb397906.aspx
	*/
	///<summary>
	///	2017-04-19	Created.
	///</summary>
    public partial class LinqBibleBook
    {
        public static void Main(string[] argv)
        {
			Stub();
        }

        public static void Stub()
        {
			Odd();
        }
		
        public static void Odd()
        {
			var oddBibleBooks =
                from bibleBook in BibleBook.BibleBooks
                where (bibleBook.Id % 2) == 1
                select bibleBook;
	
			ObjectDumper.Write(oddBibleBooks);			
        }
    }
}
