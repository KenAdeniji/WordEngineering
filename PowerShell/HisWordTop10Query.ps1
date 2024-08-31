<#
	2024-08-30T16:58:00 Created. http://learn.microsoft.com/en-us/powershell/module/sqlserver/invoke-sqlcmd?view=sqlserver-ps&redirectedfrom=MSDN
#>
Invoke-Sqlcmd -Query "SELECT TOP 10 * FROM HisWord ORDER BY Dated DESC" -ServerInstance localhost -Database WordEngineering
Invoke-Sqlcmd -InputFile "E:\WordEngineering\PowerShell\HisWordToday.sql" `
	-ServerInstance localhost -Database WordEngineering `
	| Out-File -FilePath "E:\WordEngineering\PowerShell\HisWordToday.rpt"