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
DBCC CHECKIDENT ('URI..UriEntertainment', RESEED, 24668);
DBCC CHECKIDENT ('URI..UriPolitics', RESEED, 35);	
DBCC CHECKIDENT ('URI..UriTechnology', RESEED, 2);
DBCC CHECKIDENT ('URI..UriWordEngineering', RESEED, 57024);

DBCC CHECKIDENT ('WordEngineering..ActToGod', RESEED, 563);
DBCC CHECKIDENT ('WordEngineering..APass', RESEED, 699);
DBCC CHECKIDENT ('WordEngineering..CaseBasedReasoning', RESEED, 15512);
DBCC CHECKIDENT ('WordEngineering..ClassAssociates', RESEED, 22952);
DBCC CHECKIDENT ('WordEngineering..Contact', RESEED, 11009);
DBCC CHECKIDENT ('WordEngineering..Telephone', RESEED, 5958);
DBCC CHECKIDENT ('WordEngineering..ContactURI', RESEED, 4267);
DBCC CHECKIDENT ('WordEngineering..Dream', RESEED, 5138);
DBCC CHECKIDENT ('WordEngineering..Event', RESEED, 1454);
DBCC CHECKIDENT ('WordEngineering..HisWord', RESEED, 140476);
DBCC CHECKIDENT ('WordEngineering..QuestionAndAnswer', RESEED, 2963);
DBCC CHECKIDENT ('WordEngineering..Remember', RESEED, 89557);
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
E:\WordEngineering\IIS\WordEngineering\WordUnion\2015-10-23DoctoralDissertation.pdf
KenAdeniji@hotmail.com
2020-12-02T11:02:00 ... 2020-12-02T11:48:00 Microsoft SQL Server data files archive; network error.
12:26 Microsoft SQL Server Management Studio user interface (UI) grid error.
2020-12-04T18:03:00
I am available at 10AM, Pacific Standard Time, every day of the week.

Share your contact information, such as telephone number, email and web address?

Thank you and God blesses,

KenAdeniji@hotmail.com
http://KenAdeniji.WordPress.com
http://kenadeniji.wordpress.com/2015/11/20/ken-adenijis-resume
http://kenadeniji.wordpress.com/2015/12/06/2015-10-23doctoraldissertation
(510) 796-8121
2021-01-03T15:20:00
2021-05-17T05:12:00 415-250-5365
2021-03-17T21:01:00
Bobbi Heath
Company	Streambase Systems, Inc.
Work e-mail	bobbi.heath@streambase.com
Work phone	(781) 761-0808
Notes	2007-06-25 Hello Ken, Thank you for submitting your resume to Streambase. Would you be available for a phone screen sometime this week? I can be flexible during the day, and in the evening here on the east coast, until about 7PM your time. Regards, Bobbi Heath Bobbi Heath, Ph.D. VP of Professional Services StreamBase Systems, Inc. www.streambase.com 781-761-0808 Bobbi Heath, My present work commitment will not offer me the opportunity to pursue a relationship with StreamBase. I thank you for the opportunity, and I wish StreamBase much success. Database.
2021-05-19T11:47:00 Please send resumes to Jaime.Belton@rht.com or give me a call at 415-434-4940 ext. 29667 Robert Half Technology is looking for an experienced .NET Developer for a contract opportunity in the Burlingame area. (No third party agency inquiries) Job Requirements ? 5+ years of experience building web based applications using C#, ASP.Net Broad experience with the .NET Framework Strong Sql Server knowledge (ability to develop Database from SCRATCH, queries, Stored Procedures, etc?). Deep knowledge in OOP and N-Tier architecture. Multithreaded Application Programming. WCF Services and WEB.API Experience with transitioning from older .Net Framework (VB.NET) to newer .Net Framework (C#) Hands-on experience of HTML5, JavaScript, JQuery. (nice to have)
2021-05-25T11:21:00
Kindly mail me resumes in word format at  heline@tekrek.com & Phone: 925-326-1320

 

 

To unsubscribe from future emails or to update your email preferencesclick here .
2021-05-26T14:08:00


From: craigslist 7327075979 <5aee4192f48130aa82f17f47fcc37c0e@job.craigslist.org>Sent: Wednesday, May 26, 2021 9:01 PMTo: 5aee4192f48130aa82f17f47fcc37c0e@reply.craigslist.org <5aee4192f48130aa82f17f47fcc37c0e@reply.craigslist.org>Subject: Re: Angel Funded Startup Seeking Cofounding CTO in NFT Space (Sacramento)
 
Excellent, Ken, this is a very strong résumé and we appreciate your interest.

I have Timothy, a manager, reviewing it now. We will be back to you within a day or two.

Alex
916-530-6977

2021-05-26T16:37:00
Great! Thank you, Ken, I’ve forwarded to Timothy.

916-530-6977
:Exit
