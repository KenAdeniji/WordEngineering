<#
	2021-11-01T09:06:00 Created.
		PowerShell -command "& { . E:\WordEngineering\PowerShell\Get-BookTitle.ps1; Get-BookTitle 2 4 }" 
	2021-10-31T19:29:00	https://docs.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_arrays?view=powershell-7.1
#>
Function Get-BookTitle {
    [cmdletbinding()]
    [alias("gbt")]
    [OutputType("[string[]]")]
    Param(
        [Parameter(Position = 0, HelpMessage = "Specify the BookIDFrom")]
        [int]$BookIDFrom = 1,

        [Parameter(Position = 1, HelpMessage = "Specify the BookIDUntil")]
        [int]$BookIDUntil = 5
    )

	[string[]]$BibleBookTitle = "Genesis", "Exodus", "Leviticus", "Numbers", "Deuteronomy"

	$BibleBookTitle[($BookIDFrom-1), ($BookIDUntil-1)]
}
