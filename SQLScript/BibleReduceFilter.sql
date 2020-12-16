
SELECT
	BookID,
	BookTitle,
	MAX(ChapterID) AS Chapters,
	COUNT(VerseID) AS Verses
FROM
	Bible..Scripture
GROUP BY
	BookID,
	BookTitle
ORDER BY
	BookID
