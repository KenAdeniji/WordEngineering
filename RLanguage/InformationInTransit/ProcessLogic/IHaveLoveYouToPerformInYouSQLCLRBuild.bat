REM csc IHaveLoveYouToPerformInYouSQLCLR.cs /reference:..\Bin\Debug\InformationInTransit.dll
"C:\WINDOWS\Microsoft.NET\Framework\v3.5\csc.exe" /main:InformationInTransit.ProcessLogic.IHaveLoveYouToPerformInYou /reference:mscorlib.dll,System.Core.dll IHaveLoveYouToPerformInYouSQLCLR.cs
"C:\WINDOWS\Microsoft.NET\Framework\v3.5\csc.exe" /target:library /reference:C:\Windows\Microsoft.NET\Framework\v2.0.50727\mscorlib.dll,C:\Windows\Microsoft.NET\Framework\v2.0.50727\System.Data.dll IHaveLoveYouToPerformInYouSQLCLR.cs 

REM Loading and Running the "E:\WordEngineering\InformationInTransit\ProcessLogic\IHaveLoveYouToPerformInYouSQLCLR.dll" Function in SQL Server
CREATE ASSEMBLY IHaveLoveYouToPerformInYouSQLCLR from 'E:\WordEngineering\InformationInTransit\ProcessLogic\IHaveLoveYouToPerformInYouSQLCLR.dll' WITH PERMISSION_SET = SAFE
GO

CREATE FUNCTION IHaveLoveYouToPerformInYou(@dated DateTime)
RETURNS NVARCHAR(MAX)
AS EXTERNAL NAME IHaveLoveYouToPerformInYouSQLCLR.[InformationInTransit.ProcessLogic.IHaveLoveYouToPerformInYou].Query
GO

REM Test
SELECT dbo.IHaveLoveYouToPerformInYou('Life is a spectator, if you observe it that way.')
GO

REM Removing the "IHaveLoveYouToPerformInYou" Function Sample
DROP Function IHaveLoveYouToPerformInYou
GO

DROP assembly IHaveLoveYouToPerformInYouSQLCLR
GO

REM ([dbo].[IHaveLoveYouToPerformInYou]([Dated]))