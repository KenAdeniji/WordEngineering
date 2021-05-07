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
DBCC CHECKIDENT ('URI..UriWordEngineering', RESEED, 55007);

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
https://kenadeniji.wordpress.com/2015/12/06/2015-10-23doctoraldissertation
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
2021-02-20T06:17:00 Typographical error.
2021-02-20T16:19:00 ftp://ftp.micronet-rostov.ru/linux-support/books/programming/HTML-CSS/[Wiley.%20Wrox]%20-%20Beginning%20CSS,%203rd%20ed.%20-%20[Pouncey,%20York]/[Wiley.%20Wrox]%20-%20Beginning%20CSS,%203rd%20ed.%20-%20[Pouncey,%20York].pdf
Beginning CSS: Cascading Style Sheets for Web Design, Third EditionPublished byWiley Publishing, Inc.10475 Crosspoint BoulevardIndianapolis, IN 46256www.wiley.comCopyright © 2011 by Wiley Publishing, Inc., Indianapolis, IndianaISBN: 978-0-470-89152-0ISBN: 978-1-118-12177-1 (ebk)ISBN: 978-1-118-12176-4 (ebk)ISBN: 978-1-118-12178-8 (ebk)
2021-02-23T18:26:00	Page 89
2021-03-17T17:31:00 #RandomVariables
2021-03-22T21:40:00 URIMaintenanceWebForm.aspx WordEngineering 2018-01-07 	47606
2021-03-26T18:12:00 Database Deployment
2021-03-31T13:21:00 Scott Hanselman Spanish female code.
Leslie Ramirez Gordian
Dominican Republic
Santo Domingo
https://channel9.msdn.com/Shows/On-NET/Filling-the-content-gap-for-NET-developers
2021-04-03 to seem, as a part; I have fulfilled.
2021-04-03T09:45:00 A life, I shared; as among the rest.
2021-04-03T09:47:00 I will like; to forward My journey.
2021-04-11T14:21:00
Msg 0, Level 11, State 0, Line 0
The connection is broken and recovery is not possible.  The client driver attempted to recover the connection one or more times and all attempts failed.  Increase the value of ConnectRetryCount to increase the number of recovery attempts.

Completion time: 2021-04-11T14:20:30.6731117-07:00
2021-04-12T02:48:00 Microsoft SQL Server Management Studio Data Manipulation Language (DML) Insert statement.
2021-04-12T11:07:00 Please unsubscribe KenAdeniji@hotmail.com
2021-04-12T04:44:00 
https://www.sologig.com/sg/s/about-us

About Sologig

Sologig.com is a division of CareerBuilder - the global leader in human capital solutions - whose online career site, CareerBuilder.com, is the largest in the U.S. with 23 million unique visitors. Sologig is an employment website that connects experienced IT and engineering professionals and matches them with relevant opportunities. Users can also post resumes, sign up for automatic job alerts, and take advantage of job search management tools.
Contact Us

Thank you for your interest in contacting Sologig.com. We look forward to hearing from you.

By Phone:
1-888-688-2237
Mon - Fri: 9:00 am - 6:00 pm EST
Email Us
http://www.fuzeqna.com/careerbuilder/consumer/kbdetail_qaonly.asp?kbid=1785

email@careerbuilder.com
email@cscglobal.com

200 N. LaSalle St
Suite 1100
Chicago, IL 60601

2021-04-14T18:12:00 URI..UriWordEngineering page 52.  	52336 desc.
2021-04-14T21:26:00	http://12factor.net
2021-04-16T10:54:00 Microsoft hotmail.com Your request can't be completed right now.

2021-04-21T11:11:00 Gokul (832) 485-3649 recorded voice mail, and I called him, back.

2021-04-27T10:21:00
A recruiter called from 925-233-3127.

Please call him back.

Thanks,

Daniel
2021-05-03T12:39:03
2021-05-03T14:08:00 Whose sufficiency, is unknown? 14:08 Microsoft SQL Server Management Studio data entry error.
2021-05-03T14:22:00 google.com javascript filetype:pdf
2021-05-03T21:07:00 Senior Software Engineer (C#, 
2021-05-04T09:45:00 Second dose Alameda County Fairgrounds Drive-Through Vaccine Clinic 501 Pleasanton Avenue, Pleasanton, CA 94566 Call 925-426-7500 covax@acgov.org
From: Brian Edelman <b-edelman@psi-staffing.net>
Sent: Thursday, May 6, 2021 3:05 PM
To: kenadeniji@hotmail.com <kenadeniji@hotmail.com>
Subject: Opening
:Exit
