ALTER DATABASE WordEngineering SET TRUSTWORTHY ON;

DROP FUNCTION udf_SequenceGenerator
GO

DROP ASSEMBLY SequenceGenerator
GO

CREATE ASSEMBLY SequenceGenerator from 'E:\WordEngineering\InformationInTransit\ProcessLogic\SequenceGenerator.dll' WITH PERMISSION_SET = SAFE
GO

CREATE FUNCTION udf_SequenceGenerator(@start int, @end int)
RETURNS TABLE(i int)
AS EXTERNAL NAME [SequenceGenerator].[InformationInTransit.ProcessLogic.SequenceGenerator].[Generate]
GO

select * from dbo.udf_SequenceGenerator(5, 17)
