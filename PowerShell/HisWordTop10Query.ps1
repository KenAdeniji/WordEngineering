<#
	2024-08-30T16:58:00 Created.
#>
Invoke-Sqlcmd -Query "SELECT TOP 10 * FROM HisWord ORDER BY Dated DESC" -ServerInstance localhost -Database WordEngineering