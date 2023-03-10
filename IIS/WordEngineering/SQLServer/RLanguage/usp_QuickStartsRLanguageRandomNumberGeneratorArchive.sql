USE [WordEngineering]
GO
/****** Object:  StoredProcedure [dbo].[usp_QuickStartsRLanguageRandomNumberGenerator]    Script Date: 12/13/2018 6:40:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[usp_QuickStartsRLanguageRandomNumberGenerator] 
(
	@countLength int,
	@meanAverage decimal, 
	@standardDeviation decimal
)
AS
	/*
		2018-12-13	Created.	https://docs.microsoft.com/en-us/sql/advanced-analytics/tutorials/rtsql-using-r-functions-with-sql-server-data?view=sql-server-2017
		usp_QuickStartsRLanguageRandomNumberGenerator 100, 50, 3
	*/
    EXEC sp_execute_external_script
      @language = N'R'
    , @script = N'
         OutputDataSet <- as.data.frame(rnorm(mynumbers, mymean, mysd));'
    , @input_data_1 = N'   ;'
    , @params = N' @mynumbers decimal, @mymean decimal, @mysd decimal'
    , @mynumbers = @countLength
    , @mymean = @meanAverage
    , @mysd = @standardDeviation
    WITH RESULT SETS (([Density] float NOT NULL));
