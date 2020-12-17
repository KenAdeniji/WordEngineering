"C:\WINDOWS\Microsoft.NET\Framework\v3.5\csc.exe" DateDifference.cs
"C:\WINDOWS\Microsoft.NET\Framework\v3.5\csc.exe" /target:library DateDifference.cs 

REM Loading and Running the "E:\WordEngineering\InformationInTransit\ProcessLogic\DateDifferenceSQLCLR.dll" Function in SQL Server
CREATE ASSEMBLY DateDifference from 'E:\WordEngineering\InformationInTransit\ProcessLogic\DateDifference.dll' WITH PERMISSION_SET = SAFE
GO

CREATE FUNCTION YearMonthWeekDay(@dateFrom DateTime, @dateTo DateTime)
RETURNS NVARCHAR(MAX)
AS EXTERNAL NAME DateDifference.[DateDifference].YearMonthWeekDay
GO

REM Test
SELECT dbo.DateDifference('2014-12-09', '2015-12-09')
GO

REM Removing the " YearMonthWeekDay" Function Sample
DROP Function  YearMonthWeekDay
GO

DROP assembly DateDifference
GO

