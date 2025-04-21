$PSVersionTable
Get-Service -Name w32time
Get-Process -Name powershell
Get-Process -Name powershell | Get-Member
Get-Service |
    Where-Object CanPauseAndContinue -EQ $true |
    Select-Object -Property *