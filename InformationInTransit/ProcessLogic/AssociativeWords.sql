DROP FUNCTION AssociativeWords
GO

DROP ASSEMBLY AssociativeWords
GO

CREATE ASSEMBLY AssociativeWords from 'E:\WordEngineering\InformationInTransit\ProcessLogic\AssociativeWords.dll' WITH PERMISSION_SET = SAFE
GO

CREATE FUNCTION AssociativeWords
(
	@sentence	nvarchar(MAX),
	@searchWord	nvarchar(MAX),
	@logic		int,
	@wordsCount	int
)
RETURNS nvarchar(MAX)
AS EXTERNAL NAME AssociativeWords.[AssociativeWords].Association
GO

SELECT
	dbo.AssociativeWords(verseText, 'Beside', 0, 3)	AS	Words,
	COUNT(*)										AS	Occurrences
FROM
	Bible..KJV
GROUP BY
	dbo.AssociativeWords(verseText, 'Beside', 0, 3)
ORDER BY
	dbo.AssociativeWords(verseText, 'Beside', 0, 3)
GO

