CREATE OR ALTER PROCEDURE usp_20261108T2214MuhammadImran_raresql_20221208DateTrunc_HowToGetPreviousCurrentLastWeekDates
AS
BEGIN
	/*
		Author:			Kehinde Adewumi Adeniji
		Create date:	2026-11-08T22:14:00
		Description:	SQL Server 2022 – TSQL – How to get previous, current and last week dates using DATETRUNC() function
						2022-12-08 by Muhammad Imran
		url:			http://raresql.com/2022/12/08/sql-server-2022-tsql-how-to-get-previous-current-and-last-week-dates-using-datetrunc-function
	*/

	--In order to set the first day of the week as Monday, we need to run the below script.
	SET DATEFIRST 1

	DECLARE @dated datetime2 = GETDATE();
	SELECT 'Year', DATETRUNC(year, @dated);
	SELECT 'Quarter', DATETRUNC(quarter, @dated);
	SELECT 'Month', DATETRUNC(month, @dated);
	SELECT 'Week', DATETRUNC(week, @dated); -- Using the default DATEFIRST setting value of 7 (U.S. English)
	SELECT 'Iso_week', DATETRUNC(iso_week, @dated);
	SELECT 'DayOfYear', DATETRUNC(dayofyear, @dated);
	SELECT 'Day', DATETRUNC(day, @dated);
	SELECT 'Hour', DATETRUNC(hour, @dated);
	SELECT 'Minute', DATETRUNC(minute, @dated);
	SELECT 'Second', DATETRUNC(second, @dated);
	SELECT 'Millisecond', DATETRUNC(millisecond, @dated);
	SELECT 'Microsecond', DATETRUNC(microsecond, @dated);

	SELECT
		@dated	AS	Dated,
		DATEADD
		(
			WEEK,
			-1,
			DATETRUNC
			(
				WEEK,
				@dated
			)
		)   AS FirstDateOfThePreviousWeek,
		DATEADD
		(
			DAY, 
			-1,
			 DATEADD
			 (
				WEEK,
				0, 
				DATETRUNC
				(
					WEEK, 
					@dated
				)
			)
		)  AS LastDateOfThePreviousWeek,
		DATETRUNC(WEEK, @dated) AS FirstDateOfTheCurrentWeek
END
GO

EXEC	usp_20261108T2214MuhammadImran_raresql_20221208DateTrunc_HowToGetPreviousCurrentLastWeekDates
GO
