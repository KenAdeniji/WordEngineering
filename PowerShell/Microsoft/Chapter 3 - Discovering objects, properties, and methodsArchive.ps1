<#
	Created: 2021-09-30T20:27:00
	Source:	https://docs.microsoft.com/en-us/powershell/scripting/learn/ps101/03-discovering-objects?view=powershell-7.1
	2021-10-01T16:30:00 A member may be either a property or a method.
#>
<#
Get-Service -Name w32time #Windows Time service
Get-Service -Name w32time | Get-Member #List the available members
Get-Command -ParameterType ServiceController #List the commands that accept the ServiceController as a parameter

Get-Service -Name w32time | Select-Object -Property *
Get-Service -Name w32time | Select-Object -Property Status, Name, DisplayName, ServiceType #Explicity list particular properties
Get-Service -Name w32time | Select-Object -Property Status, DisplayName, Can* #Explicity list particular properties and use wildcard

Get-Service -Name w32time | Get-Member -MemberType Method #List the methods that are available for this service
(Get-Service -Name w32time).Stop()
Get-Service -Name w32time | Start-Service -PassThru #Start the service, with feedback

Get-Service |
  Where-Object CanPauseAndContinue -eq $true |
    Select-Object -Property *

#>

Get-Service | Where-Object Name -eq w32time	