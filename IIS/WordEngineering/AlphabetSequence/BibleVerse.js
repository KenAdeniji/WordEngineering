/*
	2026-08-03T08:36:00 Date created.
*/
export class BibleVerse
{
	constructor
	(
		bookID,
		bookChapter,
		bookVerse
	)
	{
		this.bookID = bookID;
		this.bookChapter = bookChapter;
		this.bookVerse = bookVerse;		
	}
	
	toString()
	{
		return `Book ID: ${this.bookID} Book Chapter: ${this.bookChapter} Book Chapter: ${this.bookVerse}`
	}	

	static buildBibleVerseHTMLTable
	(
		bibleBookChapterVerseSet,
		tableCaption
	)
	{	
		var htmlTableStub =	"<table><caption>" + tableCaption + "</caption><tbody>";
		for (var chapterIndex = 0; chapterIndex < bibleBookChapterVerseSet.length; chapterIndex++)
		{
			htmlTableStub += "<tr><td>" + 
				BibleVerse.scriptureReferenceConcatenate
				(
					bibleBookChapterVerseSet[chapterIndex].BookTitle,
					bibleBookChapterVerseSet[chapterIndex].ChapterID,
					bibleBookChapterVerseSet[chapterIndex].VerseID
				) +
				"</td><td>" + bibleBookChapterVerseSet[chapterIndex].KingJamesVersion + "</td></tr>";
		}
		htmlTableStub += "</tbody></table>";
		return htmlTableStub;
	}
	
	static scriptureReferenceConcatenate(bookTitle, chapterID, verseID) 
	{
		return (bookTitle + " " + chapterID + ":" + verseID);
	}
}
