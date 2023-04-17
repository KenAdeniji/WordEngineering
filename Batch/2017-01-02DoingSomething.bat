@echo off
:BeginAgain
echo 1=BCP, 2=Node.js, 3=Rust, 4=SQLServerBackup, 5=SQLServerDataDefinitionLanguageDDL, 6=SQLServerDataFiles, 7=SQLServerDataManipulationLanguageDML, 8=SQLServerExport, 9=WebAssembly, 10=WinScp, 11=WordEngineering, 12=WordOfGod
set /p id=Enter Choice: 

IF %id% == 1 GOTO BCP
IF %id% == 2 GOTO Node.js
IF %id% == 3 GOTO Rust
IF %id% == 4 GOTO SQLServerBackup
IF %id% == 5 GOTO SQLServerDataDefinitionLanguageDDL
IF %id% == 6 GOTO SQLServerDataFiles
IF %id% == 7 GOTO SQLServerDataManipulationLanguageDML
IF %id% == 8 GOTO SQLServerExport
IF %id% == 9 GOTO WebAssembly
IF %id% == 10 GOTO WinScp
IF %id% == 11 GOTO WordEngineering
IF %id% == 12 GOTO WordOfGod
GOTO Exit

:BCP
xcopy e:\BCP c:\BCP /d /e /s /y
xcopy e:\BCP d:\BCP /d /e /s /y
xcopy e:\BCP f:\BCP /d /e /s /y
xcopy e:\BCP \\Noor\e$\BCP /d /e /s /y
REM xcopy e:\BCP \\Harvest\e$\BCP /d /e /s /y
xcopy e:\BCP C:\Users\KAdeniji\OneDrive\BCP /d /e /s /y
GOTO Exit

:Node.js
xcopy e:\Node.js c:\Node.js /d /e /s /y
xcopy e:\Node.js d:\Node.js /d /e /s /y
xcopy e:\Node.js f:\Node.js /d /e /s /y
xcopy e:\Node.js \\Noor\e$\Node.js /d /e /s /y
REM xcopy e:\Node.js C:\Users\KAdeniji\OneDrive\Node.js /d /e /s /y
GOTO Exit

:Rust
xcopy e:\Rust c:\Rust /d /e /s /y
xcopy e:\Rust d:\Rust /d /e /s /y
xcopy e:\Rust f:\Rust /d /e /s /y
xcopy e:\Rust \\Noor\e$\Rust /d /e /s /y
xcopy e:\Rust \\Harvest\e$\Rust /d /e /s /y
xcopy e:\Rust C:\Users\KAdeniji\OneDrive\Rust /d /e /s /y
GOTO Exit

:SQLServerBackup
xcopy e:\SQLServerBackup c:\SQLServerBackup /d /e /s /y
xcopy e:\SQLServerBackup d:\SQLServerBackup /d /e /s /y
xcopy e:\SQLServerBackup f:\SQLServerBackup /d /e /s /y
xcopy e:\SQLServerBackup \\Noor\e$\SQLServerBackup /d /e /s /y
xcopy e:\SQLServerBackup \\Harvest\e$\SQLServerBackup /d /e /s /y
xcopy e:\SQLServerBackup C:\Users\KAdeniji\OneDrive\SQLServerBackup /d /e /s /y
GOTO Exit

:SQLServerDataDefinitionLanguageDDL
xcopy e:\SQLServerDataDefinitionLanguageDDL c:\SQLServerDataDefinitionLanguageDDL /d /e /s /y
xcopy e:\SQLServerDataDefinitionLanguageDDL d:\SQLServerDataDefinitionLanguageDDL /d /e /s /y
xcopy e:\SQLServerDataDefinitionLanguageDDL f:\SQLServerDataDefinitionLanguageDDL /d /e /s /y
xcopy e:\SQLServerDataDefinitionLanguageDDL \\Noor\e$\SQLServerDataDefinitionLanguageDDL /d /e /s /y
xcopy e:\SQLServerDataDefinitionLanguageDDL \\Harvest\e$\SQLServerDataDefinitionLanguageDDL /d /e /s /y
xcopy e:\SQLServerDataDefinitionLanguageDDL C:\Users\KAdeniji\OneDrive\SQLServerDataDefinitionLanguageDDL /d /e /s /y
GOTO Exit

:SQLServerDataFiles
setlocal
set "_service=MSSQLSERVER"
rem net pause  %_service% /y
net stop  %_service% /y
xcopy E:\SQLServerDataFiles C:\sqlserverdatafiles /d /e /s /y
xcopy E:\SQLServerDataFiles D:\sqlserverdatafiles /d /e /s /y
xcopy E:\SQLServerDataFiles F:\sqlserverdatafiles /d /e /s /y
xcopy E:\SQLServerDataFiles \\noor\e$\sqlserverdatafiles /d /e /s /y
xcopy E:\SQLServerDataFiles C:\Users\KAdeniji\OneDrive\sqlserverdatafiles /d /e /s /y
rem  net continue %_service% 
net start  %_service% /y
endlocal
GOTO Exit

:SQLServerDataManipulationLanguageDML
xcopy e:\SQLServerDataManipulationLanguageDML c:\SQLServerDataManipulationLanguageDML /d /e /s /y
xcopy e:\SQLServerDataManipulationLanguageDML d:\SQLServerDataManipulationLanguageDML /d /e /s /y
xcopy e:\SQLServerDataManipulationLanguageDML f:\SQLServerDataManipulationLanguageDML /d /e /s /y
xcopy e:\SQLServerDataManipulationLanguageDML \\Noor\e$\SQLServerDataManipulationLanguageDML /d /e /s /y
xcopy e:\SQLServerDataManipulationLanguageDML \\Harvest\e$\SQLServerDataManipulationLanguageDML /d /e /s /y
xcopy e:\SQLServerDataManipulationLanguageDML C:\Users\KAdeniji\OneDrive\SQLServerDataManipulationLanguageDML /d /e /s /y
GOTO Exit

:SQLServerExport
xcopy e:\SQLServerExport c:\SQLServerExport /d /e /s /y
xcopy e:\SQLServerExport d:\SQLServerExport /d /e /s /y
xcopy e:\SQLServerExport f:\SQLServerExport /d /e /s /y
xcopy e:\SQLServerExport \\Noor\e$\SQLServerExport /d /e /s /y
xcopy e:\SQLServerExport C:\Users\KAdeniji\OneDrive\SQLServerExport /d /e /s /y
GOTO Exit

:WebAssembly
xcopy e:\WebAssembly c:\WebAssembly /d /e /s /y
xcopy e:\WebAssembly d:\WebAssembly /d /e /s /y
xcopy e:\WebAssembly f:\WebAssembly /d /e /s /y
xcopy e:\WebAssembly \\Noor\e$\WebAssembly /d /e /s /y
xcopy e:\WebAssembly \\Harvest\e$\WebAssembly /d /e /s /y
xcopy e:\WebAssembly C:\Users\KAdeniji\OneDrive\WebAssembly /d /e /s /y
GOTO Exit

:WinScp
WinScp.com -script=2021-06-15T2015WinScp.txt -log=2021-06-15T2015WinScp.log
GOTO Exit

:WordEngineering
xcopy e:\WordEngineering c:\WordEngineering /d /e /s /y
xcopy e:\WordEngineering d:\WordEngineering /d /e /s /y
xcopy e:\WordEngineering f:\WordEngineering /d /e /s /y
xcopy e:\WordEngineering \\Noor\e$\WordEngineering /d /e /s /y
xcopy e:\WordEngineering \\Harvest\e$\WordEngineering /d /e /s /y
xcopy e:\WordEngineering C:\Users\KAdeniji\OneDrive\WordEngineering /d /e /s /y
GOTO Exit

:WordOfGod
xcopy e:\WordOfGod c:\WordOfGod /d /e /s /y
xcopy e:\WordOfGod d:\WordOfGod /d /e /s /y
xcopy e:\WordOfGod f:\WordOfGod /d /e /s /y
xcopy e:\WordOfGod \\Noor\e$\WordOfGod /d /e /s /y
xcopy e:\WordOfGod \\Harvest\e$\WordOfGod /d /e /s /y
xcopy e:\WordOfGod C:\Users\KAdeniji\OneDrive\WordOfGod /d /e /s /y
GOTO Exit

:Backup
BACKUP DATABASE Account TO DISK = 'e:\SQLServerBackup\Account\Account_2018-04-30.bak' WITH INIT
BACKUP DATABASE ASPNetDB TO DISK = 'e:\SQLServerBackup\ASPNetDB\ASPNetDB_2017-11-03.bak' WITH INI
BACKUP DATABASE Bible TO DISK = 'e:\SQLServerBackup\Bible\Bible_2020-03-23.bak' WITH INIT
BACKUP DATABASE BibleDictionary TO DISK = 'e:\SQLServerBackup\BibleDictionary\BibleDictionary_2017-03-02T1518.bak' WITH INIT
BACKUP DATABASE CodingSample TO DISK = 'e:\SQLServerBackup\CodingSample\CodingSample_2019-06-23.bak' WITH INIT
BACKUP DATABASE ElectronicCopy TO DISK = 'e:\SQLServerBackup\ElectronicCopy\ElectronicCopy_2017-11-02T2114.bak' WITH INIT
BACKUP DATABASE HomeAbroad TO DISK = 'e:\SQLServerBackup\HomeAbroad\HomeAbroa2018-06-25.bak' WITH INIT
BACKUP DATABASE IHaveDecidedToWorkOnAGradualImprovingSystem TO DISK = 'e:\SQLServerBackup\IHaveDecidedToWorkOnAGradualImprovingSystem\IHaveDecidedToWorkOnAGradualImprovingSystem_2019-04-12.bak' WITH INIT
BACKUP DATABASE IShallBeTheirInheritance TO DISK = 'e:\SQLServerBackup\IShallBeTheirInheritance\IShallBeTheirInheritance_2019-08-17.bak' WITH INIT
BACKUP DATABASE Nortdwind TO DISK = 'e:\SQLServerBackup\Nortdwind\Northwin2018-01-01.bak' WITH INIT
BACKUP DATABASE RatingRank TO DISK = 'e:\SQLServerBackup\RatingRank\RatingRank_2018-01-01.bak' WITH INIT
BACKUP DATABASE SQLSharp TO DISK = 'e:\SQLServerBackup\SQLSharp\SQLSharp_2020-05-08.bak' WITH INIT
BACKUP DATABASE URI TO DISK = 'e:\SQLServerBackup\URI\URI_2019-04-12.bak' WITH INIT
BACKUP DATABASE WordEngineering TO DISK = 'e:\SQLServerBackup\WordEngineering\WordEngineering_2020-02-18.bak' WITH INIT

BACKUP DATABASE Master TO DISK = 'e:\SQLServerBackup\Master\Master_2017-01-02.bak' WITH INIT
BACKUP DATABASE Model TO DISK = 'e:\SQLServerBackup\Model\Model_2017-01-02.bak' WITH INIT
BACKUP DATABASE Msdb TO DISK = 'e:\SQLServerBackup\Msdb\Msdb_2017-01-02.bak' WITH INIT

BACKUP DATABASE AManDevelopedInAll TO DISK = 'e:\SQLServerBackup\AManDevelopedInAll\AManDevelopedInAll_2018-02-25.bak' WItd INIT

:DbccCheckIdent
DBCC CHECKIDENT ('IHaveDecidedToWorkOnAGradualImprovingSystem..Contact', RESEED, 24539);
DBCC CHECKIDENT ('IHaveDecidedToWorkOnAGradualImprovingSystem..EmailAddress', RESEED, 22139);
DBCC CHECKIDENT ('IHaveDecidedToWorkOnAGradualImprovingSystem..PhoneNumber', RESEED, 24539);
DBCC CHECKIDENT ('IHaveDecidedToWorkOnAGradualImprovingSystem..UriAddress', RESEED, 12588);

DBCC CHECKIDENT ('URI..UriBenediction', RESEED, 1188);
DBCC CHECKIDENT ('URI..UriBook', RESEED, 1);
DBCC CHECKIDENT ('URI..UriChrist', RESEED, 17865);
DBCC CHECKIDENT ('URI..UriEconomy', RESEED, 2);
DBCC CHECKIDENT ('URI..URIGoogleNews', RESEED, 8477);
DBCC CHECKIDENT ('URI..UriEntertainment', RESEED, 24711);
DBCC CHECKIDENT ('URI..UriPolitics', RESEED, 35);	
DBCC CHECKIDENT ('URI..UriTechnology', RESEED, 2);
DBCC CHECKIDENT ('URI..UriWordEngineering', RESEED, 62606);

DBCC CHECKIDENT ('WordEngineering..ActToGod', RESEED, 1299);
DBCC CHECKIDENT ('WordEngineering..APass', RESEED, 5818);
DBCC CHECKIDENT ('WordEngineering..CaseBasedReasoning', RESEED, 16629);
DBCC CHECKIDENT ('WordEngineering..ClassAssociates', RESEED, 22952);
DBCC CHECKIDENT ('WordEngineering..Contact', RESEED, 13155);
DBCC CHECKIDENT ('WordEngineering..ContactURI', RESEED, 5074);
DBCC CHECKIDENT ('WordEngineering..Dream', RESEED, 5138);
DBCC CHECKIDENT ('WordEngineering..Event', RESEED, 1454);
DBCC CHECKIDENT ('WordEngineering..HisWord', RESEED, 152637);
DBCC CHECKIDENT ('WordEngineering..QuestionAndAnswer', RESEED, 2963);
DBCC CHECKIDENT ('WordEngineering..Remember', RESEED, 154461);
DBCC CHECKIDENT ('WordEngineering..SacredText', RESEED, 606);
DBCC CHECKIDENT ('WordEngineering..Software', RESEED, 3595);
DBCC CHECKIDENT ('WordEngineering..StreetAddress', RESEED, 4517);
DBCC CHECKIDENT ('WordEngineering..Telephone', RESEED, 7197); 
DBCC CHECKIDENT ('WordEngineering..TerminologyOfTheDay', RESEED, 50); 
DBCC CHECKIDENT ('WordEngineering..TheComingAdventOfTime', RESEED, 1782);
DBCC CHECKIDENT ('WordEngineering..ToDo', RESEED, 1541);
DBCC CHECKIDENT ('WordEngineering..WhatAreTheStepsYouGoThroughInAJobInterview', RESEED, 2);
DBCC CHECKIDENT ('WordEngineering..WordOfTheDay', RESEED, 24);
DBCC CHECKIDENT ('WordEngineering..WordsInTheBible', RESEED, 481);

--2023-02-19T23:01:00
SET IDENTITY_INSERT URI..URIWordEngineering ON
INSERT URI.[dbo].[URIWordEngineering] ([SequenceOrderId], [Dated], [Title], [URI], [Keyword], [Commentary]) VALUES (57064, CAST(N'2021-08-15T20:22:53.920' AS DateTime), N'Missing Manuals by Dave McFarland', N'sawmac.com', NULL, NULL)
SET IDENTITY_INSERT URI..URIWordEngineering OFF

:Restore
RESTORE DATABASE [AManDevelopedInAll] FROM  DISK = N'E:\SQLServerBackup\AManDevelopedInAll\AManDevelopedInAll_2018-02-25.bak'

:WindowsToCentOS
pscp -pw LinuxPassword e:\SQLServerBackup\IHaveDecidedToWorkOnAGradualImprovingSystem\IHaveDecidedToWorkOnAGradualImprovingSystem_2020-02-13.bak kadeniji@10.0.4.101:/home/kadeniji/SQLServerBackup/IHaveDecidedToWorkOnAGradualImprovingSystem/IHaveDecidedToWorkOnAGradualImprovingSystem_2020-02-13.bak
pscp -pw LinuxPassword e:\SQLServerBackup\URI\URI_2020-02-17.bak kadeniji@10.0.4.101:/home/kadeniji/SQLServerBackup/URI/URI_2020-02-17.bak
pscp -pw LinuxPassword e:\SQLServerBackup\WordEngineering\WordEngineering_2020-02-18.bak kadeniji@10.0.4.101:/home/kadeniji/SQLServerBackup/WordEngineering/WordEngineering_2020-02-18.bak

:SQLScript

:ErrorMessage
http://kenadeniji.wordpress.com
http://kenadeniji.wordpress.com/2015/11/20/ken-adenijis-resume
http://kenadeniji.wordpress.com/2015/12/06/2015-10-23doctoraldissertation
E:\WordEngineering\IIS\WordEngineering\Resume\KenAdenijiResume.pdf
E:\WordEngineering\IIS\WordEngineering\WordUnion\2015-10-23DoctoralDissertation.pdf
C:\Users\kadeniji\OneDrive\WordEngineering\IIS\WordEngineering\WordUnion
KenAdeniji@hotmail.com

2023-04-14T13:25:00 drive.google.com
2023-04-16T13:23:00 "Don't be evil" is a phrase used in Google's corporate code of conduct, which it also formerly preceded as a motto. Following Google's corporate restructuring under the conglomerate Alphabet Inc. in October 2015, Alphabet took "Do the right thing" as its motto, also forming the opening of its corporate code of conduct.
UriChrist
	LauraStoryMusic.com/#video 				2020-03-06 	17594
2023-04-14T13:25:00 Drive.Google.com Google Drive Almost out of storage.
2023-04-14T14:17:00	Microsoft Windows Operating System clipboard copy paste.
2023-04-14T14:35:00 Dizzy sleepy.
2023-04-15T12:34:00	http://sfbay.craigslist.org
2023-04-16T04:08:00	Lie heard while I slept. Acts 12:23.
:Exit
