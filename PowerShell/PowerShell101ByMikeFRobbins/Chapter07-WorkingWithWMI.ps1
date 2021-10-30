<#
	2021-10-25T18:22:00 Created https://docs.microsoft.com/en-us/powershell/scripting/learn/ps101/07-working-with-wmi?view=powershell-7.1
#>
Get-Command -Noun WMI* #Windows Management Instrumentation (WMI)
Get-Command -Module CimCmdlets #Common Information Model (CIM)
Get-CimInstance -Query 'Select * from Win32_BIOS'
Get-CimInstance -ClassName Win32_BIOS
Get-CimInstance -ClassName Win32_BIOS | Select-Object -Property SerialNumber #Display only the serial number
Get-CimInstance -ClassName Win32_BIOS -Property SerialNumber | Select-Object -Property SerialNumber #Retrieve only the serial number
Get-CimInstance -ClassName Win32_BIOS -Property SerialNumber | Select-Object -ExpandProperty SerialNumber #Return a simple string
(Get-CimInstance -ClassName Win32_BIOS -Property SerialNumber).SerialNumber #dotted style of syntax to return a simple string. Class instance property