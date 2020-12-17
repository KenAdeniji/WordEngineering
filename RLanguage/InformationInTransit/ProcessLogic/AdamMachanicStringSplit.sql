ALTER DATABASE WordEngineering SET TRUSTWORTHY ON;

DROP FUNCTION udf_SplitString_Multi
GO

DROP ASSEMBLY AdamMachanicStringSplit
GO

CREATE ASSEMBLY AdamMachanicStringSplit from 'E:\WordEngineering\InformationInTransit\ProcessLogic\AdamMachanicStringSplit.dll' WITH PERMISSION_SET = SAFE
GO

CREATE FUNCTION [dbo].udf_SplitString_Multi(@string [nvarchar](MAX), @separator [nchar](255))
RETURNS TABLE (
item  nvarchar (4000)
) WITH EXECUTE AS CALLER
AS EXTERNAL NAME [AdamMachanicStringSplit].[InformationInTransit.ProcessLogic.AdamMachanicStringSplit].[SplitString_Multi]
GO

select * from dbo.udf_SplitString_Multi('Bible ,.?KJV. VerseText', ',.;!? ')
GO
