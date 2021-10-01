<#
	Created: 2021-09-30T20:27:00
	Source:	https://docs.microsoft.com/en-us/powershell/scripting/learn/ps101/03-discovering-objects?view=powershell-7.1
#>
Get-Service -Name w32time #Windows Time service
Get-Service -Name w32time | Get-Member #List the available members
Get-Service -Name w32time | Select-Object -Property Status, Name, DisplayName, ServiceType #Explicity list particular properties
Get-Service -Name w32time | Select-Object -Property Status, DisplayName, Can* #Explicity list particular properties and use wildcard
