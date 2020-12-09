using System;
using System.Data;
using System.Data.SqlTypes;
using System.IO;
using Microsoft.SqlServer.Server;

/*
2019-04-10	Created.	apress.com/us/book/9781590599808?token=cyberweek18&utm_campaign=3_fjp8312_Apress_US_PLA_cyberweek18#otherversion=9781430206255
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

ALTER DATABASE WordEngineering
SET TRUSTWORTHY ON
*/

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
*/

//namespace InformationInTransit.ProcessCode
//{
	public partial class ReadFileHelper
	{
		public static void Main(string[] argv)
		{
			ReadFile(argv[0]);
		}
		
		public static void ReadFile(String filename)
		{
			StreamReader	streamReader = new StreamReader(filename);
			String			line;
			SqlPipe			sqlPipe = SqlContext.Pipe;
			
			do
			{
				line = streamReader.ReadLine();
				if (line == null)
				{
					break;
				}
				sqlPipe.Send(line);
			} 
			while (true);
			streamReader.Close();
		}	
	}	
//}
