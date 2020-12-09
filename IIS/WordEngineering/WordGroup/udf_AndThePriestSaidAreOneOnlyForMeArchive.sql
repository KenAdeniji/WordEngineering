USE [WordEngineering]
GO

CREATE OR ALTER FUNCTION [dbo].[udf_AndThePriestSaidAreOneOnlyForMe]
(
	@word NVARCHAR(MAX)
)
RETURNS INTEGER
AS
BEGIN
	/*
		2020-08-25	Create date.	SELECT dbo.udf_AndThePriestSaidAreOneOnlyForMe('יהוה')
	*/
	DECLARE @alphabetSequenceIndex DECIMAL
	DECLARE @currentCharacter nCHARACTER
	declare @currentCharacterAsUnicode int
	DECLARE @currentCharacterUnicode  nchar
	DECLARE @length INTEGER
	DECLARE @position INTEGER
	SET @word = REPLACE(@word,'''','''''');
	SET @word = LTRIM(RTRIM(UPPER(@word)))
	SET @alphabetSequenceIndex = 0
	SET @length = LEN(@word)
	SET @position = 0

	WHILE @position <= @length
	BEGIN
		SET @position = @position + 1

		SET @currentCharacter = SUBSTRING(@word, @position, 1)

		IF @currentCharacter = ' ' OR @currentCharacter = ''''
		BEGIN
			CONTINUE
		END	 

		SET @currentCharacterAsUnicode = unicode(SUBSTRING(@word, @position, 1))

		SET @currentCharacterUnicode =  CONVERT(char(17), SUBSTRING(@word, @position, 1))

		SElect @alphabetSequenceIndex = @alphabetSequenceIndex +
				CONVERT(INT, COMMENTARY)
				FROM ActToGod
				WHERE 
					Major = 'Hebrew Alphabet' AND
					Minor LIKE '%' + @currentCharacter + '%';
	END

	RETURN @alphabetSequenceIndex
END
GO


/*
SELECT dbo.udf_AndThePriestSaidAreOneOnlyForMe('יהוה')
*/
GO
