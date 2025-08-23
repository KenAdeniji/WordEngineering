-- 	http://weblogs.sqlteam.com/phils

--	2025-08-22T12:52:00 xp_msver http://weblogs.sqlteam.com/phils/2015/02/25/sql-server-version-information-xp_msver
--	http://www.sqlservercentral.com/forums/topic/variable-assignment-to-select-and-empty-result-sets

SET NOCOUNT ON

/*
CREATE TABLE #msver
(
    [Index]             INT,
    Name                VARCHAR(50),
    Internal_Value      INT,
    Character_Value     VARCHAR(255)
)
INSERT #msver EXEC master.dbo.xp_msver
*/

DECLARE @msver AS TABLE
(
    [Index]             INT,
    Name                VARCHAR(50),
    Internal_Value      INT,
    Character_Value     VARCHAR(255)
)
INSERT @msver EXEC master.dbo.xp_msver

DECLARE @serverName AS VARCHAR(255)
SELECT @serverName = Character_Value FROM @msver WHERE NAME = 'ProductName'
PRINT 'ServerName: ' + @serverName

SELECT 
    cpu_count,
    hyperthread_ratio,
--    physical_memory_in_bytes / 1048576 AS 'mem_MB',
--    virtual_memory_in_bytes / 1048576 AS 'virtual_mem_MB',
    max_workers_count,
    os_error_mode,
    os_priority_class
FROM
    sys.dm_os_sys_info

