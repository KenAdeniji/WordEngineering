<#
	2021-11-01T09:06:00 Created.
		PowerShell -command "& { . E:\WordEngineering\PowerShell\Get-BookTitle.ps1; Get-BookTitle 2 4 in}" 
	2021-10-31	As I reached the second level of Barnes & Nobel bookstore, BN.com, beside the restroom;
		the idea came to write a PowerShell script that will accept the Bible book title and IDs 
		as query parameters.
	2021-10-31T19:29:00	https://docs.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_arrays?view=powershell-7.1
	2021-11-10T07:20:00 ... 2021-11-10T07:37:00
SELECT '''' + BookTitle + ''',' AS BookTitle
FROM Bible..Scripture_View
Group BY BookID, BookTitle
ORDER BY BookID
	2021-11-12T17:06:00 https://stackoverflow.com/questions/52170699/how-to-save-each-line-of-text-file-as-array-through-powershell/52170755
	2021-11-15T16:36:00 https://powershellexplained.com/2019-08-11-Powershell-if-then-else-equals-operator/?utm_source=blog&utm_medium=blog&utm_content=indexref
		$bookID_TitleFiltered = $bookIDFiltered.Where({$_ -like $BookTitleLikeWildcard})	
#>
Function Get-BookTitle {
    [cmdletbinding()]
    [alias("gbt")]
    [OutputType("[string[]]")]
    Param(
        [Parameter(Position = 0, HelpMessage = "Specify the BookIDFrom")]
        [int]$BookIDFrom = 1,

        [Parameter(Position = 1, HelpMessage = "Specify the BookIDUntil")]
        [int]$BookIDUntil = 66,

        [Parameter(Position = 2, HelpMessage = "Specify the BookTitleLike")]
        [string]$BookTitleLike = ""
    )

	[string[]]$bibleBookTitle = Get-Content -Path "BookTitle.txt"
	
	$bookIDStart = $BookIDFrom - 1
	$bookIDEnd = $BookIDUntil - 1

	[string[]]$BookIDFiltered = $bibleBookTitle[ $bookIDStart .. $bookIDEnd ]
	
	$BookTitleLikeWildcard = "*" + $BookTitleLike + "*" 
	$bookID_TitleFiltered = $bookIDFiltered.Where({$_ -like $BookTitleLikeWildcard})

	$bookID_TitleCombined = $bookID_TitleFiltered -join ", "
	
	Write-Output $bookID_TitleCombined
}
