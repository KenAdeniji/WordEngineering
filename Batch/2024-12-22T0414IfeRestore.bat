@echo off
REM	2025-05-09T13:32:00	http://superuser.com/questions/466682/why-use-start-over-call-when-using-batch-files
:C_Drive
start xcopy \\HolySpirit\d$\SQLServerBackup c:\SQLServerBackup /d /e /s /y
start xcopy \\HolySpirit\d$\WordEngineering c:\WordEngineering /d /e /s /y
start xcopy \\HolySpirit\d$\WordOfGod c:\WordOfGod /d /e /s /y

:D_Drive
start xcopy \\HolySpirit\d$\SQLServerBackup d:\SQLServerBackup /d /e /s /y
start xcopy \\HolySpirit\d$\WordEngineering d:\WordEngineering /d /e /s /y
start xcopy \\HolySpirit\d$\WordOfGod d:\WordOfGod /d /e /s /y
