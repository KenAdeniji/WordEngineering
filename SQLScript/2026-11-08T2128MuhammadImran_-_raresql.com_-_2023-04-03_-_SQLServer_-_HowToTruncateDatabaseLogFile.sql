/*
	http://raresql.com/2023/04/03/sql-server-how-to-truncate-database-log-file
	http://github.com/KenAdeniji/WordEngineering/blob/main/SQLScript/2026-11-08T2128MuhammadImran_-_raresql.com_-_2023-04-03_-_SQLServer_-_HowToTruncateDatabaseLogFile.sql
	SQL Server – How to truncate database log file
	2023-04-03 by Muhammad Imran 
	D:\WordEngineering\SQLScript\2026-11-08T2128MuhammadImran_-_raresql.com_-_2023-04-03_-_SQLServer_-_HowToTruncateDatabaseLogFile.sql
*/
USE WordEngineering
GO
 
--Let's change recovery model to simple
ALTER DATABASE WordEngineering 
SET RECOVERY SIMPLE
GO
 
--Let's shrink the database log file
DBCC SHRINKFILE (WordEngineering_Log, 1, TRUNCATEONLY)
GO
 
--Let's change recovery model to full
/*
ALTER DATABASE WordEngineering 
SET RECOVERY FULL
GO
*/
