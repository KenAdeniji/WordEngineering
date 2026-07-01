export class BibleBook {
/*
	2026-07-01T11:38:00 http://javascript.info/map-set
	SELECT 'new BibleBook(' + CONVERT(VARCHAR, BookID) + ', "' + BookTitle + '"),'
	FROM Bible..BibleBook
	ORDER BY BookID
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
		new BibleBook(3, "Leviticus"),
		new BibleBook(4, "Numbers"),
		new BibleBook(5, "Deuteronomy"),
		new BibleBook(6, "Joshua"),
		new BibleBook(7, "Judges"),
		new BibleBook(8, "Ruth"),
		new BibleBook(9, "1 Samuel"),
		new BibleBook(10, "2 Samuel"),
		new BibleBook(11, "1 Kings"),
		new BibleBook(12, "2 Kings"),
		new BibleBook(13, "1 Chronicles"),
		new BibleBook(14, "2 Chronicles"),
		new BibleBook(15, "Ezra"),
		new BibleBook(16, "Nehemiah"),
		new BibleBook(17, "Esther"),
		new BibleBook(18, "Job"),
		new BibleBook(19, "Psalms"),
		new BibleBook(20, "Proverbs"),
		new BibleBook(21, "Ecclesiastes"),
		new BibleBook(22, "Song of Solomon"),
		new BibleBook(23, "Isaiah"),
		new BibleBook(24, "Jeremiah"),
		new BibleBook(25, "Lamentations"),
		new BibleBook(26, "Ezekiel"),
		new BibleBook(27, "Daniel"),
		new BibleBook(28, "Hosea"),
		new BibleBook(29, "Joel"),
		new BibleBook(30, "Amos"),
		new BibleBook(31, "Obadiah"),
		new BibleBook(32, "Jonah"),
		new BibleBook(33, "Micah"),
		new BibleBook(34, "Nahum"),
		new BibleBook(35, "Habakkuk"),
		new BibleBook(36, "Zephaniah"),
		new BibleBook(37, "Haggai"),
		new BibleBook(38, "Zechariah"),
		new BibleBook(39, "Malachi"),
		new BibleBook(40, "Matthew"),
		new BibleBook(41, "Mark"),
		new BibleBook(42, "Luke"),
		new BibleBook(43, "John"),
		new BibleBook(44, "Acts"),
		new BibleBook(45, "Romans"),
		new BibleBook(46, "1 Corinthians"),
		new BibleBook(47, "2 Corinthians"),
		new BibleBook(48, "Galatians"),
		new BibleBook(49, "Ephesians"),
		new BibleBook(50, "Philippians"),
		new BibleBook(51, "Colossians"),
		new BibleBook(52, "1 Thessalonians"),
		new BibleBook(53, "2 Thessalonians"),
		new BibleBook(54, "1 Timothy"),
		new BibleBook(55, "2 Timothy"),
		new BibleBook(56, "Titus"),
		new BibleBook(57, "Philemon"),
		new BibleBook(58, "Hebrews"),
		new BibleBook(59, "James"),
		new BibleBook(60, "1 Peter"),
		new BibleBook(61, "2 Peter"),
		new BibleBook(62, "1 John"),
		new BibleBook(63, "2 John"),
		new BibleBook(64, "3 John"),
		new BibleBook(65, "Jude"),
		new BibleBook(66, "Revelation"),
	];
}
