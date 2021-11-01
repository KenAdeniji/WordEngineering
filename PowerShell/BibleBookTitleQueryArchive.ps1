<#
	2021-10-31T19:29:00 Created.
	2021-10-31T19:29:00	https://docs.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_arrays?view=powershell-7.1
#>
[string[]]$BibleBookTitle = "Genesis", "Exodus", "Leviticus", "Numbers", "Deuteronomy"
"Pentateuch: " + $BibleBookTitle[0..4]
"GetType(): " + $BibleBookTitle.GetType()
"Count: "  + $BibleBookTitle.Count

