@echo off

REM 2021-09-29T07:25:00 https://docs.microsoft.com/en-us/powershell/scripting/samples/selecting-parts-of-objects--select-object-?view=powershell-7.1
REM I pre-append the source URI; so I can give credit, and contiune referencing at a later time.
REM 2021-09-29T06:37:00 List the Members of a Process Object
PowerShell -command "Get-Process | Get-Member | Out-Host -Paging"
REM 2021-09-29T06:45:00 List Members of a Process Object, restrict to only properties
PowerShell -command "Get-Process | Get-Member -MemberType Properties"
REM 2021-09-29T06:53:00 Selecting Parts of Objects (Select-Object)
PowerShell -command "Get-CimInstance -Class Win32_LogicalDisk | Select-Object -Property Name,FreeSpace"
REM 2021-09-29T07:17:00 Computed colums, formatting freespace, as a GB
REM 2021-09-29T07:14:00 This is where, I am moving to.

goto Win32_LogicalDisk

PowerShell -command "Get-CimInstance -Class Win32_LogicalDisk | Select-Object -Property Name, @{
    label='FreeSpace'
    expression={($_.FreeSpace/1GB).ToString('F2')}
  }
"

:Win32_LogicalDisk

PowerShell -file 2021-09-29Win32_LogicalDisk.ps1

