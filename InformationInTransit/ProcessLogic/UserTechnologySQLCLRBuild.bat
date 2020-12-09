REM csc UserTechnologySQLCLR.cs /reference:..\Bin\Debug\InformationInTransit.dll
"C:\WINDOWS\Microsoft.NET\Framework\v3.5\csc.exe" /target:library /reference:C:\Windows\Microsoft.NET\Framework\v2.0.50727\mscorlib.dll,C:\Windows\Microsoft.NET\Framework\v2.0.50727\System.Data.dll UserTechnologySQLCLR.cs

REM Loading and Running the "E:\WordEngineering\InformationInTransit\ProcessLogic\UserTechnologySQLCLR.dll" Stored Procedure in SQL Server
CREATE ASSEMBLY UserTechnologySQLCLR from 'E:\WordEngineering\InformationInTransit\ProcessLogic\UserTechnologySQLCLR.dll' WITH PERMISSION_SET = SAFE
GO

CREATE FUNCTION UserTechnology(@verseText nvarchar(MAX))
RETURNS nvarchar(MAX)
AS EXTERNAL NAME UserTechnologySQLCLR.[InformationInTransit.ProcessLogic.UserTechnology].Query
GO

REM Test
SELECT dbo.UserTechnology('God will know me, at heart.')
GO

REM Removing the "UserTechnology" Function Sample
DROP Function UserTechnology
GO

DROP assembly UserTechnologySQLCLR
GO
