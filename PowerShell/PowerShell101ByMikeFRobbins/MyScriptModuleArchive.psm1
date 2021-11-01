<#
	2021-10-30T19:06:00 Created https://docs.microsoft.com/en-us/powershell/scripting/learn/ps101/10-script-modules?view=powershell-7.1#dot-sourcing-functions
	$env:PSModulePath -split ';' #Location of PowerShell module script files. For module autoloading to work, the MyScriptModule.psm1 file needs to be located in a folder named MyScriptModule directly inside one of those paths.
		#The preferred option is the C:\Program Files\WindowsPowerShell\Modules
		#For module autoloading to work, the MyScriptModule.psm1 file needs to be located in a folder named MyScriptModule directly inside one of those paths.
	Get-Module -Name MyScriptModule #The version of a module without a manifest is 0.0. This is a dead giveaway that the module doesn't have a manifest.
	New-ModuleManifest -Path $env:ProgramFiles\WindowsPowerShell\Modules\MyScriptModule\MyScriptModule.psd1 -RootModule MyScriptModule -Author 'Mike F Robbins' -Description 'MyScriptModule' -CompanyName 'mikefrobbins.com'
		Issue New-ModuleManifest only once, after issue Update-ModuleManifest
#>
function Get-MrPSVersion {
    $PSVersionTable
}

function Get-MrComputerName {
    $env:COMPUTERNAME
}
