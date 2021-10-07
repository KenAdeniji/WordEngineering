<#
	Created: 2021-10-02T07:17:00
	Source:	https://docs.microsoft.com/en-us/powershell/scripting/learn/ps101/05-formatting-aliases-providers-comparison?view=powershell-7.1
	When there are more than 4 columns, default to list.
#>

Get-Service -Name w32time | Select-Object -Property Status, DisplayName, Can* |
Format-Table

Get-Service -Name w32time | Select-Object -Property Status, DisplayName, Can* |
Format-List