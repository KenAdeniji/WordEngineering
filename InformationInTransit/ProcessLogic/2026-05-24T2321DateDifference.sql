CREATE OR ALTER FUNCTION dbo.udf_BiblicalCalendar(@datedFrom DateTime2, @datedUntil DateTime2)
RETURNS NVARCHAR(MAX)
AS
BEGIN
    --2026-05-24T23:21:00
    DECLARE @dateDifference INT = DATEDIFF(day, @datedFrom, @datedUntil)
    DECLARE @years INT = @dateDifference / 360;
    DECLARE @months INT = (@dateDifference % 360) / 30;
    DECLARE @days INT = (@dateDifference % 360) % 30;

    DECLARE @result NVARCHAR(MAX) = '';

    IF @years > 0 
    BEGIN
        SET @result += CONVERT(NVARCHAR(MAX), @years) + ' biblical year(s)'
    END

    IF @months > 0
    BEGIN
        IF (@result != '')
        BEGIN
            SET @result += ', '
        END
        SET @result += CONVERT(NVARCHAR(MAX), @months) + ' biblical month(s)'
    END

    IF @days > 0
    BEGIN
        IF (@result != '')
        BEGIN
            SET @result += ', '
        END
        SET @result += CONVERT(NVARCHAR(MAX), @days) + ' biblical days(s)'
    END

    RETURN @result;
END;
GO

SELECT dbo.udf_BiblicalCalendar('2007-05-19', '2026-05-24')
GO

CREATE OR ALTER FUNCTION dbo.udf_DateDifferenceGregorianCalendar
(
    @datedFrom DateTime2,
    @datedUntil DateTime2
)
RETURNS NVARCHAR(MAX)
AS
BEGIN
/*
    --2026-05-24T23:21:00
    --http://stackoverflow.com/questions/11208715/how-to-calculate-datediff-between-two-date-in-year-month-days
    DECLARE @date datetime, @tmpdate datetime, @years int, @months int, @days int
    SELECT @date = '2/29/04'

    SELECT @tmpdate = @date

    SELECT @years = DATEDIFF(yy, @tmpdate, GETDATE()) - CASE WHEN (MONTH(@date) > MONTH(GETDATE())) OR (MONTH(@date) = MONTH(GETDATE()) AND DAY(@date) > DAY(GETDATE())) THEN 1 ELSE 0 END
    SELECT @tmpdate = DATEADD(yy, @years, @tmpdate)
    SELECT @months = DATEDIFF(m, @tmpdate, GETDATE()) - CASE WHEN DAY(@date) > DAY(GETDATE()) THEN 1 ELSE 0 END
    SELECT @tmpdate = DATEADD(m, @months, @tmpdate)
    SELECT @days = DATEDIFF(d, @tmpdate, GETDATE())

    SELECT @years, @months, @days
*/
    DECLARE @datedStub  DATETIME2, @years int, @months int, @weeksDays int, @weeks int, @days int, @resultInterval NVARCHAR(MAX)
    SET @datedStub = @datedFrom
    SET @resultInterval = ''

    SELECT @years = DATEDIFF("year", @datedStub, @datedUntil) - CASE WHEN (MONTH(@datedFrom) > MONTH(@datedUntil)) OR (MONTH(@datedFrom) = MONTH(@datedUntil) AND DAY(@datedFrom) > DAY(@datedUntil)) THEN 1 ELSE 0 END
    SELECT @datedStub = DATEADD("year", @years, @datedStub)
    SELECT @months = DATEDIFF("month", @datedStub, @datedUntil) - CASE WHEN DAY(@datedFrom) > DAY(@datedUntil) THEN 1 ELSE 0 END
    SELECT @datedStub = DATEADD("month", @months, @datedStub)
    SELECT @weeksDays = DATEDIFF("day", @datedStub, @datedUntil)

    IF (@years > 0) SET @resultInterval += CONVERT(NVARCHAR(MAX), @years) + ' Year(s)'

    IF (@months > 0) 
    BEGIN
        IF @resultInterval != '' SET @resultInterval += ', '
        SET @resultInterval += CONVERT(NVARCHAR(MAX), @months) + ' Month(s)'
    END

    IF (@weeksDays > 0) 
    BEGIN
        SET @days = @weeksDays % 7
        SET @weeks = @weeksDays / 7
    END

    IF (@weeks > 0) 
    BEGIN
        IF @resultInterval != '' SET @resultInterval += ', '
        SET @resultInterval += CONVERT(NVARCHAR(MAX), @weeks) + ' Week(s)'
    END

    IF (@days > 0) 
    BEGIN
        IF @resultInterval != '' SET @resultInterval += ', '
        SET @resultInterval += CONVERT(NVARCHAR(MAX), @days) + ' Day(s)'
    END

    RETURN @resultInterval
END
GO

SELECT dbo.udf_DateDifferenceGregorianCalendar('2007-05-19', '2026-05-24')
GO

CREATE OR ALTER VIEW [dbo].[Remember_view]
AS
SELECT
/*
    --2026-05-24T23:21:00
    --http://stackoverflow.com/questions/11208715/how-to-calculate-datediff-between-two-date-in-year-month-days
*/
	*,
    dbo.udf_BiblicalCalendar(DatedFrom, DatedUntil) DatedFromUntil_BiblicalCalendar,
	dbo.udf_DateDifferenceGregorianCalendar(DatedFrom, DatedUntil) DatedFromUntil_GregorianCalendar
FROM Remember
GO
