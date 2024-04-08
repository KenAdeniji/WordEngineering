USE [WordEngineering]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE OR ALTER FUNCTION [dbo].[udf_ToInitiateAllBring]
(
	@bookIDInput INTEGER,
	@chapterIDInput INTEGER,
	@verseIDInput INTEGER
)
RETURNS NVARCHAR(MAX)
AS
BEGIN

-- 2024-04-06T07:26:00 udf_ToInitiateAllBring date created.
-- SELECT dbo.udf_ToInitiateAllBring(35, 87, 25)

DECLARE @booksCount INTEGER
DECLARE @chaptersCount INTEGER
DECLARE @versesCount INTEGER

DECLARE @bookIDForward INTEGER
DECLARE @chapterIDForward INTEGER
DECLARE	@verseIDForward INTEGER
DECLARE @scriptureReferenceForward NVARCHAR(MAX)

DECLARE @bookIDBackward INTEGER
DECLARE @chapterIDBackward INTEGER
DECLARE	@verseIDBackward INTEGER
DECLARE @scriptureReferenceBackward NVARCHAR(MAX)

DECLARE	@resultSet NVARCHAR(MAX)

SELECT @booksCount = MAX(BookID) 
FROM Bible..Scripture_View

SET @bookIDForward = @booksCount % @bookIDInput
SET @bookIDBackward = @booksCount - @bookIDForward

IF ( @bookIDBackward = 0 )
BEGIN 
	SET @bookIDBackward = 1
END

SELECT @chaptersCount = MAX(ChapterID)
FROM Bible..Scripture_View
WHERE BookID = @bookIDForward

SET @chapterIDForward = @chaptersCount % @chapterIDInput
SET @chapterIDBackward = @chaptersCount - @chapterIDForward

IF ( @chapterIDBackward = 0 )
BEGIN 
	SET @chapterIDBackward = 1
END
												
SELECT @versesCount = MAX(VerseID)
FROM Bible..Scripture_View
WHERE BookID = @bookIDForward
AND	ChapterID = @chapterIDForward	

SET @verseIDForward = @versesCount % @verseIDInput
SET @verseIDBackward = @versesCount - @verseIDForward

IF ( @verseIDBackward = 0 )
BEGIN 
	SET @verseIDBackward = 1
END

SELECT 
	@scriptureReferenceForward = ScriptureReference
FROM Bible..Scripture_View
WHERE BookID = @bookIDForward
AND	ChapterID = @chapterIDForward
AND	VerseID = @verseIDForward

SELECT 
	@scriptureReferenceBackward = ScriptureReference
FROM Bible..Scripture_View
WHERE BookID = @bookIDBackward
AND	ChapterID = @chapterIDBackward
AND	VerseID = @verseIDBackward

SET @resultSet = @scriptureReferenceForward + ', ' + @scriptureReferenceBackward

RETURN @resultSet
END
GO
