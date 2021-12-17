<#
	2021-12-09T17:47:00 http://leanpub.com/windowspowershellnetworkingguide/read
#>
Get-Process
Get-Hotfix
Get-NetAdapter
Get-NetConnectionProfile <# Each interface #>
Get-Culture
Get-Date
(New-Object system.random).next() <# 225513766 #>
Get-Random
Get-Hotfix -D Update
Get-Random -Maximum 21 -Minimum 1 ### An introduction to parameter
Get-Random -InputObject (1..10) -Count 5
ipconfig
Get-NetIPAddress
1..3 | % {gpupdate ; sleep 1} ### Refresh Group Policy three times and wait for 1 second between refresh
