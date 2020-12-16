using System;
using System.Linq;
using System.Data.Linq;

/*
	2018-11-04	https://books.google.com/books/about/Pro_LINQ.html?id=438nCgAAQBAJ&printsec=frontcover&source=kp_read_button#v=onepage&q&f=false
	2018-11-12	Created.
*/
public static partial class ConvertingAnArrayOfStringsToIntegers
{
	public static void Main(String[] argv)
	{
		Query();
	}

	public static void Query()
	{
		int[] bibleBookChapters	= BibleBookChapters.Select
		(
			s => Int32.Parse(s)
		).ToArray();
		foreach(int bibleBookChapter in bibleBookChapters)
		{
			System.Console.WriteLine(bibleBookChapter);
		}	
	}
	
	public static readonly string[] BibleBookChapters	= {
	"50", 
	"40",
	"27",
	"36",
	"34",
	"24",
	"21",
	"4",
	"31",
	"24",
	"22",
	"25",
	"29",
	"36",
	"10",
	"13",
	"10",
	"42",
	"150",
	"31",
	"12",
	"8",
	"66",
	"52",
	"5",
	"48",
	"12",
	"14",
	"3",
	"9",
	"1",
	"4",
	"7",
	"3",
	"3",
	"3",
	"2",
	"14",
	"4",
	"28",
	"16",
	"24",
	"21",
	"28",
	"16",
	"16",
	"13",
	"6",
	"6",
	"4",
	"4",
	"5",
	"3",
	"6",
	"4",
	"3",
	"1",
	"13",
	"5",
	"5",
	"3",
	"5",
	"1",
	"1",
	"1",
	"22"
	};
}	
			