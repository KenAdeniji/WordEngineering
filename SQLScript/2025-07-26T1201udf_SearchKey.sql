CREATE OR ALTER FUNCTION [dbo].[udf_SearchKey]
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
        ISNULL(OtherName + ' ', '') +
        ISNULL(LastName + ' ',  '')
   FROM WordEngineering..Contact
   WHERE ContactId = @ContactId
 RETURN @searchKey
END

