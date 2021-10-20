$PSVersionTable
New-Item -Path 'D:\temp\test' -ItemType Directory
New-Item -Path 'D:\temp\test\test.txt' -ItemType File
Get-Date
Get-Date -DisplayHint Time
Set-Content D:\temp\test\test.txt 'Welcome to TutorialsPoint'