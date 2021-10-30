<#
	2021-10-25T12:56:00 Created https://docs.microsoft.com/en-us/powershell/scripting/learn/ps101/04-pipelines?view=powershell-7.1
#>
Get-Service |
  Where-Object CanPauseAndContinue -eq $true |
    Select-Object -Property *
$Service = 'w32time'; Get-Service -Name $Service #Filters at the source
Get-Service | Where-Object Status -eq 'Running' #Filtering left