REM http://social.technet.microsoft.com/Forums/windows/en-US/10f14ccf-0680-450f-8d49-54c06d0fe54f/mircosoft-jet-oledb-40-provider-is-not-registered?forum=w7itproappcompat
csc /main:InformationInTransit.ProcessLogic.ExcelHelper /platform:x86 ExcelHelper.cs DataTableHelper.cs
ExcelHelper "E:\Program Files (x86)\Microsoft Office\Office14\SAMPLES\SOLVSAMP.XLS" "Quick Tour"
ExcelHelper "E:\Program Files (x86)\Microsoft Office\Office14\SAMPLES\SOLVSAMP.XLS" "Product Mix"