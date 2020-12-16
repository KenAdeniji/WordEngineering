--BibleBooks[0].setBibleBook(1, "Genesis", 50);

SELECT
	'BibleBooks[' + CONVERT(VARCHAR, BookID - 1) + '].setBibleBook(' + CONVERT(VARCHAR, BookID) + ',"' + BookTitle + '",' + CONVERT(VARCHAR, MAX(ChapterID)) + ');' AS CodeTemplate
FROM
	Bible..Scripture
GROUP BY BookID, BookTitle
ORDER BY BookID, BookTitle
