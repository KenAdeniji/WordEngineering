ALTER PROCEDURE usp_BibleStatisticsExact
AS
BEGIN
	--Created 2017-03-04
	/*
		These are words that occur in the Bible, in order of occurrence. Bible..KJV.BibleWord.
		Because You exist; Thy must be found.
	*/
	SELECT	'Unique words count'	AS Question,	CONVERT(VARCHAR, COUNT(BibleWord))	AS	Answer
	FROM	Bible..Exact
	UNION
	SELECT	'First word in dictionary ascending sort order',	MIN(BibleWord)
	FROM	Bible..Exact
	UNION
	SELECT	'Last word in dictionary ascending sort order',	MAX(BibleWord)
	FROM	Bible..Exact
	UNION
	SELECT	'First word in record order',	BibleWord
	FROM	Bible..Exact
	WHERE	SequenceOrderID = 1
	UNION
	SELECT	'Last word in record order',	BibleWord
	FROM	Bible..Exact
	WHERE	SequenceOrderID = (SELECT MAX(SequenceOrderID) FROM Bible..Exact)
	UNION
	SELECT	'Most occurring word',	BibleWord
	FROM	Bible..Exact
	WHERE	SequenceOrderID = (SELECT TOP 1 SequenceOrderID FROM Bible..Exact ORDER BY FrequencyOfOccurrence DESC)
	UNION
	SELECT	'Least occurring word',	BibleWord
	FROM	Bible..Exact
	WHERE	SequenceOrderID = (SELECT TOP 1 SequenceOrderID FROM Bible..Exact ORDER BY FrequencyOfOccurrence ASC)
	ORDER BY Question
END
GO


