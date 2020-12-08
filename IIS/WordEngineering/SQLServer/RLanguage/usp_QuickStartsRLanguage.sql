ALTER PROCEDURE usp_QuickStartsRLanguage AS
	/*
		2018-12-13	Created.	https://docs.microsoft.com/en-us/sql/advanced-analytics/tutorials/rtsql-using-r-functions-with-sql-server-data?view=sql-server-2017
		2018-12-14	http://radacad.com/r-in-sql-server-write-r-scripts-part-1
	*/
EXECUTE sp_execute_external_script
  @language =N'R',
  @script=N'OutputDataSet<-InputDataSet',
  @input_data_1 =N'SELECT 1 AS hello'
  WITH RESULT SETS (([Hello World] int));

EXECUTE sp_execute_external_script
      @language = N'R'
    , @script = N' OutputDataSet <- InputDataSet;'
    , @input_data_1 = N' SELECT MAX(ChapterID) AS ChapterIDs FROM Bible..Scripture GROUP BY BookID ORDER BY BookID;'
    WITH RESULT SETS (([Chapters] int NOT NULL));

EXECUTE sp_execute_external_script
    @language = N'R'
   , @script = N' mytextvariable <- c("Genesis", "Exodus", "Leviticus", "Numbers", "Deuteronomy");
       OutputDataSet <- as.data.frame(mytextvariable);'
   , @input_data_1 = N' SELECT 1 as Temp1'
   WITH RESULT SETS (([BookTitle] char(20) NOT NULL));

EXECUTE sp_execute_external_script
       @language = N'R'
     , @script = N' mytextvariable <- c("hello", " ", "world");
       OutputDataSet <- as.data.frame(mytextvariable); str(OutputDataSet);'
     , @input_data_1 = N' ';

EXECUTE sp_execute_external_script
        @language = N'R'
      , @script = N' OutputDataSet<- data.frame(c("hello"), " ", c("world")); str(OutputDataSet);'
      , @input_data_1 = N'  ';

EXECUTE sp_execute_external_script
      @language = N'R'
    , @script = N'
        library(utils);
        mymemory <- memory.limit();
        OutputDataSet <- as.data.frame(mymemory);'
    , @input_data_1 = N' ;'
WITH RESULT SETS (([MemoryLimit] int not null));

EXECUTE sp_execute_external_script
        @language = N'R'
      , @script = N' 
		mySystemDate <- Sys.Date();
		mySystemTime <- Sys.time();
		OutputDataSet<- data.frame(mySystemDate, mySystemTime);'
      , @input_data_1 = N''
		WITH RESULT SETS (([SystemDate] int, [SystemTime] datetime));

		EXECUTE sp_execute_external_script
        @language = N'R'
      , @script = N'OutputDataSet <- data.frame(.libPaths());'
      , @input_data_1 = N''
		WITH RESULT SETS (([DefaultLibraryName] VARCHAR(MAX) NOT NULL));

		EXECUTE sp_execute_external_script
        @language = N'R'
      , @script = N'str(OutputDataSet); packagematrix <- installed.packages(); NameOnly <- packagematrix[,1]; OutputDataSet <- as.data.frame(NameOnly);'
      , @input_data_1 = N''
		WITH RESULT SETS (([PackageName] NVARCHAR(250)));

GO
