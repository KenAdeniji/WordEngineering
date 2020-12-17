REM csc UnLikeSQLCLR.cs /reference:..\Bin\Debug\InformationInTransit.dll
"C:\WINDOWS\Microsoft.NET\Framework\v3.5\csc.exe" /main:InformationInTransit.ProcessLogic.UnLike /reference:mscorlib.dll,System.Core.dll UnLike.cs ..\DataAccess\DataCommand.cs 
"C:\WINDOWS\Microsoft.NET\Framework\v3.5\csc.exe" /target:library /reference:C:\Windows\Microsoft.NET\Framework\v2.0.50727\mscorlib.dll,C:\Windows\Microsoft.NET\Framework\v2.0.50727\System.Data.dll UnLike.cs ..\DataAccess\DataCommand.cs 

REM Loading and Running the "E:\WordEngineering\InformationInTransit\ProcessLogic\UnLike.dll" Stored Procedure in SQL Server
CREATE ASSEMBLY UnLike from 'E:\WordEngineering\InformationInTransit\ProcessLogic\UnLike.dll' WITH PERMISSION_SET = SAFE
GO

CREATE FUNCTION UnLike(@wordSaid nvarchar(MAX))
RETURNS nvarchar(MAX)
AS EXTERNAL NAME UnLike.[InformationInTransit.ProcessLogic.UnLike].Query
GO

REM Test
SELECT dbo.UnLike('God will know me, at heart.')
GO

REM Removing the "UnLike" Function Sample
DROP Function UnLike
GO

DROP assembly UnLike
GO
