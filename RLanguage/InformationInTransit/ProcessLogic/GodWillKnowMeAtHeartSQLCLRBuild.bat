REM csc GodWillKnowMeAtHeartSQLCLR.cs /reference:..\Bin\Debug\InformationInTransit.dll
"C:\WINDOWS\Microsoft.NET\Framework\v3.5\csc.exe" /main:InformationInTransit.ProcessLogic.GodWillKnowMeAtHeart /reference:mscorlib.dll,System.Core.dll GodWillKnowMeAtHeartSQLCLR.cs ..\DataAccess\DataCommand.cs 
"C:\WINDOWS\Microsoft.NET\Framework\v3.5\csc.exe" /target:library /reference:C:\Windows\Microsoft.NET\Framework\v2.0.50727\mscorlib.dll,C:\Windows\Microsoft.NET\Framework\v2.0.50727\System.Data.dll GodWillKnowMeAtHeartSQLCLR.cs ..\DataAccess\DataCommand.cs 

REM Loading and Running the "E:\WordEngineering\InformationInTransit\ProcessLogic\GodWillKnowMeAtHeartSQLCLR.dll" Stored Procedure in SQL Server
CREATE ASSEMBLY GodWillKnowMeAtHeartSQLCLR from 'E:\WordEngineering\InformationInTransit\ProcessLogic\GodWillKnowMeAtHeartSQLCLR.dll' WITH PERMISSION_SET = SAFE
GO

CREATE FUNCTION GodWillKnowMeAtHeart(@verseText nvarchar(MAX))
RETURNS nvarchar(MAX)
AS EXTERNAL NAME GodWillKnowMeAtHeartSQLCLR.[InformationInTransit.ProcessLogic.GodWillKnowMeAtHeart].Query
GO

REM Test
SELECT dbo.GodWillKnowMeAtHeart('God will know me, at heart.')
GO

REM Removing the "GodWillKnowMeAtHeart" Function Sample
DROP Function GodWillKnowMeAtHeart
GO

DROP assembly GodWillKnowMeAtHeartSQLCLR
GO
