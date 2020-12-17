REM csc LifeIsASpectatorIfYouObserveItThatWaySQLCLR.cs /reference:..\Bin\Debug\InformationInTransit.dll
"C:\WINDOWS\Microsoft.NET\Framework\v3.5\csc.exe" /main:InformationInTransit.ProcessLogic.LifeIsASpectatorIfYouObserveItThatWay /reference:mscorlib.dll,System.Core.dll LifeIsASpectatorIfYouObserveItThatWaySQLCLR.cs AlphabetSequence.cs       ..\DataAccess\DataCommand.cs 
"C:\WINDOWS\Microsoft.NET\Framework\v3.5\csc.exe" /target:library /reference:C:\Windows\Microsoft.NET\Framework\v2.0.50727\mscorlib.dll,C:\Windows\Microsoft.NET\Framework\v2.0.50727\System.Data.dll LifeIsASpectatorIfYouObserveItThatWaySQLCLR.cs AlphabetSequence.cs ..\DataAccess\DataCommand.cs 

REM Loading and Running the "E:\WordEngineering\InformationInTransit\ProcessLogic\LifeIsASpectatorIfYouObserveItThatWaySQLCLR.dll" Function in SQL Server
CREATE ASSEMBLY LifeIsASpectatorIfYouObserveItThatWaySQLCLR from 'E:\WordEngineering\InformationInTransit\ProcessLogic\LifeIsASpectatorIfYouObserveItThatWaySQLCLR.dll' WITH PERMISSION_SET = SAFE
GO

CREATE FUNCTION LifeIsASpectatorIfYouObserveItThatWay(@verseText nvarchar(MAX))
RETURNS nvarchar(MAX)
AS EXTERNAL NAME LifeIsASpectatorIfYouObserveItThatWaySQLCLR.[InformationInTransit.ProcessLogic.LifeIsASpectatorIfYouObserveItThatWay].Query
GO

REM Test
SELECT dbo.LifeIsASpectatorIfYouObserveItThatWay('Life is a spectator, if you observe it that way.')
GO

REM Removing the "LifeIsASpectatorIfYouObserveItThatWay" Function Sample
DROP Function LifeIsASpectatorIfYouObserveItThatWay
GO

DROP assembly LifeIsASpectatorIfYouObserveItThatWaySQLCLR
GO

REM ([dbo].[LifeIsASpectatorIfYouObserveItThatWay]([Word]))