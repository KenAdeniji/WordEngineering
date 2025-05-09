@echo off
REM	2025-05-09T13:32:00	http://superuser.com/questions/466682/why-use-start-over-call-when-using-batch-files
:C_Drive
start xcopy \\HolySpirit\d$\SQLServerBackup c:\SQLServerBackup /d /e /s /y
start xcopy \\HolySpirit\d$\SQLServerDataDefinitionLanguageDDL c:\SQLServerDataDefinitionLanguageDDL /d /e /s /y
start xcopy \\HolySpirit\d$\SQLServerDataManipulationLanguageDML c:\SQLServerDataManipulationLanguageDML /d /e /s /y
start xcopy \\HolySpirit\d$\SQLServerExport c:\SQLServerExport /d /e /s /y
start xcopy \\HolySpirit\d$\WordEngineering c:\WordEngineering /d /e /s /y
start xcopy \\HolySpirit\d$\WordOfGod c:\WordOfGod /d /e /s /y

:D_Drive
start xcopy \\HolySpirit\d$\SQLServerBackup d:\SQLServerBackup /d /e /s /y
start xcopy \\HolySpirit\d$\SQLServerDataDefinitionLanguageDDL d:\SQLServerDataDefinitionLanguageDDL /d /e /s /y
start xcopy \\HolySpirit\d$\SQLServerDataManipulationLanguageDML d:\SQLServerDataManipulationLanguageDML /d /e /s /y
start xcopy \\HolySpirit\d$\SQLServerExport d:\SQLServerExport /d /e /s /y
start xcopy \\HolySpirit\d$\WordEngineering d:\WordEngineering /d /e /s /y
start xcopy \\HolySpirit\d$\WordOfGod d:\WordOfGod /d /e /s /y
