/*
	2019-01-30	https://docs.microsoft.com/en-us/sql/relational-databases/system-dynamic-management-views/index-related-dynamic-management-views-and-functions-transact-sql?view=sql-server-2017	
*/
DECLARE @db_id int;    
DECLARE @object_id int;    
SET @db_id = DB_ID(N'Bible');    
SET @object_id = OBJECT_ID(N'Bible..Scripture');    
IF @db_id IS NULL     
  BEGIN;    
    PRINT N'Invalid database';    
  END;    
ELSE IF @object_id IS NULL    
  BEGIN;    
    PRINT N'Invalid object';    
  END;    
ELSE    
  BEGIN;    
    SELECT * FROM sys.dm_db_index_operational_stats(@db_id, @object_id, NULL, NULL);    
  END;    
GO  

--select * from sys.objects where name = 'PK%' order by name
--SELECT OBJECT_ID(N'PK_Scripture')
