SELECT
	COUNT(ChapterID) AS Chapters
FROM
	Bible..Scripture
WHERE
	BookID BETWEEN 1 AND 5
GROUP BY
	BookID

	