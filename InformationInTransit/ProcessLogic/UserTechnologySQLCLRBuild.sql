--"C:\WINDOWS\Microsoft.NET\Framework\v3.5\csc.exe" /target:library /reference:C:\Windows\Microsoft.NET\Framework\v2.0.50727\mscorlib.dll,C:\Windows\Microsoft.NET\Framework\v2.0.50727\System.Data.dll UserTechnologySQLCLR.cs

DROP FUNCTION FindMatchingDates
GO

DROP ASSEMBLY UserTechnologySQLCLR
GO

CREATE ASSEMBLY UserTechnologySQLCLR from 'E:\WordEngineering\InformationInTransit\ProcessLogic\UserTechnologySQLCLR.dll' WITH PERMISSION_SET = SAFE --EXTERNAL_ACCESS
GO

CREATE FUNCTION FindMatchingDates(@datedUntil DateTime)
RETURNS TABLE 
(
	UserTechnologyID	int,
	Dated				DateTime,
	Occasion			nvarchar(255),
	ContactID			int,
	URI					nvarchar(255),
	DebugInfo			nvarchar(255)
)
AS EXTERNAL NAME UserTechnologySQLCLR.[InformationInTransit.ProcessLogic.UserTechnology].FindMatchingDates
GO

SELECT * FROM FindMatchingDates('2016-02-14')
GO

SELECT * FROM FindMatchingDates('2016-06-01')
GO

SELECT * FROM FindMatchingDates('2016-03-20')
GO
