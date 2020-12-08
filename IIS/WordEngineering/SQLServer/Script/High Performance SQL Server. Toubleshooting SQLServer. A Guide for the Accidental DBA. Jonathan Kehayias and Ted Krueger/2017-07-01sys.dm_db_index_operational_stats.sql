--2017-07-01	http://www.sqlpassion.at/archive/2017/05/22/tracking-lookup-operations-in-sql-server/

SELECT singleton_lookup_count, *
FROM sys.dm_db_index_operational_stats(DB_ID(), OBJECT_ID('HisWord'), 1, NULL)
GO
