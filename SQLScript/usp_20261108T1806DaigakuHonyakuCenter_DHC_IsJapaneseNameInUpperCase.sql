CREATE OR ALTER FUNCTION dbo.udf_20261108T1806DaigakuHonyakuCenter_DHC_Extract_small_letters_From_String
(
	@String VARCHAR(MAX)  -- Variable for string
)
RETURNS VARCHAR(MAX)
BEGIN
	DECLARE @RETURN_STRING VARCHAR(MAX)
 
	;WITH N1 (n) AS (SELECT 1 UNION ALL SELECT 1),
	N2 (n) AS (SELECT 1 FROM N1 AS X, N1 AS Y),
	N3 (n) AS (SELECT 1 FROM N2 AS X, N2 AS Y),
	N4 (n) AS (SELECT ROW_NUMBER() OVER(ORDER BY X.n)
	FROM N3 AS X, N3 AS Y)
 
	SELECT	@RETURN_STRING=ISNULL(@RETURN_STRING,'')
			+ SUBSTRING(@String,Nums.n,1)
	FROM N4 Nums
	WHERE Nums.n	<= LEN(@String)
	AND ASCII(SUBSTRING(@String,Nums.n,1)) BETWEEN 97 AND 122
 
	RETURN @RETURN_STRING
END
GO

CREATE OR ALTER PROCEDURE usp_20261108T1806DaigakuHonyakuCenter_DHC_IsJapaneseNameInUpperCase
AS
BEGIN
	/*
		Author:			Kehinde Adewumi Adeniji
		Create date:	2026-11-08T18:06:00
		Description:	Is in uppercase?
		url:			http://raresql.com/2013/11/01/sql-server-how-to-find-a-row-that-contains-a-lower-case-letter
	*/

	print GETDATE()

	CREATE SEQUENCE MyTableVarCounter
    AS INT
    START WITH 1
    INCREMENT BY 1

	DECLARE @MyTableVar TABLE 
	(
		SequenceOrderID	INT	DEFAULT (NEXT VALUE FOR MyTableVarCounter) PRIMARY KEY CLUSTERED, 
		Named			VARCHAR(50)
	)

	INSERT INTO @MyTableVar VALUES ('RARESQL.COM')
	INSERT INTO @MyTableVar VALUES ('RaReSql.com')
	INSERT INTO @MyTableVar VALUES ('Raresql')
	INSERT INTO @MyTableVar VALUES ('raresql.com')

	/*
	PRINT	'Table dump'
	SELECT	*	
	FROM	@MyTableVar

	PRINT	'SOLUTION 1 : Using UPPER (String) Function'
	SELECT	* 
	FROM	@MyTableVar
	WHERE	UPPER(Named) COLLATE Latin1_General_CS_AS != Named

	PRINT	'SOLUTION 2 : Using PATINDEX (String) Function'
	SELECT	* 
	FROM	@MyTableVar
	WHERE	PATINDEX('%[a-z]%', Named COLLATE Latin1_General_CS_AS) > 0
	*/

	PRINT	'SOLUTION 3 : Using ASCII(String) Function'
	SELECT	*,
			dbo.udf_20261108T1806DaigakuHonyakuCenter_DHC_Extract_small_letters_From_String(Named) AS LowerCaseLetters
	FROM 
			@MyTableVar

END
GO

--EXEC usp_20261108T1806DaigakuHonyakuCenter_DHC_IsJapaneseNameInUpperCase
GO
