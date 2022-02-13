@echo off
:BeginAgain
echo 1=BCP, 2=Node.js, 3=SQLServerBackup, 4=SQLServerDataDefinitionLanguageDDL, 5=SQLServerDataFiles, 6=SQLServerExport, 7=WinScp, 8=WordEngineering, 9=WordOfGod
set /p id=Enter Choice: 

IF %id% == 1 GOTO BCP
IF %id% == 2 GOTO Node.js
IF %id% == 3 GOTO SQLServerBackup
IF %id% == 4 GOTO SQLServerDataDefinitionLanguageDDL
IF %id% == 5 GOTO SQLServerDataFiles
IF %id% == 6 GOTO SQLServerExport
IF %id% == 7 GOTO WinScp
IF %id% == 8 GOTO WordEngineering
IF %id% == 9 GOTO WordOfGod
GOTO Exit

:BCP
xcopy e:\BCP d:\BCP /d /e /s /y
xcopy e:\BCP f:\BCP /d /e /s /y
xcopy e:\BCP \\Noor\e$\BCP /d /e /s /y
REM xcopy e:\BCP \\Harvest\e$\BCP /d /e /s /y
xcopy e:\BCP C:\Users\KAdeniji\OneDrive\BCP /d /e /s /y
GOTO Exit

:Node.js
xcopy e:\Node.js d:\Node.js /d /e /s /y
xcopy e:\Node.js f:\Node.js /d /e /s /y
xcopy e:\Node.js \\Noor\e$\Node.js /d /e /s /y
REM xcopy e:\Node.js C:\Users\KAdeniji\OneDrive\Node.js /d /e /s /y
GOTO Exit

:SQLServerBackup
xcopy e:\SQLServerBackup d:\SQLServerBackup /d /e /s /y
xcopy e:\SQLServerBackup f:\SQLServerBackup /d /e /s /y
xcopy e:\SQLServerBackup \\Noor\e$\SQLServerBackup /d /e /s /y
xcopy e:\SQLServerBackup \\Harvest\e$\SQLServerBackup /d /e /s /y
xcopy e:\SQLServerBackup C:\Users\KAdeniji\OneDrive\SQLServerBackup /d /e /s /y
GOTO Exit

:SQLServerDataDefinitionLanguageDDL
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
xcopy E:\SQLServerDataFiles D:\sqlserverdatafiles /d /e /s /y
xcopy E:\SQLServerDataFiles F:\sqlserverdatafiles /d /e /s /y
xcopy E:\SQLServerDataFiles \\noor\e$\sqlserverdatafiles /d /e /s /y
xcopy E:\SQLServerDataFiles C:\Users\KAdeniji\OneDrive\sqlserverdatafiles /d /e /s /y
rem  net continue %_service% 
net start  %_service% /y
endlocal
GOTO Exit

:SQLServerExport
xcopy e:\SQLServerExport d:\SQLServerExport /d /e /s /y
xcopy e:\SQLServerExport f:\SQLServerExport /d /e /s /y
xcopy e:\SQLServerExport \\Noor\e$\SQLServerExport /d /e /s /y
xcopy e:\SQLServerExport C:\Users\KAdeniji\OneDrive\SQLServerExport /d /e /s /y
GOTO Exit

:WinScp
WinScp.com -script=2021-06-15T2015WinScp.txt -log=2021-06-15T2015WinScp.log
GOTO Exit

:WordEngineering
xcopy e:\WordEngineering d:\WordEngineering /d /e /s /y
xcopy e:\WordEngineering f:\WordEngineering /d /e /s /y
xcopy e:\WordEngineering \\Noor\e$\WordEngineering /d /e /s /y
xcopy e:\WordEngineering \\Harvest\e$\WordEngineering /d /e /s /y
xcopy e:\WordEngineering C:\Users\KAdeniji\OneDrive\WordEngineering /d /e /s /y
GOTO Exit

:WordOfGod
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
DBCC CHECKIDENT ('IHaveDecidedToWorkOnAGradualImprovingSystem..Contact', RESEED, 20082);
DBCC CHECKIDENT ('IHaveDecidedToWorkOnAGradualImprovingSystem..PhoneNumber', RESEED, 19000);
DBCC CHECKIDENT ('IHaveDecidedToWorkOnAGradualImprovingSystem..UriAddress', RESEED, 10404);

DBCC CHECKIDENT ('URI..UriBenediction', RESEED, 1188);
DBCC CHECKIDENT ('URI..UriBook', RESEED, 1);
DBCC CHECKIDENT ('URI..UriChrist', RESEED, 17700);
DBCC CHECKIDENT ('URI..UriEconomy', RESEED, 2);
DBCC CHECKIDENT ('URI..URIGoogleNews', RESEED, 8477);
DBCC CHECKIDENT ('URI..UriEntertainment', RESEED, 24668);
DBCC CHECKIDENT ('URI..UriPolitics', RESEED, 35);	
DBCC CHECKIDENT ('URI..UriTechnology', RESEED, 2);
DBCC CHECKIDENT ('URI..UriWordEngineering', RESEED, 57055);

DBCC CHECKIDENT ('WordEngineering..ActToGod', RESEED, 1084);
DBCC CHECKIDENT ('WordEngineering..APass', RESEED, 3520);
DBCC CHECKIDENT ('WordEngineering..CaseBasedReasoning', RESEED, 16629);
DBCC CHECKIDENT ('WordEngineering..ClassAssociates', RESEED, 22952);
DBCC CHECKIDENT ('WordEngineering..Contact', RESEED, 11377);
DBCC CHECKIDENT ('WordEngineering..Telephone', RESEED, 6102);
DBCC CHECKIDENT ('WordEngineering..ContactURI', RESEED, 4753);
DBCC CHECKIDENT ('WordEngineering..Dream', RESEED, 5138);
DBCC CHECKIDENT ('WordEngineering..Event', RESEED, 1454);
DBCC CHECKIDENT ('WordEngineering..HisWord', RESEED, 145490);
DBCC CHECKIDENT ('WordEngineering..QuestionAndAnswer', RESEED, 2963);
DBCC CHECKIDENT ('WordEngineering..Remember', RESEED, 96166);
DBCC CHECKIDENT ('WordEngineering..SacredText', RESEED, 586);
DBCC CHECKIDENT ('WordEngineering..Software', RESEED, 3595);
DBCC CHECKIDENT ('WordEngineering..StreetAddress', RESEED, 4517);
DBCC CHECKIDENT ('WordEngineering..TerminologyOfTheDay', RESEED, 50); 
DBCC CHECKIDENT ('WordEngineering..TheComingAdventOfTime', RESEED, 1718);
DBCC CHECKIDENT ('WordEngineering..ToDo', RESEED, 1471);
DBCC CHECKIDENT ('WordEngineering..WhatAreTheStepsYouGoThroughInAJobInterview', RESEED, 2);
DBCC CHECKIDENT ('WordEngineering..WordOfTheDay', RESEED, 24);
DBCC CHECKIDENT ('WordEngineering..WordsInTheBible', RESEED, 481);

SET IDENTITY_INSERT ClassAssociates ON
SET IDENTITY_INSERT ClassAssociates OFF

:Restore
RESTORE DATABASE [AManDevelopedInAll] FROM  DISK = N'E:\SQLServerBackup\AManDevelopedInAll\AManDevelopedInAll_2018-02-25.bak'

:WindowsToCentOS
pscp -pw LinuxPassword e:\SQLServerBackup\IHaveDecidedToWorkOnAGradualImprovingSystem\IHaveDecidedToWorkOnAGradualImprovingSystem_2020-02-13.bak kadeniji@10.0.4.101:/home/kadeniji/SQLServerBackup/IHaveDecidedToWorkOnAGradualImprovingSystem/IHaveDecidedToWorkOnAGradualImprovingSystem_2020-02-13.bak
pscp -pw LinuxPassword e:\SQLServerBackup\URI\URI_2020-02-17.bak kadeniji@10.0.4.101:/home/kadeniji/SQLServerBackup/URI/URI_2020-02-17.bak
pscp -pw LinuxPassword e:\SQLServerBackup\WordEngineering\WordEngineering_2020-02-18.bak kadeniji@10.0.4.101:/home/kadeniji/SQLServerBackup/WordEngineering/WordEngineering_2020-02-18.bak

:SQLScript
SELECT TOP 1 ContactID FROM WordEngineering..Contact ORDER BY ContactID DESC
DELETE FROM WordEngineering..APass WHERE SequenceOrderID > 13
UPDATE WordEngineering..HisWord SET ContactID = 517 WHERE ContactID = 2077
DELETE FROM WordEngineering..Remember WHERE SequenceOrderID > 48737
DELETE FROM WordEngineering..HisWord WHERE SequenceOrderID > 92804

INSERT INTO WordEngineering..ClassAssociates
(
	Commentary,
	ContactID,
	URI
)
VALUES
(
	'Microsoft Internet Explorer (IE) user interface (UI) error.',
	69,
	'Microsoft.com'
)	

UPDATE WordEngineering..Hisword
SET URI = 'en.wikipedia.org/wiki/Victor_Hugo'
where word = 'A even, of my half.'

INSERT INTO URI..URIWordEngineering
(
	URI,
	Title,
	Commentary,
	Keyword
)
SELECT
	URI,
	Title,
	Commentary,
	Keyword
FROM
	URI..URIChrist
WHERE CONVERT(Date, Dated) = '2018-11-06'

:ErrorMessage
http://kenadeniji.wordpress.com
http://kenadeniji.wordpress.com/2015/11/20/ken-adenijis-resume
http://kenadeniji.wordpress.com/2015/12/06/2015-10-23doctoraldissertation
E:\WordEngineering\IIS\WordEngineering\Resume\KenAdenijiResume.pdf
E:\WordEngineering\IIS\WordEngineering\WordUnion\2015-10-23DoctoralDissertation.pdf
KenAdeniji@hotmail.com

2021-11-28T19:45:00 BookOfSpeed.com 	Book of Speed By Stoyan Stefanov 		Performance 	2019-12-29 	52613
13:47 NotePad++ file save folder error, C:\Users\kadeniji\OneDrive\The Winter Tech
13:52 NotePad++ file save folder error, C:\Users\kadeniji\OneDrive\The Winter Tech
The thesis contains some images for database and object modeling. 11:53 Urine (Jo ko le). 13:17 Dizzy sleepy. 13:35 To find a reason for our use? (O low) left ear. 13:52 NotePad++ file save folder error, C:\Users\kadeniji\OneDrive\The Winter Tech.
06:16 When I close a tab on Mozilla Firefox, multiple tabs close.
2021-11-30T07:21:00 http://leanpub.com/windowspowershellnetworkingguide/read
	PowerShell Networking Guide By Ed Wilson Created by Microsoft’s “The Scripting Guy,” Ed Wilson, this guide helps you understand how PowerShell can be used to manage the networking aspects of your server and client computers. Ed Wilson is the Microsoft Scripting Guy and a well-known scripting expert. He writes the twice daily Hey Scripting Guy! blog (the number 1 blog on TechNet). He is a Microsoft-certified trainer who has delivered a popular Windows PowerShell workshop to Microsoft Premier Customers worldwide.
	Mozilla Firefox error, Microsoft SQL Server Management Studio object explorer error with the URI..URIWordEngineering table.
	Re-start Microsoft SQL Server Management Studio.
	07:43 I see nobody, has evolved as someone.
	07:50 Urine. 07:58 Urine.
	08:01 I love for somebody as me; as I seem somebody as me.
	08:02 Urine.
	08:02 Without nobody as a target, there is nobody as a representative.
	The birthday for Seun Fatai Adeniji is December 2, not December 1, as mother figure. 10:41 ... 11:07 https://www.governmentjobs.com/careers/humboldtcountyca?keywords=%20IT%20Applications%20Analyst%20III%20-%20County%20of%20Humboldt%20(Eureka)%20 https://sfbay.craigslist.org/sfc/sof/d/eureka-it-applications-analyst-iii/7414272884.html e-mail for password reset not received.  IT Applications Analyst III - County of Humboldt (Eureka). 
	11:11 Microsoft SQL Server Management Studio timeout error.
2021-11-30T11:49:00 ... 2021-11-30T12:05:00
	Microsoft SQL Server Management Studio.
	No row was updated.
	The data in row 1 was not committed.
	Error Source: .NET SQLClient Data Provider.
	Error Message: The connection is broken and recovery is not 
	possible. The client driver attempted to recover the
	connection one or more times and all attempts failed.
	Increase the value of ConnectRetryCount to increase
	the number of recovery attempts.
	Correct the errors and retry or press ESC to cancel the change(s).
	OK.
September 15, 2008, which was when Stack Overflow launched.
2021-12-17T18:26:00 URIMaintenance.aspx 139
05:38 C:\Users\kadeniji\OneDrive\The Winter Tech NotePad++ file save folder error.
01:04 Microsoft SQL Server Management Studio user interface (UI) error tab.
02:47
Firefox had a problem and crashed. We’ll try to restore your tabs and windows when it restarts.

To help us diagnose and fix the problem, you can send us a crash report.
2022-01-02T03:14:00 https://stackoverflow.com/questions/67064101/python-temperature-class-converter-k-f-c
2022-01-07T05:01:00 Microsoft Windows status bar error.
2022-01-07T06:32 ... 06:38 Microsoft Windows operating system, Explorer wait error.
Old and well-known pancake family handed from generation to generation. Founder of Kobayashi Pancake and Japanese Mr. Chung-Hsiang became good friends while Mr. Lin served in Japanese Navy during World War II under Japan's occupation of Taiwan. At the time of their departure, Mr. Chung Hsiang, whom was live with pancake in Japan before war, taught Mr. Lin all the unique skills of pancake he learned to Mr. Lin Zhen-nan, and it were at that time the Kobayashi Pancake started to incubation. 
:Exit
