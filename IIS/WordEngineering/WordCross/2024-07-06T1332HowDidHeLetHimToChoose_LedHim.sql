SELECT
	BibleWord,
	FirstOccurrenceScriptureReference,
	LastOccurrenceScriptureReference,
	Difference,
	FrequencyOfOccurrence
FROM
	Bible..Exact_View
WHERE
	BibleWord IN ('What', 'When', 'Where', 'Who', 'Why')
ORDER BY
	BibleWord
;

SELECT TOP 1 
	'When' [When],
    (
		SELECT		TOP 1 ScriptureReference
	    FROM		Bible..Scripture_View
		WHERE 		KingJamesVersion LIKE '%Passover%'
		ORDER BY	VerseIDSequence
	)	FirstOccurrenceScriptureReference,
    (
		SELECT		TOP 1 ScriptureReference
	    FROM		Bible..Scripture_View
		WHERE 		KingJamesVersion LIKE '%Passover%'
		ORDER BY	VerseIDSequence DESC
	)	LastOccurrenceScriptureReference,
    (
		SELECT		MAX(VerseIDSequence) - MIN(VerseIDSequence)
	    FROM		Bible..Scripture_View
		WHERE 		KingJamesVersion LIKE '%Passover%'
	)	Difference,
    (
		SELECT		COUNT(*)
	    FROM		Bible..Scripture_View
		WHERE 		KingJamesVersion LIKE '%Passover%'
	)	FrequencyOfOccurrence
FROM 
	Bible..Scripture_View
