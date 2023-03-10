ALTER PROCEDURE [dbo].[usp_QuickStartsRLanguageMemoryLimit] 
AS
	/*
		2018-12-13	Created.	https://docs.microsoft.com/en-us/sql/advanced-analytics/tutorials/rtsql-using-r-functions-with-sql-server-data?view=sql-server-2017
	*/
EXECUTE sp_execute_external_script
      @language = N'R'
    , @script = N'
        library(utils);
        mymemory <- memory.limit();
        OutputDataSet <- as.data.frame(mymemory);'
    , @input_data_1 = N' ;'
WITH RESULT SETS (([MemoryLimit] int not null));
GO

