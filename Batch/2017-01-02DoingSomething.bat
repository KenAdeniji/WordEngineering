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
DBCC CHECKIDENT ('IHaveDecidedToWorkOnAGradualImprovingSystem..UriAddress', RESEED, 10404);

DBCC CHECKIDENT ('URI..UriBenediction', RESEED, 1173);
DBCC CHECKIDENT ('URI..UriBook', RESEED, 1);
DBCC CHECKIDENT ('URI..UriChrist', RESEED, 17700);
DBCC CHECKIDENT ('URI..UriEconomy', RESEED, 2);
DBCC CHECKIDENT ('URI..URIGoogleNews', RESEED, 8477);
DBCC CHECKIDENT ('URI..UriEntertainment', RESEED, 24668);
DBCC CHECKIDENT ('URI..UriPolitics', RESEED, 35);	
DBCC CHECKIDENT ('URI..UriTechnology', RESEED, 2);
DBCC CHECKIDENT ('URI..UriWordEngineering', RESEED, 57055);

DBCC CHECKIDENT ('WordEngineering..ActToGod', RESEED, 902);
DBCC CHECKIDENT ('WordEngineering..APass', RESEED, 2131);
DBCC CHECKIDENT ('WordEngineering..CaseBasedReasoning', RESEED, 16513);
DBCC CHECKIDENT ('WordEngineering..ClassAssociates', RESEED, 22952);
DBCC CHECKIDENT ('WordEngineering..Contact', RESEED, 11318);
DBCC CHECKIDENT ('WordEngineering..Telephone', RESEED, 5958);
DBCC CHECKIDENT ('WordEngineering..ContactURI', RESEED, 4753);
DBCC CHECKIDENT ('WordEngineering..Dream', RESEED, 5138);
DBCC CHECKIDENT ('WordEngineering..Event', RESEED, 1454);
DBCC CHECKIDENT ('WordEngineering..HisWord', RESEED, 143764);
DBCC CHECKIDENT ('WordEngineering..QuestionAndAnswer', RESEED, 2963);
DBCC CHECKIDENT ('WordEngineering..Remember', RESEED, 93795);
DBCC CHECKIDENT ('WordEngineering..SacredText', RESEED, 586);
DBCC CHECKIDENT ('WordEngineering..Software', RESEED, 3595);
DBCC CHECKIDENT ('WordEngineering..StreetAddress', RESEED, 4517);
DBCC CHECKIDENT ('WordEngineering..TerminologyOfTheDay', RESEED, 50); 
DBCC CHECKIDENT ('WordEngineering..TheComingAdventOfTime', RESEED, 1584);
DBCC CHECKIDENT ('WordEngineering..ToDo', RESEED, 1368);
DBCC CHECKIDENT ('WordEngineering..WhatAreTheStepsYouGoThroughInAJobInterview', RESEED, 2);
DBCC CHECKIDENT ('WordEngineering..WordOfTheDay', RESEED, 24);
DBCC CHECKIDENT ('WordEngineering..WordsInTheBible', RESEED, 479);

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
http://e-comfort.ephraimtech.com/WordEngineering/Resume/KenAdenijiResume.html
E:\WordEngineering\IIS\WordEngineering\Resume\KenAdenijiResume.pdf
E:\WordEngineering\IIS\WordEngineering\WordUnion\2015-10-23DoctoralDissertation.pdf
KenAdeniji@hotmail.com
2020-12-02T11:02:00 ... 2020-12-02T11:48:00 Microsoft SQL Server data files archive; network error.
12:26 Microsoft SQL Server Management Studio user interface (UI) grid error.
2020-12-04T18:03:00
I am available at 9AM, Pacific Standard Time, every day of the week.

Share your contact information, such as telephone number, email and web address?

Thank you and God blesses,

KenAdeniji@hotmail.com
http://KenAdeniji.WordPress.com
http://kenadeniji.wordpress.com/2015/11/20/ken-adenijis-resume
http://kenadeniji.wordpress.com/2015/12/06/2015-10-23doctoraldissertation
(510) 796-8121

2021-06-16T04:18:00 Microsoft SQL Server Management Studio
SQL Execution Error.
Executed SQL Statement: SELECT        TOP (15) TheWordId, RememberID, DatedFrom, DatedUntil, Filename, Commentary, ScriptureReference, ContactId, URI, HisWordID, FromUntilFirst
FROM            Remember
ORDER BY RememberID DESC
Error Source: .NET SQL Client Data Provider
Error Message: Connection Timeout Expired. The timeout period elapsed
while attempting to consume the pre-login handshake failed or the
server was unable to respond back in time. The duration spent
while attempting to connect to this server [pre-login initialization=30981; handshake=15750.
09:31 ... 09:44 Is that how you want to live your life?
2021-06-10T21:19:00 E:\WordEngineering\IIS\WordEngineering\WordUnion\2015-10-23DoctoralDissertation.pdf 
	The HisWordID column is an
	2021-06-16T11:27:00 Who is the work for? Who can benefit from reading this work?
2021-06-18T10:22:00 800 Service 1-800-991-8708
	Before you are to lower your credit card interest rate,
	press one to speak to the member service department,
	or press two and your eligibility to lower your interest will expire.
2021-06-18T16:14:00 800 Service 1-800-991-8708
	Before you are to lower your credit card interest rate,
	press one to speak to the member service department,
	or press two and your eligibility to lower your interest will expire.

2021-07-07 git clone http://github.com/KenAdeniji/WordEngineering
2021-07-07 https://theswissbay.ch/pdf/Gentoomen Library/Programming/Bash/O'Reilly bash CookBook.pdf

2021-07-23T15:09:00 ResultsAndDiscussion
2021-07-23T15:22:00 The author uses the div as a container for the ubiquitous result set; which may contain a single or multiple tables.
13:05 Urine, dizzy sleepy. 13:12 Dizzy, sleepy. I see your true color, shining true. 13:05 Urine. 13:30 Urine. (Go forward, Kehinde) (No turning people backward). 15:01 Teeth (Kehinde go forward). Hotmail.com advertisement The Climate Pledge. TheClimatePledge.com 15:16 Mouse highlight copy error Mozilla Firefox. 15:23 Hmm. We’re having trouble finding that site.

We can’t connect to the server at www.grammarcheck.net.

If that address is correct, here are three other things you can try:

    Try again later.
    Check your network connection.
    If you are connected but behind a firewall, check that Firefox has permission to access the Web.
2021-07-27T07:53:00 google.com/books/edition/Design_for_How_People_Think/UFSQDwAAQBAJ?hl=en&gbpv=1&printsec=frontcover
2021-07-27T11:24:00 Microsoft SQL Server Management Studio HisWord tab grid cursor moved upward.
2021-08-02T07:04:00 foxnews.com/world/death-toll-jumps-300-china-flooding
System.Exception: There is insufficient system memory in resource pool 'internal' to run this query. Error: 596, Severity: 21, State: 1. (Params:). The error is printed in terse mode because there was error during formatting. Tracing, ETW, notifications etc are skipped. A severe error occurred on the current command. The results, if any, should be discarded. 
2021-08-02T07:04:00
Microsoft SQL Server Management Studio System.Exception: A connection was successfully established with the server, but then an error occurred during the pre-login handshake. (provider: Shared Memory Provider, error: 0 - No process is on the other end of the pipe.) 
2021-08-16T16:40:00 ... 2021-08-16T16:49:00
Re: 2021-08-13T21:34:00 Market Research Manager (santa cruz)
Your message can't be displayed right now. Please check your network connection and try again later.
05:20AM. 0001-01-01 ... 2021-08-18, 738019. (738019 * 320) / (60 * 24) = 164004.22222222222222222222222222. 0001-01-01 + 164004 = 0450-01-11.
05:40AM. 0001-01-01 ... 2021-08-18, 738019. (738019 * 340) / (60 * 24) = 174254.48611111111111111111111111. 0001-01-01 + 174254 = 0478-02-03.
2021-08-18T13:18:00 Soumya Sourav. (732) 301-6270.
2021-08-18T19:20:00 ... 2021-08-18T19:28:00 Microsoft Windows Services services.msc
	Windows could not stat the SQL Server (MSSQLSERVER) service on local computer.
	Error 1053: The service did not respond to the start or control request in a timely fashion.
	OK
2021-08-20T12:27:00	is.js.org 	Arasatasaygin 		JavaScript, check, Dubai 	2021-02-07 	54942
2021-08-20T13:38:00 Psalms 37:9, Psalms 123:2, Isaiah 30:18, Isaiah 40:31, Jeremiah 14:22, Zephaniah 3:8,  Zechariah 11:11	
2021-08-20T13:52:00 What He truly realizes; is how He truly values ( 2 Chronicles 25:9 ).
2021-08-21T23:57:00 http://js4ds.org
2021-08-28T16:52:00 C:\Users\kadeniji\OneDrive
2021-08-30T19:26:00
dotnet
dir "C:\Program Files\dotnet\sdk\3.1.412"
CD E:\Accounting\dmitry-merzlyakov\nledger\nledger\Build
NLedgerBuild.Console.cmd
2021-08-30T20:53:00
System Variables Path. 
This environment variable is too large. This dialog allows setting Windows up to 2027 characters long.
env
2021-09-17T06:59:00
06:59 Urine. 07:35 Urine. 07:51 Urine. 08:08 Urine. 08:58 Urine. 10:46 Urine.
--SELECT * FROM Sys.all_columns where name = 'ContactID'
--UPDATE Sys.all_columns set name = 'ContactID' where name = 'ContactID'
EXEC sp_configure 'allow updates', 1
1 Samuel 16:1-3, 1 Samuel 16:10, Acts 13:22

SELECT    top 1    WordsInTheBibleID, Dated, Word, Logic, HisWordId, Commentary, ContactID, Uri
FROM     wordengineering..WordsInTheBible
ORDER BY WordsInTheBibleID desc
DANIEL 2:10-11, dANIEL 2:26-28
Ninth, involve story, as Himself.

2021-09-28T21:55:00
Get-Process | Get-Member | Out-Host -Paging
powershell -command "Get-Process | Get-Member | Out-Host -Paging
2021-10-02 23:15:30.007 2021-10-02T23:03:00 Wake-up Orientation: Head at West; legs cross at knee; right foot at South East to the North; lamp light goes off during the recording writing; left foot at South East to the West. 2021-10-02T23:17:00 Dizzy sleepy.
2021-10-02T11:59:00
12 quantity of books.
70 sheets wide ruled.
1 subject notebook.
10 1/2" * 8"
26.7 * 20.3 cm
Daiso Japan.
Bazic Products.
Los Angeles, CA, U.S.A
Made in Vietnam / Hecho en Vietnam
538
7 64608 00538 5
www.BazicProducts.com
V01236-012021-70002262
3 sets of four pieces of pencils, made in Japan.
sac@DaisoBrasil.com

Kraft
Serving suggestion
Slow Simmered
Original
Barbecue Sauce
See nutrition for sodium content
60 calories per tbsp
Net weight (wt) 18 oz (1 LB 2 OZ) 510g
04050032152600

:Exit
