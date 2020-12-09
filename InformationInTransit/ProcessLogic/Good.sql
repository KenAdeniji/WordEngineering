
			SELECT
				'Half' AS Ratio,
				COUNT(*) AS VerseCount,
				(SELECT scriptureReference FROM Bible..KJV WHERE verseIdSequence = (SELECT MIN(verseIdSequence) FROM Bible..KJV WHERE VerseText LIKE '%Half%')) AS FirstScriptureReference, 
				(SELECT scriptureReference FROM Bible..KJV WHERE verseIdSequence = (SELECT MAX(verseIdSequence) FROM Bible..KJV WHERE VerseText LIKE '%Half%')) AS LastScriptureReference
			FROM 
				Bible..KJV
			WHERE
			VerseText LIKE '%Half%'
		 UNION 
			SELECT
				'A third' AS Ratio,
				COUNT(*) AS VerseCount,
				(SELECT scriptureReference FROM Bible..KJV WHERE verseIdSequence = (SELECT MIN(verseIdSequence) FROM Bible..KJV WHERE VerseText LIKE '%A third%')) AS FirstScriptureReference, 
				(SELECT scriptureReference FROM Bible..KJV WHERE verseIdSequence = (SELECT MAX(verseIdSequence) FROM Bible..KJV WHERE VerseText LIKE '%A third%')) AS LastScriptureReference
			FROM 
				Bible..KJV
			WHERE
			VerseText LIKE '%A third%'
		 UNION 
			SELECT
				'A fourth' AS Ratio,
				COUNT(*) AS VerseCount,
				(SELECT scriptureReference FROM Bible..KJV WHERE verseIdSequence = (SELECT MIN(verseIdSequence) FROM Bible..KJV WHERE VerseText LIKE '%A fourth%')) AS FirstScriptureReference, 
				(SELECT scriptureReference FROM Bible..KJV WHERE verseIdSequence = (SELECT MAX(verseIdSequence) FROM Bible..KJV WHERE VerseText LIKE '%A fourth%')) AS LastScriptureReference
			FROM 
				Bible..KJV
			WHERE
			VerseText LIKE '%A fourth%'
		 UNION 
			SELECT
				'A fifth' AS Ratio,
				COUNT(*) AS VerseCount,
				(SELECT scriptureReference FROM Bible..KJV WHERE verseIdSequence = (SELECT MIN(verseIdSequence) FROM Bible..KJV WHERE VerseText LIKE '%A fifth%')) AS FirstScriptureReference, 
				(SELECT scriptureReference FROM Bible..KJV WHERE verseIdSequence = (SELECT MAX(verseIdSequence) FROM Bible..KJV WHERE VerseText LIKE '%A fifth%')) AS LastScriptureReference
			FROM 
				Bible..KJV
			WHERE
			VerseText LIKE '%A fifth%'
		 ORDER BY Ratio
