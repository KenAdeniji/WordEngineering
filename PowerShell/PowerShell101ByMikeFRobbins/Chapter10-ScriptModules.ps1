<#
	2021-10-30T19:06:00 Created https://docs.microsoft.com/en-us/powershell/scripting/learn/ps101/10-script-modules?view=powershell-7.1#dot-sourcing-functions
#>
Get-ChildItem -Path Function:\Get-MrPSVersion #determine if functions are loaded into memory by checking to see if they exist on the Function PSDrive.
.\Get-MrPSVersion.ps1