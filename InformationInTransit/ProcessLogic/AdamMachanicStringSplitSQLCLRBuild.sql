ALTER DATABASE WordEngineering SET TRUSTWORTHY ON;

DROP FUNCTION udf_AdamMachanicStringSplit
GO

DROP ASSEMBLY AdamMachanicStringSplit
GO

CREATE ASSEMBLY AdamMachanicStringSplit from 'E:\WordEngineering\InformationInTransit\ProcessLogic\AdamMachanicStringSplit.dll' WITH PERMISSION_SET = SAFE
GO

CREATE FUNCTION udf_AdamMachanicStringSplit(@start int, @end int)
RETURNS TABLE(i int)
AS EXTERNAL NAME [AdamMachanicStringSplit].[InformationInTransit.ProcessLogic.AdamMachanicStringSplit].[Generate]
GO

select * from dbo.udf_AdamMachanicStringSplit(5, 17)
