/*
--	2019-04-10	https://stackoverflow.com/questions/12389656/the-database-owner-sid-recorded-in-the-master-database-differs-from-the-database
DECLARE @Command NVARCHAR(MAX) 
SET @Command = N'ALTER AUTHORIZATION ON DATABASE::<<DatabaseName>> TO <<LoginName>>' 
SELECT @Command = REPLACE 
                  ( 
                      REPLACE(@Command, N'<<DatabaseName>>', QUOTENAME(SD.Name)) 
                      , N'<<LoginName>>' 
                      ,
                      QUOTENAME
                      (
                          COALESCE
                          (
                               SL.name 
                              ,(SELECT TOP 1 name FROM sys.server_principals WHERE type_desc = 'SQL_LOGIN' AND is_disabled = 'false' ORDER BY principal_id ASC )
                          )
                      )
                  ) 
FROM sys.databases AS SD
LEFT JOIN sys.server_principals  AS SL 
    ON SL.SID = SD.owner_sid 


WHERE SD.Name = DB_NAME() 

PRINT @command 
EXECUTE(@command) 
GO
*/

/*
ALTER DATABASE WordEngineering
	SET TRUSTWORTHY ON
GO
*/

/*
REM Batch file. Command line.
csc.exe ReadFileHelper.cs
csc.exe /target:library ReadFileHelper.cs
*/

DROP PROCEDURE dbo.usp_FileReader
GO

DROP ASSEMBLY ReadFileHelper
GO

CREATE ASSEMBLY ReadFileHelper
FROM 'E:\WordEngineering\InformationInTransit\ProcessCode\ReadFileHelper.dll'
WITH PERMISSION_SET = EXTERNAL_ACCESS
GO

CREATE PROCEDURE dbo.usp_FileReader(@FileName nvarchar(1024))
AS EXTERNAL NAME ReadFileHelper.ReadFileHelper.ReadFile
GO

EXEC dbo.usp_FileReader
	@FileName = "E:\WordEngineering\InformationInTransit\ProcessCode\ReadFileHelper.cs"
GO
