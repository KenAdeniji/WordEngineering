DECLARE	@CounterPrefix NVARCHAR(30)
SET	@CounterPrefix =
	CASE 
		WHEN @@SERVICENAME = 'MSSQLSERVER'
			THEN 'SQLSERVER:'
		ELSE
			'MSSQL$' + @@SERVICENAME + ':'
	END;

-- Capture the first counter set
SELECT
	CAST(1 AS INT)	AS	Collection_Instance,
	[OBJECT_NAME],
	Counter_Name,
	instance_name,
	cntr_value,
	cntr_type,
	CURRENT_TIMESTAMP AS Collection_Time
INTO
	#perf_counters_init
FROM
	sys.dm_os_performance_counters
WHERE
	( OBJECT_NAME = @CounterPrefix + 'Access Methods' AND counter_name = 'Full Scans/sec' )
OR	( OBJECT_NAME = @CounterPrefix + 'Access Methods' AND counter_name = 'Index Searches/sec' )
OR	( OBJECT_NAME = @CounterPrefix + 'Buffer Manager' AND counter_name = 'Lazy Writes/sec' )
OR	( OBJECT_NAME = @CounterPrefix + 'Buffer Manager' AND counter_name = 'Page life expectancy' )
OR	( OBJECT_NAME = @CounterPrefix + 'General Statistics' AND counter_name = 'Processes Blocked' )
OR	( OBJECT_NAME = @CounterPrefix + 'General Statistics' AND counter_name = 'User Connections' )
OR	( OBJECT_NAME = @CounterPrefix + 'Locks' AND counter_name = 'Lock Waits/sec' )
OR	( OBJECT_NAME = @CounterPrefix + 'Locks' AND counter_name = 'Lock Wait Time (ms)' )
OR	( OBJECT_NAME = @CounterPrefix + 'SQL Statistics' AND counter_name = 'SQL Re-Compilations/sec' )
OR	( OBJECT_NAME = @CounterPrefix + 'Memory Manager' AND counter_name = 'Memory Grants Pending' )
OR	( OBJECT_NAME = @CounterPrefix + 'SQL Statistics' AND counter_name = 'Batch Requests/sec' )
OR	( OBJECT_NAME = @CounterPrefix + 'SQL Statistics' AND counter_name = 'SQL Compilations/sec' )
--or	( 1 = 1 )
-- Wait on second between data collection
WAITFOR DELAY '00:00:01'

-- Capture the second counter set
SELECT
	CAST(2 AS INT)	AS	Collection_Instance,
	[OBJECT_NAME],
	Counter_Name,
	instance_name,
	cntr_value,
	cntr_type,
	CURRENT_TIMESTAMP AS Collection_Time
INTO
	#perf_counters_second
FROM
	sys.dm_os_performance_counters
WHERE
	( OBJECT_NAME = @CounterPrefix + 'Access Methods' AND counter_name = 'Full Scans/sec' )
OR	( OBJECT_NAME = @CounterPrefix + 'Access Methods' AND counter_name = 'Index Searches/sec' )
OR	( OBJECT_NAME = @CounterPrefix + 'Buffer Manager' AND counter_name = 'Lazy Writes/sec' )
OR	( OBJECT_NAME = @CounterPrefix + 'Buffer Manager' AND counter_name = 'Page life expectancy' )
OR	( OBJECT_NAME = @CounterPrefix + 'General Statistics' AND counter_name = 'Processes Blocked' )
OR	( OBJECT_NAME = @CounterPrefix + 'General Statistics' AND counter_name = 'User Connections' )
OR	( OBJECT_NAME = @CounterPrefix + 'Locks' AND counter_name = 'Lock Waits/sec' )
OR	( OBJECT_NAME = @CounterPrefix + 'Locks' AND counter_name = 'Lock Wait Time (ms)' )
OR	( OBJECT_NAME = @CounterPrefix + 'SQL Statistics' AND counter_name = 'SQL Re-Compilations/sec' )
OR	( OBJECT_NAME = @CounterPrefix + 'Memory Manager' AND counter_name = 'Memory Grants Pending' )
OR	( OBJECT_NAME = @CounterPrefix + 'SQL Statistics' AND counter_name = 'Batch Requests/sec' )
OR	( OBJECT_NAME = @CounterPrefix + 'SQL Statistics' AND counter_name = 'SQL Compilations/sec' )
--or	( 1 = 1 )

-- Calculate the cumulative counter values
SELECT
	i.OBJECT_Name,
	i.counter_Name,
	i.instance_name,
	CASE	WHEN	i.cntr_type = 272696576 THEN s.cntr_value - i.cntr_value
			WHEN	i.cntr_type = 65792 THEN s.cntr_value
	END AS cntr_value
FROM
	#perf_counters_init AS i
	JOIN
		#perf_counters_second AS s
		ON i.Collection_Instance + 1 = s.Collection_Instance
			AND i.OBJECT_Name = s.OBJECT_Name
			AND i.counter_Name = s.counter_Name
			AND i.instance_name = s.instance_name
	ORDER BY
		OBJECT_NAME

--Cleanup tables
DROP TABLE #perf_counters_init
DROP TABLE #perf_counters_second

