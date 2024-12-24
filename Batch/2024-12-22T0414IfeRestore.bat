@echo off

:BeginAgain
echo 1=C:, 2=D:
set /p id=Enter Choice: 

IF %id% == 1 GOTO C_Drive
IF %id% == 2 GOTO D_Drive
GOTO BeginAgain

:C_Drive
xcopy \\HolySpirit\d$\SQLServerBackup c:\SQLServerBackup /d /e /s /y
xcopy \\HolySpirit\d$\SQLServerDataDefinitionLanguageDDL c:\SQLServerDataDefinitionLanguageDDL /d /e /s /y
xcopy \\HolySpirit\d$\SQLServerDataManipulationLanguageDML c:\SQLServerDataManipulationLanguageDML /d /e /s /y
xcopy \\HolySpirit\d$\SQLServerExport c:\SQLServerExport /d /e /s /y
xcopy \\HolySpirit\d$\WordEngineering c:\WordEngineering /d /e /s /y
xcopy \\HolySpirit\d$\WordOfGod c:\WordOfGod /d /e /s /y

:D_Drive
xcopy \\HolySpirit\d$\SQLServerBackup d:\SQLServerBackup /d /e /s /y
xcopy \\HolySpirit\d$\SQLServerDataDefinitionLanguageDDL d:\SQLServerDataDefinitionLanguageDDL /d /e /s /y
xcopy \\HolySpirit\d$\SQLServerDataManipulationLanguageDML d:\SQLServerDataManipulationLanguageDML /d /e /s /y
xcopy \\HolySpirit\d$\SQLServerExport d:\SQLServerExport /d /e /s /y
xcopy \\HolySpirit\d$\WordEngineering d:\WordEngineering /d /e /s /y
xcopy \\HolySpirit\d$\WordOfGod d:\WordOfGod /d /e /s /y
