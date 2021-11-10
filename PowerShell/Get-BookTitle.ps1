<#
	2021-11-01T09:06:00 Created.
		PowerShell -command "& { . E:\WordEngineering\PowerShell\Get-BookTitle.ps1; Get-BookTitle 2 4 }" 
	2021-10-31	As I reached the second level of Barnes & Nobel bookstore, BN.com, beside the restroom;
		the idea came to write a PowerShell script that will accept the Bible book title and IDs 
		as query parameters.
	2021-10-31T19:29:00	https://docs.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_arrays?view=powershell-7.1
	2021-11-10T07:20:00 ... 2021-11-10T07:37:00
SELECT '''' + BookTitle + ''',' AS BookTitle
FROM Bible..Scripture_View
Group BY BookID, BookTitle
ORDER BY BookID
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

	[string[]]$BibleBookTitle = 
	@(
'Genesis',
'Exodus',
'Leviticus',
'Numbers',
'Deuteronomy',
'Joshua',
'Judges',
'Ruth',
'1 Samuel',
'2 Samuel',
'1 Kings',
'2 Kings',
'1 Chronicles',
'2 Chronicles',
'Ezra',
'Nehemiah',
'Esther',
'Job',
'Psalms',
'Proverbs',
'Ecclesiastes',
'Song of Solomon',
'Isaiah',
'Jeremiah',
'Lamentations',
'Ezekiel',
'Daniel',
'Hosea',
'Joel',
'Amos',
'Obadiah',
'Jonah',
'Micah',
'Nahum',
'Habakkuk',
'Zephaniah',
'Haggai',
'Zechariah',
'Malachi',
'Matthew',
'Mark',
'Luke',
'John',
'Acts',
'Romans',
'1 Corinthians',
'2 Corinthians',
'Galatians',
'Ephesians',
'Philippians',
'Colossians',
'1 Thessalonians',
'2 Thessalonians',
'1 Timothy',
'2 Timothy',
'Titus',
'Philemon',
'Hebrews',
'James',
'1 Peter',
'2 Peter',
'1 John',
'2 John',
'3 John',
'Jude',
'Revelation'
)
	
	$BookIDStart = $BookIDFrom - 1
	$BookIDEnd = $BookIDUntil - 1

	[string[]]$BookIDFiltered = $BibleBookTitle[ $BookIDStart .. $BookIDEnd ].ToUpper()
	
	$BookTitleLike = $BookTitleLike.ToUpper()
		
	$BookID_TitleFiltered = $BookIDFiltered.Where({$_.Contains($BookTitleLike)})

	$BookID_TitleFiltered
}
