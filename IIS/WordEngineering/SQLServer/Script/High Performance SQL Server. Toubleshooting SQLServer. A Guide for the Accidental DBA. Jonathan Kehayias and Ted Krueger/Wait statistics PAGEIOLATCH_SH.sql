SELECT * FROM sys.dm_os_wait_stats ORDER BY Wait_Type 
GO

SELECT * FROM sys.dm_os_wait_stats
WHERE wait_type IN
(
	'PAGEIOLATCH_SH'
)
ORDER BY Wait_Type
GO

--http://stackoverflow.com/questions/620626/what-is-pageiolatch-sh-wait-type-in-sql-server

/*
Occurs when a task is waiting on a latch for a buffer that is in an I/O request.
The latch request is in Shared mode. Long waits may indicate problems with the disk subsystem.
*/

/*
n practice, this almost always happens due to large scans over big tables. It almost never happens in queries that use indexes efficiently.

If your query is like this:

Select * from <table> where <col1> = <value> order by <PrimaryKey>

, check that you have a composite index on (col1, col_primary_key).

If you don't have one, then you'll need either a full INDEX SCAN if the PRIMARY KEY is chosen, or a SORT if an index on col1 is chosen.

Both of them are very disk I/O consuming operations on large tables.
*/

SELECT        *
FROM            sys.dm_io_virtual_file_stats(NULL, NULL) AS dm_io_virtual_file_stats_1
GO

SELECT        *
FROM            sys.dm_io_virtual_file_stats(DB_ID(N'WordEngineering'), NULL) AS dm_io_virtual_file_stats_1
GO

SELECT        *
FROM            sys.dm_io_virtual_file_stats(DB_ID(N'Bible'), NULL) AS dm_io_virtual_file_stats_1
GO

SELECT  
	sysdatabases.name AS DatabaseName,
	sysfiles.filename AS FileName,
	dm_io_virtual_file_stats_1.*
FROM
	sys.dm_io_virtual_file_stats(NULL, NULL) AS dm_io_virtual_file_stats_1
	JOIN master..sysdatabases on sysdatabases.dbid = dm_io_virtual_file_stats_1.database_id
	JOIN master..sysfiles on sysfiles.fileid = dm_io_virtual_file_stats_1.file_id
GO
