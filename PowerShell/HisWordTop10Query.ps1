<#
	2024-08-30T16:58:00 Created. http://learn.microsoft.com/en-us/powershell/module/sqlserver/invoke-sqlcmd?view=sqlserver-ps&redirectedfrom=MSDN
	2024-08-31T14:19:00...2024-08-31T14:30:00 runas /user:kadeniji powershell
		Install-Module SQLServer -Scope CurrentUser 
		Install-Module SQLServer -Scope CurrentUser -AllowClobber
		Uninstall-Module SQLServer
#>
#Install-Module SQLServer
#Import-Module SQLServer
$TopRecordsCount=10
Invoke-Sqlcmd -Query "SELECT TOP $TopRecordsCount * FROM HisWord ORDER BY Dated DESC" -ServerInstance localhost -Database WordEngineering
<#
Invoke-Sqlcmd -InputFile "E:\WordEngineering\PowerShell\HisWordToday.sql" `
	-ServerInstance localhost -Database WordEngineering `
	-StatisticsVariable stats `
	| Out-File -FilePath "E:\WordEngineering\PowerShell\HisWordToday.rpt"
Write-Host "Number of rows affected......: $($stats.IduRows)"
Write-Host "Number of insert statements..: $($stats.IduCount)"
Write-Host "Number of select statements..: $($stats.SelectCount)"
Write-Host "Total execution time.........: $($stats.ExecutionTime)ms"
#>
# 2024-08-31T10:47:00 http://techcommunity.microsoft.com/t5/azure-database-support-blog/lesson-learned-172-applicationintent-readonly-in-general-purpose/ba-p/2375941
Invoke-Sqlcmd -Query "SELECT COUNT(*) AS Count FROM HisWord" `
	-ConnectionString "Data Source=(local);Initial Catalog=WordEngineering;Integrated Security=True;ApplicationIntent=ReadOnly"
