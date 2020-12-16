USE [Bible]
GO

ALTER FUNCTION [dbo].[udf_CountBibleChaptersUsingDistinct]
(
)
RETURNS INTEGER
AS
BEGIN
	--Created 2017-03-04
	DECLARE @count INTEGER

	SET @count = 
	(
		SELECT count(
					    DISTINCT
						  CAST(BookID as varchar(6))
						+ ' '
						+ CAST(ChapterID as varchar(6))
				    )
		FROM	Bible..KJV
	)

	RETURN @count
END
GO

SELECT dbo.udf_CountBibleChaptersUsingDistinct()
GO

