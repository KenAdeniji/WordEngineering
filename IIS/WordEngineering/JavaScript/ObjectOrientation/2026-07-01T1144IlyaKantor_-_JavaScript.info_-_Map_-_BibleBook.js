export class BibleBook {
/*
	2026-07-01T11:38:00 http://javascript.info/map-set
*/
	constructor
	(
		bookID,
		bookTitle
	)
	{
		this.bookID = bookID;
		this.bookTitle = bookTitle;
	}
	
	toString()
	{
		return `Book ID: ${this.bookID} Title: ${this.bookTitle}`
	}	
	
	static BibleBooks =
	[
		new BibleBook(1, "Genesis"),
		new BibleBook(2, "Exodus"),
	];
}
