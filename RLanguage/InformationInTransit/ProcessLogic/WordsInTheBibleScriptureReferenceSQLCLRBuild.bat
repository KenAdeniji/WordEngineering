REM csc WordsInTheBibleScriptureReferenceSQLCLR.cs /reference:..\Bin\Debug\InformationInTransit.dll
"C:\WINDOWS\Microsoft.NET\Framework\v3.5\csc.exe" /main:InformationInTransit.ProcessLogic.WordsInTheBibleScriptureReference /reference:mscorlib.dll,System.Core.dll WordsInTheBibleScriptureReferenceSQLCLR.cs ..\DataAccess\DataCommand.cs 
"C:\WINDOWS\Microsoft.NET\Framework\v3.5\csc.exe" /target:library /reference:C:\Windows\Microsoft.NET\Framework\v2.0.50727\mscorlib.dll,C:\Windows\Microsoft.NET\Framework\v2.0.50727\System.Data.dll WordsInTheBibleScriptureReferenceSQLCLR.cs ..\DataAccess\DataCommand.cs 

REM Loading and Running the "E:\WordEngineering\InformationInTransit\ProcessLogic\WordsInTheBibleScriptureReferenceSQLCLR.dll" Function in SQL Server
CREATE ASSEMBLY WordsInTheBibleScriptureReferenceSQLCLR from 'E:\WordEngineering\InformationInTransit\ProcessLogic\WordsInTheBibleScriptureReferenceSQLCLR.dll' WITH PERMISSION_SET = SAFE
GO

CREATE FUNCTION udf_WordsInTheBibleScriptureReference
(
	@words nvarchar(MAX),
	@logic nvarchar(MAX)	
)
RETURNS nvarchar(MAX)
AS EXTERNAL NAME WordsInTheBibleScriptureReferenceSQLCLR.[InformationInTransit.ProcessLogic.WordsInTheBibleScriptureReference].Query
GO

REM Test
SELECT dbo.WordsInTheBibleScriptureReference('In the beginning', 'Phrase')
GO

REM Removing the "WordsInTheBibleScriptureReference" Function Sample
DROP Function WordsInTheBibleScriptureReference
GO

DROP assembly WordsInTheBibleScriptureReferenceSQLCLR
GO

REM ([dbo].[WordsInTheBibleScriptureReference]([Word]))