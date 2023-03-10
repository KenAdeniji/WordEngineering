USE [WordEngineering]
GO
/****** Object:  UserDefinedFunction [dbo].[udf_AlphabetSequenceIndex]    Script Date: 10/7/2020 9:13:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE OR ALTER FUNCTION [dbo].[udf_SplitSelectRandom]
(
	@word NVARCHAR(MAX)
)
RETURNS NVARCHAR(MAX)
AS
BEGIN
/*
	2020-10-07T09:15:00	https://docs.microsoft.com/en-us/sql/t-sql/functions/string-split-transact-sql?view=sql-server-ver15
	2020-10-07T10:08:00	https://dba.stackexchange.com/questions/110664/random-selection-of-a-row-within-a-function
*/
	DECLARE @splitSelectRandom AS NVARCHAR(MAX)
	SELECT TOP 1
		@splitSelectRandom = TRIM(value)  
	FROM STRING_SPLIT(@word, ',')  
	WHERE RTRIM(value) <> ''
	ORDER BY (Select ID From ViewNewID)

	RETURN @splitSelectRandom
END
GO

CREATE OR ALTER View ViewNewID As Select NEWID() as id
GO

