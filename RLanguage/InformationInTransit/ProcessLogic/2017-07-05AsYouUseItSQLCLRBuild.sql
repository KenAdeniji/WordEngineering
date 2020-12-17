ALTER DATABASE WordEngineering SET TRUSTWORTHY ON;

DROP FUNCTION udf_AsYouUseIt 
GO

DROP ASSEMBLY AsYouUseIt
GO

CREATE ASSEMBLY AsYouUseIt from 'E:\WordEngineering\InformationInTransit\ProcessLogic\AsYouUseIt.dll' WITH PERMISSION_SET = SAFE
GO

CREATE FUNCTION udf_AsYouUseIt(@HisWord NVARCHAR(MAX))
RETURNS NVARCHAR(MAX)
AS EXTERNAL NAME AsYouUseIt.[InformationInTransit.ProcessLogic.HisWordHelper].AsYouUseIt
GO

SELECT dbo.udf_AsYouUseIt('As you, use it.')
GO

SELECT TOP 1 Word --, AsYouUseIt
FROM HisWord_view
where word like '%Premade.%'
ORDER BY SequenceOrderId DESC
GO

