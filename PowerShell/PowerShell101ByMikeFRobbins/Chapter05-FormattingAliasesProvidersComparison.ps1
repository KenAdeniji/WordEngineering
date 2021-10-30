<#
	2021-10-25T16:46:00 Created https://docs.microsoft.com/en-us/powershell/scripting/learn/ps101/05-formatting-aliases-providers-comparison?view=powershell-7.1
	2021-10-25T17:53:00 A command that returns more than four properties defaults to a list unless custom formatting is used.	
#>
Get-Service -Name w32time | Select-Object -Property Status, DisplayName, Can* |
Format-Table
Get-Service -Name w32time | Format-List

Get-Alias -Name gcm, gm #The Name parameter is used to determine what command the alias is associated with.
Get-Alias -Definition Get-Command, Get-Member #If you want to find aliases for a command, you'll need to use the Definition parameter.
