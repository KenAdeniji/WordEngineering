/*
	2025-08-29T20:31:00 http://sqlshack.com/sql-performance-tuning-tips-for-newbies
	2025-08-29T20:31:00...2025-08-31T00:59:00 executing... wait error... reboot.
*/
SET STATISTICS TIME ON 
EXEC WordEngineering.dbo.usp_ContactMaintenanceQuery 
	@query = 'Bill Clinton', 
	@debug = 0 
SET STATISTICS TIME OFF

SET STATISTICS IO ON 
EXEC WordEngineering.dbo.usp_ContactMaintenanceQuery 
	@query = 'Bill Clinton', 
	@debug = 0 
SET STATISTICS IO OFF

