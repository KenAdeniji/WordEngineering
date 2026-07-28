#define CONTRACTS_FULL

using System;
using System.Diagnostics.Contracts;

/*
	http://learn.microsoft.com/en-us/dotnet/framework/debug-trace-profile/code-contracts
	http://learn.microsoft.com/en-us/dotnet/standard/base-types/how-to-pad-a-number-with-leading-zeros
	SELECT
		MAX(BookID)		BookIDMaximum,
		MAX(ChapterID)	ChapterIDMaximum,
		MAX(VerseID)	VerseIDMaximum
	FROM
		Bible..Scripture
*/	
namespace InformationInTransit.BertrandMeyer_DesignByContract_DbC
{
	public static partial class BertrandMeyer_DesignByContract_DbCHelper
    {
		public static void Main(string[] argv)
		{
			System.Console.WriteLine(BibleReference(43, 1, 1));
			//System.Console.WriteLine(BibleReference(67, 1, 1));
			//System.Console.WriteLine(BibleReference(43, 151, 1));
			//System.Console.WriteLine(BibleReference(43, 1, 177));
		}
		
        public static String BibleReference
		(
			int	bookID,
			int	chapterID,
			int	verseID
		)
        {
			//Contract.Requires<ArgumentException>(bookID < 1 || bookID > BookIDMaximum, "bookID");
			if (bookID < 1 || bookID > BookIDMaximum) throw new ArgumentException(String.Format("bookID={0} bookID < 1 || bookID > {1}", bookID, BookIDMaximum));
			if (chapterID < 1 || chapterID > ChapterIDMaximum) throw new ArgumentException(String.Format("chapterID={0} chapterID < 1 || chapterID > {1}", chapterID, ChapterIDMaximum));
			if (verseID < 1 || verseID > VerseIDMaximum) throw new ArgumentException(String.Format("verseID={0} verseID < 1 || verseID > {1}", verseID, VerseIDMaximum));
			Contract.EndContractBlock(); // All previous "if" checks are preconditions
			return 
			(
				String.Format
				(
					"{0,2:D2}{1,3:D3}{2,3:D3}",
					bookID,
					chapterID,
					verseID
				)
			);
		}
		
		public const int BookIDMaximum = 66;
		public const int ChapterIDMaximum = 150;
		public const int VerseIDMaximum = 176;
	}
}	
