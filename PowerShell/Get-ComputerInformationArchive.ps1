<#
	2021-11-27T17:40:00 Created. https://powershellexplained.com/2017-05-27-Powershell-module-building-basics/?utm_source=blog&utm_medium=blog&utm_content=indexactions
#>
Function Get-ComputerInformation {
    [cmdletbinding()]
    [alias("gcn")]
    [OutputType("[string[]]")]
    Param(
        [Parameter(Position = 0, HelpMessage = "Specify the ComputerName")]
        [string]$ComputerName = 'localhost'
    )
	Get-WmiObject -ComputerName $ComputerName -Class Win32_BIOS
}
