-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ken Adeniji
-- Create date: 2025-09-29T17:00:00
-- Description:	Temperature conversion. vector-search-in-sql-server.
-- =============================================
CREATE OR ALTER PROCEDURE usp_20250929T1700TemperatureConversion_VectorSearchInSqlServer
	-- Add the parameters for the stored procedure here
	@celsuisTemperature INTEGER --Between freezing point, 0 ... boiling point, 100
AS
BEGIN
/*
    http://www.mssqltips.com/sqlservertip/8299/vector-search-in-sql-server/
    2025-09-29T17:50:00 Se o le lo... vector as a computed column?
                        Can it use... vector as a computed column?
    EXEC usp_20250929T1700TemperatureConversion_VectorSearchInSqlServer 50
*/
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

    DECLARE      @TemperatureConversion
    TABLE   
    (
        CelsuisTemperature  INTEGER,
        Embedding           VECTOR(2)
    );
  
    CREATE SEQUENCE CelsuisSequence AS SMALLINT

    DECLARE @CelsuisIndex INTEGER 
    SET @CelsuisIndex = 0
    
    WHILE @CelsuisIndex <= 100
    BEGIN
        INSERT INTO @TemperatureConversion (CelsuisTemperature, Embedding)
        SELECT @celsuisIndex, + '[' + CONVERT(VARCHAR, 1.8 + @CelsuisIndex) + ', ' + CONVERT(VARCHAR, 273.15 + @CelsuisIndex) + ']'
        SET @celsuisIndex += 1
    END

    DECLARE @TemperatureEmbedding VECTOR(2);
 
    --- Comparing which ones are similar to the temperature
    SELECT   @TemperatureEmbedding = Embedding
    FROM     @TemperatureConversion
    WHERE    CelsuisTemperature = @celsuisTemperature
 
    SELECT TOP 10 
        CelsuisTemperature,
        Embedding,
        VECTOR_DISTANCE('COSINE', @TemperatureEmbedding, Embedding) CosineSimilarityDistance
    FROM    
        @TemperatureConversion
    --WHERE CelsuisTemperature <> @celsuisTemperature
    ORDER BY CosineSimilarityDistance ASC;

    DROP SEQUENCE CelsuisSequence
END
GO
