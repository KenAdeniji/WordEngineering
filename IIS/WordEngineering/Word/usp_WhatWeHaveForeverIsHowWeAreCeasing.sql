USE [WordEngineering]
GO
/****** Object:  StoredProcedure [dbo].[usp_WhatWeHaveForeverIsHowWeAreCeasing]    Script Date: 2/28/2025 5:14:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE OR ALTER PROCEDURE [dbo].[usp_WhatWeHaveForeverIsHowWeAreCeasing]
	@query  AS NVARCHAR(4000)	=	NULL
    , @debug bit = 0
AS
BEGIN
/*
	2015-01-04	blogs.msdn.com/b/raulga/archive/2007/01/04/dynamic-sql-sql-injection.aspx
    2025-02-26  File created.
	2017-08-28	docs.microsoft.com/en-us/sql/t-sql/functions/isdate-transact-sql
	2017-08-29	blogs.sentryone.com/aaronbertrand/bad-habits-revival/#index
*/
/*
    EXEC usp_WhatWeHaveForeverIsHowWeAreCeasing
              @query = '165461'
            , @debug = 1
*/
    SET NOCOUNT ON

	DECLARE @sqlSelectStatement NVARCHAR(4000)
	DECLARE @CRLF nvarchar(10) = char(13) + char(10)

    DECLARE @isNumeric BIT = ISNUMERIC(@query)
    DECLARE @queryNumber INT = NULL
    IF (@isNumeric = 1)
    BEGIN
        SET @queryNumber = CONVERT( INT, @query )
    END

	DECLARE @isDateTime BIT = ISDATE(@query)
	DECLARE @queryDateTime DateTime = NULL
    IF (@isDateTime = 1)
    BEGIN
        SET @queryDateTime = CONVERT( DateTime, @query )
    END

	if @query is not null
	begin
		set @query = '%' + @query + '%'
	end
	
    SET @sqlSelectStatement =	'SELECT * ' +
								' FROM WordEngineering..HisWord ' +
								' WHERE '

	+   ' (Word like case '
	+   ' when @query is null then Word '
	+   ' else @query  '
	+	' end  ' 
	+	' ) '
	+   @CRLF

    +   ' OR (Commentary like case '
	+   ' when @query is null then Commentary '
	+   ' else @query  '
	+	' end  ' 
	+	' ) '
	+   @CRLF

    +   ' OR (Uri like case '
	+   ' when @query is null then Uri '
	+   ' else @query  '
	+	' end  ' 
	+	' ) '
	+   @CRLF

    +   ' OR (ScriptureReference like case '
	+   ' when @query is null then ScriptureReference '
	+   ' else @query  '
	+	' end  ' 
	+	' ) '
	+   @CRLF

    +   ' OR (FileName like case '
	+   ' when @query is null then FileName '
	+   ' else @query  '
	+	' end  ' 
	+	' ) '
	+   @CRLF

    +   ' OR (EnglishTranslation like case '
	+   ' when @query is null then EnglishTranslation '
	+   ' else @query  '
	+	' end  ' 
	+	' ) '
	+   @CRLF

    +   ' OR (Location like case '
	+   ' when @query is null then Location '
	+   ' else @query  '
	+	' end  ' 
	+	' ) '
	+   @CRLF

    +   ' OR (Scene like case '
	+   ' when @query is null then Scene '
	+   ' else @query  '
	+	' end  ' 
	+	' ) '
	+   @CRLF

    +   ' OR (PseudoCode like case '
	+   ' when @query is null then PseudoCode '
	+   ' else @query  '
	+	' end  ' 
	+	' ) '
	+   @CRLF

    +   ' OR (Actor like case '
	+   ' when @query is null then Actor '
	+   ' else @query  '
	+	' end  ' 
	+	' ) '
	+   @CRLF

    +   ' OR (RegularExpression like case '
	+   ' when @query is null then RegularExpression '
	+   ' else @query  '
	+	' end  ' 
	+	' ) '
	+   @CRLF

    IF (@isNumeric = 1)
    BEGIN
    SET @sqlSelectStatement += 
       ' OR (HiswordID = ' + CONVERT(VARCHAR, @queryNumber) + ') '
	+   @CRLF
    END

    IF (@queryDateTime IS NOT NULL)
    BEGIN
    SET @sqlSelectStatement += 
       ' OR (CONVERT(DATE, Dated) = ' + '''' + CONVERT(VARCHAR, @queryDateTime) + ''') '
	+   @CRLF
    END

	SET @sqlSelectStatement += ' ORDER BY HisWordID DESC '

    DECLARE @parmDefinition nvarchar(4000)
    SET @parmDefinition = '@query nvarchar(4000)'

    IF ( @debug = 1)
    BEGIN
        PRINT @sqlSelectStatement
    END

	EXEC sp_executesql 
			  @sqlSelectStatement
			, @parmDefinition
			, @query = @query

END
