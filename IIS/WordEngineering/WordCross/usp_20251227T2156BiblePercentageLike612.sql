CREATE OR ALTER PROCEDURE usp_20251227T2156BiblePercentageLike612
(
	@dynvalue    NVARCHAR(MAX)   = '%612'
)
AS
	--Created	2025-12-27T21:56:00	http://csharpdeveloper.wordpress.com/2019/08/18/sql-servers-sp_executesql-does-not-protect-you-from-sql-injection
    SET NOCOUNT ON
    DECLARE @sql nvarchar(MAX)
    SET @sql =  N'SELECT KingJamesVersion, ScriptureReference, ChapterIDSequence, VerseIDSequence, ChapterIDSequencePercent, VerseIDSequencePercent' +
                +   ' FROM Bible..Scripture_View'
                +   ' WHERE ScriptureReference LIKE @p1'
                +   ' OR ChapterIDSequence LIKE @p1'
                +   ' OR VerseIDSequence LIKE @p1'
                +   ' OR ChapterIDSequencePercent LIKE @p1'
                +   ' OR VerseIDSequencePercent LIKE @p1'
                +   ' ORDER By VerseIDSequence';
    EXEC sp_executesql @sql, N'@p1 nvarchar(MAX)', @dynvalue
GO
