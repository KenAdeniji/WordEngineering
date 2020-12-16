USE [Bible]
GO

ALTER FUNCTION [dbo].[udf_CountBibleChaptersUsingCommonTableExpressionCTE]
(
)
RETURNS INTEGER
AS
BEGIN
	--Created 2017-03-04
	DECLARE @count INTEGER

; with cte
(
	  BookID
	, chapterID
)
as
(
	SELECT DISTINCT BookID, chapterID
	FROM	Bible..KJV
)

SELECT @count = count(*)
from   cte

	RETURN @count
END
GO

SELECT dbo.udf_CountBibleChaptersUsingCommonTableExpressionCTE()
GO

