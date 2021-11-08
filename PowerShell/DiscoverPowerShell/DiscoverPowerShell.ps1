<#
	2021-11-08T07:00:00 Created. https://docs.microsoft.com/en-us/powershell/scripting/learn/tutorials/01-discover-powershell?view=powershell-7.2
#>
Get-Verb #What you are trying to do, for example, add
Get-Command -Name '*Process' #Get the list of commands, that their name ends with Process, for example, Get-Process
Get-Command -Verb 'Get'
Get-Command -Noun Process
Get-Command -Verb Get -Noun Process
Get-Command | Select-Object -First 3
Get-Process | Where-Object {$_.ProcessName -Like '*SQL*'}
Get-Process | Get-Member
