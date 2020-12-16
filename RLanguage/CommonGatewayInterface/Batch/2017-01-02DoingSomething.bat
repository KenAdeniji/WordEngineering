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
xcopy e:\BCP \\Harvest\e$\BCP /d /e /s /y
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
xcopy e:\WordEngineering C:\Users\KAdeniji\OneDrive\WordEngineering /d /e /s /y
GOTO Exit

:WordOfGod
xcopy e:\WordOfGod d:\WordOfGod /d /e /s /y
xcopy e:\WordOfGod f:\WordOfGod /d /e /s /y
xcopy e:\WordOfGod \\Noor\e$\WordOfGod /d /e /s /y
xcopy e:\WordOfGod C:\Users\KAdeniji\OneDrive\WordOfGod /d /e /s /y
GOTO Exit

:Backup
BACKUP DATABASE Account TO DISK = 'e:\SQLServerBackup\Account\Account_2018-04-30.bak' WITH INIT
BACKUP DATABASE ASPNetDB TO DISK = 'e:\SQLServerBackup\ASPNetDB\ASPNetDB_2017-11-03.bak' WITH INI
BACKUP DATABASE Bible TO DISK = 'e:\SQLServerBackup\Bible\Bible_2020-04-22.bak' WITH INIT
BACKUP DATABASE BibleDictionary TO DISK = 'e:\SQLServerBackup\BibleDictionary\BibleDictionary_2017-03-02T1518.bak' WITH INIT
BACKUP DATABASE CodingSample TO DISK = 'e:\SQLServerBackup\CodingSample\CodingSample_2019-06-23.bak' WITH INIT
BACKUP DATABASE ElectronicCopy TO DISK = 'e:\SQLServerBackup\ElectronicCopy\ElectronicCopy_2017-11-02T2114.bak' WITH INIT
BACKUP DATABASE HomeAbroad TO DISK = 'e:\SQLServerBackup\HomeAbroad\HomeAbroad_2018-06-25.bak' WITH INIT
BACKUP DATABASE IHaveDecidedToWorkOnAGradualImprovingSystem TO DISK = 'e:\SQLServerBackup\IHaveDecidedToWorkOnAGradualImprovingSystem\IHaveDecidedToWorkOnAGradualImprovingSystem_2019-04-12.bak' WITH INIT
BACKUP DATABASE IShallBeTheirInheritance TO DISK = 'e:\SQLServerBackup\IShallBeTheirInheritance\IShallBeTheirInheritance_2019-08-17.bak' WITH INIT
BACKUP DATABASE Nortdwind TO DISK = 'e:\SQLServerBackup\Nortdwind\Northwind_2018-01-01.bak' WITH INIT
BACKUP DATABASE RatingRank TO DISK = 'e:\SQLServerBackup\RatingRank\RatingRank_2018-01-01.bak' WITH INIT
BACKUP DATABASE SQLSharp TO DISK = 'e:\SQLServerBackup\SQLSharp\SQLSharp_2020-04-22.bak' WITH INIT
BACKUP DATABASE URI TO DISK = 'e:\SQLServerBackup\URI\URI_2019-04-12.bak' WITH INIT
BACKUP DATABASE WordEngineering TO DISK = 'e:\SQLServerBackup\WordEngineering\WordEngineering_2020-02-18.bak' WITH INIT

BACKUP DATABASE Master TO DISK = 'e:\SQLServerBackup\Master\Master_2017-01-02.bak' WITH INIT
BACKUP DATABASE Model TO DISK = 'e:\SQLServerBackup\Model\Model_2017-01-02.bak' WITH INIT
BACKUP DATABASE Msdb TO DISK = 'e:\SQLServerBackup\Msdb\Msdb_2017-01-02.bak' WITH INIT

BACKUP DATABASE AManDevelopedInAll TO DISK = 'e:\SQLServerBackup\AManDevelopedInAll\AManDevelopedInAll_2018-02-25.bak' WItd INIT

:DbccCheckIdent
DBCC CHECKIDENT ('IHaveDecidedToWorkOnAGradualImprovingSystem..Contact', RESEED, 20082);

DBCC CHECKIDENT ('URI..UriBook', RESEED, 1);
DBCC CHECKIDENT ('URI..UriChrist', RESEED, 17584);
DBCC CHECKIDENT ('URI..UriEconomy', RESEED, 2);
DBCC CHECKIDENT ('URI..URIGoogleNews', RESEED, 2413);
DBCC CHECKIDENT ('URI..UriEntertainment', RESEED, 24513);
DBCC CHECKIDENT ('URI..UriPolitics', RESEED, 35);	
DBCC CHECKIDENT ('URI..UriTechnology', RESEED, 2);
DBCC CHECKIDENT ('URI..UriWordEngineering', RESEED, 52525);

DBCC CHECKIDENT ('WordEngineering..ActToGod', RESEED, 563);
DBCC CHECKIDENT ('WordEngineering..APass', RESEED, 203);
DBCC CHECKIDENT ('WordEngineering..CaseBasedReasoning', RESEED, 15512);
DBCC CHECKIDENT ('WordEngineering..ClassAssociates', RESEED, 22952);
DBCC CHECKIDENT ('WordEngineering..Contact', RESEED, 10506);
DBCC CHECKIDENT ('WordEngineering..Telephone', RESEED, 5958);
DBCC CHECKIDENT ('WordEngineering..ContactURI', RESEED, 4267);
DBCC CHECKIDENT ('WordEngineering..Dream', RESEED, 5138);
DBCC CHECKIDENT ('WordEngineering..Event', RESEED, 1454);
DBCC CHECKIDENT ('WordEngineering..HisWord', RESEED, 133204);
DBCC CHECKIDENT ('WordEngineering..QuestionAndAnswer', RESEED, 2888);
DBCC CHECKIDENT ('WordEngineering..Remember', RESEED, 78064);
DBCC CHECKIDENT ('WordEngineering..SacredText', RESEED, 500);
DBCC CHECKIDENT ('WordEngineering..Software', RESEED, 3595);
DBCC CHECKIDENT ('WordEngineering..TerminologyOfTheDay', RESEED, 11); 
DBCC CHECKIDENT ('WordEngineering..TheComingAdventOfTime', RESEED, 1273);
DBCC CHECKIDENT ('WordEngineering..ToDo', RESEED, 1281);
DBCC CHECKIDENT ('WordEngineering..WhatAreTheStepsYouGoThroughInAJobInterview', RESEED, 2);
DBCC CHECKIDENT ('WordEngineering..WordsInTheBible', RESEED, 400);

SET IDENTITY_INSERT ClassAssociates ON
SET IDENTITY_INSERT ClassAssociates OFF

:WindowsToCentOS
pscp -pw LinuxPassword e:\SQLServerBackup\IHaveDecidedToWorkOnAGradualImprovingSystem\IHaveDecidedToWorkOnAGradualImprovingSystem_2020-02-13.bak kadeniji@10.0.4.101:/home/kadeniji/SQLServerBackup/IHaveDecidedToWorkOnAGradualImprovingSystem/IHaveDecidedToWorkOnAGradualImprovingSystem_2020-02-13.bak
pscp -pw LinuxPassword e:\SQLServerBackup\URI\URI_2020-02-17.bak kadeniji@10.0.4.101:/home/kadeniji/SQLServerBackup/URI/URI_2020-02-17.bak
pscp -pw LinuxPassword e:\SQLServerBackup\WordEngineering\WordEngineering_2020-02-18.bak kadeniji@10.0.4.101:/home/kadeniji/SQLServerBackup/WordEngineering/WordEngineering_2020-02-18.bak

:SQLScript
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
2020-04-04T16:16:00

Server Error in '/InformationInTransit' Application.
The system cannot find the file specified
Description: An unhandled exception occurred during the execution of the current web request. Please review the stack trace for more information about the error and where it originated in the code.

Exception Details: System.ComponentModel.Win32Exception: The system cannot find the file specified

Source Error:


Line 542:  )
Line 543:  {
Line 544:   GridViewContact.DataBind();
Line 545:  }//public void ButtonSubmit_Click()
Line 546:


Source File: e:\WordOfGod\ContactMaintenancePage.aspx.cs    Line: 544

Stack Trace:


[Win32Exception (0x80004005): The system cannot find the file specified]

[SqlException (0x80131904): A network-related or instance-specific error occurred while establishing a connection to SQL Server. The server was not found or was not accessible. Verify that the instance name is correct and that SQL Server is configured to allow remote connections. (provider: Named Pipes Provider, error: 40 - Could not open a connection to SQL Server)]
   System.Data.SqlClient.SqlInternalConnectionTds..ctor(DbConnectionPoolIdentity identity, SqlConnectionString connectionOptions, SqlCredential credential, Object providerInfo, String newPassword, SecureString newSecurePassword, Boolean redirectedUserInstance, SqlConnectionString userConnectionOptions, SessionData reconnectSessionData, DbConnectionPool pool, String accessToken, Boolean applyTransientFaultHandling, SqlAuthenticationProviderManager sqlAuthProviderManager) +1524
   System.Data.SqlClient.SqlConnectionFactory.CreateConnection(DbConnectionOptions options, DbConnectionPoolKey poolKey, Object poolGroupProviderInfo, DbConnectionPool pool, DbConnection owningConnection, DbConnectionOptions userOptions) +467
   System.Data.ProviderBase.DbConnectionFactory.CreatePooledConnection(DbConnectionPool pool, DbConnection owningObject, DbConnectionOptions options, DbConnectionPoolKey poolKey, DbConnectionOptions userOptions) +70
   System.Data.ProviderBase.DbConnectionPool.CreateObject(DbConnection owningObject, DbConnectionOptions userOptions, DbConnectionInternal oldConnection) +940
   System.Data.ProviderBase.DbConnectionPool.UserCreateRequest(DbConnection owningObject, DbConnectionOptions userOptions, DbConnectionInternal oldConnection) +111
   System.Data.ProviderBase.DbConnectionPool.TryGetConnection(DbConnection owningObject, UInt32 waitForMultipleObjectsTimeout, Boolean allowCreate, Boolean onlyOneCheckConnection, DbConnectionOptions userOptions, DbConnectionInternal& connection) +1567
   System.Data.ProviderBase.DbConnectionPool.TryGetConnection(DbConnection owningObject, TaskCompletionSource`1 retry, DbConnectionOptions userOptions, DbConnectionInternal& connection) +118
   System.Data.ProviderBase.DbConnectionFactory.TryGetConnection(DbConnection owningConnection, TaskCompletionSource`1 retry, DbConnectionOptions userOptions, DbConnectionInternal oldConnection, DbConnectionInternal& connection) +268
   System.Data.ProviderBase.DbConnectionInternal.TryOpenConnectionInternal(DbConnection outerConnection, DbConnectionFactory connectionFactory, TaskCompletionSource`1 retry, DbConnectionOptions userOptions) +315
   System.Data.SqlClient.SqlConnection.TryOpenInner(TaskCompletionSource`1 retry) +128
   System.Data.SqlClient.SqlConnection.TryOpen(TaskCompletionSource`1 retry) +265
   System.Data.SqlClient.SqlConnection.Open() +133
   System.Data.Common.DbDataAdapter.FillInternal(DataSet dataset, DataTable[] datatables, Int32 startRecord, Int32 maxRecords, String srcTable, IDbCommand command, CommandBehavior behavior) +182
   System.Data.Common.DbDataAdapter.Fill(DataSet dataSet, Int32 startRecord, Int32 maxRecords, String srcTable, IDbCommand command, CommandBehavior behavior) +180
   System.Data.Common.DbDataAdapter.Fill(DataSet dataSet, String srcTable) +123
   System.Web.UI.WebControls.SqlDataSourceView.ExecuteSelect(DataSourceSelectArguments arguments) +2947
   System.Web.UI.DataSourceView.Select(DataSourceSelectArguments arguments, DataSourceViewSelectCallback callback) +26
   WordEngineering.ContactMaintenancePage.ButtonSubmit_Click(Object sender, EventArgs e) in e:\WordOfGod\ContactMaintenancePage.aspx.cs:544
   System.Web.UI.WebControls.Button.OnClick(EventArgs e) +11594496
   System.Web.UI.WebControls.Button.RaisePostBackEvent(String eventArgument) +274
   System.Web.UI.Page.ProcessRequestMain(Boolean includeStagesBeforeAsyncPoint, Boolean includeStagesAfterAsyncPoint) +1964


Version Information: Microsoft .NET Framework Version:4.0.30319; ASP.NET Version:4.8.4075.0 

2020-04-04T20:00:00 
A history; as told. Can you look at use-case; and say how your life, parallel it. For example, I was deported at age twenty, the census age; and two years before 2000-01-0, I was told, I have brought something against you, but I Am with you. From: Prashant Wakade <pwakade@saiconinc.biz>
Sent: Wednesday, March 25, 2020 1:16 PM
To: kenadeniji@hotmail.com <kenadeniji@hotmail.com>
Subject: Urgent Requirement: - OSIsoft PI-System
 
Click here to unsubscribe if you no longer wish to receive our emails

Hello Ken,

 

Hope you are doing well.

 

Saicon Consultants, Inc. is a highly recognized provider of professional IT Consulting services in the US.

 

Here is our open requirement which can be filled immediately. Kindly respond to this requirement with your resume,contact and current location info to speed up the interview process.

 

Job Type: Contract

Duration: 12 Months

Location: New Orleans, LA

 

Job Requirement:

    3 yrs + experience in OSIsoft PI-System Consulting and Support
    Installation / configuration / monitoring of PI-System servers, interfaces & user tools
    PI-System tag creation / monitoring / maintenance
    Monitoring / maintenance of PI-System security & deployment of patches
    PI-System performance optimization, monitoring system health (CPU, RAM, HDspace)
    Documenting procedures and best practices
    Experience is supporting applications (Level 2, Level 3)
    Needs to coordinate with client on day to day basis and provide timely updates.
    Good Troubleshooting skills
    Co-ordination with 3rd party vendors for fixes, releases, etc.
    Good analytical and communication skills

 

Please respond at the earliest to speed up the interview process. I will contact you if I need further details.

 

Thanks and Regards,

--

Prashant Wakade - Technical Recruiter
Saicon Consultants, Inc.            
(913) 257 3377 Ext: 129 (Work)
(913) 273-0058 (Fax)

URL: www.saiconinc.com 
Email: pwakade@saiconinc.biz 

WBE/MBE

Inc. 500 Company â€“2006, 2007, 2008, 2009

Ranked #1 "Fastest-Growing Area Businesses" - Kansas City Business Journal

Ranked in Top 10of Corporate 100 - Ingram's

CMMI Level 3Assessed

This e-mail and any attachments are intended only for the individual or company to which it is addressed and may contain information which is privileged, confidential and prohibited from disclosure or unauthorized use under applicable law. If you are not the intended recipient of this e-mail, you are hereby notified that any use, dissemination, or copying of this e-mail or the information contained in this e-mail is strictly prohibited by the sender. If you have received this transmission in error, please return the material received to the sender and delete all copies from your system.

 

Please think about resource conservation before you print this message

 

Join me on LinkedIn https://www.linkedin.com/in/prashant-wakde/



This email is generated using CONREP software.
On 2020-04-04T20:00:00 as I search for HelloWorldFilm.com by Shawn Wildermuth, I found that out Microsoft SQL Server Management Studio Generate Scripts 2020-02-27UriSchemaAndData.sql does no longer contain the data, as it did, when I first created it.
en.wikipedia.org/wiki/Japan
2020-04-02T15:48:00 for_each(v, [](int x) { /* do something with the value of x */ });
2020-04-03T12:55:00 Harassment telephone call (510) 323-4115.
2020-04-04T10:39:00 Please unsubscribe KenAdeniji@hotmail.com
					I left a message on your voice mail, please remove me from your e-mail subscription list.
2020-04-04T16:53:00 ... 2020-04-04T20:00:00 Hotmail.com junk mail folder.

2020-04-14T12:58:00
Daniel,

I don't have anymore Boston Market. Thank you. 
(Be difficult).

This past Easter weekend, I told you, on several occasions, that I will run out of Boston Market, on Monday.

I also reminded you, on 2020-04-12, Saturday, when we went to:

Nation's Giant Hamburgers 
5213 Mowry Avenue
Fremont, CA 94538
(510) 797-3211

2020-04-14, Tuesday, when you went to collect my medication,
CVS, Fremont Hub; I would have hoped, that you will purchase the Boston Market.

2020-04-15T08:38:00 ... 2020-04-15T10:03:00
Microsoft Windows Explorer message, when I try to connect to Noor.
Windows Security
Enter Network Credentials
Enter your credentials to connect to Noor
Username
Password
Domain EphraimTech
Remember my credentials
The system cannot contact a domain controller to secure the authentication request. Please try again later.
OK Cancel

2020-04-15T11:29:00 ... 2020-04-15T11:42:00
Logon Message
The current time on this computer and the network are different.
For more information about Date/Time properties, see help and support.
To log on contact your system administrator.

2020-04-15T21:26:00 ... 2020-04-15T21:55:00
CVS Pharmacy. Face Masks. 4020 Fremont Hub. Fremont, California (CA) 94538. Monitor change replacement.

2020-04-15T22:06:00 ... 2020-04-15T22:22:00
Microsoft Windows Explorer message, when I try to connect to Noor.
Windows Security
Enter Network Credentials
Enter your credentials to connect to Noor
Username
Password
Domain EphraimTech
Remember my credentials
The system cannot contact a domain controller to secure the authentication request. Please try again later.
OK Cancel

2020-04-18T21:32:00 ... 2020-04-18T22:42:00 ... 2020-04-19T12:14:00
Microsoft Windows Explorer message, when I try to connect to Noor.
Windows Security
Enter Network Credentials
Enter your credentials to connect to Noor
Username
Password
Domain EphraimTech
Remember my credentials
The system cannot contact a domain controller to secure the authentication request. Please try again later.
OK Cancel

2020-04-22T06:00:00	https://stackoverflow.com/questions/14290857/sql-select-where-field-contains-words
:Exit
