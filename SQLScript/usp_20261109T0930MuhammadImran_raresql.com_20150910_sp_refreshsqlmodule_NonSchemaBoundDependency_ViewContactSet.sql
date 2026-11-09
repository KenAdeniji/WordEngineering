CREATE OR ALTER PROCEDURE usp_20261109T0930MuhammadImran_raresql_20150910_sp_refreshsqlmodule_NonSchemaBoundDependency_ViewContactSet
AS
BEGIN
	/*
		Author:			Kehinde Adewumi Adeniji
		Create date:	2026-11-09T09:30:00
		Description:	SQL SERVER – sp_refreshsqlmodule – How to update the metadata of an object
						2015-09-10 by Muhammad Imran
		url:			http://raresql.com/2015/09/10/sql-server-sp_refreshsqlmodule-how-to-update-the-metadata-of-an-object
		Filename:		D:\WordEngineering\SQLScript\usp_20261109T0930MuhammadImran_raresql.com_20150910_sp_refreshsqlmodule_NonSchemaBoundDependency_ViewContactSet
	*/
	-- 2026-11-09T09:39:00
	EXEC sys.sp_refreshsqlmodule ViewContactSet
END
GO

EXEC	usp_20261109T0930MuhammadImran_raresql_20150910_sp_refreshsqlmodule_NonSchemaBoundDependency_ViewContactSet	
GO
