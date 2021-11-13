<#
	2021-11-12T07:33:00 Created. https://powershellexplained.com/2019-08-11-Powershell-if-then-else-equals-operator/?utm_source=blog&utm_medium=blog&utm_content=indexref
	2021-11-12T07:33:00	https://powershellexplained.com/2017-01-13-powershell-variable-substitution-in-strings/?utm_source=blog&utm_medium=blog&utm_content=indexref
	2021-11-12T12:19:00	https://social.technet.microsoft.com/Forums/ie/en-US/3c1efee6-baef-4d40-b6d1-e3a823f987d1/check-if-string-starts-with-lettercharacter?forum=winserverpowershell
	2021-11-12T14:19:00	Set-based query instead of for loop.
						I chose to implement with PowerShell, while learning;
						instead of relying on my experience? C# Linq, JavaScript, SQL.
						Where you are; is where your experience is.	
						.NET Framework? Programming languages.
	2021-11-12T14:41:00	PowerShell -command "& { . E:\WordEngineering\PowerShell\Get-GroupOfBook.ps1; Get-GroupOfBook 55 11 in }" 
	2021-11-12T17:06:00 https://stackoverflow.com/questions/52170699/how-to-save-each-line-of-text-file-as-array-through-powershell/52170755
#>
Function Get-GroupOfBook {
    [cmdletbinding()]
    [alias("ggb")]
    [OutputType("[string[]]")]
    Param(
        [Parameter(Position = 0, HelpMessage = "Specify the BookIDFrom")]
        [int]$BookIDFrom = 1,

        [Parameter(Position = 1, HelpMessage = "Specify the BookIDUntil")]
        [int]$BookIDUntil = 66,

        [Parameter(Position = 2, HelpMessage = "Specify the BookTitleLike")]
        [string]$BookTitleLike = ""
    )

	[string[]]$bibleBookTitle = Get-Content -Path 'BookTitle.txt'

	$bookIDStart = $BookIDFrom - 1
	$bookIDEnd = $BookIDUntil - 1

	[string[]]$bookIDFiltered = $bibleBookTitle[ $bookIDStart .. $bookIDEnd ].ToUpper()
	
	$BookTitleLike = $BookTitleLike.ToUpper()
		
	$bookID_TitleFiltered = $bookIDFiltered.Where({$_.Contains($BookTitleLike) -And ($_.Substring(0,1) -match "[0-9]")})

	$bookID_TitleCombined = $bookID_TitleFiltered -join ', '
	
	Write-Output $bookID_TitleCombined
}
