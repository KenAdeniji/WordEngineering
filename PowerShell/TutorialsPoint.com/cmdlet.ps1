$pentateuch = "Genesis", "Exodus", "Leviticus", "Numbers", "Deteuronomy" 
$pentateuch | sort | get-unique
get-content D:\temp\test\test.txt | measure-object -character -line -word
Get-ChildItem | Measure-Object