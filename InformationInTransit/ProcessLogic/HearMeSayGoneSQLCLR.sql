DROP Function UpIsTheDefinitePushIHaveMade
GO

DROP Assembly HearMeSayGone
GO

CREATE ASSEMBLY HearMeSayGone from 'E:\WordEngineering\InformationInTransit\ProcessLogic\HearMeSayGone.dll' WITH PERMISSION_SET =  SAFE --SAFE, UNSAFE, EXTERNAL_ACCESS
GO

CREATE FUNCTION UpIsTheDefinitePushIHaveMade(@question NVARCHAR(MAX))
RETURNS NVARCHAR(MAX)
AS EXTERNAL NAME HearMeSayGone.[HearMeSayGone].UpIsTheDefinitePushIHaveMade
GO

SELECT dbo.UpIsTheDefinitePushIHaveMade('Hear me say gone.')
GO
