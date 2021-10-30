<#
	2021-10-21T18:16:00 Created https://docs.microsoft.com/en-us/powershell/scripting/learn/ps101/03-discovering-objects?view=powershell-7.1
	2021-10-21T18:44:00 https://docs.microsoft.com/en-us/powershell/module/microsoft.powershell.management/get-service?view=powershell-7.1
#>
Get-Service -Name w32time
Get-Service | Where-Object {$_.Status -eq "Running"}
Get-Service -Name w32time | Select-Object -Property *
Get-Service -Name w32time | Select-Object -Property Status, Name, DisplayName, ServiceType, Can"