/*
	2026-03-31T05:21:00...2026-03-31T05:52:00 How can I query by period... week, month, year?
	Aileen.A.Nielsen@gmail.com
	http://www.oreilly.com/library/view/practical-time-series/9781492041641
*/
SELECT
	MIN(Dated) AS MinimumDated,
	MAX(Dated) AS MaximumDated,
	ContactID,
	COUNT(*) AS Occurrences
FROM
	WordEngineering..CaseBasedReasoning
WHERE
	ContactID BETWEEN 467 AND 483
GROUP BY
	DATEPART ( Year, Dated ),
	ContactID
ORDER BY
	DATEPART ( Year, Dated ),
	ContactID

