EXEC sp_configure 'allow updates', 0
RECONFIGURE

sp_configure 'show advanced options', 1;
GO
RECONFIGURE WITH OVERRIDE;
GO

sp_configure 'clr enabled', 1;
GO
RECONFIGURE WITH OVERRIDE;
GO

DROP FUNCTION [dbo].[YearMonthWeekDay]
GO

DROP ASSEMBLY DateDifference
GO

CREATE ASSEMBLY DateDifference
FROM 'E:\WordEngineering\InformationInTransit\ProcessLogic\DateDifference.dll'
WITH PERMISSION_SET = SAFE
GO

CREATE FUNCTION [dbo].[FromUntil] (@datedFrom DateTime2, @datedUntil DateTime2)
RETURNS int
AS EXTERNAL NAME [DateDifference].[DateDifference].[FromUntil];
GO

SELECT dbo.Fromuntil('20 March 2003', '15 December 2011')
GO

CREATE FUNCTION [dbo].[YearMonthWeekDay] (@dateFrom DateTime2, @dateTo DateTime2)
RETURNS NVARCHAR(50)
AS EXTERNAL NAME [DateDifference].[DateDifference].[YearMonthWeekDay];
GO

SELECT dbo.YearMonthWeekDay('20 March 2003', '15 December 2011')
GO

CREATE FUNCTION [dbo].[YearMonthWeekDay] (@dateFrom DateTime2, @dateTo DateTime2)
RETURNS NVARCHAR(50)
AS EXTERNAL NAME [DateDifference].[DateDifference].[YearMonthWeekDay];
GO

SELECT dbo.YearMonthWeekDay('20 March 2003', '15 December 2011')
GO

