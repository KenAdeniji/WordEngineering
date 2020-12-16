CREATE PROCEDURE usp_SelectNumberSign_WithNumberInFigure
(
	@biblePhrase	VARCHAR(MAX),
	@bibleNumber	INT,
	@bibleVersion	VARCHAR(MAX)	=	'KingJamesVersion'
)
AS
BEGIN
	--Created	2018-11-23.
	DECLARE @scriptureReferenceVariable VARCHAR(MAX)
	SELECT @scriptureReferenceVariable = ScriptureReference
	FROM WordEngineering..NumberSign
	WHERE Number = {2}
	DECLARE @scriptureReferenceTable Table
	(
		ScriptureReference VARCHAR(MAX)
	)	
	INSERT @scriptureReferenceTable(ScriptureReference)
	SELECT trim(value)
	FROM STRING_SPLIT(@scriptureReferenceVariable, ',')
	SELECT ScriptureReference, {0} AS VerseText 
		FROM Bible..Scripture 
		WHERE {0} LIKE '%{1}%' AND 
		ScriptureReference IN (SELECT sct.ScriptureReference FROM @scriptureReferenceTable AS sct)
		ORDER BY BookID, ChapterID, VerseID
END
GO
