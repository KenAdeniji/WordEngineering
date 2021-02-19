@echo off
:BeginAgain
echo 1=BCP, 2=Node.js, 3=SQLServerBackup, 4=SQLServerDataDefinitionLanguageDDL, 5=SQLServerDataFiles, 6=SQLServerExport, 7=WordEngineering, 8=WordOfGod
set /p id=Enter Choice: 

IF %id% == 1 GOTO BCP
IF %id% == 2 GOTO Node.js
IF %id% == 3 GOTO SQLServerBackup
IF %id% == 4 GOTO SQLServerDataDefinitionLanguageDDL
IF %id% == 5 GOTO SQLServerDataFiles
IF %id% == 6 GOTO SQLServerExport
IF %id% == 7 GOTO WordEngineering
IF %id% == 8 GOTO WordOfGod
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
DBCC CHECKIDENT ('URI..UriChrist', RESEED, 17654);
DBCC CHECKIDENT ('URI..UriEconomy', RESEED, 2);
DBCC CHECKIDENT ('URI..URIGoogleNews', RESEED, 2728);
DBCC CHECKIDENT ('URI..UriEntertainment', RESEED, 24657);
DBCC CHECKIDENT ('URI..UriPolitics', RESEED, 35);	
DBCC CHECKIDENT ('URI..UriTechnology', RESEED, 2);
DBCC CHECKIDENT ('URI..UriWordEngineering', RESEED, 53805);

DBCC CHECKIDENT ('WordEngineering..ActToGod', RESEED, 563);
DBCC CHECKIDENT ('WordEngineering..APass', RESEED, 699);
DBCC CHECKIDENT ('WordEngineering..CaseBasedReasoning', RESEED, 15512);
DBCC CHECKIDENT ('WordEngineering..ClassAssociates', RESEED, 22952);
DBCC CHECKIDENT ('WordEngineering..Contact', RESEED, 10976);
DBCC CHECKIDENT ('WordEngineering..Telephone', RESEED, 5958);
DBCC CHECKIDENT ('WordEngineering..ContactURI', RESEED, 4267);
DBCC CHECKIDENT ('WordEngineering..Dream', RESEED, 5138);
DBCC CHECKIDENT ('WordEngineering..Event', RESEED, 1454);
DBCC CHECKIDENT ('WordEngineering..HisWord', RESEED, 139300);
DBCC CHECKIDENT ('WordEngineering..QuestionAndAnswer', RESEED, 2963);
DBCC CHECKIDENT ('WordEngineering..Remember', RESEED, 84387);
DBCC CHECKIDENT ('WordEngineering..SacredText', RESEED, 544);
DBCC CHECKIDENT ('WordEngineering..Software', RESEED, 3595);
DBCC CHECKIDENT ('WordEngineering..StreetAddress', RESEED, 4517);
DBCC CHECKIDENT ('WordEngineering..TerminologyOfTheDay', RESEED, 11); 
DBCC CHECKIDENT ('WordEngineering..TheComingAdventOfTime', RESEED, 1584);
DBCC CHECKIDENT ('WordEngineering..ToDo', RESEED, 1368);
DBCC CHECKIDENT ('WordEngineering..WhatAreTheStepsYouGoThroughInAJobInterview', RESEED, 2);
DBCC CHECKIDENT ('WordEngineering..WordOfTheDay', RESEED, 24);
DBCC CHECKIDENT ('WordEngineering..WordsInTheBible', RESEED, 419);

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
KenAdeniji@hotmail.com
2020-12-02T11:02:00 ... 2020-12-02T11:48:00 Microsoft SQL Server data files archive; network error.
12:26 Microsoft SQL Server Management Studio user interface (UI) grid error.
2020-12-04T18:03:00
I am available at 10AM, Pacific Standard Time, every day of the week.

Share your contact information, such as telephone number, email and web address?

Thank you and God blesses,

KenAdeniji@hotmail.com
http://KenAdeniji.WordPress.com
(510) 796-8121
2021-01-03T15:20:00
https://learn.shayhowe.com/
10:45 ... 10:54 Microsoft SQL Server data files archive. 10:59 https://news.google.com/topstories?hl=en-US&gl=US&ceid=US:en user interface (UI) error world, business, technology, entertainment, sports, science, health.
2021-01-07T22:35:00 http://www.taffydb.com/
Hmm. We’re having trouble finding that site.

We can’t connect to the server at www.taffydb.com.

If that address is correct, here are three other things you can try:

    Try again later.
    Check your network connection.
    If you are connected but behind a firewall, check that Firefox has permission to access the Web.

09:35 Microsoft SQL Server Management Studio grid user interface jumps to the upper row, from the blank bottom row to the earlier completed upper row. 09:38 Urine (O ti old).
17:07 http://bedford-computing.co.uk/learning/wp-content/uploads/2016/08/learning_javascript.pdf
I am driving a car at Center West towards the South, I turn the steering and the tire aligned; I saw a tire to the South. 10:27 ... 11:06 Microsoft SQL Server datafiles archive.
2021-01-23T20:27:00 https://www.peopledatalabs.com/signup/confirm/
2021-01-26A young man response to every question, is James; this may be, where the name of his partner or where he sleeps. 03:51 Urine.
2021-02-04T18:50:00 https://www.codemag.com/Article/2101071/Understanding-and-Using-Web-Workers
By Miguel Castro
Published in: CODE Magazine: 2021 - January/February
Last updated: December 28, 2020
2021-02-05T08:38:00 https://www.codeproject.com/Articles/179106/Web-Workers-in-HTML
importScripts('WebWorker_XMLHttpRequest.js');
2021-02-05T12:28:00 https://news.google.com/articles/CBMiTWh0dHBzOi8vdmlzdWFsc3R1ZGlvbWFnYXppbmUuY29tL2FydGljbGVzLzIwMjEvMDIvMDQvZGV2c2tpbGxlci0yMDIxLmFzcHg_bT0x0gEA?hl=en-US&gl=US&ceid=US%3Aen

2021-02-06T08:14:00
Daniel, I will run out of Boston Market, on Saturday.
Please get me 6 meatloaf and the side orders will be 2 sweet potatoes, 2 rice, 2 vegetables.
Thank you and God bless.
https://javascriptweekly.com/issues/250
https://javascriptweekly.com/issues/465
2021-02-08 08:20:28.970 Omo to so pe, iya ohun, o ni sinu; ohun na, o ni, sinu.
https://javascriptweekly.com/issues/370
To answer yes; you need to abandon no.
2021-02-13T11:28:00
Msg 3201, Level 16, State 1, Line 1
Cannot open backup device 'e:\SQLServerBackup\WordEngineering\WordEngineering_2021-02-13.bak'. Operating system error 3(The system cannot find the path specified.).
Msg 3013, Level 16, State 1, Line 1
BACKUP DATABASE is terminating abnormally.
What do you need out of life; that is what I have chosen for you? 
Called Eric mistakenly Eddie. Called Phoo mistakenly Pee. 
Pauline Epistles, 2 Corinthians 11:2. 1089 - 1047 = 42. 1133 - 1047 = 86. 42 / 86 = 0.48837209302325581395348837209302.
He has to be on his own. 28992 - 27932 = 1060. 29964 - 27932 = 2032. 1060 / 2032 = 0.52165354330708661417322834645669. 0.48837209302325581395348837209302 ... 0.52165354330708661417322834645669 = 0.03328145028383080021973997436367 Albertsons Lucky, Charter Square, Parking lot, North East shopping cart.
19:26 you may be +black you may be +white it does not make a +difference to me four generations of my family we have been intermarry +kevin michael wyclef
Matthew 16:21, Matthew 17:23, Matthew 20:19, Matthew 27:64, Mark 9:31, Mark 10:34, Luke 9:22, Luke 13:32, Luke 18:33, Luke 24:7, Luke 24:21, Luke 24:46, Acts 10:40, 1 Corinthians 15:4
2021-02-17T17:32:00 http://localhost/InformationInTransit/URIMaintenanceWebFOrm.aspx page 113 SequenceOrderId 53862
2021-02-17T20:56:00 https://play.google.com/store/books/details?id=SJ1eDwAAQBAJ&gl=us&hl=en-US&source=productsearch&utm_source=HA_Desktop_US&utm_medium=SEM&utm_campaign=PLA&pcampaignid=MKT-FDR-na-us-1000189-Med-pla-bk-Evergreen-Jul1520-PLA-eBooks_Computers&gclid=CjwKCAiAmrOBBhA0EiwArn3mfLr7zHQJ6lOesfiaC9wHH0O2qmUXifmh4f09MnCNPKBN3sKMRDXOURoCFr0QAvD_BwE&gclsrc=aw.ds
2021-02-18T15:13:00 Unsubscribe.
2021-02-18T14:37:00 ... 2021-02-18T15:54:00 Microsoft Hotmail.com junk mail folder 2021-02-18 08:54:03.373 This woman has messed up your day. Commentary column emptied.

:Exit
