SELECT
	CONVERT(VARCHAR, BookID) + ',' + BookTitle + ',' + CONVERT(VARCHAR, MAX(ChapterID)) AS CodeTemplate
FROM
	Bible..Scripture
GROUP BY BookID, BookTitle
ORDER BY BookID, BookTitle
