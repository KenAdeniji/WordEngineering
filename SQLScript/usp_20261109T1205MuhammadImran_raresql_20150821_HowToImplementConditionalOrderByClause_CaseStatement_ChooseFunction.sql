CREATE OR ALTER PROCEDURE usp_20261109T1205MuhammadImran_raresql_20150821_HowToImplementConditionalOrderByClause_CaseStatement_ChooseFunction
	 @sortColumnName SYSNAME	=	'BookID'
AS
BEGIN
	/*
		Author:			Kehinde Adewumi Adeniji
		Create date:	2026-11-09T12:05:00
		Description:	SQL SERVER – How to implement conditional order by clause
						2015-08-21 by Muhammad Imran
		url:			http://raresql.com/2015/08/21/sql-server-how-to-implement-conditional-order-by-clause
						http://stackoverflow.com/questions/5720212/what-is-sysname-data-type-in-sql-server
						http://github.com/KenAdeniji/WordEngineering/blob/main/SQLScript/usp_20261109T1205MuhammadImran_raresql_20150821_HowToImplementConditionalOrderByClause_CaseStatement_ChooseFunction.sql
		Filename:		D:\WordEngineering\SQLScript\usp_20261109T1205MuhammadImran_raresql_20150821_HowToImplementConditionalOrderByClause_CaseStatement_ChooseFunction.sql
	*/
	DECLARE @SortColumnNumber AS INT
 
	SET @SortColumnNumber	=	CASE
		WHEN	@sortColumnName	=	'BookID'		THEN	0
		WHEN	@sortColumnName	=	'BookTitle'		THEN	1
		WHEN	@sortColumnName	=	'Chapters'		THEN	2
		WHEN	@sortColumnName	=	'Actor'			THEN	3
		WHEN	@sortColumnName	=	'Author'		THEN	4
		WHEN	@sortColumnName	=	'Category'		THEN	5
		WHEN	@sortColumnName	=	'TimeSpan'		THEN	6
		ELSE	0
	END
	
	-- By Default, it will sort on first column
	SELECT	*
	FROM
		Bible..BibleBook
	ORDER BY
		CHOOSE
		(
			@SortColumnNumber,
			BookID,
			BookTitle,
			Chapters,
			Actor,
			Author,
			Category,
			Timespan
		)	ASC

END
GO

EXEC	usp_20261109T1205MuhammadImran_raresql_20150821_HowToImplementConditionalOrderByClause_CaseStatement_ChooseFunction
		@sortColumnName = 'author'
GO