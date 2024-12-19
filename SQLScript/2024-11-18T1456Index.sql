--2024-11-18T14:57:00
--Point query
/*
SELECT *
FROM Bible..Scripture_View
WHERE VerseIDSequence = 1
*/

--Multipoint query
/*
SELECT *
FROM Bible..Scripture_View
WHERE ChapterIDSequence = 1
*/

--Range query
SELECT *
FROM Bible..Scripture_View
WHERE VerseIDSequence BETWEEN 1 AND 10
;
SELECT *
FROM Bible..Scripture_View
WHERE VerseIDSequence <= 5

--Prefix match query
SELECT *
FROM Bible..Scripture_View
WHERE KingJamesVersion LIKE
(
	SELECT TOP 1 KingJamesVersion
	FROM Bible..Scripture_View
	GROUP BY KingJamesVersion
	ORDER BY COUNT(KingJamesVersion) DESC
)

--Extremal query
SELECT *
FROM Bible..Scripture_View
WHERE VerseIDSequence =
(
	SELECT MAX( VerseIDSequence )
	FROM Bible..Scripture_View
)

--Ordering query
SELECT TOP 10 *
FROM Bible..Scripture_View
ORDER BY VerseIDSequence DESC


--Grouping query
SELECT BookGroup, COUNT(BookGroup ) BookGroupVersesCount
FROM Bible..Scripture_View
GROUP BY BookGroup
ORDER BY BookGroup
