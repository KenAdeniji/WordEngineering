/*
Loving Once
Psalms 40:10
*/
SELECT 
 --LEFT( scriptureReferenceWithoutBracket, 20 ) AS ScriptureReference,
 --verseText
 --verseText + '(' + scriptureReferenceWithoutBracket + ').'
 scriptureReferenceWithoutBracket + ', '
 --verseText + '(' + scriptureReferenceWithoutBracket + ').'
FROM
 BIBLE..KJV
WHERE
 verseText LIKE '%Loving%' AND verseText LIKE '%Once%' --AND verseText LIKE '%Once%' AND verseText LIKE '%More%'
 --CHARINDEX('', verseText) > 0 AND CHARINDEX('', verseText) > 0 AND CHARINDEX('', verseText) > 0 AND CHARINDEX('', verseText) < CHARINDEX('', verseText) AND CHARINDEX('', verseText) < CHARINDEX('', verseText)
ORDER BY
 verseIdSequence

/*
UPDATE BibleWord SET
 ScriptureReference = 'Psalms 40:10',
 TheWordId          = 415,
 Word               = 'Loving Once'
WHERE  
 SequenceOrderId    = 571
*/

/*
UPDATE CaseBasedReasoning SET
 Commentary         = 'Afghan Village, 5698 Thornton Avenue Newark CA 94560.',
 TheWordId          = 415
WHERE  
 SequenceOrderId    = 1524
*/

/*
UPDATE CaseBasedReasoning SET
 Commentary         = 'Flavor House Products, Inc. Regency Dry Roasted Peanuts Flavor House Products Inc. Dothan AL 36303 033618 18 23633 2 Net wt 7.5oz (212g).',
 TheWordId          = 270
WHERE  
 SequenceOrderId    = 1525
*/

/*
UPDATE ClassAssociates SET
 Commentary         = 'Hip ... private part ... lip ...',
 TheWordId          = 415
WHERE  
 SequenceOrderId    = 671
*/

/*
UPDATE TheWord SET
 ContactId          = 48,
 Filename           = 'Comforter_-_20040203AfghanVillage_LovingYouForeverOnceMore.xml',
 ScriptureReference = 'Psalms 40:10'
WHERE  
 SequenceOrderId    = 415
*/

/*
UPDATE AlphabetSequence SET
 ContactId                    = 48,
 Dated                        = '20040203',
 ScriptureReferenceAssociates = 'Psalms 40:10',
 TheWordId                    = 415
WHERE  
 SequenceOrderId BETWEEN 3963 AND 3994
*/

/*
DELETE FROM AlphabetSequence 
WHERE
 SequenceOrderId BETWEEN 3963 AND 3994
*/

/*
DBCC CHECKIDENT (AlphabetSequence, RESEED, 3962)
*/