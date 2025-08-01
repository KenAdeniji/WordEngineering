USE [WordEngineering]
GO
/****** Object:  UserDefinedFunction [dbo].[udf_SearchKey]    Script Date: 7/27/2025 8:08:28 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER   FUNCTION [dbo].[udf_SearchKey]
(
    @ContactId  Integer
)
RETURNS NVARCHAR(MAX)
BEGIN
    /*
        2025-07-26T12:01:00
        SELECT WordEngineering.dbo.udf_SearchKey(13070) --Faith An Yào
        Sen Wang
        Teresa Keng
        SELECT WordEngineering.dbo.udf_SearchKey(513) --Ralph Silverman
        SELECT WordEngineering.dbo.udf_SearchKey(1307)
    */
    DECLARE @searchKey NVARCHAR(MAX)
    SELECT @searchKey = 
        ISNULL(FirstName + ' ', '') +
        --ISNULL(OtherName + ' ', '') +
        ISNULL(LastName + ' ',  '')

    FROM WordEngineering..Contact
    WHERE ContactId = @ContactId
    SELECT @searchKey = TRIM(@searchKey)
 RETURN @searchKey
END

